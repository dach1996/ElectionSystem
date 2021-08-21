using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorCreateHandler : IRequestHandler<EventAdministratorCreateRequest, EventAdministratorCreateResponse>
    {
        #region Constructor 
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly ILogger<EventAdministratorCreateHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;

        public EventAdministratorCreateHandler(
        IMapper mapper,
        ValidateIntegrity validateIntegrity,
        ILogger<EventAdministratorCreateHandler> logger,
        IElectionUnitOfWork electionUnitOfWork)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler
        public async Task<EventAdministratorCreateResponse> Handle(EventAdministratorCreateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que exista el evento
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Valida que exista el usuario
                    var userToAdmin = await _validateIntegrity.ValidateUser(request.IdUser);
                    //Valida que el usuario de contexto sea administrador en este e vento
                    var isUserCurrentAdministrator = request.UserContext.ListEventAdministrator.Exists(e => e.IdEvent == eventCurrent.Id);
                    if (!isUserCurrentAdministrator)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                        "El no tiene permisos para registrar administradores a este evento");
                    //Valida que el usuario a ingresar no sea administrador en este momento
                    var isUserAdministrator = userToAdmin.ListEventAdministrator.Exists(e => e.IdEvent == eventCurrent.Id);
                    if (isUserAdministrator)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                        "El usuario ya se encuentra registrado como administrador en este Evento");
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(eventCurrent.Id).ConfigureAwait(false);
                    //Creamos el nuevo administrador
                    var eventAdministrator = new Models.Persitence.EventAdministrator()
                    {
                        IdUser = userToAdmin.Id,
                        IdEvent = eventCurrent.Id,
                        Privileges = "All",
                        Date = DateTime.Now
                    };
                    var isCreate = await _electionUnitOfWork.GetEventAdministratorRepository().CreateAsync(eventAdministrator);
                    if (!isCreate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<EventAdministratorCreateResponse>(eventAdministrator);
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
