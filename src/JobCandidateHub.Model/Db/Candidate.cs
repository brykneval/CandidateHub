namespace JobCandidateHub.Model.Db
{
	public class Candidate
	{
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string PossibleCallTimeInterval { get; set; }
		public string LinkedInProfileUrl { get; set; }
		public string GitHubProfileUrl { get; set; }
		public string Comment { get; set; }
	}
}
