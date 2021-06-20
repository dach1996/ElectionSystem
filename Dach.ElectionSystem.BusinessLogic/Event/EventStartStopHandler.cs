using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventStartStopHandler : IRequestHandler<EventStartStopRequest, EventStartStopResponse>
    {
        #region Constructor 
        private readonly ILogger<EventStartStopHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        public EventStartStopHandler(
        IMapper mapper,
        IElectionUnitOfWork electionUnitOfWork,
        ILogger<EventStartStopHandler> logger,
        ValidateIntegrity validateIntegrity)
        {
            _mapper = mapper;
            _electionUnitOfWork = electionUnitOfWork;
            _logger = logger;
            _validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<EventStartStopResponse> Handle(EventStartStopRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que el evento exista
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent).ConfigureAwait(false);
                    //Valida que el Usuario que envía el request, sea administrtador del evento
                    var isUserAdministrator = eventCurrent.ListEventAdministrator.Count(e => e.IdUser == request.UserContext.Id);
                    if (isUserAdministrator == 0)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound,
                                                    $"El usuario con Id: {request.UserContext.Id} no es administrador en el evento: {eventCurrent.Name}");
                    //Valida que el evento no haya finalizado
                    if (eventCurrent.IsFinished)
                        throw new CustomException(Models.Enums.MessageCodesApi.EventIsFinished, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    //Valida que el evento no haya empezado
                    if (!eventCurrent.IsStarted)
                    {
                        eventCurrent.IsStarted = true;
                        eventCurrent.DateMinVote = DateTime.Now;
                        eventCurrent.DateMaxVote = DateTime.Now.AddDays(request.DaysAllow);
                    }
                    else
                    {
                        eventCurrent.IsFinished = true;
                        eventCurrent.DateMaxVote = DateTime.Now;
                    }
                    var isUpdate = await _electionUnitOfWork.GetEventRepository().Update(eventCurrent);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<EventStartStopResponse>(eventCurrent);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(EventStartStopHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }

        }
        #endregion
    }
}
