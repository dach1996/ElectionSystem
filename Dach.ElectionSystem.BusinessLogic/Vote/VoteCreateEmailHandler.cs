using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteCreateEmailHandler : IRequestHandler<VoteCreateEmailRequest, VoteCreateEmailResponse>
    {
        #region Constructor 
        private readonly IVoteRepository _voteRepository;
        private readonly IUserRepository userRepository;
        private readonly IVoteRegisterEmailRepository voteRegisterEmailRepository;

        public VoteCreateEmailHandler(
        IVoteRepository voteRepository,
        IUserRepository userRepository,
        IVoteRegisterEmailRepository voteRegisterEmailRepository
        )
        {
            this._voteRepository = voteRepository;
            this.userRepository = userRepository;
            this.voteRegisterEmailRepository = voteRegisterEmailRepository;
        }
        #endregion
        #region Handler
        public async Task<VoteCreateEmailResponse> Handle(VoteCreateEmailRequest request, CancellationToken cancellationToken)
        {
            //Valida si el usuario es administrador del evento
            var isAdministrator = request.UserContext.ListEventAdministrator.Any(e => e.IdEvent == request.IdEvent);
            if (!isAdministrator)
                throw new CustomException(Models.Enums.MessageCodesApi.UserIsnotAdministratorEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            // encuentra los participantes del evento
            var participants = await _voteRepository.GetAsync(v => v.IdEvent == request.IdEvent);
            // Consulta la lista de usuarios que existen registrados con el mail
            var usersExist = await userRepository.GetAsync(u => request.EmailUser.Any(um => um == u.Email));
            // Consulta la lista de correos de  usuario que no existán registrados
            var emailUserNotExist = request.EmailUser.Where(m => !usersExist.Any(ue => ue.Email == m)).ToList();
            // Obtiene la lista de usuario que no están registrados en el event
            var userToRegister = usersExist.Where(p => !participants.Any(ue => ue.IdUser == p.Id)).ToList();
            //Registramos las usuarios para ser participantes
            var listParticipantesToRegister = userToRegister.Select(utr => new Models.Persitence.Vote()
            {
                IdEvent = request.IdEvent,
                DateInscription = DateTime.Now,
                IsActive = true,
                IdUser = utr.Id
            }
            );
            var isRegisterVote = await _voteRepository.CreateManyAsync(listParticipantesToRegister);
            if (!isRegisterVote)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            //Registramos los usuarios que no están registrados en la tabla de votos_email

            var listParticipantesRegisterVoteEmail = await voteRegisterEmailRepository.GetAsync(v => emailUserNotExist.Any(ur => ur == v.UserEmail));
            var listParticipantesWithOutRegister = emailUserNotExist.Where(eune => !listParticipantesRegisterVoteEmail.Any(prvm => prvm.UserEmail == eune)).ToList();
            var listParticipantesWithOutRegisterToRegister = listParticipantesWithOutRegister.Select(mailParticipant => new Models.Persitence.VoteRegisterEmail()
            {
                IdEvent = request.IdEvent,
                IdUserAdministrator = request.UserContext.Id,
                UserEmail = mailParticipant
            }
            );
            var isRegisterVoteMail = await voteRegisterEmailRepository.CreateManyAsync(listParticipantesWithOutRegisterToRegister);
            if (!isRegisterVoteMail)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            // TODO: Enviar Correo a usuario que registrados en tabla de Mail
            return new VoteCreateEmailResponse()
            {
                EmailUserRegister = usersExist.Select(ue => ue.Email).ToList(),
                NumberRegister = usersExist.Count(),
                EmailUserWithOutRegister = listParticipantesRegisterVoteEmail.Select(p => p.UserEmail).ToList(),
                NumberSendEmail =listParticipantesRegisterVoteEmail.Count()
            };
        }
        #endregion
    }
}
