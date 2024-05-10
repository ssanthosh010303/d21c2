/*
 * Author: Sakthi Santhosh
 * Created on: 10/05/2024
 */
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerLibrary.Repositories;

public class EmployeeRepository : IRepository<int, Employee>
{
    private readonly RequestTrackerContext _context;

    public EmployeeRepository(RequestTrackerContext context)
    {
        _context = context;
    }

    public Employee Add(Employee entity)
    {
        _context.Employees.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Employee Delete(int key)
    {
        var employee = Get(key);

        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        return employee;
    }

    public Employee Get(int key)
    {
        var employee = _context.Employees.FirstOrDefault(
            e => e.EmployeeId == key);

        return employee;
    }

    public IList<Employee> GetAll()
    {
        return _context.Employees.ToList();
    }

    public Employee Update(Employee entity)
    {
        var existingEmployee = Get(entity.EmployeeId);

        if (existingEmployee != null)
        {
            _context.Entry(existingEmployee).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        return existingEmployee;
    }
}
