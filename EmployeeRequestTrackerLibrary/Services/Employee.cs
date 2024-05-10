/*
 * Author: Sakthi Santhosh
 * Created on: 10/05/2024
 */
using EmployeeRequestTrackerLibrary.Models;
using EmployeeRequestTrackerLibrary.Repositories;

namespace EmployeeRequestTrackerLibrary.Services;

public interface IEmployeeLogin
{
    public bool Login(Employee employee);
    public Employee Register(Employee employee);
}

public class EmployeeLogin : IEmployeeLogin
{
    private readonly IRepository<int, Employee> _repository;

    public EmployeeLogin(IRepository<int, Employee> repository)
    {
        _repository = repository;
    }

    public bool Login(Employee employee)
    {
        var existingEmployee = _repository.Get(employee.EmployeeId);

        return existingEmployee != null
            && existingEmployee.Password == employee.Password;
    }

    public Employee Register(Employee employee)
    {
        return _repository.Add(employee);
    }
}
