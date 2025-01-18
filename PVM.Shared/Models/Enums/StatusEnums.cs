using System.ComponentModel;

namespace PVM.Models.Enums
{
	public enum StatusEnums
	{
		[Description("Genehmigt")]
		Approved,
		[Description("Abgelehnt")]
		Rejected,
		[Description("Neu")]
		New,
		[Description("Bearbeitet")]
		Edited
	}
}
