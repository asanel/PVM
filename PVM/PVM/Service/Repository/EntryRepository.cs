using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PVM.Client.Service.Repository;
using PVM.Data;
using PVM.Models;
using PVM.Shared.DTOs;

namespace PVM.Service.Repository
{

	public class EntryRepository : IEntryRepository
	{
		private readonly ApplicationDbContext context;
		public EntryRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		public async Task<AbsenceEntry> AddAbsenceEntryAsync(AbsenceEntry absenceEntry)
		{
			if (absenceEntry == null) { return null; }
			var response = context.AbsenceEntries.Add(absenceEntry).Entity;
			await context.SaveChangesAsync();
			return response;
		}

		public async Task<List<AbsenceEntry>> GetAllAbsenceEntriesAsync()
		{
			var response = await this.context.AbsenceEntries.ToListAsync();
			return response;
		}

		public async Task<List<AbsenceEntry>> GetAllAbsenceEntriesByEmployeeIdAsync(int employeeId)
		{
			var response = await this.context.AbsenceEntries.Where<AbsenceEntry>(a => a.EmployeeId == employeeId).ToListAsync();
			return response;
		}

		public async Task<List<AbsenceEntry>> GetAllAbsenceEntriesByManagerIdAsync(int managerId)
		{
			var response = await this.context.AbsenceEntries.Where<AbsenceEntry>(a => a.ManagerId == managerId).ToListAsync();
			return response;
		}

		public async Task<AbsenceEntry> ReviewAbsenceEntryAsync(int entryId, ApproveDto approveDto)
		{
			var entryRequest = await context.AbsenceEntries
					.FirstOrDefaultAsync(lr => lr.Id == entryId);

			if (entryRequest == null)
			{
				Console.WriteLine("Abwesenheitantrag wurde nicht gefunden");
			}

			var manager = await context.Employees
				.Include(e => e.Department)
				.FirstOrDefaultAsync(e => e.Id == approveDto.ManagerId && e.IsManager == true);

			//if (manager == null || manager.DepartmentId != entryRequest.Employee.DepartmentId)
			//{
			//	Console.WriteLine("Sie sind nicht berechtigt, diesen Antrag zu überprüfen.");
			//}

			entryRequest.Status = approveDto.IsApproved ? "Genehmigt" : "Abgelehnt";
			context.AbsenceEntries.Update(entryRequest);
			await context.SaveChangesAsync();

			Console.WriteLine($"Abwesenheitantrag wurde {entryRequest.Status.ToLower()}");
			return entryRequest;
		}
	}
}
