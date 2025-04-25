using System;
using System.Collections.Generic;

public class EmployeeManagement
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        if (employees.Exists(e => e.ID == employee.ID))
        {
            throw new DuplicateEmployeeException("Employee with the same ID already exists.");
        }
        employees.Add(employee);
    }

    public void RemoveEmployee(int id)
    {
        var employee = employees.Find(e => e.ID == id);
        if (employee == null)
        {
            throw new EmployeeNotFoundException("Employee not found.");
        }
        employees.Remove(employee);
    }

    public Employee SearchEmployee(string name)
    {
        var employee = employees.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (employee == null)
        {
            throw new EmployeeNotFoundException("Employee not found.");
        }
        return employee;
    }

    public decimal CalculateTotalSalaries()
    {
        decimal total = 0;
        foreach (var employee in employees)
        {
            total += employee.Salary;
        }
        return total;
    }

    public void DisplayAllEmployees()
    {
        Console.WriteLine("Employee List:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"Name: {employee.Name}, Role: {employee.Role}, Salary: Rs:{employee.Salary}");
        }
    }

    public void SortEmployeesBySalary(bool ascending)
    {
        if (ascending)
        {
            employees.Sort((e1, e2) => e1.Salary.CompareTo(e2.Salary));
        }
        else
        {
            employees.Sort((e1, e2) => e2.Salary.CompareTo(e1.Salary));
        }
        Console.WriteLine("Employees sorted by salary.");
    }

    public bool Login(string username, string password)
    {
        if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "admin123")
        {
            return true;
        }

        var employee = employees.Find(e => e.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (employee != null && employee.Password == password)
        {
            return true;
        }

        return false;
    }
}
