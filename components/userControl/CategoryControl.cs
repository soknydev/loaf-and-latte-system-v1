﻿using bakery_management_system.components.userControl.admin;
using bakery_management_system.Controllers;
using bakery_management_system.Views.admin;

namespace bakery_management_system.components.userControl
{
    public partial class CategoryControl : UserControl
    {
        private readonly CategoryController _categoryController;

        public CategoryControl()
        {
            InitializeComponent();
            _categoryController = new CategoryController();
        }

        public void LoadCategory(int categoryId, string categoryName)
        {
            // Set category label
            lblCategoryName.Text = categoryName;

            // Clear existing products in the FlowLayoutPanel
            flowLayoutPanelProducts.Controls.Clear();

            // Fetch products for the category
            var products = _categoryController.GetProductsByCategory(categoryId);

            // Add product controls dynamically
            foreach (var product in products)
            {
                var productControl = new ProductAdminControl();
                productControl.SetProduct(product); // Set product details dynamically
                flowLayoutPanelProducts.Controls.Add(productControl);
            }
        }

        private void lblCategoryName_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelProducts_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
