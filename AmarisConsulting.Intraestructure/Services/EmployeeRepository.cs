using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using AmarisConsulting.Domain.Entities;
using AmarisConsulting.Intraestructure.Common;
using AmarisConsulting.Intraestructure.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AmarisConsulting.Intraestructure.Services
{
	public class EmployeeRepository: IEmployeeRepository
	{
        private readonly HttpClient _httpClient;

		public EmployeeRepository(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                var api = await _httpClient.GetAsync($"http://dummy.restapiexample.com/api/v1/employee/{id}");
                if (api.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    throw new Exception("Demasiadas petaciones a la API");
                }
                api.EnsureSuccessStatusCode();
                var json = await api.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<dynamic>>(json);
                if (apiResponse != null)
                {
                    if (apiResponse.Data != null)
                    {
                        var employeeObject = apiResponse.Data as JObject;
                        if (employeeObject != null)
                        {
                            return ConvertJObjectToEmployee(employeeObject);
                        }
                    }
                }

                return null;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al obtener el empleado ID {id}", ex);
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                var response = new List<Employee>();
                var api = await _httpClient.GetAsync("http://dummy.restapiexample.com/api/v1/employees");
                if (api.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    throw new Exception("Demasiadas petaciones a la API");
                }
                api.EnsureSuccessStatusCode();
                var json = await api.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<dynamic>>>(json);
                if (apiResponse != null && apiResponse.Data != null)
                {
                    var employees = apiResponse.Data.Select(employee =>
                    {
                        var employeeObject = employee as JObject;
                        if (employeeObject != null)
                        {
                            return ConvertJObjectToEmployee(employeeObject);
                        }
                        return null;
                    })?.Where(employee => employee != null).ToList();

                    return employees;
                }
                return new List<Employee>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener la lista de empleados", ex);
            }
        }

        private Employee ConvertJObjectToEmployee(JObject employeeObject)
        {
            try
            {
                var _employee = new Employee
                {
                    Id = (int)employeeObject["id"],
                    Name = (string)employeeObject["employee_name"],
                    Salary = (decimal)employeeObject["employee_salary"],
                    AnnualSalary = (decimal)employeeObject["employee_salary"] * 12

                };
                return _employee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al convertir el JObject a empleado", ex);
            }
        }
    }
}

