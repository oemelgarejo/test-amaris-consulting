using System;
using AmarisConsulting.Application.Dtos;
using AmarisConsulting.Domain.Entities;
using AutoMapper;

namespace AmarisConsulting.Application.Mappers
{
	public class EmployeeProfile: Profile
	{
		public EmployeeProfile()
		{
			CreateMap<EmployeeDto, Employee>().ReverseMap();
		}
	}
}

