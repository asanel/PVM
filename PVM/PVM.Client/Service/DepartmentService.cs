using Newtonsoft.Json;
using PVM.Client.Service.Repository;
using PVM.Models;
using System.Net.Http.Json;

namespace PVM.Client.Service
{
	public class DepartmentService : IDepartmentRepository
	{
		private HttpClient httpClient;
		public DepartmentService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		public async Task<Department> AddDepartmentAsync(Department department)
		{
			var response = await httpClient.PostAsJsonAsync("api/Department/Add-Department", department);
			var result = await response.Content.ReadFromJsonAsync<Department>();
			return result;
		}

		public async Task<List<Department>> GetAllDepartmentsAsync()
		{
			var response = await httpClient.GetFromJsonAsync<List<Department>>("api/Department/All-Departments");
			return response;

		}
	}
}
