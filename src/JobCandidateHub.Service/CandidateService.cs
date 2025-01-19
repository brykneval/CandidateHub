using JobCandidateHub.Cache;
using JobCandidateHub.Data.Repository;
using JobCandidateHub.Model.Common;
using JobCandidateHub.Model.Db;

namespace JobCandidateHub.Service
{
	public class CandidateService : ICandidateService
	{
		private readonly ICandidateRepository _candidateRepository;
		private readonly IJobCandidateCache<Candidate> _cache;
		public CandidateService(ICandidateRepository candidateRepository)
		{
			_candidateRepository = candidateRepository;
			_cache = new JobCandidateDictionaryCache<Candidate>();
		}

		public async Task<EnumHelpers.EOpResult> AddOrUpdateCandidateAsync(Candidate candidate)
		{
			var oCandidate = _cache.GetCache(candidate.Email) ?? await _candidateRepository.GetCandidateAsync(candidate.Email);
			var dbStatus = EnumHelpers.EOpResult.Processing;
			if (oCandidate == null)
			{
				dbStatus = await _candidateRepository.SaveCandidateAsync(candidate);
			}
			else
			{
				dbStatus = await _candidateRepository.UpdateCandidateAsync(oCandidate);
			}
			_cache.SetCache(candidate.Email, candidate);
			return dbStatus;
		}
	}
}