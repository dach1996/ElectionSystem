
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Vote
{
    /// <summary>
    /// Clase Model para User Get Request
    /// </summary>
    public class VoteGetRequest : VoteBaseRequest, IRequest<VoteGetResponse>
    {
    
    }
}