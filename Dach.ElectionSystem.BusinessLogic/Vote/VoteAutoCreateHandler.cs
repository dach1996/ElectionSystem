using System;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dach.ElectionSystem.Services.Data;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteAutoCreateHandler : IRequestHandler<VoteAutoCreateRequest, VoteAutoCreateResponse>
    {
        #region Constructor 
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly ILogger<VoteAutoCreateHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;

        public VoteAutoCreateHandler(
         ValidateIntegrity validateIntegrity,
         ILogger<VoteAutoCreateHandler> logger,
         IElectionUnitOfWork electionUnitOfWork)
        {
            _validateIntegrity = validateIntegrity;
            _logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler
        public async Task<VoteAutoCreateResponse> Handle(VoteAutoCreateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    // Valida existencia del evento
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Validar la fecha máxima para registrar participantes
                    var isDateValid = eventCurrent.DateMaxRegisterParticipants >= DateTime.Now;
                    if (!isDateValid)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectDates, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadGateway,
                                                    $"La fecha máxima para poder registrar participantes ha terminado.");
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(eventCurrent.Id).ConfigureAwait(false);
                    if (eventCurrent.DateMaxRegisterParticipants < DateTime.Now)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectDates, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest, $"La fecha máxima para registrad candidatos ha pasado: {eventCurrent.DateMaxRegisterParticipants}");
                    // encuentra los participantes del evento
                    var participantsEvent = await _electionUnitOfWork.GetVoteRepository().GetAsync(v => v.IdEvent == request.IdEvent && v.IdUser == request.UserContext.Id);
                    // Valida si el usuario no se encuentra registrado previamente
                    var hasRegister = participantsEvent.Any();
                    if (hasRegister)
                        throw new CustomException(Models.Enums.MessageCodesApi.UserRegisterEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    //Valida que no se supere el número máximo de participantes en caso de existir
                    if (eventCurrent.MaxPeople && participantsEvent.Count(p=>p.IsActive) >= eventCurrent.NumberMaxPeople)
                        throw new CustomException(Models.Enums.MessageCodesApi.LimitMaxParticipants, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                    // Validamos que el código enviado sea correcto
                    var isCodeCorrect = eventCurrent.CodeEvent == request.CodeEvent;
                    if (!isCodeCorrect)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectCodeEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    // Validamos si el evento permite registrace libremente
                    var allowRegisterWithOutCode = eventCurrent.AllowFreeAccess;
                    if (!allowRegisterWithOutCode)
                    {
                        var allowRegister = (await _electionUnitOfWork.GetVoteRegisterEmailRepository().GetAsync(vre => vre.IdEvent == request.IdEvent && vre.UserEmail == request.UserContext.Email)).Any();
                        if (!allowRegister)
                            throw new CustomException(Models.Enums.MessageCodesApi.EventNotAllowFreeRegister, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    }
                    //Creamos el registro
                    var newVote = new Models.Persitence.Vote()
                    {
                        IdEvent = request.IdEvent,
                        IdUser = request.UserContext.Id,
                        IsActive = true,
                        DateInscription = DateTime.Now
                    };
                    var isCreate = await _electionUnitOfWork.GetVoteRepository().CreateAsync(newVote);
                    if (!isCreate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return new VoteAutoCreateResponse();
                }
                catch (Exception)
                {
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }
        #endregion
    }
}
