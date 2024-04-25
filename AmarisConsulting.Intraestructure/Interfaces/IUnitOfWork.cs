using System;
namespace AmarisConsulting.Intraestructure.Interfaces
{
	public interface IUnitOfWork: IDisposable
	{
		IEmployeeRepository Employee { get; }
	}
}

