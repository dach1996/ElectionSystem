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
        public ValidateIntegrity(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
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
            var existUser = await userRepository.GetAsync(u =>  u.Id == System.Convert.ToInt32(request.TokenModel.Id) &&
                                                                u.UserName == request.TokenModel.Username &&
                                                                u.Email == request.TokenModel.Email,
                                                                includeProperties: nameof(User.AdministratorEvent));
            if(existUser.Count()!=1)
               throw new ExceptionCustom(MessageCodesApi.DataInconsistency, ResponseType.Error, HttpStatusCode.Unauthorized);
            return existUser.FirstOrDefault();
        }
        #endregion  
    }
}