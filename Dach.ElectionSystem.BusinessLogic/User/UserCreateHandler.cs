using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
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
        private readonly ValidateIntegrity validateIntegrity;

        public UserCreateHandler(
            ILogger<UserCreateHandler> logger,
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration,
            ValidateIntegrity validateIntegrity)
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
            _configuration = configuration;
            this.validateIntegrity = validateIntegrity;
            _secretKey = _configuration.GetSection("SecretKey").Value;
        }
        #endregion

        #region Handler
        public async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            logger.Log(LogLevel.Error, "Entre al controlador");
            //Hash a la clave
            request.Password = Common.Util.ComputeSHA256(request.Password, _secretKey);
            //Valida que el usuario exista
            var emailExist = await userRepository.GetAsync(u=>u.Email ==request.Email);
            if(emailExist.Count() != 0)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.EmailRegistered, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            var userNew = mapper.Map<Models.Persitence.User>(request);
            userNew.IsActive = true;
            var isRegister = await userRepository.CreateAsync(userNew);
            if(!isRegister)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return mapper.Map<UserCreateResponse>(userNew);
           }
        #endregion
    }
}
