//using PVManage.Enums;

namespace PVM.Models
{
    public class AbsenceEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Employee { get; set; }
        public Manager Manager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public AbsenceEntryTypeEnums Type { get; set; }
        public string Type { get; set; }
        //public StatusEnums Status { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public int Duration { get; set; }
    }
}
