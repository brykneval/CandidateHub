using JobCandidateHub.Data.Configuration;
using JobCandidateHub.Model.Db;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateHub.Data
{
	public class JobCandidateHubContext : DbContext
	{
		public JobCandidateHubContext(DbContextOptions<JobCandidateHubContext> options)
			: base(options)
		{
		}

		public DbSet<Candidate> Candidates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CandidateConfiguration());
		}
	}
}