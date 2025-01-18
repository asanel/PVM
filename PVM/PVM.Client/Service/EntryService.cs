using Newtonsoft.Json;
using PVM.Client.Service.Repository;
using PVM.Models;
using PVM.Shared.DTOs;
using System.Net.Http.Json;

namespace PVM.Client.Service
{
	public class EntryService : IEntryRepository
	{
		private HttpClient httpClient;

		public EntryService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		public async Task<AbsenceEntry> AddAbsenceEntryAsync(AbsenceEntry entry)
		{
			var response = await httpClient.PostAsJsonAsync("api/Entry/Add-AbsenceEntry", entry);
			var result = await response.Content.ReadFromJsonAsync<AbsenceEntry>();
			return result;
		}

		public async Task<List<AbsenceEntry>> GetAllAbsenceEntriesAsync()
		{
			var response = await httpClient.GetFromJsonAsync<List<AbsenceEntry>>("api/Entry/Get-All-AbsenceEntries");
			return response;
		}

		public async Task<List<AbsenceEntry>> GetAllAbsenceEntriesByEmployeeIdAsync(int employeeId)
		{
			var response = await httpClient.GetAsync($"api/Entry/Get-All-AbsenceEntries{employeeId}");
			var result = await response.Content.ReadFromJsonAsync<List<AbsenceEntry>>();
			return result;
		}

		public async Task<List<AbsenceEntry>> GetAllAbsenceEntriesByManagerIdAsync(int managerId)
		{
			var response = await httpClient.GetAsync($"api/Entry/Get-All-AbsenceEntries{managerId}");
			var result = await response.Content.ReadFromJsonAsync<List<AbsenceEntry>>();
			return result;
		}

		public async Task<AbsenceEntry> ReviewAbsenceEntryAsync(int entryId, ApproveDto approveDto)
		{
			var response = await httpClient.PostAsJsonAsync($"api/Entry/Review-AbsenceEntry/{entryId}", approveDto);
			var result = await response.Content.ReadFromJsonAsync<AbsenceEntry>();
			return result;
		}
	}
}
