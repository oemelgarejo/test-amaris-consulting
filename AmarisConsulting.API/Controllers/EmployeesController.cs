using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AmarisConsulting.Intraestructure.Interfaces;
using AmarisConsulting.Domain.Entities;
using AmarisConsulting.Application.Interfaces;

namespace AmarisConsulting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeApplication _employeeApplication;

        public EmployeesController(IEmployeeApplication employeeApplication)
        {
            _employeeApplication = employeeApplication;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeApplication.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeApplication.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
