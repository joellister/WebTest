using System;

namespace Omega.Test.Web.Models
{
	public class NoteViewModel
	{
		public int Index { get; set; }
		public string NoteText { get; set; }
		public DateTimeOffset DateEntered { get; set; }
	}
}