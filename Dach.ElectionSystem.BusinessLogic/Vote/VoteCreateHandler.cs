using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Models.Mail;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteCreateHandler : IRequestHandler<VoteCreateRequest, VoteCreateResponse>
    {
        #region Constructor 
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly ILogger<VoteCreateHandler> _logger;
        private readonly Services.Notification.INotification _notification;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IConfiguration _configuration;

        public VoteCreateHandler(
        IMapper mapper,
        ValidateIntegrity validateIntegrity,
        IElectionUnitOfWork electionUnitOfWork,
        ILogger<VoteCreateHandler> logger,
        Services.Notification.INotification notification,
        IConfiguration configuration)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _electionUnitOfWork = electionUnitOfWork;
            _logger = logger;
            _notification = notification;
            _configuration = configuration;
        }
        #endregion
        #region Handler
        public async Task<VoteCreateResponse> Handle(VoteCreateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    //Iniciamos transacción
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Validamos que exista el usuario a registrar
                    var userCurrent = await _validateIntegrity.ValidateUser(request.IdUser);
                    //Validamos que exista el Evento
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Validar la fecha máxima para registrar participantes
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(eventCurrent.Id).ConfigureAwait(false);
                    if (eventCurrent.DateMaxRegisterParticipants < DateTime.Now)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectDates, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest, $"La fecha máxima para registrad candidatos ha pasado: {eventCurrent.DateMaxRegisterParticipants}");
                    // encuentra los participantes del evento
                    var participants = await _electionUnitOfWork.GetVoteRepository().GetAsync(v => v.IdEvent == request.IdEvent);
                    //Valida que l usuario no esté registrado ya como votante en el evento
                    var hasRegister = participants.Any(u => u.IdUser == request.IdUser);
                    if (hasRegister)
                        throw new CustomException(Models.Enums.MessageCodesApi.UserRegisterEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    //Valida que no se supere el número máximo de participantes en caso de existir
                    if (eventCurrent.MaxPeople && participants.Count() > eventCurrent.NumberMaxPeople)
                        throw new CustomException(Models.Enums.MessageCodesApi.LimitMaxParticipants, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                    //Valida que el usuario que envía el request sea la administrador del evento
                    if (!eventCurrent.ListEventAdministrator.Any(e => e.IdUser == request.UserContext.Id))
                        throw new CustomException(Models.Enums.MessageCodesApi.UserIsnotAdministratorEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);

                    //Validamos que exista el Candidato
                    var newVote = new Models.Persitence.Vote()
                    {
                        IdEvent = request.IdEvent,
                        IdUser = request.IdUser,
                        IsActive = true,
                        DateInscription = DateTime.Now
                    };
                    var isCreate = await _electionUnitOfWork.GetVoteRepository().CreateAsync(newVote);
                    if (!isCreate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    //Enviamos correos
                    var templates = _configuration.GetSection("SendgridConfiguration:Templates").Get<Template[]>();
                    var templateSendEvent = templates.FirstOrDefault(t => t.TemplateName == Models.Static.Template.NewParticipant);
                    var isSend = _notification.SendMail(
                        new MailModel()
                        {
                            Subject = templateSendEvent.TemplateName,
                            To = new List<string>() { userCurrent.Email },
                            Template = templateSendEvent.TemplateKey,
                            Params = new
                            {
                                EventName = eventCurrent.Name,
                                LinkRegister = _configuration.GetSection("LinkToRegister").Value,
                                CodeRegister = eventCurrent.CodeEvent,
                                DateStartVote = eventCurrent.DateMaxRegisterParticipants.ToString("dd/MM/yyyy")
                            }
                        }
                    );
                    if (!isSend)
                        _logger.LogWarning($"No se pudo Envíar correo: {userCurrent.Email}");
                    //Guardamos los cambios
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<VoteCreateResponse>(newVote);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(VoteCreateHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }

            }

        }
        #endregion
    }
}
