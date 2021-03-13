using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.Response.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic
{
    public class Request 
    {
        public Request(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {

            var list = new List<int>() { 1, 2, 6 };

                var j= new LoginResponse() { Token = "" };
            var res= await Task.Run(() => j);
            return res;
            
        }
    }
}
