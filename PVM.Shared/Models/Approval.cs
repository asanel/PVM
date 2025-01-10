using PVM.Models;

namespace PVM.Models
{
    public class Approval
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public Employee Approver { get; set; }
        public string Type { get; set; }
        public Employee Creator { get; set; }
        public string Status { get; set; }
        public int ObjectID { get; set; }
    }
}
