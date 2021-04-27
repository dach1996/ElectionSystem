using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Repository.Interfaces;

namespace Dach.ElectionSystem.Services.Data
{
    public class ValidateIntegrity
    {
        #region Constructor        
        private readonly IUserRepository userRepository;
        private readonly IVoteRepository voteRepository;
        private readonly IEventRepository eventRepository;
        private readonly ICandidateRepository candidateRepository;
        public ValidateIntegrity(
            IUserRepository userRepository,
            IVoteRepository voteRepository,
            IEventRepository eventRepository,
            ICandidateRepository candidateRepository)
        {
            this.userRepository = userRepository;
            this.voteRepository = voteRepository;
            this.eventRepository = eventRepository;
            this.candidateRepository = candidateRepository;
        }
        #endregion

        #region Methods Service
        /// <summary>
        /// Valida si los datos que llegan son reales.
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> ValidateUser(IRequestBase request)
        {
            var existUser = await userRepository.GetAsync(u => u.Id == System.Convert.ToInt32(request.TokenModel.Id) &&
                                                                u.UserName == request.TokenModel.Username &&
                                                                u.Email == request.TokenModel.Email,
                                                                includeProperties: nameof(User.ListEventAdministrator));
            if (existUser.Count() != 1)
                throw new ExceptionCustom(MessageCodesApi.DataInconsistency, ResponseType.Error, HttpStatusCode.Unauthorized, $"No se encuntra usuario con correo:{request.TokenModel.Email}");
            return existUser.FirstOrDefault();
        }

        public async Task<Event> ValidateEvent(int id)
        {
            var existEvent = await eventRepository.GetAsync(u => u.Id == id);
            if (existEvent.Count() != 1)
                throw new ExceptionCustom(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.NotFound, $"No se encuntra el evento con Id:{id}");
            var eventCurrent = existEvent.First();
            if (eventCurrent.IsDelete)
                throw new ExceptionCustom(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.NotFound, $"El evento con Id:{id} ha sido borrado");
            return existEvent.FirstOrDefault();
        }

        public async Task<User> ValidateUser(int idUser)
        {
            var existUser = await userRepository.GetAsync(u => u.Id == idUser);
            if (existUser.Count() != 1)
                throw new ExceptionCustom(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.Unauthorized, $"No se encuntra el Usuario con Id:{idUser}");
            return existUser.FirstOrDefault();
        }

        public async Task<Vote> ValidateVote(int id)
        {
            var existVote = await voteRepository.GetAsync(u => u.Id == id);
            if (existVote.Count() != 1)
                throw new ExceptionCustom(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.NotFound, $"No se encuntra el voto con Id:{id}");
            return existVote.FirstOrDefault();
        }

        public async Task<Candidate> ValidateCandiate(int id)
        {
            var existCandidate = await candidateRepository.GetAsyncInclude(u => u.Id == id
                                                                            , includeProperties: u => $"{nameof(u.User)}");
            if (existCandidate.Count() != 1)
                throw new ExceptionCustom(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.NotFound, $"No se encuntra el candidato con Id:{id}");
            return existCandidate.FirstOrDefault();
        }

        #endregion
    }
}