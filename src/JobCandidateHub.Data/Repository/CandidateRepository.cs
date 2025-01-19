using JobCandidateHub.Model.Common;
using JobCandidateHub.Model.Db;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.Data.Repository
{
	public class CandidateRepository : ICandidateRepository
	{
		private readonly JobCandidateHubContext _context;
		public CandidateRepository(JobCandidateHubContext context)
		{
			_context = context;
		}

		public async Task<EnumHelpers.EOpResult> SaveCandidate(Candidate candidate)
		{
			await _context.AddAsync(candidate);
			var isSuccess = await SaveAsync();
			return isSuccess ? EnumHelpers.EOpResult.Added : EnumHelpers.EOpResult.Failed;
		}

		public async Task<EnumHelpers.EOpResult> UpdateCandidate(Candidate candidate)
		{
			_context.Update(candidate);
			var isSuccess = await SaveAsync();
			return isSuccess ? EnumHelpers.EOpResult.Updated : EnumHelpers.EOpResult.Failed;
		}

		public async Task<Candidate?> GetCandidateAsync(string email)
		{
			var candidate = await _context.Candidates
						.FirstOrDefaultAsync(c => c.Email == email);
			return candidate;
		}

		private async Task<bool> SaveAsync()
		{
			bool isSuccess = false;
			try
			{
				await _context.SaveChangesAsync();
				isSuccess = true;
			}
			catch (Exception ex)
			{
				throw;
			}
			return isSuccess;
		}
	}
}