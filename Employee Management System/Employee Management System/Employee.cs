using System;

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public decimal Salary { get; set; }
    public string Password { get; set; } 

    public Employee(int id, string name, string role, decimal salary, string password)
    {
        ID = id;
        Name = name;
        Role = role;
        Salary = salary;
        Password = password;
    }
}
