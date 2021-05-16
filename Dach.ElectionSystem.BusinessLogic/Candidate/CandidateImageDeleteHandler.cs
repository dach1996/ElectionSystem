using Dach.ElectionSystem.Repository.Interfaces;
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
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Persitence;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateImageDeleteHandler : IRequestHandler<CandidateImageDeleteRequest, Unit>
    {
        #region Constructor 
        private readonly ValidateIntegrity validateIntegrity;
        private readonly IConfiguration configuration;
        private readonly ICandidateRepository _candidateRepository;

        public CandidateImageDeleteHandler(

        ValidateIntegrity validateIntegrity,
        IConfiguration configuration,
        ICandidateRepository candidateRepository)
        {
            this.validateIntegrity = validateIntegrity;
            this.configuration = configuration;
            _candidateRepository = candidateRepository;
        }
        #endregion
        #region Handler
        public async Task<Unit> Handle(CandidateImageDeleteRequest request, CancellationToken cancellationToken)
        {
            //Valida que exista el candidato mediante el id de usuario y el evento
            var candidateCurrent = await validateIntegrity.ValidateCandiateWithUserAndEvent(request.UserContext.Id, request.IdEvent);
            //Generar ruta del archivo
            var pathEnviroment = configuration.GetSection("PathSaveImage").Value;
            var pathToSave = $"{pathEnviroment}/{Models.Enums.TypeImage.Candidate}/{candidateCurrent.Id}";
            //Guardamos la imagen
            var originalFileName = $"{request.NameResoruce}";
            var finalPathFile = $"{pathToSave}/{originalFileName}";
            var file = new FileInfo(finalPathFile);
            //Validamos si existe la imagen para eliminarlo
            var recordImage = candidateCurrent.ListCandidateImage.FirstOrDefault(i => i.Image==finalPathFile);
            if (recordImage==null || !file.Exists)
                throw new CustomException(Models.Enums.MessageCodesApi.ResourceNotFound,
                 Models.Enums.ResponseType.Error,
                System.Net.HttpStatusCode.NotFound,
                $"No se encuentra imágen en la ruta: {finalPathFile}");
            file.Delete();
            //Acualizamos la base de datos
            candidateCurrent.ListCandidateImage.Remove(recordImage);
            var isUpdate = await _candidateRepository.Update(candidateCurrent);
            if (!isUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return Unit.Value;
        }
        #endregion
    }
}
