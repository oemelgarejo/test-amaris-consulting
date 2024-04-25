using System;
using AmarisConsulting.Intraestructure.Interfaces;
using AmarisConsulting.Intraestructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AmarisConsulting.Intraestructure
{
	public static class InfraestructureServices
	{
		public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(configuration);
			services.AddTransient<IUnitOfWork, UnitOfWork>();
			return services;
		}
	}
}

