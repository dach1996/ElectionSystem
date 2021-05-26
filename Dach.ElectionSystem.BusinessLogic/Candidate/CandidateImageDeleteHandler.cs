using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Linq;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateImageDeleteHandler : IRequestHandler<CandidateImageDeleteRequest, Unit>
    {
        #region Constructor 
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CandidateImageDeleteHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;

        public CandidateImageDeleteHandler(
        ValidateIntegrity validateIntegrity,
        IConfiguration configuration,
        ILogger<CandidateImageDeleteHandler> logger,
        IElectionUnitOfWork electionUnitOfWork)
        {
            _validateIntegrity = validateIntegrity;
            _configuration = configuration;
            _logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler
        public async Task<Unit> Handle(CandidateImageDeleteRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que exista el candidato mediante el id de usuario y el evento
                    var candidateCurrent = await _validateIntegrity.ValidateCandiateWithUserAndEvent(request.UserContext.Id, request.IdEvent);
                    //Generar ruta del archivo
                    var pathEnviroment = _configuration.GetSection("PathSaveImage").Value;
                    var pathToSave = $"{pathEnviroment}/{Models.Enums.TypeImage.Candidate}/{candidateCurrent.Id}";
                    //Guardamos la imagen
                    var originalFileName = $"{request.NameResoruce}";
                    var finalPathFile = $"{pathToSave}/{originalFileName}";
                    var file = new FileInfo(finalPathFile);
                    //Validamos si existe la imagen para eliminarlo
                    var recordImage = candidateCurrent.ListCandidateImage.FirstOrDefault(i => i.Image == finalPathFile);
                    if (recordImage == null || !file.Exists)
                        throw new CustomException(Models.Enums.MessageCodesApi.ResourceNotFound,
                         Models.Enums.ResponseType.Error,
                        System.Net.HttpStatusCode.NotFound,
                        $"No se encuentra imágen en la ruta: {finalPathFile}");
                    file.Delete();
                    //Acualizamos la base de datos
                    candidateCurrent.ListCandidateImage.Remove(recordImage);
                    var isUpdate = await _electionUnitOfWork.GetCandidateRepository().Update(candidateCurrent);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(CandidateImageDeleteHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }

        }
        #endregion
    }
}
