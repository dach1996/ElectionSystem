using System;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorUpdateHandler : IRequestHandler<EventAdministratorUpdateRequest, EventAdministratorUpdateResponse>
    {
        #region Constructor
        private readonly IEventAdministratorRepository _eventAdministratorRepository;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity validateIntegrity;

        public EventAdministratorUpdateHandler(
            IEventAdministratorRepository EventAdministratorRepository,
            IMapper mapper,
            ValidateIntegrity validateIntegrity)
        {
            this._eventAdministratorRepository = EventAdministratorRepository;
            this._mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler

        public async Task<EventAdministratorUpdateResponse> Handle(EventAdministratorUpdateRequest request, CancellationToken cancellationToken)
        {
            //Valida que exista el evento
            var events = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Valida que el usuario de contexto sea administrador en este e vento
            var isUserCurrentCreatorEvent = events.IdUser == request.UserContext.Id;
            if (!isUserCurrentCreatorEvent)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                "Para Eliminar administradores debe ser el creador del evento");
            //Valida que exista el usuario  administrador
            var isUserAdministrator = events.ListEventAdministrator.ToList().Exists(e => e.IdUser == request.IdUser);
            if (!isUserAdministrator)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                $"No existe registrado el administrador con Id: {request.IdUser} en el evento");
            //Valida que el administrador se encuentre desactivado
            var isUserAdministratorActive = events.ListEventAdministrator.FirstOrDefault(e => e.IdUser == request.IdUser).IsActive;
            if (!isUserAdministratorActive)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                $"El usuario administrador se encuentra Acticado");
            //Creamos el nuevo administrador
            var updateEventAdministrator = events.ListEventAdministrator.FirstOrDefault(e => e.IdUser == request.IdUser);
            updateEventAdministrator.IsActive = true;
            updateEventAdministrator.Date = DateTime.Now;
            var isUpdate = await _eventAdministratorRepository.Update(updateEventAdministrator);
            if (!isUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<EventAdministratorUpdateResponse>(updateEventAdministrator);
        }
        #endregion


    }
}