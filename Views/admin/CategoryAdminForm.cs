using bakery_management_system.components.userControl;
using bakery_management_system.Controllers;
using bakery_management_system.Utils;

namespace bakery_management_system.Views.admin
{
    public partial class CategoryAdminForm : Form
    {
        private readonly CategoryController _categoryController;
        private readonly ProductController _productController;

        public CategoryAdminForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            _categoryController = new CategoryController();
            _productController = new ProductController();
            LoadCategory();

            // Display user info.
            UserInfo();
        }

        private void LoadCategory()
        {
            try
            {
                // Fetch categories from the database
                var categories = _categoryController.GetCategories();

                // Check if categories are fetched correctly
                Console.WriteLine($"Categories Count: {categories.Count}"); // Debugging output
                if (categories.Count == 0)
                {
                    MessageBox.Show("No categories found in the system.", "Info");
                }

                // Dynamically add rows for each category
                foreach (var category in categories)
                {
                    var categoryControl = new CategoryControl();
                    categoryControl.LoadCategory(category.CategoryId, category.CategoryName);

                    // Make sure categoryControl is properly populated with data
                    Console.WriteLine($"Loading Category: {category.CategoryName}");

                    // Add to FlowLayoutPanel
                    //flowLayoutPanelCategories.Controls.Add(categoryControl);
                    //flowLayoutPanelCategories.Controls.Add(categoryControl);
                    flowLayoutPanelCategories.Controls.Add(categoryControl);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        private void UserInfo()
        {
            // Section: User Information Display
            if (UserSession.CurrentUser != null)
            {
                lblWelcome.Text = $"Hello, {UserSession.CurrentUser.Name}";

                // Check if the user has a profile picture
                if (!string.IsNullOrEmpty(UserSession.CurrentUser.ImagePath) && File.Exists(UserSession.CurrentUser.ImagePath))
                {
                    pbProfile.Image = Image.FromFile(UserSession.CurrentUser.ImagePath);
                }
                else
                {
                    // Default avatar if the user doesn't have a profile picture
                    pbProfile.Image = Properties.Resources.photo_2023_08_01_20_25_42;
                }
            }
            else
            {
                lblWelcome.Text = "Welcome, Guest!";
                pbProfile.Image = Properties.Resources.photo_2023_08_01_20_25_42;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                // Search products
                var filteredProducts = _productController.SearchProducts(keyword);

                // Search categories
                var filteredCategories = _categoryController.SearchCategories(keyword);

                // Clear existing controls
                flowLayoutPanelCategories.Controls.Clear();

                // Load filtered categories
                foreach (var category in filteredCategories)
                {
                    var categoryControl = new CategoryControl();
                    categoryControl.LoadCategory(category.CategoryId, category.CategoryName);
                    flowLayoutPanelCategories.Controls.Add(categoryControl);
                }

                // If no matching products or categories, show a message
                if (!filteredProducts.Any() && !filteredCategories.Any())
                {
                    MessageBox.Show("No matching products or categories found.", "Search Results");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}");
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            DashboardAdminForm dashboardAdminForm = new DashboardAdminForm();
            dashboardAdminForm.Show();
            this.Hide();
        }

        private void btnMyPayments_Click(object sender, EventArgs e)
        {
            PaymentAdminForm paymentAdminForm = new PaymentAdminForm();
            paymentAdminForm.Show();
            this.Hide();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerAdminForm customerAdminForm = new CustomerAdminForm();
            customerAdminForm.Show();
            this.Hide();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeeAdminForm employeeAdminForm = new EmployeeAdminForm();
            employeeAdminForm.Show();
            this.Hide();
        }

        private void btnMyOrders_Click_1(object sender, EventArgs e)
        {
            CartAdminForm cartAdminForm = new CartAdminForm(UserSession.CurrentUser.EmployeeId);
            cartAdminForm.Show();
            this.Hide();
        }

        private void logoutButton1_Click(object sender, EventArgs e)
        {
            // Confirm logout action
            var confirmLogout = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmLogout == DialogResult.Yes)
            {
                // Clear user session or any logged-in state
                UserSession.CurrentUser = null;

                // Navigate to the LoginForm
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Close the current form
                this.Close();
            }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            // Handle click on Categories button, if needed
        }

        private void flowLayoutPanelCategories_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Handle paint events if necessary
        }

        private void flowLayoutPanelCategories_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
