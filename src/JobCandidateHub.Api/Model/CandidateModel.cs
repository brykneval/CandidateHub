using System.ComponentModel.DataAnnotations;

namespace JobCandidateHub.Api.Model
{
	public class CandidateModel
	{
		[Required]
		[EmailAddress]
		[StringLength(200, MinimumLength = 5)]
		public string Email { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string LastName { get; set; }

		[StringLength(50)]
		public string PhoneNumber { get; set; }

		[StringLength(100)]
		public string PossibleCallTimeInterval { get; set; }

		[StringLength(200)]
		public string LinkedInProfileUrl { get; set; }

		[StringLength(200)]
		public string GitHubProfileUrl { get; set; }

		[Required]
		[StringLength(200, MinimumLength = 2)]
		public string Comment { get; set; }
	}
}