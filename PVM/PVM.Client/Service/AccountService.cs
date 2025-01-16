﻿using Newtonsoft.Json;
using PVM.Client.Service.Repository;
using PVM.Models;
using System.Net.Http.Json;

namespace PVM.Client.Service
{
	public class AccountService : IAccountRepository
	{
		private readonly HttpClient httpClient;


		public AccountService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<Address> AddAddressAsync(Address address)
		{

			var newAddress = await httpClient.PostAsJsonAsync("api/Account/Add-Address", address);
			//var response = await newAddress.Content.ReadFromJsonAsync<Address>();
			//return response;
			var json = await newAddress.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<Address>(json);
			return result;
		}

		public async Task<Employee> AddEmployeeAsync(Employee employee)
		{
			var newEmployee = await httpClient.PostAsJsonAsync("api/Account/Add-Employee", employee);
			var json = await newEmployee.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<Employee>(json);
			return result;
		}

		public async Task<Employee> GetEmployeeByIdAsync(int id)
		{
			
			var newEmployee = await httpClient.GetAsync("api/Account/Get-Single-Employee/{id}" + id);
			var json = await newEmployee.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<Employee>(json);
			return result;
		}

		public async Task<Employee> UpdateEmployeeAsync(Employee employee)
		{
			var newEmployee = await httpClient.PatchAsJsonAsync("api/Account/Update-Employee", employee);
			var json = await newEmployee.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<Employee>(json);
			return result;
		}

		public async Task<List<Employee>> GetAllEmployeesAsync()
		{
			var employyes = await httpClient.GetFromJsonAsync<List<Employee>>("api/Account/All-Employees");
			return employyes;
		}

		public async Task<Address> UpdateAddressAsync(Address address)
		{
			var newAddress = await httpClient.PatchAsJsonAsync("api/Account/Update-Address", address);
			var json = await newAddress.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<Address>(json);
			return result;
		}

		public async Task<Employee> GetEmployeeByUserIdAsync(string userId)
		{
			try
			{
				// Sende die GET-Anfrage und prüfe auf Erfolg
				var response = await httpClient.GetAsync($"api/Account/Get-Single-EmployeeByUserId");
				if (!response.IsSuccessStatusCode)
				{
					// Fehlerbehandlung bei nicht erfolgreichem Statuscode
					var errorContent = await response.Content.ReadAsStringAsync();
					throw new HttpRequestException($"Fehler beim Abrufen der Daten: {response.StatusCode}, Nachricht: {errorContent}");
				}

				// JSON in ein Employee-Objekt deserialisieren
				var employee = await response.Content.ReadFromJsonAsync<Employee>();
				return employee ?? throw new Exception("Employee-Daten sind leer.");
			}
			catch (HttpRequestException ex)
			{
				// Behandlung von HTTP-spezifischen Fehlern
				Console.WriteLine($"HTTP-Fehler: {ex.Message}");
				throw;
			}
			catch (Exception ex)
			{
				// Allgemeine Fehlerbehandlung
				Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
				throw;
			}
		}
	}
}
