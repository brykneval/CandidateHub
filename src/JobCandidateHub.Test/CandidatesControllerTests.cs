using JobCandidateHub.Api.Controllers;
using JobCandidateHub.Api.Model;
using JobCandidateHub.Model.Common;
using JobCandidateHub.Model.Db;
using JobCandidateHub.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace JobCandidateHub.Test
{
	public class CandidatesControllerTests
	{
		[Fact]
		public async Task Validate_Invalid_Model_Returns_Invalid()
		{
			var candidateModel = new CandidateModel { Email = "abc@gmail.com", FirstName = "", LastName = "lastName", Comment = "comment" };

			var context = new ValidationContext(candidateModel, null, null);
			var results = new List<ValidationResult>();
			var isModelStateValid = Validator.TryValidateObject(candidateModel, context, results, true);

			Assert.False(isModelStateValid);
		}

		[Fact]
		public async Task Validate_Valid_Model_Returns_Valid()
		{
			var candidateModel = new CandidateModel { Email = "abc@gmail.com", FirstName = "firstName", LastName = "lastName", Comment = "comment" };

			var context = new ValidationContext(candidateModel, null, null);
			var results = new List<ValidationResult>();
			var isModelStateValid = Validator.TryValidateObject(candidateModel, context, results, true);

			Assert.True(isModelStateValid);
		}

		[Fact]
		public async Task Post_Success_AddOrUpdate_Returns_Ok()
		{
			var candidateServiceMock = new Mock<ICandidateService>();
			candidateServiceMock.Setup(r => r.AddOrUpdateCandidateAsync(It.IsAny<Candidate>())).ReturnsAsync(EnumHelpers.EOpResult.Added);
			var candidateModel = new CandidateModel { Email = "abc@gmail.com", FirstName = "firstName", LastName = "lastName", Comment = "comment" };

			var candidatesController = new CandidatesController(candidateServiceMock.Object);
			var result = await candidatesController.Post(candidateModel) as ObjectResult;

			Assert.Equal(200, result.StatusCode);
		}

		[Fact]
		public async Task Post_Failed_AddOrUpdate_Returns_InternalServerError()
		{
			var candidateServiceMock = new Mock<ICandidateService>();
			candidateServiceMock.Setup(r => r.AddOrUpdateCandidateAsync(It.IsAny<Candidate>())).ReturnsAsync(EnumHelpers.EOpResult.Failed);
			var candidateModel = new CandidateModel { Email = "abc@gmail.com", FirstName = "firstName", LastName = "lastName", Comment = "comment" };

			var candidatesController = new CandidatesController(candidateServiceMock.Object);
			var result = await candidatesController.Post(candidateModel) as ObjectResult;

			Assert.Equal(500, result.StatusCode);
		}
	}
}
