using System.Collections.Generic;

namespace Omega.Test.Web.Models
{
	public class CandidateEditViewModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string Surname { get; set; }
		public bool Excluded { get; set; }

		public List<NoteViewModel> Notes { get; set; }
	}
}