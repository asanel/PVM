using System.ComponentModel.DataAnnotations;

namespace PVM.Models
{
	public class Address
	{
		public int ZipCode { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string Region { get; set; }
		[Key]
		public int Id { get; set; }
		public string HouseNumber { get; set; }
		public string Country { get; set; }

	}
}
