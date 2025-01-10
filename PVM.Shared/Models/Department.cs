using System.ComponentModel.DataAnnotations;

namespace PVM.Models
{
	public class Department
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Employee> Employees { get; set; }
		public Manager Manager { get; set; }
		//public int ManagerId { get; set; }
	}
}
