namespace PVM.Shared.ViewModels
{
	public class RegisterViewModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Lastname { get; set; }
		public string Firstname { get; set; }
		public string TaxId { get; set; }
		public string Position { get; set; }
		public string MaritalStatus { get; set; }
		public DateOnly DateOfBirth { get; set; }
		public int ZipCode { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string Region { get; set; }
		public string HouseNumber { get; set; }
		public string Country { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public int DepartmentId { get; set; }
		public bool IsManager { get; set; }
		public bool IsAdmin { get; set; }
	}
}
