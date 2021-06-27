using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.IO;
using System;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Persitence;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateImageHandler : IRequestHandler<CandidateImageRequest, Unit>
    {
        #region Constructor 
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CandidateImageHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        public CandidateImageHandler(
        ValidateIntegrity validateIntegrity,
        IConfiguration configuration,
        ILogger<CandidateImageHandler> logger,
        IElectionUnitOfWork electionUnitOfWork)
        {
            _validateIntegrity = validateIntegrity;
            _configuration = configuration;
            _logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler
        public async Task<Unit> Handle(CandidateImageRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que el evento no esté inactivo
                    _ = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Valida que exista el candidato mediante el id de usuario y el evento
                    var candidateCurrent = await _validateIntegrity.ValidateCandiateWithUserAndEvent(request.UserContext.Id, request.IdEvent);
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(candidateCurrent.IdEvent).ConfigureAwait(false);
                    //Generar ruta del archivo
                    var pathEnviroment = _configuration.GetSection("PathSaveImage").Value;
                    var pathToSave = $"{pathEnviroment}/{Models.Enums.TypeImage.Candidate}/{candidateCurrent.Id}";
                    var pathExists = Directory.Exists(pathToSave);
                    if (!pathExists)
                        Directory.CreateDirectory(pathToSave);
                    //Validamos la cantitad máxima de candidtos permitido
                    var maxImageAllow = _configuration.GetSection("MaxImageAllowCandidate").Value;
                    if (candidateCurrent.ListCandidateImage.Count >= Convert.ToInt16(maxImageAllow))
                        throw new CustomException(
                            Models.Enums.MessageCodesApi.MaxImageAllow, Models.Enums.ResponseType.Error,
                            System.Net.HttpStatusCode.BadRequest,
                            $"El candidato con Id: {candidateCurrent.Id} posee: {candidateCurrent.ListCandidateImage.Count} y el máximo es: {maxImageAllow}");
                    //Guardamos la imagen
                    var originalFileName = ContentDispositionHeaderValue.Parse(request.Image.ContentDisposition).FileName.Trim('"');
                    var finalPathFile = $"{pathToSave}/{Guid.NewGuid()}_{originalFileName}".Replace("-", "_").Replace(" ", "_");
                    using Stream fileStream = new FileStream(finalPathFile, FileMode.Create);
                    await request.Image.CopyToAsync(fileStream, cancellationToken);
                    //Actualizamos registro en la base de datos
                    var imageCandidate = new CandidateImage()
                    {
                        Event = candidateCurrent.Event,
                        Candidate = candidateCurrent,
                        Image = finalPathFile,
                        Environment = request.PathRoot
                    };
                    //Agregamos la imagen a la lista
                    candidateCurrent.ListCandidateImage.Add(imageCandidate);
                    //Acualizamos
                    var isUpdate = await _electionUnitOfWork.GetCandidateRepository().Update(candidateCurrent);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(CandidateImageHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }

        }
        #endregion
    }
}
