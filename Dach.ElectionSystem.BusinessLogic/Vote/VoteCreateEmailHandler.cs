using System;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dach.ElectionSystem.Services.Data;
using Dach.ElectionSystem.Models.Mail;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteCreateEmailHandler : IRequestHandler<VoteCreateEmailRequest, VoteCreateEmailResponse>
    {
        #region Constructor 
        private readonly IVoteRepository _voteRepository;
        private readonly IUserRepository userRepository;
        private readonly IVoteRegisterEmailRepository voteRegisterEmailRepository;
        private readonly ValidateIntegrity validateIntegrity;
        private readonly Services.Notification.INotification notification;
        private readonly IConfiguration _configuration;
        private readonly ILogger<VoteCreateEmailHandler> logger;


        public VoteCreateEmailHandler(
        IVoteRepository voteRepository,
        IUserRepository userRepository,
        IVoteRegisterEmailRepository voteRegisterEmailRepository,
        ValidateIntegrity validateIntegrity,
        Services.Notification.INotification notification,
        IConfiguration configuration,
        ILogger<VoteCreateEmailHandler> logger)
        {
            this._voteRepository = voteRepository;
            this.userRepository = userRepository;
            this.voteRegisterEmailRepository = voteRegisterEmailRepository;
            this.validateIntegrity = validateIntegrity;
            this.notification = notification;
            _configuration = configuration;
            this.logger = logger;
        }
        #endregion
        #region Handler
        public async Task<VoteCreateEmailResponse> Handle(VoteCreateEmailRequest request, CancellationToken cancellationToken)
        {
            //Valida que por lo menos se envíe un correo
            var hasEmail = request.EmailUser.Any();
            if (!hasEmail)
                throw new CustomException(Models.Enums.MessageCodesApi.InvalidEmail, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            //Valida si el usuario es administrador del evento
            var isAdministrator = request.UserContext.ListEventAdministrator.Any(e => e.IdEvent == request.IdEvent);
            if (!isAdministrator)
                throw new CustomException(Models.Enums.MessageCodesApi.UserIsnotAdministratorEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            //Validar la fecha máxima para registrar participantes
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            var isDateValid = eventCurrent.DateMaxRegisterParticipants >= DateTime.Now;
            if (!isDateValid)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectDates, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadGateway,
                                            $"La fecha máxima para poder registrar participantes ha terminado.");
            // encuentra los participantes del evento
            var participants = await _voteRepository.GetAsync(v => v.IdEvent == request.IdEvent);
            // Consulta la lista de usuarios que existen registrados con el mail
            var usersExist = await userRepository.GetAsync(u => request.EmailUser.Any(um => um == u.Email));
            // Consulta la lista de correos de  usuario que no existán registrados
            var emailUserNotExist = request.EmailUser.Where(m => !usersExist.Any(ue => ue.Email == m)).ToList();
            // Obtiene la lista de usuario que no están registrados en el event
            var userToRegister = usersExist.Where(p => !participants.Any(ue => ue.IdUser == p.Id)).ToList();
            //Registramos las usuarios para ser participantes
            var listParticipantesToRegister = userToRegister.Select(utr => new Models.Persitence.Vote()
            {
                IdEvent = request.IdEvent,
                DateInscription = DateTime.Now,
                IsActive = true,
                IdUser = utr.Id
            }
            );
            var isRegisterVote = await _voteRepository.CreateManyAsync(listParticipantesToRegister);
            if (!isRegisterVote)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            //Registramos los usuarios que no están registrados en la tabla de votos_email

            var listParticipantesRegisterVoteEmail = await voteRegisterEmailRepository.GetAsync(v => emailUserNotExist.Any(ur => ur == v.UserEmail));
            var listParticipantesWithOutRegister = emailUserNotExist.Where(eune => !listParticipantesRegisterVoteEmail.Any(prvm => prvm.UserEmail == eune)).ToList();
            var listParticipantesWithOutRegisterToRegister = listParticipantesWithOutRegister.Select(mailParticipant => new Models.Persitence.VoteRegisterEmail()
            {
                IdEvent = request.IdEvent,
                IdUserAdministrator = request.UserContext.Id,
                UserEmail = mailParticipant
            }
            );
            var isRegisterVoteMail = await voteRegisterEmailRepository.CreateManyAsync(listParticipantesWithOutRegisterToRegister);
            if (!isRegisterVoteMail)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            //Enviar Correo a usuario que registrados en tabla de Mail
            var templates = _configuration.GetSection("SendgridConfiguration:Templates").Get<Template[]>();
            var templateSendEvent = templates.FirstOrDefault(t => t.TemplateName == Models.Static.Template.NewParticipant);
            var isSend = notification.SendMail(
                new MailModel()
                {
                    Subject = templateSendEvent.TemplateName,
                    To = new List<string>(emailUserNotExist),
                    Template = templateSendEvent.TemplateKey,
                    Params = new
                    {
                        EventName = eventCurrent.Name,
                        LinkRegister = _configuration.GetSection("LinkToRegister").Value,
                        CodeRegister = eventCurrent.CodeEvent,
                        DateStartVote = eventCurrent.DateMinVote.ToString("dd/MM/yyyy")
                    }
                }
            );
            if (!isSend)
                logger.LogWarning("No se pudo Envíar correo");

            //Devolver Respuesta
            return new VoteCreateEmailResponse()
            {
                EmailUserRegister = usersExist.Select(ue => ue.Email).ToList(),
                NumberRegister = usersExist.Count(),
                EmailUserWithOutRegister = emailUserNotExist.ToList(),
                NumberSendEmail = listParticipantesRegisterVoteEmail.Count()
            };

        }
        #endregion
    }
}
