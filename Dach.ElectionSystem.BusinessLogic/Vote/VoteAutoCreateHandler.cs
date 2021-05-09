using System;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dach.ElectionSystem.Services.Data;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteAutoCreateHandler : IRequestHandler<VoteAutoCreateRequest, VoteAutoCreateResponse>
    {
        #region Constructor 
        private readonly IVoteRepository _voteRepository;
        private readonly IVoteRegisterEmailRepository voteRegisterEmailRepository;
        private readonly ValidateIntegrity validateIntegrity;

        public VoteAutoCreateHandler(
        IVoteRepository voteRepository,
        IVoteRegisterEmailRepository voteRegisterEmailRepository,
         ValidateIntegrity validateIntegrity
        )
        {
            _voteRepository = voteRepository;
            this.voteRegisterEmailRepository = voteRegisterEmailRepository;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<VoteAutoCreateResponse> Handle(VoteAutoCreateRequest request, CancellationToken cancellationToken)
        {
            // Valida existencia del evento
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Validar la fecha máxima para registrar participantes
            var isDateValid = eventCurrent.DateMaxRegisterParticipants >= DateTime.Now;
            if (!isDateValid)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectDates, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadGateway,
                                            $"La fecha máxima para poder registrar participantes ha terminado.");
            // encuentra los participantes del evento
            var participantsEvent = await _voteRepository.GetAsync(v => v.IdEvent == request.IdEvent);
            // Valida si el usuario no se encuentra registrado previamente
            var hasRegister = participantsEvent.Any(p => p.IdUser == request.UserContext.Id);
            if (hasRegister)
                throw new CustomException(Models.Enums.MessageCodesApi.UserRegisterEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            // Validamos que el código enviado sea correcto
            var isCodeCorrect = eventCurrent.CodeEvent == request.CodeEvent;
            if (!isCodeCorrect)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectCodeEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            // Validamos si el evento permite registrace libremente
            var allowRegisterWithOutCode = eventCurrent.AllowFreeAccess;
            if (!allowRegisterWithOutCode)
            {
                var allowRegister = (await voteRegisterEmailRepository.GetAsync(vre => vre.IdEvent == request.IdEvent && vre.UserEmail == request.UserContext.Email)).Any();
                if (!allowRegister)
                    throw new CustomException(Models.Enums.MessageCodesApi.EventNotAllowFreeRegister, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            }
            //Creamos el registro
            var newVote = new Models.Persitence.Vote()
            {
                IdEvent = request.IdEvent,
                IdUser = request.UserContext.Id,
                IsActive = true,
                DateInscription = DateTime.Now
            };
            var isCreate = await _voteRepository.CreateAsync(newVote);
            if (!isCreate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return new VoteAutoCreateResponse();
        }
        #endregion
    }
}
