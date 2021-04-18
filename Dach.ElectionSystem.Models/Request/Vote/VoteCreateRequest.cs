using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Vote

{
    /// <summary>
    /// Request para crear Usuarios
    /// </summary>
    public class VoteCreateRequest : VoteBaseRequest, IRequest<VoteCreateResponse>
    {
        
    }
}
