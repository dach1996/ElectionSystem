using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dach.ElectionSystem.Models.Request.Candidate
{
    public class CandidateCreateRequest : IRequest<CandidateCreateResponse>, IRequestBase
    {
        public string Image { get; set; }
        public string Video { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string ProposalDetails { get; set; }
        public string PostionsWorks { get; set; }
        public TokenModel TokenModel { get ; set; }
    }
}
