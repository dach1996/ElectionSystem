using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dach.ElectionSystem.Models.Mail;
using System.Collections.Generic;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateCreateHandler : IRequestHandler<CandidateCreateRequest, CandidateCreateResponse>
    {
        #region Constructor
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;
        private readonly ValidateIntegrity validateIntegrity;
        private readonly IConfiguration configuration;
        private readonly Services.Notification.INotification notification;
        private readonly ILogger<CandidateCreateHandler> logger;

        public CandidateCreateHandler(
            ICandidateRepository candidateRepository,
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            IConfiguration configuration,
            Services.Notification.INotification notification,
            ILogger<CandidateCreateHandler> logger
            )
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
            this.validateIntegrity = validateIntegrity;
            this.configuration = configuration;
            this.notification = notification;
            this.logger = logger;
        }
        #endregion

        #region Handler
        public async Task<CandidateCreateResponse> Handle(CandidateCreateRequest request, CancellationToken cancellationToken)
        {

            //Valida que el evento exista
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Valida que el usuario exista
            var userCurrent = await validateIntegrity.ValidateUser(request.IdUser);
            var isUserCurrentAdministrator = request.UserContext.ListEventAdministrator.Any(e => e.IdEvent == eventCurrent.Id);
            if (!isUserCurrentAdministrator)
                throw new CustomException(Models.Enums.MessageCodesApi.UserIsnotAdministratorEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            //Valida que el usuario no esté registrado ya como candidato del evento
            var hasRegisterCandidate = eventCurrent.ListCandidate.Any(c => c.IdUser == userCurrent.Id);
            if (hasRegisterCandidate)
                throw new CustomException(Models.Enums.MessageCodesApi.IsCandidateInEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            //Validar la fecha máxima para crear candidatos
            var isDateValid = eventCurrent.DateMaxRegisterCandidate >= DateTime.Now;
            if (!isDateValid)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectDates, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadGateway,
                                            $"La fecha máxima para poder registrar candidatos ha terminado.");
            //Creamos el nuevo Candidato
            var newCandidate = mapper.Map<Models.Persitence.Candidate>(request);
            var isCreate = await candidateRepository.CreateAsync(newCandidate);
            if (!isCreate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            //Preparamos para envíar correo
            var templates = configuration.GetSection("SendgridConfiguration:Templates").Get<Template[]>();
            var templateForggotenPassword = templates.FirstOrDefault(t => t.TemplateName == Models.Static.Template.NewCandidate);
            var isSend = notification.SendMail(
                new MailModel()
                {
                    Subject = templateForggotenPassword.TemplateName,
                    To =  new List<string>(){userCurrent.Email},
                    Template = templateForggotenPassword.TemplateKey,
                    Params = new
                    {
                        EventName = eventCurrent.Name,
                        Fullname = $"{userCurrent.FirstName} {userCurrent.FirstLastName}",
                        DateMaxRegisterCandidate = eventCurrent.DateMaxRegisterCandidate.ToString("dd/MM/yyyy"),
                        DateMinVote = eventCurrent.DateMinVote.ToString("dd/MM/yyyy")
                    }
                }
            );
            if (!isSend)
                logger.LogWarning("No se pudo Envíar correo");
            var response = mapper.Map<CandidateCreateResponse>(newCandidate);
            return response;
        }
        #endregion

    }
}
