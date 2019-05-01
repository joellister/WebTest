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
			var service = new CandidateService();
			var model = await service.GetCandidate(id);

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
