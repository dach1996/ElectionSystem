using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorUpdateHandler : IRequestHandler<EventAdministratorUpdateRequest, EventAdministratorUpdateResponse>
    {
        #region Constructor
        private readonly ILogger<EventAdministratorUpdateHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        public EventAdministratorUpdateHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            ILogger<EventAdministratorUpdateHandler> logger,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler

        public async Task<EventAdministratorUpdateResponse> Handle(EventAdministratorUpdateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que exista el evento
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Valida que el usuario de contexto sea creador del evento
                    await _validateIntegrity.IsCreatorEvent(request.UserContext.Id, eventCurrent.Id).ConfigureAwait(false);
                    //Valida que exista el usuario  administrador
                    await _validateIntegrity.IsAdministratorEvent(request.IdUser, eventCurrent.Id);
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(eventCurrent.Id).ConfigureAwait(false);
                    //Valida que el administrador se encuentre desactivado
                    var isUserAdministratorActive = eventCurrent.ListEventAdministrator.FirstOrDefault(e => e.IdUser == request.IdUser).IsActive;
                    if (!isUserAdministratorActive)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                        $"El usuario administrador se encuentra Acticado");
                    //Creamos el nuevo administrador
                    var updateEventAdministrator = eventCurrent.ListEventAdministrator.FirstOrDefault(e => e.IdUser == request.IdUser);
                    updateEventAdministrator.IsActive = true;
                    updateEventAdministrator.Date = DateTime.Now;
                    var isUpdate = await _electionUnitOfWork.GetEventAdministratorRepository().Update(updateEventAdministrator);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<EventAdministratorUpdateResponse>(updateEventAdministrator);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(EventAdministratorUpdateHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }
        #endregion
    }
}