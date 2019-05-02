using System.Diagnostics;
using System.Linq;
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
			var service = new CandidateService();
			var model = await service.GetCandidate(id);

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Note(int id, int? index)
		{

			var model = new NoteViewModel { Id = id };
			if (index.HasValue)
			{
				var service = new CandidateService();
				var candidate = await service.GetCandidate(id);
				model.Index = index.Value;
				var note = candidate.Notes.First(x => x.Index == index.Value);
				model.NoteText = note.NoteText;
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Note(NoteViewModel model)
		{

			if (ModelState.IsValid)
			{
				var service = new CandidateService();
				await service.SaveNote(model);
				return RedirectToAction("Candidate", new {id = model.Id});
			}

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
