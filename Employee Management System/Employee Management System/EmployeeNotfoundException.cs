﻿using System;

public class EmployeeNotFoundException : Exception
{
    public EmployeeNotFoundException(string message) : base(message)
    {
    }
}
