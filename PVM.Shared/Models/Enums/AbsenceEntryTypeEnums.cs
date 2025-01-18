using System.ComponentModel;

namespace PVM.Models.Enums
{
	public enum AbsenceEntryTypeEnums
	{
		[Description("Urlaub")]
		Vacation,
		[Description("Krankmeldung")]
		SickNote,
		[Description("Andere")]
		Other
	}
}
