using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorDeleteHandler : IRequestHandler<EventAdministratorDeleteRequest, EventAdministratorDeleteResponse>
    {
        #region Constructor
        private readonly IEventAdministratorRepository _EventAdministratorRepository;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity validateIntegrity;
        public EventAdministratorDeleteHandler(
            IEventAdministratorRepository EventAdministratorRepository,
            IMapper mapper,
             ValidateIntegrity validateIntegrity)
        {
            this._EventAdministratorRepository = EventAdministratorRepository;
            this._mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<EventAdministratorDeleteResponse> Handle(EventAdministratorDeleteRequest request, CancellationToken cancellationToken)
        {
            //Valida que exista el evento
            var events = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Valida que el usuario de contexto sea administrador en este e vento
            var isUserCurrentCreatorEvent = events.IdUser == request.UserContext.Id;
            if (!isUserCurrentCreatorEvent)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                "Para Eliminar administradores debe ser el creador del evento");
            //Valida que exista el usuario sea administrador
            var isUserAdministrator = events.ListEventAdministrator.ToList().Exists(e => e.IdUser == request.IdUser);
            if (!isUserAdministrator)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                $"No existe registrado el administrador con Id: {request.IdUser} en el evento");
            //Valida que el administrador no se encuentre activado
            var isUserAdministratorActive = events.ListEventAdministrator.FirstOrDefault(e => e.IdUser == request.IdUser).State;
            if (!isUserAdministratorActive)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                $"El administrador a se encuentra desactivado");
            //Seleccionamos el administrador a desactivar
            var updateEventAdministrator = events.ListEventAdministrator.FirstOrDefault(e => e.IdUser == request.IdUser);
            updateEventAdministrator.State = false;
            updateEventAdministrator.Date = DateTime.Now;
            var isUpdate = await _EventAdministratorRepository.Update(updateEventAdministrator);
            if (!isUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<EventAdministratorDeleteResponse>(updateEventAdministrator);
        }
        #endregion

    }
}
