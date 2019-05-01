using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Omega.Test.Web.Models;
using Omega.Test.Web.Models.Api;

namespace Omega.Test.Web.Services
{
	public class CandidateService
	{
		private static readonly HttpClient Client = new HttpClient();
		private const string BaseUrl = "https://www.peg-em.com/v1/candidates/0/-1";

		public async Task<CandidateListViewModel> GetCandidates(int pageNumber)
		{
			var url = pageNumber > 1 ? $"{BaseUrl}?page={pageNumber}": BaseUrl;

			var response = await Client.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				//TODO: log error
			}

			var list = await response.Content.ReadAsAsync<CandidateQuery>();

			var candidates = new CandidateListViewModel
			{
				Candidates = list.Data.Select(x => new CandidateViewModel
				{
					Id = x.Id,
					FirstName = x.Name,
					Surname = x.Surname
				}).ToList(),
				Paging = ToPage(list.Meta)
			};

			return candidates;

		}

		private static Paging ToPage(Meta meta)
		{
			return new Paging
			{
				CurrentPage = meta.CurrentPage,
				Previous = Math.Max(1, meta.CurrentPage - 1),
				Next = Math.Min(meta.TotalPages, meta.CurrentPage + 1),
				Total = meta.Total,
				TotalPages = meta.TotalPages
			};
		}
	}
}