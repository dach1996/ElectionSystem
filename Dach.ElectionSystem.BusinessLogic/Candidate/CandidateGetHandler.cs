﻿using AutoMapper;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateGetHandler : IRequestHandler<CandidateGetRequest, CandidateGetResponse>
    {
        #region Constructor
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        public CandidateGetHandler(
            IMapper mapper,
            IElectionUnitOfWork electionUnitOfWork, 
            ValidateIntegrity validateIntegrity)
        {
            this.mapper = mapper;
            _electionUnitOfWork = electionUnitOfWork;
            _validateIntegrity = validateIntegrity;
        }
        #endregion

        #region Handler
        public async Task<CandidateGetResponse> Handle(CandidateGetRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                _ = await _validateIntegrity.HasRegisterWithEvent(request.UserContext.Id,request.IdEvent);
                List<Models.Persitence.Candidate> listCandidates;
                if (request.IdCandidate != null)
                    listCandidates = (await _electionUnitOfWork.GetCandidateRepository().GetAsyncInclude(c => c.Id == request.IdCandidate && c.IdEvent == request.IdEvent && c.IsActive,
                    includeProperties: i => $"{nameof(i.ListCandidateImage)},{nameof(i.User)}")).ToList();
                else
                    listCandidates = (await _electionUnitOfWork.GetCandidateRepository().GetAsyncInclude(c => c.IdEvent == request.IdEvent && c.IsActive,
                    includeProperties: i => $"{nameof(i.ListCandidateImage)},{nameof(i.User)}")).ToList();
                var totalCandidate = listCandidates.Count;
                listCandidates = listCandidates.OrderByDescending(e => e.Id)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToList();
                var response = mapper.Map<List<CandidateResponseBase>>(listCandidates);
                return new CandidateGetResponse(response, totalCandidate);
            }
        }
        #endregion
    }
}
