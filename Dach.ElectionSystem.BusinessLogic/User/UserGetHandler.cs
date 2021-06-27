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
                {
                    listUser = (await _electionUnitOfWork.GetUserRepository().GetAsync()).ToList();
                    if (!string.IsNullOrWhiteSpace(request.FirstName))
                        listUser = listUser.Where(u => u.FirstName.Contains(request.FirstName)).ToList();
                    if (!string.IsNullOrWhiteSpace(request.LastName))
                        listUser = listUser.Where(u => u.FirstName.Contains(request.LastName)).ToList();
                    if (!string.IsNullOrWhiteSpace(request.Email))
                        listUser = listUser.Where(u => u.FirstName.Contains(request.Email)).ToList();
                    if (!string.IsNullOrWhiteSpace(request.Username))
                        listUser = listUser.Where(u => u.FirstName.Contains(request.Username)).ToList();
                }

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