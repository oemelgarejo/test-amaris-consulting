using System;
namespace AmarisConsulting.Application.Dtos
{
	public class EmployeeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public decimal AnnualSalary { get; set; }
    }
}

