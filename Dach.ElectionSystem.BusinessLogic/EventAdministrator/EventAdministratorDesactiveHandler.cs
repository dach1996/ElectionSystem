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
using Dach.ElectionSystem.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorDesactiveHandler : IRequestHandler<EventAdministratorDesactiveRequest, EventAdministratorDesactiveResponse>
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly ILogger<EventAdministratorDesactiveHandler> _logger;
        public EventAdministratorDesactiveHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            ILogger<EventAdministratorDesactiveHandler> logger,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler
        public async Task<EventAdministratorDesactiveResponse> Handle(EventAdministratorDesactiveRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que exista el evento
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Valida que el usuario de contexto sea administrador en este e vento
                    var isUserCurrentCreatorEvent = eventCurrent.IdUser == request.UserContext.Id;
                    if (!isUserCurrentCreatorEvent)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                        "Para Eliminar administradores debe ser el creador del evento");
                    //Valida que exista el usuario sea administrador
                    var isUserAdministrator = eventCurrent.ListEventAdministrator.Any(e => e.IdUser == request.IdUser);
                    if (!isUserAdministrator)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                        $"No existe registrado el administrador con Id: {request.IdUser} en el evento");
                    //Seleccionamos el administrador y  cambia de estado
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(eventCurrent.Id).ConfigureAwait(false);
                    var updateEventAdministrator = eventCurrent.ListEventAdministrator.FirstOrDefault(e => e.IdUser == request.IdUser);
                    updateEventAdministrator.IsActive = !updateEventAdministrator.IsActive;
                    updateEventAdministrator.Date = DateTime.Now;
                    var isUpdate = await _electionUnitOfWork.GetEventAdministratorRepository().Update(updateEventAdministrator);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<EventAdministratorDesactiveResponse>(updateEventAdministrator);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(EventAdministratorDesactiveHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }

        }
        #endregion

    }
}
