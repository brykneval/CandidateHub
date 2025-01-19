using JobCandidateHub.Model.Common;
using JobCandidateHub.Model.Db;

namespace JobCandidateHub.Data.Repository
{
	public interface ICandidateRepository
	{
		Task<EnumHelpers.EOpResult> SaveCandidateAsync(Candidate candidate);
		Task<EnumHelpers.EOpResult> UpdateCandidateAsync(Candidate candidate);
		Task<Candidate?> GetCandidateAsync(string email);
	}
}