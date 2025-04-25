using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        EmployeeManagement management = new EmployeeManagement();
        bool isAuthenticated = false;
        string username = "";

        AddInitialEmployees(management);

        Console.WriteLine("Welcome to the Employee Management System");

        while (!isAuthenticated)
        {
            Console.Write("Username: ");
            username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            isAuthenticated = management.Login(username, password);

            if (!isAuthenticated)
            {
                Console.WriteLine("Invalid login credentials. Try again.");
            }
        }

        if (username.ToLower() == "admin")
        {
            AdminMenu(management);
        }
        else
        {
            EmployeeMenu(management, username); 
        }
    }

    static void AddInitialEmployees(EmployeeManagement management)
    {
        management.AddEmployee(new Employee(1, "Ashi", "Developer", 90000, "ashi123"));
        management.AddEmployee(new Employee(2, "Priya", "HR", 55000, "priya123"));
        management.AddEmployee(new Employee(3, "Shri", "Manager", 75000, "shri123"));
        management.AddEmployee(new Employee(4, "Bharkavi", "Developer", 62000, "bharkavi123"));
        management.AddEmployee(new Employee(5, "Harini", "Developer", 50000, "harini123"));
    }

    static void AdminMenu(EmployeeManagement management)
    {
        while (true)
        {
            Console.WriteLine("\nAdmin Menu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Remove Employee");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Display All Employees");
            Console.WriteLine("5. Calculate Total Salaries");
            Console.WriteLine("6. Sort Employees by Salary");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        AddEmployee(management);
                        break;

                    case 2:
                        RemoveEmployee(management);
                        break;

                    case 3:
                        SearchEmployee(management);
                        break;

                    case 4:
                        management.DisplayAllEmployees();
                        break;

                    case 5:
                        decimal totalSalaries = management.CalculateTotalSalaries();
                        Console.WriteLine($"Total Salary Expense: Rs:{totalSalaries}");
                        break;

                    case 6:
                        SortEmployeesBySalary(management);
                        break;

                    case 7:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void EmployeeMenu(EmployeeManagement management, string username)
    {
        while (true)
        {
            Console.WriteLine("\nEmployee Menu:");
            Console.WriteLine("1. View My Details");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        var employee = management.SearchEmployee(username);
                        Console.WriteLine($"Employee Details: {employee.Name}, Role: {employee.Role}, Salary:Rs: {employee.Salary}");
                        break;

                    case 2:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void AddEmployee(EmployeeManagement management)
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Employee Role: ");
        string role = Console.ReadLine();
        Console.Write("Enter Employee Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());
        Console.Write("Enter Employee Password: ");
        string password = Console.ReadLine();

        Employee employee = new Employee(id, name, role, salary, password);
        management.AddEmployee(employee);
        Console.WriteLine("Employee added successfully.");
    }

    static void RemoveEmployee(EmployeeManagement management)
    {
        Console.Write("Enter Employee ID to remove: ");
        int removeId = int.Parse(Console.ReadLine());
        management.RemoveEmployee(removeId);
        Console.WriteLine("Employee removed successfully.");
    }

    static void SearchEmployee(EmployeeManagement management)
    {
        Console.Write("Enter Employee Name to search: ");
        string searchName = Console.ReadLine();
        Employee foundEmployee = management.SearchEmployee(searchName);
        Console.WriteLine($"Employee found: {foundEmployee.Name}, Role: {foundEmployee.Role}, Salary: Rs:{foundEmployee.Salary}");
    }

    static void SortEmployeesBySalary(EmployeeManagement management)
    {
        Console.Write("Sort by ascending (y/n): ");
        bool ascending = Console.ReadLine().ToLower() == "y";
        management.SortEmployeesBySalary(ascending);
    }
}
