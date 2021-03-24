using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserCreateHandler : IRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        #region Constructor
        private readonly ILogger<UserCreateHandler> logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly string _secretKey;
        private readonly IConfiguration _configuration;

        public UserCreateHandler(
            ILogger<UserCreateHandler> logger,
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
            _configuration = configuration;
            _secretKey = _configuration.GetSection("SecretKey").Value;
        }
        #endregion

        #region Handler
        public async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            request.Password = Common.Util.ComputeSHA256(request.Password, _secretKey);
            //Controlar que solo se pueda crear superAdmin siendo SuperAdmin
            if (request.Role == Models.Enums.RolUser.Admin ||
                    request.Role == Models.Enums.RolUser.SuperAdmin)
            {
                if (request.TokenModel.RolUser == Models.Enums.RolUser.SuperAdmin)
                {
                    var user = mapper.Map<Models.Persitence.User>(request);
                    var newUser = await userRepository.CreateAsync(user);
                    return mapper.Map<UserCreateResponse>(user);
                }
                logger.LogWarning($"No se puede crear usuario con Rol: {request.Role} siendo : {request.TokenModel.RolUser}");
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.InsufficientPrivileges, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            }

            if (request.Role == Models.Enums.RolUser.User)
            {
                if (request.TokenModel.RolUser != Models.Enums.RolUser.User)
                {
                    var user = mapper.Map<Models.Persitence.User>(request);
                    var newUser = await userRepository.CreateAsync(user);
                    return mapper.Map<UserCreateResponse>(user);
                }
                logger.LogWarning($"No se puede crear usuario con Rol: {request.Role} siendo : {request.TokenModel.RolUser}");
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.InsufficientPrivileges, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            }
            throw new ExceptionCustom(Models.Enums.MessageCodesApi.ErrorGeneric, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
        }
        #endregion
    }
}
