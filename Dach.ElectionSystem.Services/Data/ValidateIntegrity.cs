using System.Linq.Expressions;
using System.Reflection.Metadata;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Models.Base;

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


        public async Task<Event> ValidateEvent(int id, bool validateState = true)
        {
            var existEvent = await eventRepository.GetAsync(u => u.Id == id, includeProperties: $"{nameof(Event.ListCandidate)},{nameof(Event.ListEventAdministrator)}");
            if (existEvent.Count() != 1)
                throw new CustomException(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.NotFound, $"No se encuntra el evento con Id:{id}");
            var eventCurrent = existEvent.First();
            if (eventCurrent.IsDelete)
                throw new CustomException(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.NotFound, $"El evento con Id:{id} ha sido borrado");
            if (validateState && !eventCurrent.IsActive)
                throw new CustomException(MessageCodesApi.EventIsInactive, ResponseType.Error, HttpStatusCode.BadRequest, $"El evento con Id:{id} se encuentra desactivado");
            return existEvent.FirstOrDefault();
        }

        /// <summary>
        /// Valida que el evento haya comenzado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ValidateStartedEvent(int id)
        {
            var listEvents = await eventRepository.GetAsync(u => u.Id == id, includeProperties: $"{nameof(Event.ListCandidate)},{nameof(Event.ListEventAdministrator)}");
            var eventCurrent = listEvents.FirstOrDefault();
            if (!eventCurrent.IsStarted)
                throw new CustomException(MessageCodesApi.EventIsStarted, ResponseType.Error, HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Valida que el evento haya comenzado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ValidateEventStateNotStarterNotFinished(int id)
        {
            var listEvents = await eventRepository.GetAsync(u => u.Id == id, includeProperties: $"{nameof(Event.ListCandidate)},{nameof(Event.ListEventAdministrator)}");
            var eventCurrent = listEvents.FirstOrDefault();
            if (eventCurrent.IsFinished)
                throw new CustomException(MessageCodesApi.EventIsFinished, ResponseType.Error, HttpStatusCode.NotFound);
            if (eventCurrent.IsStarted)
                throw new CustomException(MessageCodesApi.EventIsStarted, ResponseType.Error, HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Valida estado del evento para votar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ValidateEventStateToVote(int id)
        {
            var listEvents = await eventRepository.GetAsync(u => u.Id == id, includeProperties: $"{nameof(Event.ListCandidate)},{nameof(Event.ListEventAdministrator)}");
            var eventCurrent = listEvents.FirstOrDefault();
            if (eventCurrent.IsFinished)
                throw new CustomException(MessageCodesApi.EventIsFinished, ResponseType.Error, HttpStatusCode.NotFound);
            if (!eventCurrent.IsStarted)
                throw new CustomException(MessageCodesApi.EventDontStarted, ResponseType.Error, HttpStatusCode.NotFound);
        }


        /// <summary>
        /// Validar Usuario
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<User> ValidateUser(int idUser)
        {
            var existUser = await userRepository.GetAsyncInclude(u => u.Id == idUser, includeProperties: e => $"{nameof(e.EventNumber)}");
            if (existUser.Count() != 1)
                throw new CustomException(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.Unauthorized, $"No se encuntra el Usuario con Id:{idUser}");
            return existUser.FirstOrDefault();
        }

        public async Task<User> ValidateUser(IRequestBase request)
        {
            var existUser = await userRepository.GetAsync(u => u.Id == System.Convert.ToInt32(request.TokenModel.Id) &&
                                                                u.UserName == request.TokenModel.Username &&
                                                                u.Email == request.TokenModel.Email,
                                                                includeProperties: $"{nameof(User.ListEventAdministrator)},{nameof(User.EventNumber)}");
            if (existUser.Count() != 1)
                throw new CustomException(MessageCodesApi.DataInconsistency, ResponseType.Error, HttpStatusCode.Unauthorized, $"No se encuntra usuario con correo:{request.TokenModel.Email}");
            return existUser.FirstOrDefault();
        }

        /// <summary>
        /// Valida que exista el registro del participante
        /// </summary>
        /// <param name="idEvent"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<Vote> ValidateVote(int idEvent, int idUser, bool validateActiveState = true)
        {
            var existVote = await voteRepository.GetAsync(v => v.IdEvent == idEvent && v.IdUser == idUser);
            if (existVote.Count() != 1)
                throw new CustomException(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.NotFound, $"No se encuntra el registro de participante con UserID: {idUser}, EventID: {idEvent}");
            var voteCurrent = existVote.FirstOrDefault();
            if (validateActiveState && !voteCurrent.IsActive)
                throw new CustomException(MessageCodesApi.ParticipantIsDesactive, ResponseType.Error, HttpStatusCode.NotFound, $"El participante con UserID: {idUser}, EventID: {idEvent} está desactivado");
            return voteCurrent;
        }

        public async Task<Candidate> ValidateCandiate(int id, bool validateActiveState = true)
        {
            var listCandidates = await candidateRepository.GetAsyncInclude(u => u.Id == id
                                                                            , includeProperties:
                                                                            u => $"{nameof(u.User)},{nameof(u.ListCandidateImage)}");
            if (listCandidates.Count() != 1)
                throw new CustomException(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.NotFound, $"No se encuntra el candidato con Id:{id}");
            var candidateCurrent = listCandidates.FirstOrDefault();
            if (validateActiveState && !candidateCurrent.IsActive)
                throw new CustomException(MessageCodesApi.CandidateIsDesactive, ResponseType.Error, HttpStatusCode.NotFound, $"El candidato con Id:{id} se encuentra desactivado");
            return candidateCurrent;
        }

        /// <summary>
        /// Valida que el Usuario sea candidato del evento
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        public async Task<Candidate> ValidateCandiateWithUserAndEvent(int idUser, int idEvent)
        {
            var existCandidate = await candidateRepository.GetAsyncInclude(u => u.IdUser == idUser &&
                                                                                u.IdEvent == idEvent
                                                                            , includeProperties: u => $"{nameof(u.User)},{nameof(u.ListCandidateImage)},{nameof(u.Event)}");
            if (existCandidate.Count() != 1)
                throw new CustomException(MessageCodesApi.NotFindRecord, ResponseType.Error, HttpStatusCode.NotFound, $"El usaurio :{idUser} no es candidato en el evento : {idEvent}");
            return existCandidate.FirstOrDefault();
        }

        public async Task<bool> HasRegisterWithEvent(int idUser, int idEvent)
        {
            var events = await eventRepository.GetAsync(u => u.Id == idEvent, includeProperties: $"{nameof(Event.ListCandidate)},{nameof(Event.ListEventAdministrator)},{nameof(Event.ListVote)}");
            if (!events.Any())
                throw new CustomException(MessageCodesApi.ResourceNotFound, ResponseType.Error, HttpStatusCode.NotFound, $"El evento con id :{idEvent} no existe");
            var eventCurrent = events.FirstOrDefault();
            if (eventCurrent.ListEventAdministrator.Any(le => le.IdUser == idUser && le.IsActive) ||
                eventCurrent.ListVote.Any(le => le.IdUser == idUser && le.IsActive) ||
                eventCurrent.ListCandidate.Any(le => le.IdUser == idUser && le.IsActive))
                return true;
            throw new CustomException(MessageCodesApi.ResourceNotFound, ResponseType.Error, HttpStatusCode.NotFound, $"El usuario con  ID: {idUser} no posee ningún registro en el evento con ID: {idEvent}");
        }

        /// <summary>
        /// Valida que el Usuario sea administrador del evento
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        public async Task IsAdministratorEvent(int idUser, int idEvent)
        {
            var events = await eventRepository.GetAsync(u => u.Id == idEvent, includeProperties: $"{nameof(Event.ListEventAdministrator)}");
            if (!events.Any())
                throw new CustomException(MessageCodesApi.ResourceNotFound, ResponseType.Error, HttpStatusCode.NotFound, $"El evento con id :{idEvent} no existe");
            var eventCurrent = events.FirstOrDefault();
            var isAdministrator = eventCurrent.ListEventAdministrator.Any(administrator => administrator.IdUser == idUser);
            if (!isAdministrator)
                throw new CustomException(MessageCodesApi.UserIsnotAdministratorEvent, ResponseType.Error, HttpStatusCode.NotFound, $"El usuario con  ID: {idUser} no es administrador en el evento con ID: {idEvent}");
        }

        /// <summary>
        /// Valida que el usuario sea creador del evento
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        public async Task IsCreatorEvent(int idUser, int idEvent)
        {
            var events = await eventRepository.GetAsync(u => u.Id == idEvent, includeProperties: $"{nameof(Event.ListEventAdministrator)}");
            if (!events.Any())
                throw new CustomException(MessageCodesApi.ResourceNotFound, ResponseType.Error, HttpStatusCode.NotFound, $"El evento con id :{idEvent} no existe");
            var eventCurrent = events.FirstOrDefault();
            var isCreator = eventCurrent.IdUser == idUser;
            if (!isCreator)
                throw new CustomException(MessageCodesApi.EventCreator, ResponseType.Error, HttpStatusCode.NotFound, $"El usuario con  ID: {idUser} no es creador del evento con ID: {idEvent}");
        }
        #endregion
    }
}