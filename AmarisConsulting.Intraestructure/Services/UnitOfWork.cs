using System;
using AmarisConsulting.Intraestructure.Interfaces;

namespace AmarisConsulting.Intraestructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HttpClient _httpClient;
        public IEmployeeRepository Employee {get; private set;}

        public UnitOfWork(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Employee = new EmployeeRepository(_httpClient);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}

