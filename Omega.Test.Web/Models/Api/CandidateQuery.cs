using System;
using System.Collections.Generic;

namespace Omega.Test.Web.Models.Api
{
	public class CandidateQuery
	{
		public List<Candidate> Data { get; set; }
		public Meta Meta { get; set; }
	}

	public class PersonalityScores
	{
		public int conscientious { get; set; }
		public int impression { get; set; }
		public int team { get; set; }
		public int conventional { get; set; }
		public int extrovert { get; set; }
		public int tough { get; set; }
		public int stable { get; set; }
	}

	public class Candidate
	{
		public DateTime dateresponsereceived { get; set; }
		public PersonalityScores personalityScores { get; set; }
		public string big5assessmenturl { get; set; }
		public string email { get; set; }
		public string Name { get; set; }
		public DateTime daterequestsent { get; set; }
		public List<object> leadershipFit { get; set; }
		public int performance { get; set; }
		public string phone { get; set; }
		public List<object> trainingAndCoaching { get; set; }
		public List<object> notes { get; set; }
		public List<object> jobFits { get; set; }
		public string big5clientorder { get; set; }
		public string jobtitle { get; set; }
		public string Surname { get; set; }
		public string big5receipt { get; set; }
		public int Id { get; set; }
		public int overall { get; set; }
		public int excluded { get; set; }
		public int companyid { get; set; }
		public int modelemployee { get; set; }
	}

	public class Meta
	{
		public int Total { get; set; }
		public int TotalPages { get; set; }
		public string Url { get; set; }
		public int CurrentPage { get; set; }
		public int PerPage { get; set; }
		public Links Links { get; set; }
	}

	public class Links
	{
		public string Next { get; set; }
	}
}