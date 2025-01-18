using PVM.Models;
using PVM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVM.Shared.DTOs
{
	public class AbsenceEntryDto
	{
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Type { get; set; }
		public string Status { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
