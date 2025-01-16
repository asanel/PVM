using PVM.Models;

namespace PVM.Client.Service.Repository
{
	public interface IAccountRepository
	{
		Task<Address> AddAddressAsync(Address address);
		Task<Employee> AddEmployeeAsync(Employee employee);
		Task<Employee> GetEmployeeByIdAsync(int id);
		Task<Employee> UpdateEmployeeAsync(Employee employee);
		Task<List<Employee>> GetAllEmployeesAsync();
		Task<Address> UpdateAddressAsync(Address address);
		Task<Employee> GetEmployeeByUserIdAsync(string userId);
	}

}
