using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
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
           
        }
        #endregion

        #region Handler
        public async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            var _secretKey = _configuration.GetSection("SecretKey").Value;
            //Hash a la clave
            request.Password = Common.Util.ComputeSHA256(request.Password, _secretKey);
            //Valida que el usuario exista
            var emailExist = await userRepository.GetAsync(u => u.Email == request.Email);
            if (emailExist.Any())
                throw new CustomException(Models.Enums.MessageCodesApi.EmailRegistered, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            var userNew = mapper.Map<Models.Persitence.User>(request);
            userNew.EventNumber = new Models.Persitence.EventNumber()
            {
                User = userNew
            };
            userNew.IsActive = true;
            var isRegister = await userRepository.CreateAsync(userNew);
            if (!isRegister)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            logger.LogInformation("Usuario Creado con éxito");
            return mapper.Map<UserCreateResponse>(userNew);
        }
        #endregion
    }
}
