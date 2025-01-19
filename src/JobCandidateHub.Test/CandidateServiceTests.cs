using JobCandidateHub.Data.Repository;
using JobCandidateHub.Model.Common;
using JobCandidateHub.Model.Db;
using JobCandidateHub.Service;
using Moq;

namespace JobCandidateHub.Test
{
	public class CandidateServiceTests
	{
		[Fact]
		public async Task AddOrUpdateCandidate_No_Existing_Candidate_Returns_Added()
		{
			var candidateModel = new Candidate { Email = "abc1@gmail.com" };
			var candidateRepositoryMock = new Mock<ICandidateRepository>();
			candidateRepositoryMock.Setup(r => r.UpdateCandidateAsync(It.IsAny<Candidate>())).ReturnsAsync(EnumHelpers.EOpResult.Updated);
			candidateRepositoryMock.Setup(r => r.SaveCandidateAsync(It.IsAny<Candidate>())).ReturnsAsync(EnumHelpers.EOpResult.Added);
			candidateRepositoryMock.Setup(r => r.GetCandidateAsync(It.IsAny<string>())).ReturnsAsync(() => null);

			ICandidateService candidateService = new CandidateService(candidateRepositoryMock.Object);
			var dbStatus = await candidateService.AddOrUpdateCandidateAsync(candidateModel);

			Assert.Equal(EnumHelpers.EOpResult.Added, dbStatus);
		}

		[Fact]
		public async Task AddOrUpdateCandidate_Having_Existing_Candidate_Returns_Updated()
		{
			var candidateModel = new Candidate { Email = "abc@gmail.com" };
			var candidateRepositoryMock = new Mock<ICandidateRepository>();
			candidateRepositoryMock.Setup(r => r.UpdateCandidateAsync(It.IsAny<Candidate>())).ReturnsAsync(EnumHelpers.EOpResult.Updated);
			candidateRepositoryMock.Setup(r => r.SaveCandidateAsync(It.IsAny<Candidate>())).ReturnsAsync(EnumHelpers.EOpResult.Added);
			candidateRepositoryMock.Setup(r => r.GetCandidateAsync(It.IsAny<string>())).ReturnsAsync(candidateModel);

			ICandidateService candidateService = new CandidateService(candidateRepositoryMock.Object);
			var dbStatus = await candidateService.AddOrUpdateCandidateAsync(candidateModel);

			Assert.Equal(EnumHelpers.EOpResult.Updated, dbStatus);
		}
	}
}
