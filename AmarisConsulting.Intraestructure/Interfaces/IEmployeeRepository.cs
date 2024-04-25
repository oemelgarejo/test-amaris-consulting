using System;
using AmarisConsulting.Domain.Entities;

namespace AmarisConsulting.Intraestructure.Interfaces
{
	public interface IEmployeeRepository
	{
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
    }
}

