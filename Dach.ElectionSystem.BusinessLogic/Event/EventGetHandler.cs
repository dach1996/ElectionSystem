using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.UnitOfWork;
using MediatR;
namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventGetHandler : IRequestHandler<EventGetRequest, EventGetResponse>
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly IElectionUnitOfWork _electionUnitOfWork;


        public EventGetHandler(
            IMapper mapper,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _mapper = mapper;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler
        public async Task<EventGetResponse> Handle(EventGetRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                //Creamos una lista genérica
                List<Models.Persitence.Event> listEvents;
                //Verificamos si la consulta es por id o todos los registros
                if (request.Id != null)
                    listEvents = (await _electionUnitOfWork.GetEventRepository().GetAsyncInclude(e => e.Id == request.Id && !e.IsDelete, includeProperties: e => $"{nameof(e.UserCreator)}")).ToList();
                else
                {
                    listEvents = (await _electionUnitOfWork.GetEventRepository().GetAsyncInclude(e => !e.IsDelete, includeProperties: e => $"{nameof(e.UserCreator)}")).ToList();
                    listEvents = request.TypeFilter switch
                    {
                        Models.Enums.TypeFilterEvent.Administrator => (await _electionUnitOfWork.GetEventAdministratorRepository().GetAsyncInclude(e => e.IdUser == request.UserContext.Id, includeProperties: e => $"{nameof(e.Event)}")).Select(e => e.Event).Where(e => e.IsActive).ToList(),
                        Models.Enums.TypeFilterEvent.All => listEvents,
                        Models.Enums.TypeFilterEvent.Mine => listEvents.Where(e => e.IdUser == request.UserContext.Id).ToList(),
                        Models.Enums.TypeFilterEvent.MineWithVote => (await _electionUnitOfWork.GetVoteRepository().GetAsyncInclude(v => v.IdUser == request.UserContext.Id && v.HasVote && v.IsActive, includeProperties: v => $"{nameof(v.Event)}")).Select(e => e.Event).Where(e => e.IsActive).ToList(),
                        Models.Enums.TypeFilterEvent.MineWithOutVote => (await _electionUnitOfWork.GetVoteRepository().GetAsyncInclude(v => v.IdUser == request.UserContext.Id && !v.HasVote && v.IsActive, includeProperties: v => $"{nameof(v.Event)}")).Select(e => e.Event).Where(e => e.IsActive).ToList(),
                        Models.Enums.TypeFilterEvent.Participant => (await _electionUnitOfWork.GetVoteRepository().GetAsyncInclude(v => v.IdUser == request.UserContext.Id, includeProperties: v => $"{nameof(v.Event)}")).Select(e => e.Event).Where(e => e.IsActive).ToList(),
                        Models.Enums.TypeFilterEvent.Candidate => (await _electionUnitOfWork.GetCandidateRepository().GetAsyncInclude(c => c.IdUser == request.UserContext.Id && c.IsActive, includeProperties: c => $"{nameof(c.Event)}")).Select(e => e.Event).Where(e => e.IsActive).ToList(),
                        Models.Enums.TypeFilterEvent.Relation => await GetEventsWithRelation(request.UserContext.Id),
                        
                        _ => listEvents
                    };

                }
                //Filtramos todos los eventos o por usuario
                var totalEvents = listEvents.Count;
                var response = listEvents.OrderByDescending(e => e.Id)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToList();

                listEvents.ForEach(e =>
                {
                    if (!string.IsNullOrEmpty(e.Image))
                        e.Image = $"{request.PathRoot}/{e.Image}";
                });
                return new EventGetResponse()
                {
                    ListEvents = _mapper.Map<List<EventBaseResponse>>(response),
                    TotalEvents = totalEvents
                };
            }
        }

        private async Task<List<Models.Persitence.Event>> GetEventsWithRelation(int idUser)
        {

            var events = await _electionUnitOfWork
                .GetEventRepository()
                .GetAsyncInclude(
                includeProperties: e => $"{nameof(e.ListCandidate)},{nameof(e.ListEventAdministrator)},{nameof(e.ListVote)}");
            var eventsFilter = events.Where(e => e.ListEventAdministrator.Any(le => le.IdUser == idUser && le.IsActive) ||
                e.ListVote.Any(le => le.IdUser == idUser && le.IsActive) ||
                e.ListCandidate.Any(le => le.IdUser == idUser && le.IsActive)).ToList();
            return eventsFilter;
        }
        #endregion
    }
}