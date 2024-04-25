using System;
using AmarisConsulting.Application.Dtos;
using AmarisConsulting.Application.Interfaces;
using AmarisConsulting.Domain.Entities;
using AmarisConsulting.Intraestructure.Interfaces;
using AutoMapper;

namespace AmarisConsulting.Application.Services
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            var employee = await _unitOfWork.Employee.GetEmployeeById(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var employees = await _unitOfWork.Employee.GetEmployees();
            return _mapper.Map<List<EmployeeDto>>(employees);
        }
    }
}

