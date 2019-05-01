using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Omega.Test.Web.Models;
using Omega.Test.Web.Services;

namespace Omega.Test.Web.Controllers
{
	public class HomeController : Controller
	{
		public async Task<IActionResult> Index(int page)
		{
			var service = new CandidateService();
			var model = await service.GetCandidates(page);
			return View(model);
		}

		public async Task<IActionResult> Candidate(int id)
		{
			var model = new CandidateEditViewModel
			{
				FirstName = "joel",
				Id = 1,
				Surname = "Lister",
				Excluded = true,
				Notes = new List<NoteViewModel>
				{
					new NoteViewModel{Index = 1,DateEntered = DateTimeOffset.Now.AddDays(-1), NoteText = "Test sample 1"},
					new NoteViewModel{Index = 2,DateEntered = DateTimeOffset.Now, NoteText = "Test sample 2"},
				}
			};
			return View(model);
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
