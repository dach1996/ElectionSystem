using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteCreateHandler : IRequestHandler<VoteCreateRequest, VoteCreateResponse>
    {
        #region Constructor 
        private readonly IVoteRepository _voteRepository;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity validateIntegrity;

        public VoteCreateHandler(
        IVoteRepository voteRepository,
        IMapper mapper,
        ValidateIntegrity validateIntegrity
        )
        {
            this._voteRepository = voteRepository;
            this._mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<VoteCreateResponse> Handle(VoteCreateRequest request, CancellationToken cancellationToken)
        {
            //Validamos que exista el usuario a registrar
            await validateIntegrity.ValidateUser(request.IdUser);
            //Validamos que exista el Evento
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            // encuentra los participantes del evento
            var participants = await _voteRepository.GetAsync(v => v.IdEvent == request.IdEvent);
            //Valida que l usuario no esté registrado ya como votante en el evento
            var hasRegister = participants.Any(u => u.IdUser == request.IdUser);
            if (hasRegister)
                throw new CustomException(Models.Enums.MessageCodesApi.UserRegisterEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            //Valida que no se supere el número máximo de participantes en caso de existir
            if (eventCurrent.MaxPeople && participants.Count() > eventCurrent.NumberMaxPeople)
                throw new CustomException(Models.Enums.MessageCodesApi.LimitMaxParticipants, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            //Valida que el usuario que envía el request sea la administrador del evento
            if (!eventCurrent.ListEventAdministrator.Any(e => e.IdUser == request.UserContext.Id))
                throw new CustomException(Models.Enums.MessageCodesApi.UserIsnotAdministratorEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);

            //Validamos que exista el Candidato
            var newVote = new Models.Persitence.Vote()
            {
                IdEvent = request.IdEvent,
                IdUser = request.IdUser,
                IsActive = true,
                DateInscription = DateTime.Now
            };
            var isCreate = await _voteRepository.CreateAsync(newVote);
            if (!isCreate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<VoteCreateResponse>(newVote);
        }
        #endregion
    }
}
