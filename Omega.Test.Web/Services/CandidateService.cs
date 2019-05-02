using Omega.Test.Web.Models;
using Omega.Test.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Omega.Test.Web.Services
{
	public class CandidateService
	{
		private static readonly HttpClient Client = new HttpClient();


		public async Task<CandidateListViewModel> GetCandidates(int pageNumber)
		{
			//return new CandidateListViewModel
			//{
			//	Candidates = new List<CandidateViewModel>
			//	{
			//		new CandidateViewModel {Id = 1, FirstName = "Joel", Surname = "Lister"},
			//		new CandidateViewModel {Id = 2, FirstName = "Fred", Surname = "Smith"},
			//	},
			//	Paging = new Paging { CurrentPage = 1, Next = 2, Previous = 1, TotalPages = 10, Total = 27 }
			//};

			const string baseUrl = "https://www.peg-em.com/v1/candidates/0/-1";
			var url = pageNumber > 1 ? $"{baseUrl}?page={pageNumber}" : baseUrl;

			var response = await Client.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				//TODO: log error
			}

			var candidateListResponse = await response.Content.ReadAsAsync<CandidateListResponse>();

			var candidates = new CandidateListViewModel
			{
				Candidates = candidateListResponse.Data.Select(x => new CandidateViewModel
				{
					Id = x.Id,
					FirstName = x.Name,
					Surname = x.Surname
				}).ToList(),
				Paging = ToPage(candidateListResponse.Meta)
			};

			return candidates;
		}

		public async Task<CandidateEditViewModel> GetCandidate(int id)
		{
			//return new CandidateEditViewModel
			//{
			//	FirstName = "joel",
			//	Id = 1,
			//	Surname = "Lister",
			//	Excluded = true,
			//	Notes = new List<NoteViewModel>
			//	{
			//		new NoteViewModel{Index = 1,DateEntered = DateTimeOffset.Now.AddDays(-1), NoteText = "Test sample 1"},
			//		new NoteViewModel{Index = 2,DateEntered = DateTimeOffset.Now, NoteText = "Test sample 2"},
			//	}
			//};


			var url = $"https://www.peg-em.com/v1/candidate/{id}";
			var response = await Client.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				//TODO: log error
			}
			var candidateResponse = await response.Content.ReadAsAsync<CandidateResponse>();

			var candidate = new CandidateEditViewModel
			{
				Id = candidateResponse.Id,
				FirstName = candidateResponse.Name,
				Surname = candidateResponse.Surname,
				Excluded = candidateResponse.Excluded > 0,
				Notes = new List<NoteViewModel>()
			};

			if (candidateResponse.Notes==null)
				return candidate;

			var index = 0;
			foreach (var note in candidateResponse.Notes)
			{
				index++;
				candidate.Notes.Add(new NoteViewModel {Index = index,DateEntered = ToLocalTime(note.DateEntered), NoteText = note.Text});
			}

			return candidate;
		}

		private static DateTimeOffset ToLocalTime(DateTime utcDateTime)
		{
			var originalTime = new DateTimeOffset(utcDateTime, new TimeSpan(0));
			return originalTime.ToLocalTime();
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

		public async Task SaveNote(NoteViewModel model)
		{
			if (model.Index==0)
			{
				await AddNewNote(model);
				return;
			}
			await AmendNote(model);
		}

		private async Task AmendNote(NoteViewModel model)
		{
			var url = $"https://www.peg-em.com/v1/candidateupdatenote/{model.Id}/{model.Index}";

			var formContent = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("note", model.NoteText)
			});

			var response = await Client.PostAsync(url, formContent);
			if (!response.IsSuccessStatusCode)
			{
				//TODO: log error
			}

			var stringContent = await response.Content.ReadAsStringAsync();
		}

		private async Task AddNewNote(NoteViewModel model)
		{
			var url = $"https://www.peg-em.com/v1/candidateaddnote/{model.Id}";

			var formContent = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("note", model.NoteText)
			});

			var response = await Client.PostAsync(url, formContent);
			if (!response.IsSuccessStatusCode)
			{
				//TODO: log error
			}

			var stringContent = await response.Content.ReadAsStringAsync();

		}

		public async Task ToggleExcludeFlag(int id)
		{
			var url = $"https://www.peg-em.com/v1/candidatetoggleexcluded/{id}";

			var response = await Client.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				//TODO: log error
			}
			var stringContent = await response.Content.ReadAsStringAsync();

		}
	}
}