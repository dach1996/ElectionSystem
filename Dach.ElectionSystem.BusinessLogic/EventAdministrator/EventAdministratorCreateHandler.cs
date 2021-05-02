using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorCreateHandler : IRequestHandler<EventAdministratorCreateRequest, EventAdministratorCreateResponse>
    {
        #region Constructor 
        private readonly IEventAdministratorRepository _eventAdministratorRepository;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity validateIntegrity;

        public EventAdministratorCreateHandler(
        IEventAdministratorRepository EventAdministratorRepository,
        IMapper mapper,
        ValidateIntegrity validateIntegrity
        )
        {
            this._eventAdministratorRepository = EventAdministratorRepository;
            this._mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<EventAdministratorCreateResponse> Handle(EventAdministratorCreateRequest request, CancellationToken cancellationToken)
        {
            //Valida que exista el evento
            var events = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Valida que exista el usuario
            var user = await validateIntegrity.ValidateUser(request.IdUser);
            //Valida que el usuario de contexto sea administrador en este e vento
            var isUserCurrentAdministrator = request.UserContext.ListEventAdministrator.Exists(e => e.Id == events.Id);
             if (!isUserCurrentAdministrator)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                "El no tiene permisos para registrar administradores a este evento");
            //Valida que el usuario a ingresar no sea administrador en este momento
            var isUserAdministrator = user.ListEventAdministrator.Exists(e => e.Id == events.Id);
            if (isUserAdministrator)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                "El usuario ya se encuentra registrado como administrador en este Evento");
            //Creamos el nuevo administrador
            var eventAdministrator = new Models.Persitence.EventAdministrator()
            {
                IdUser = user.Id,
                IdEvent = events.Id,
                Privileges = "All",
                Date = DateTime.Now
            };
            var isCreate = await _eventAdministratorRepository.CreateAsync(eventAdministrator);
            if (!isCreate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<EventAdministratorCreateResponse>(eventAdministrator);
        }
        #endregion
    }
}
