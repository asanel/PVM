using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PVM.Client.Service.Repository;
using PVM.Models;
using PVM.Shared.DTOs;

namespace PVM.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class EntryController : ControllerBase
	{
		private readonly IEntryRepository entryRepository;
		public EntryController(IEntryRepository entryRepository)
		{
			this.entryRepository = entryRepository;
		}

		[HttpPost("Add-AbsenceEntry")]
		public async Task<ActionResult<AbsenceEntry>> AddAbsenceEntryAsync(AbsenceEntry entry)
		{
			var response = await entryRepository.AddAbsenceEntryAsync(entry);
			
			return Ok(response);
		}
		[HttpPost("Review-AbsenceEntry/{entryId}")]
		public async Task<ActionResult<AbsenceEntry>> ReviewAbsenceEntryAsync(int entryId, ApproveDto approveDto)
		{
			var response = await entryRepository.ReviewAbsenceEntryAsync(entryId, approveDto);
			return Ok(response);
		}
		[HttpGet("Get-All-AbsenceEntries")]
		public async Task<ActionResult<List<AbsenceEntry>>> GetAllAbsenceEntriesAsync()
		{
			var response = await entryRepository.GetAllAbsenceEntriesAsync();
			return Ok(response);
		}
		[HttpGet("Get-All-AbsenceEntriesByEmployee{employeeId}")]
		public async Task<ActionResult<List<AbsenceEntry>>> GetAllAbsenceEntrieByEmployeeIdAsync(int employeeId)
		{
			var response = await entryRepository.GetAllAbsenceEntriesByEmployeeIdAsync(employeeId);
			return Ok(response);
		}
		[HttpGet("Get-All-AbsenceEntriesByManager{managerId}")]
		public async Task<ActionResult<List<AbsenceEntry>>> GetAllAbsenceEntriesByManagerIdAsync(int managerId)
		{
			var response = await entryRepository.GetAllAbsenceEntriesByManagerIdAsync(managerId);
			return Ok(response);
		}
	}
}
