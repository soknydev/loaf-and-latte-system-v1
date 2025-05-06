namespace bakery_management_system.components.userControl.admin
{
    partial class ProductAdminControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductAdminControl));
            btnDelete = new PictureBox();
            btnUpdate = new PictureBox();
            ptImage = new PictureBox();
            lblProductName = new Label();
            btnAddToCart = new ButtonComponent1();
            lblProductPrice = new Label();
            labeltttt = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)btnDelete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnUpdate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptImage).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.trash;
            btnDelete.Location = new Point(279, 351);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(49, 37);
            btnDelete.SizeMode = PictureBoxSizeMode.Zoom;
            btnDelete.TabIndex = 15;
            btnDelete.TabStop = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Image = (Image)resources.GetObject("btnUpdate.Image");
            btnUpdate.Location = new Point(218, 352);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(49, 37);
            btnUpdate.SizeMode = PictureBoxSizeMode.Zoom;
            btnUpdate.TabIndex = 14;
            btnUpdate.TabStop = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ptImage
            // 
            ptImage.Image = Properties.Resources.bakery1;
            ptImage.Location = new Point(0, -10);
            ptImage.Name = "ptImage";
            ptImage.Size = new Size(346, 246);
            ptImage.SizeMode = PictureBoxSizeMode.Zoom;
            ptImage.TabIndex = 13;
            ptImage.TabStop = false;
            ptImage.Click += ptImage_Click;
            // 
            // lblProductName
            // 
            lblProductName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.ForeColor = Color.FromArgb(255, 101, 0);
            lblProductName.Location = new Point(45, 9);
            lblProductName.Margin = new Padding(10);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(63, 28);
            lblProductName.TabIndex = 11;
            lblProductName.Text = "label1";
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(255, 101, 0);
            btnAddToCart.BackgroundColor = Color.FromArgb(255, 101, 0);
            btnAddToCart.BorderColor = Color.PaleVioletRed;
            btnAddToCart.BorderRadius = 10;
            btnAddToCart.BorderSize = 0;
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI Semibold", 12F);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(18, 340);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Padding = new Padding(15, 8, 15, 8);
            btnAddToCart.Size = new Size(167, 52);
            btnAddToCart.TabIndex = 16;
            btnAddToCart.Text = "Add to cart";
            btnAddToCart.TextColor = Color.White;
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // lblProductPrice
            // 
            lblProductPrice.AutoSize = true;
            lblProductPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductPrice.ForeColor = Color.Blue;
            lblProductPrice.Location = new Point(131, 288);
            lblProductPrice.Name = "lblProductPrice";
            lblProductPrice.Size = new Size(54, 28);
            lblProductPrice.TabIndex = 17;
            lblProductPrice.Text = "Price";
            lblProductPrice.Click += label1_Click;
            // 
            // labeltttt
            // 
            labeltttt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labeltttt.AutoSize = true;
            labeltttt.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeltttt.ForeColor = Color.FromArgb(255, 101, 0);
            labeltttt.Location = new Point(131, 0);
            labeltttt.Margin = new Padding(10);
            labeltttt.Name = "labeltttt";
            labeltttt.Size = new Size(0, 28);
            labeltttt.TabIndex = 18;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblProductName);
            panel1.Location = new Point(3, 239);
            panel1.Name = "panel1";
            panel1.Size = new Size(337, 47);
            panel1.TabIndex = 19;
            // 
            // ProductAdminControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(panel1);
            Controls.Add(labeltttt);
            Controls.Add(lblProductPrice);
            Controls.Add(btnAddToCart);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(ptImage);
            Margin = new Padding(10);
            Name = "ProductAdminControl";
            Size = new Size(343, 416);
            Load += ProductAdminControl_Load;
            ((System.ComponentModel.ISupportInitialize)btnDelete).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnUpdate).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptImage).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox btnDelete;
        private PictureBox btnUpdate;
        private PictureBox ptImage;
        private Label lblProductPrice;
        private Label lblProductName;
        private ButtonComponent1 btnAddToCart;
        private Label labeltttt;
        private Panel panel1;
    }
}
