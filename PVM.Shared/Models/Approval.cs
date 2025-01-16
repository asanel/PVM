namespace PVM.Models
{
	public class Approval
	{
		//public Approval(Manager approver, Employee creator)
		//{
		//	this.Approver = approver;
		//          this.Creator = creator;
		//}
		public int Id { get; set; }
		public string Comment { get; set; }
		public Manager Approver { get; private set; }
		public string Type { get; set; }
		public Employee Creator { get; private set; }
		public string Status { get; set; }
	}
}
