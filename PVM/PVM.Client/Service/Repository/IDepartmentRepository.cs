using PVM.Models;

namespace PVM.Client.Service.Repository
{
	public interface IDepartmentRepository
	{
		Task<List<Department>> GetAllDepartmentsAsync();
		Task<Department> AddDepartmentAsync(Department department);
	}
}
