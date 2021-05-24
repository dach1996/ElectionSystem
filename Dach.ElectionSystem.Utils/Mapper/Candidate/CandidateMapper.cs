using System.Linq;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;

namespace Dach.ElectionSystem.Utils.Mapper.Candidate
{
    public static class CandidateMapper
    {
        public static void ConfigCandidateMapper(this CustomMapperDto profile)
        {
            //Mapper to Candidate - Candidate Create
            profile.CreateMap<CandidateCreateRequest, Models.Persitence.Candidate>();
            profile.CreateMap<Models.Persitence.Candidate, CandidateCreateResponse>();

            //Mapper to Candidate - Candidate Update
            profile.CreateMap<CandidateUpdateRequest, Models.Persitence.Candidate>();
            profile.CreateMap<Models.Persitence.Candidate, CandidateUpdateResponse>();

            //Mapper to Candidate Delete
            profile.CreateMap<Models.Persitence.Candidate, CandidateDeleteResponse>();
            //Mapper to Candidate - Get 
            profile.CreateMap<Models.Persitence.Candidate, CandidateResponseBase>()
            .ForMember(destinationMember=> destinationMember.ListCandidateImage,
            act=> act.MapFrom(src =>src.ListCandidateImage.Select(lci => lci.ImageFullPath)));
            

        }

    }
}
