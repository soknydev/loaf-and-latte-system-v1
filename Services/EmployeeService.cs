﻿using bakery_management_system.Models;
using bakery_management_system.Utils;
using Npgsql;
using System;
using System.Collections.Generic;

namespace bakery_management_system.Services
{
    public class EmployeeService
    {
        // delete employee
        public bool DeleteEmployee(int employeeId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Employees WHERE employee_id = @employee_id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);
                    return cmd.ExecuteNonQuery() > 0; // Returns true if at least one row was deleted
                }
            }
        }

        // update employee
        public bool UpdateEmployee(Employee employee)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE Employees 
                    SET name = @Name, 
                        username = @Username, 
                        password = @Password, 
                        role = @Role, 
                        email = @Email, 
                        phone = @Phone, 
                        salary = @Salary, 
                        hire_date = @HireDate, 
                        image_path = @ImagePath 
                    WHERE employee_id = @EmployeeId";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    // Add parameters for all fields
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Username", employee.Username);
                    command.Parameters.AddWithValue("@Password", employee.Password); // Ensure password is hashed before saving
                    command.Parameters.AddWithValue("@Role", employee.Role);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    command.Parameters.AddWithValue("@ImagePath", employee.ImagePath);
                    command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);

                    // Execute the query and return true if rows were affected
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // get all employee
        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Employees";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                EmployeeId = Convert.ToInt32(reader["employee_id"]),
                                Name = reader["name"].ToString(),
                                Role = reader["role"].ToString(),
                                Email = reader["email"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Salary = Convert.ToDecimal(reader["salary"]),
                                HireDate = Convert.ToDateTime(reader["hire_date"]),
                                Username = reader["username"].ToString(),
                                ImagePath = reader["image_path"].ToString()
                            });
                        }
                    }
                }
            }

            return employees;
        }

        // handle user login
        public Employee AuthenticateUser(string username, string password)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Employees WHERE username = @username AND password = @password";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Employee
                            {
                                EmployeeId = Convert.ToInt32(reader["employee_id"]),
                                Name = reader["name"].ToString(),
                                Role = reader["role"].ToString(),
                                Email = reader["email"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Salary = Convert.ToDecimal(reader["salary"]),
                                HireDate = Convert.ToDateTime(reader["hire_date"]),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                ImagePath = reader["image_path"].ToString()
                            };
                        }
                    }
                }
            }
            return null; // Return null if login fails
        }

        // handle user register new account
        public bool AddEmployee(Employee employee)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = @"
                    INSERT INTO Employees (name, role, email, phone, salary, hire_date, username, password, image_path) 
                    VALUES (@Name, @Role, @Email, @Phone, @Salary, @HireDate, @Username, @Password, @ImagePath)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Role", employee.Role);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    command.Parameters.AddWithValue("@Username", employee.Username);
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    command.Parameters.AddWithValue("@ImagePath", employee.ImagePath);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
