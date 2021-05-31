using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using Dach.ElectionSystem.Services.Data;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserGetHandler : IRequestHandler<UserGetRequest, UserGetResponse>
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        private readonly IElectionUnitOfWork _electionUnitOfWork;

        public UserGetHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        public async Task<UserGetResponse> Handle(UserGetRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                await _validateIntegrity.ValidateUser(request);
                List<Models.Persitence.User> listUser;
                if (request.Id != null)
                    listUser = (await _electionUnitOfWork.GetUserRepository().GetAsync(u => u.Id == request.Id)).ToList();
                else if (request.TypeFilter == Models.Enums.TypeFilterUser.Mine)
                    listUser = (await _electionUnitOfWork.GetUserRepository().GetAsync(u => u.Id == request.UserContext.Id)).ToList();
                else
                    listUser = (await _electionUnitOfWork.GetUserRepository().GetAsync()).ToList();
                if (request.FirstName != null)
                    listUser = (await _electionUnitOfWork.GetUserRepository().GetAsync(u => u.FirstName == request.FirstName)).ToList();
                if (request.LastName != null)
                    listUser = (await _electionUnitOfWork.GetUserRepository().GetAsync(u => u.FirstLastName == request.LastName)).ToList();
                if (request.Username != null)
                    listUser = (await _electionUnitOfWork.GetUserRepository().GetAsync(u => u.UserName == request.Username)).ToList();

                var result = listUser.OrderByDescending(e => e.Id)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToList();

                var listUserGet = _mapper.Map<List<Models.Persitence.User>, List<UserBaseResponse>>(result);
                return new UserGetResponse()
                {
                    ListUser = listUserGet
                };
            }
        }
    }
}