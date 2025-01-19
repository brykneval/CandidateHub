using JobCandidateHub.Api.Model;
using JobCandidateHub.Model.Common;
using JobCandidateHub.Model.Db;
using JobCandidateHub.Service;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CandidatesController : ControllerBase
	{
		private readonly ICandidateService _candidateService;

		public CandidatesController(ICandidateService candidateService)
		{
			_candidateService = candidateService;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CandidateModel candidateModel)
		{
			if (ModelState.IsValid)
			{
				var candidate = MapToDb(candidateModel);
				var opStatus = await _candidateService.AddOrUpdateCandidateAsync(candidate);
				if (opStatus == EnumHelpers.EOpResult.Added || opStatus == EnumHelpers.EOpResult.Updated)
				{
					return Ok(new { message = $"Candidate {opStatus.ToString()} successfully." });
				}
				else
				{
					return StatusCode(500, new { message = "A database error occurred while saving candidate." });
				}
			}
			return BadRequest(ModelState);
		}

		private Candidate MapToDb(CandidateModel candidateModel)
		{
			var candidate = new Candidate();
			candidate.Email = candidateModel.Email;
			candidate.FirstName = candidateModel.FirstName;
			candidate.LastName = candidateModel.LastName;
			candidate.PhoneNumber = candidateModel.PhoneNumber;
			candidate.Comment = candidateModel.Comment;
			candidate.PossibleCallTimeInterval = candidateModel.PossibleCallTimeInterval;
			candidate.LinkedInProfileUrl = candidateModel.LinkedInProfileUrl;
			candidate.GitHubProfileUrl = candidateModel.GitHubProfileUrl;
			return candidate;
		}
	}
}