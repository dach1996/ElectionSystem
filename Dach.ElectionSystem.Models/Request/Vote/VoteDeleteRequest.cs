using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Vote
{
    /// <summary>
    /// Clase para Request Delete User
    /// </summary>
    public class VoteDeleteRequest : VoteBaseRequest, IRequest<VoteDeleteResponse>
    {
       
    }
}
