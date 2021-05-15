
using Dach.ElectionSystem.Models.Request.Event;
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
    public class CandidateImageHandler : IRequestHandler<CandidateImageRequest, Unit>
    {
        #region Constructor 
        private readonly ValidateIntegrity validateIntegrity;
        private readonly IConfiguration configuration;
        private readonly ICandidateRepository _candidateRepository;

        public CandidateImageHandler(

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
        public async Task<Unit> Handle(CandidateImageRequest request, CancellationToken cancellationToken)
        {
            //Validar que el evento exista
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Valida que el Usuario que envía el request, sea administrtador del evento
            var candidateCurrent = eventCurrent.ListCandidate.FirstOrDefault(c => c.IdUser == request.UserContext.Id);
            if (candidateCurrent == null)
                throw new CustomException(Models.Enums.MessageCodesApi.CandidateDontRegister, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound,
                                            $"El usuario con Id: {request.UserContext.Id} no es candidato en el evento: {eventCurrent.Name}");
            candidateCurrent = await validateIntegrity.ValidateCandiate(candidateCurrent.Id);
            //Generar ruta del archivo
            var pathEnviroment = configuration.GetSection("PathSaveImage").Value;
            var pathToSave = $"{pathEnviroment}/{Models.Enums.TypeImage.Candidate}/{candidateCurrent.Id}";
            var pathExists = Directory.Exists(pathToSave);
            if (!pathExists)
                Directory.CreateDirectory(pathToSave);
            //Validamos la cantitad máxima de candidtos permitido
            var maxImageAllow = configuration.GetSection("MaxImageAllowCandidate").Value;
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
                Event = eventCurrent,
                Candidate = candidateCurrent,
                Image = finalPathFile,
                Environment = request.PartRoot
            };
            //Agregamos la imagen a la lista
            candidateCurrent.ListCandidateImage.Add(imageCandidate);
            //Acualizamos
            var isUpdate = await _candidateRepository.Update(candidateCurrent);
            if (!isUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return Unit.Value;
        }
        #endregion
    }
}
