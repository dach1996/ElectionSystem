using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventDeleteHandler : IRequestHandler<EventDeleteRequest, EventDeleteResponse>
    {
        #region Constructor
        private readonly ILogger<EventDeleteHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        public EventDeleteHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            IElectionUnitOfWork electionUnitOfWork,
            ILogger<EventDeleteHandler> logger)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _electionUnitOfWork = electionUnitOfWork;
            _logger = logger;
        }
        #endregion
        #region Handler
        public async Task<EventDeleteResponse> Handle(EventDeleteRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    //Obtiene evento por ID y verifica si está borrado el evento
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent,false);
                    //Valida que el usuario sea el creador del evento
                    var isUserCurrentCreatorEvent = eventCurrent.IdUser == request.UserContext.Id;
                    if (!isUserCurrentCreatorEvent)
                        throw new CustomException(Models.Enums.MessageCodesApi.EventCreator, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                        $"El usuario con ID: {request.UserContext.Id} no es creador del evento con ID: {request.IdEvent}");
                    //Valida que el e venton no haya sido borrado
                    if (!eventCurrent.IsActive)
                        throw new CustomException(Models.Enums.MessageCodesApi.EventIsInactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(eventCurrent.Id).ConfigureAwait(false);
                    eventCurrent.IsDelete = true;
                    eventCurrent.Name = $"{eventCurrent.Name}_{DateTime.Now}_Delete";
                    eventCurrent.IsActive = false;
                    var responseDelete = await _electionUnitOfWork.GetEventRepository().Update(eventCurrent);
                    //Valida que el evento se haya desactivado
                    if (!responseDelete)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotDeleteRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<EventDeleteResponse>(eventCurrent);
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
