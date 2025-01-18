using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVM.Shared.DTOs
{
	public class EmployeeDto
	{
		public int Id { get; set; }
		public string Lastname { get; set; }
		public string Firstname { get; set; }
		public string TaxId { get; set; }
		public string Position { get; set; }
		public string MaritalStatus { get; set; }
		public DateOnly DateOfBirth { get; set; }
		public int AddressId { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public int DepartmentId { get; set; }
		public bool IsManager { get; set; }

	}
}
