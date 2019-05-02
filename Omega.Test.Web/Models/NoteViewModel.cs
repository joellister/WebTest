using System;
using System.ComponentModel.DataAnnotations;

namespace Omega.Test.Web.Models
{
	public class NoteViewModel
	{
		public int Id { get; set; }
		public int Index { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Note cannot be blank")]
		public string NoteText { get; set; }
		public DateTimeOffset DateEntered { get; set; }
	}
}