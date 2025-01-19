using JobCandidateHub.Model.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace JobCandidateHub.Data.Configuration
{
	public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
	{
		public void Configure(EntityTypeBuilder<Candidate> builder)
		{
			builder.HasKey(x => x.Email);
			builder.HasIndex(x => x.Email).IsUnique();
			builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
			builder.Property(x => x.PhoneNumber).HasMaxLength(50);
			builder.Property(x => x.PossibleCallTimeInterval).HasMaxLength(100);
			builder.Property(x => x.LinkedInProfileUrl).HasMaxLength(200);
			builder.Property(x => x.GitHubProfileUrl).HasMaxLength(200);
			builder.Property(x => x.Comment).IsRequired().HasMaxLength(200);
		}
	}
}
