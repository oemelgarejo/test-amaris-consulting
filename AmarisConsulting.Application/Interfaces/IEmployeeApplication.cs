using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmarisConsulting.Application.Dtos;

namespace AmarisConsulting.Application.Interfaces
{
	public interface IEmployeeApplication
	{
        Task<List<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployeeById(int id);
    }
}

