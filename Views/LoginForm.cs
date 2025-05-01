﻿using bakery_management_system.Controllers;
using bakery_management_system.Models;
using bakery_management_system.Utils;
using bakery_management_system.Views.admin;

namespace bakery_management_system.Views
{
    public partial class LoginForm : Form
    {
        private EmployeeController employeeController;
        public LoginForm()
        {
            InitializeComponent();
            employeeController = new EmployeeController();
            // Make the form full screen
            this.WindowState = FormWindowState.Maximized; // Maximized state
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Employee employee = employeeController.Login(username, password);
            if (employee != null)
            {
                MessageBox.Show("Login successful! Welcome, " + employee.Name);

                // Store the logged-in user in the session
                UserSession.CurrentUser = employee;

                // Navigate based on the user's role
                Form dashboardForm;
                if (employee.Role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    dashboardForm = new DashboardAdminForm();
                }
                else
                {
                    dashboardForm = new DashboardForm();
                }

                dashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonComponent11_Click(object sender, EventArgs e)
        {
            this.Hide();

            RegisterForm registerForm = new RegisterForm();
            registerForm.FormClosed += (s, args) => this.Show();

            registerForm.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
