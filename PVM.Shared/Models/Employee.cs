
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PVM.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string TaxId { get; set; }
        public string Position {  get; set; }
        public string MaritalStatus { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string ApplicationUserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
		
	}
}
