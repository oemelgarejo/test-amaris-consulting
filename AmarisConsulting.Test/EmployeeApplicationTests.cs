using AmarisConsulting.Application.Dtos;
using AmarisConsulting.Application.Services;
using AmarisConsulting.Domain.Entities;
using AmarisConsulting.Intraestructure.Interfaces;
using AutoMapper;
using Moq;

namespace AmarisConsulting.Test;

[TestClass]
public class EmployeeApplicationTests
{
    [TestMethod]
    public async Task GetEmployeeByIdTest()
    {
        int employeeId = 1;
        var employee = new Employee { Id = employeeId, Name = "John Doe" };
        var _unitOfWorkMock = new Mock<IUnitOfWork>();
        _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Employee.GetEmployeeById(employeeId))
            .ReturnsAsync(employee);

        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(mapper => mapper.Map<EmployeeDto>(employee))
            .Returns(new EmployeeDto { Id = employee.Id, Name = employee.Name });

        var employeeApplication = new EmployeeApplication(_unitOfWorkMock.Object, mapperMock.Object);

        var result = await employeeApplication.GetEmployeeById(employeeId);

        Assert.IsNotNull(result);
        Assert.AreEqual(employeeId, result.Id);
        Assert.AreEqual(employee.Name, result.Name);
    }

    [TestMethod]
    public async Task GetEmployeesTest()
    {
        // Arrange
        var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe" },
                new Employee { Id = 2, Name = "Jane Smith" }
            };

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(uow => uow.Employee.GetEmployees())
            .ReturnsAsync(employees);

        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(mapper => mapper.Map<List<EmployeeDto>>(employees))
            .Returns(new List<EmployeeDto>
            {
                    new EmployeeDto { Id = 1, Name = "John Doe" },
                    new EmployeeDto { Id = 2, Name = "Jane Smith" }
            });

        var employeeApplication = new EmployeeApplication(unitOfWorkMock.Object, mapperMock.Object);

        // Act
        var result = await employeeApplication.GetEmployees();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(employees.Count, result.Count);
        for (int i = 0; i < employees.Count; i++)
        {
            Assert.AreEqual(employees[i].Id, result[i].Id);
            Assert.AreEqual(employees[i].Name, result[i].Name);
        }
    }

}
