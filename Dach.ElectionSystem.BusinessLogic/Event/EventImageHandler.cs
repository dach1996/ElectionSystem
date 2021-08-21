
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.IO;
using System;
using System.Linq;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventImageHandler : IRequestHandler<EventImageRequest, Unit>
    {
        #region Constructor 
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly IConfiguration _configuration;

        public EventImageHandler(
        ValidateIntegrity validateIntegrity,
        IConfiguration configuration,
        IElectionUnitOfWork electionUnitOfWork)
        {
            _validateIntegrity = validateIntegrity;
            _configuration = configuration;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler
        public async Task<Unit> Handle(EventImageRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Validar que el evento Exista
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Valida que el Usuario que envía el request, sea administrtador del evento
                    var isUserAdministrator = eventCurrent.ListEventAdministrator.Count(e => e.IdUser == request.UserContext.Id);
                    if (isUserAdministrator == 0)
                        throw new CustomException(Models.Enums.MessageCodesApi.UserIsnotAdministratorEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound,
                                                    $"El usuario con Id: {request.UserContext.Id} no es administrador en el evento: {eventCurrent.Name}");
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(eventCurrent.Id).ConfigureAwait(false);
                    //Generar ruta del archivo
                    var originalFileName = ContentDispositionHeaderValue.Parse(request.Image.ContentDisposition).FileName.Trim('"');
                    var pathEnviroment = _configuration.GetSection("PathSaveImage").Value;
                    var pathToSave = $"{pathEnviroment}/{Models.Enums.TypeImage.Event}/{eventCurrent.Id}";
                    //Verificamos que la imágen no esté vacía
                    var pathExists = Directory.Exists(pathToSave);
                    if (!string.IsNullOrEmpty(eventCurrent.Image))
                    {
                        var file = new FileInfo(eventCurrent.Image);
                        //Validamos si existe la imagen para eliminarlo
                        if (pathExists && file.Exists)
                            file.Delete();
                    }
                    //Validamos que exista la ruta
                    if (!pathExists)
                        Directory.CreateDirectory(pathToSave);
                    //Creamos la ruta final del archivo
                    var finalPathFile = $"{pathToSave}/{Guid.NewGuid()}_{originalFileName}".Replace("-", "_").Replace(" ", "_");
                    using Stream fileStream = new FileStream(finalPathFile, FileMode.Create);
                    await request.Image.CopyToAsync(fileStream, cancellationToken);
                    //Actualizamos registro en la base de datos
                    eventCurrent.Image = finalPathFile;
                    var isUpdate = await _electionUnitOfWork.GetEventRepository().Update(eventCurrent);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return Unit.Value;
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
