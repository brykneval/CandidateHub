using JobCandidateHub.Model.Common;
using JobCandidateHub.Model.Db;

namespace JobCandidateHub.Data.Repository
{
	public interface ICandidateRepository
	{
		Task<EnumHelpers.EOpResult> SaveCandidate(Candidate candidate);
		Task<EnumHelpers.EOpResult> UpdateCandidate(Candidate candidate);
		Task<Candidate?> GetCandidateAsync(string email);
	}
}