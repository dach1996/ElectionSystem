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
using Microsoft.Extensions.Configuration;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventStartStopHandler : IRequestHandler<EventStartStopRequest, EventStartStopResponse>
    {
        #region Constructor 
        private readonly ILogger<EventStartStopHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly IConfiguration _configuration;

        public EventStartStopHandler(
        IMapper mapper,
        IElectionUnitOfWork electionUnitOfWork,
        ILogger<EventStartStopHandler> logger,
        ValidateIntegrity validateIntegrity,
        IConfiguration configuration
        )
        {
            _mapper = mapper;
            _electionUnitOfWork = electionUnitOfWork;
            _logger = logger;
            _validateIntegrity = validateIntegrity;
            _configuration = configuration;
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
                    await _validateIntegrity.IsCreatorEvent(request.UserContext.Id, eventCurrent.Id).ConfigureAwait(false);
                    //Valida que el evento se encuentre activado
                    if (!eventCurrent.IsActive)
                        throw new CustomException(Models.Enums.MessageCodesApi.EventIsInactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound,
                                                       $"El evento con id: {eventCurrent.Id} está desactivado");
                    //Valida que el evento no haya finalizado
                    if (eventCurrent.IsFinished)
                        throw new CustomException(Models.Enums.MessageCodesApi.EventIsFinished, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    // TODO: Correo informando los resultados
                    //Valida que el evento no haya empezado
                    if (!eventCurrent.IsStarted)
                    {
                        eventCurrent.IsStarted = true;
                        eventCurrent.DateMinVote = DateTime.Now;
                        eventCurrent.DateMaxVote = DateTime.Now.AddDays(request.DaysAllow);
                        //Valida cantidad mínima de candidatos para comenzar el evento
                        _ = int.TryParse(_configuration.GetSection("MinCandidateToEvent").Value, out var numberMinCandidate);
                        if (eventCurrent.NumberMaxCandidate < numberMinCandidate)
                            throw new CustomException(Models.Enums.MessageCodesApi.MinCandidateRequired, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest, $"El número mínimo de candidatos debe ser: {numberMinCandidate} para comenzar el evento");
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
