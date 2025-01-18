using PVM.Models;
using PVM.Shared.DTOs;

namespace PVM.Client.Service.Repository
{
	public interface IEntryRepository
	{
		Task<AbsenceEntry> AddAbsenceEntryAsync(AbsenceEntry entry);
		Task<AbsenceEntry> ReviewAbsenceEntryAsync(int entryId, ApproveDto approveDto);
		Task<List<AbsenceEntry>> GetAllAbsenceEntriesAsync();
		Task<List<AbsenceEntry>> GetAllAbsenceEntriesByEmployeeIdAsync(int employeeId);
		Task<List<AbsenceEntry>> GetAllAbsenceEntriesByManagerIdAsync(int managerId);
	}
}
