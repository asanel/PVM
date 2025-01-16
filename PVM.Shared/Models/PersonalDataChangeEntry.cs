using PVM.Models;
using PVM.Models.Enums;

namespace PVM.Shared.Models
{
	internal class PersonalDataChangeEntry
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }
		public int ManagerId { get; set; }
		public Manager Manager { get; set; }

		public StatusEnums Status { get; set; }
		public DateTime CreationDate { get; set; }

	}
}
