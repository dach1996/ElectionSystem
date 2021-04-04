using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;

namespace Dach.ElectionSystem.Utils.Mapper.Candidate
{
    public static class CandidateMapper
    {
        public static void ConfigCandidateMapper(this CustomMapperDTO profile)
        {
            //Mapper to Candidate - Candidate Create
            /*profile.CreateMap<CandidateCreateRequest, Models.Persitence.Candidate>()
                .ForMember(
                destino => destino.Rol,
                origen => origen.MapFrom(u => (int)u.Role))
                .ForMember(
                destino => destino.RolName,
                origen => origen.MapFrom(u => u.Role.ToString())
                );*/
            profile.CreateMap<CandidateCreateRequest, Models.Persitence.Candidate>();
            profile.CreateMap<Models.Persitence.Candidate, CandidateCreateResponse>();

            //Mapper to Candidate - Candidate Update
            profile.CreateMap<CandidateUpdateRequest, Models.Persitence.Candidate>();
            profile.CreateMap<Models.Persitence.Candidate, CandidateUpdateResponse>();

            //Mapper to Candidate Delete
            profile.CreateMap<Models.Persitence.Candidate, CandidateDeleteResponse>();
            //Mapper to Candidate - Get Update

            profile.CreateMap<Models.Persitence.Candidate, CandidateResponseBase>();

        }

    }
}
