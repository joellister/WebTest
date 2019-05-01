using System;
using System.Collections.Generic;

namespace Omega.Test.Web.Models.Api
{

	public class CandidateResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Excluded { get; set; }
		public List<Note> Notes { get; set; }

		public string phone { get; set; }
		public PersonalityScores personalityScores { get; set; }
		public int performance { get; set; }
		public DateTime dateresponsereceived { get; set; }
		public List<object> trainingAndCoaching { get; set; }
		public List<object> leadershipFit { get; set; }
		public string big5receipt { get; set; }
		public string big5clientorder { get; set; }
		public List<object> jobFits { get; set; }
		public DateTime daterequestsent { get; set; }
		public string big5assessmenturl { get; set; }
		public int modelemployee { get; set; }
		public int companyid { get; set; }
		public string email { get; set; }
		public string jobtitle { get; set; }
		public int overall { get; set; }
	}

	public class Note
	{
		public DateTime DateEntered { get; set; }
		public string Text { get; set; }
	}
}