﻿using bakery_management_system.Models;
using bakery_management_system.Services;

namespace bakery_management_system.Controllers
{
    public class EmployeeController
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        public bool DeleteEmployee(int employeeId)
        {
            return _employeeService.DeleteEmployee(employeeId);
        }

        // update employee
        public bool UpdateEmployee(Employee employee)
        {
            return _employeeService.UpdateEmployee(employee);
        }


        // get all employees
        public List<Employee> GetEmployees()
        {
            return _employeeService.GetAllEmployees();
        }

        // handle user login
        public Employee Login(string username, string password)
        {
            return _employeeService.AuthenticateUser(username, password);
        }

        // handle user register new account
        public bool RegisterEmployee(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Name) || string.IsNullOrWhiteSpace(employee.Username) || string.IsNullOrWhiteSpace(employee.Password))
            {
                throw new ArgumentException("Name, Username, and Password are required.");
            }

            return _employeeService.AddEmployee(employee);
        }

    }
}
