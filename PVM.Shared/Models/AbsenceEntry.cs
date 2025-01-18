//using PVManage.Enums;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PVM.Models
{
	public class AbsenceEntry
	{
		[Key]
		public int Id { get; set; }
		public int EmployeeId { get; set;  }
		public int DepartmentId { get; set; }
		public int ManagerId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }		
		public string Type { get; set; }
		public string Status { get; set; }
		public DateTime CreationDate { get; set; }


	}
}
