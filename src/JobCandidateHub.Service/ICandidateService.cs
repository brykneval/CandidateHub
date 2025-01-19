using JobCandidateHub.Model.Common;
using JobCandidateHub.Model.Db;

namespace JobCandidateHub.Service
{
	public interface ICandidateService
	{
		Task<EnumHelpers.EOpResult> AddOrUpdateCandidate(Candidate candidate);
	}
}