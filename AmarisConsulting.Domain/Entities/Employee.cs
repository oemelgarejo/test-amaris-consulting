using System;
namespace AmarisConsulting.Domain.Entities
{
	public class Employee
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public decimal AnnualSalary { get; set; }
    }
}

