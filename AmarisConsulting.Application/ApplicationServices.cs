using System.Reflection;
using AmarisConsulting.Application.Interfaces;
using AmarisConsulting.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmarisConsulting.Application
{
	public static class ApplicationServices
	{
		public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(configuration);
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddScoped<IEmployeeApplication, EmployeeApplication>();
			return services;
		}
	}
}

