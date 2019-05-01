using System.Collections.Generic;

namespace Omega.Test.Web.Models
{
	public class CandidateListViewModel
	{
		public List<CandidateViewModel> Candidates { get; set; }
		public Paging Paging { get; set; }
	}

	public class Paging
	{
		public int Total { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }
		public int Previous { get; set; }
		public int Next { get; set; }
	}
}