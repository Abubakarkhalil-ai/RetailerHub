using System;
using System.Windows.Forms;

namespace RetailInventoryHub.UI
{
    public partial class DashboardForm : Form
    {
        private Button btnSuppliers;
        private Button btnCategories;
        private Button btnSales;

        public DashboardForm()
        {
            InitializeComponent();

            // Increase form size
            this.Width = 320;
            this.Height = 420;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Move existing designer buttons
            btnProducts.SetBounds(50, 40, 180, 40);
            btnExit.SetBounds(50, 280, 180, 40);

            // Create additional buttons
            btnSuppliers = new Button();
            btnCategories = new Button();
            btnSales = new Button();

            btnSuppliers.Text = "Suppliers";
            btnCategories.Text = "Categories";
            btnSales.Text = "Sales";

            btnSuppliers.SetBounds(50, 100, 180, 40);
            btnCategories.SetBounds(50, 160, 180, 40);
            btnSales.SetBounds(50, 220, 180, 40);

            Controls.Add(btnSuppliers);
            Controls.Add(btnCategories);
            Controls.Add(btnSales);

            btnSuppliers.Click += BtnSuppliers_Click;
            btnCategories.Click += BtnCategories_Click;
            btnSales.Click += BtnSales_Click;
        }

        private void btnProducts_Click(
            object sender,
            EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.ShowDialog();
        }

        private void btnExit_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSuppliers_Click(
            object sender,
            EventArgs e)
        {
            SupplierForm frm = new SupplierForm();
            frm.ShowDialog();
        }

        private void BtnCategories_Click(
            object sender,
            EventArgs e)
        {
            CategoryForm frm = new CategoryForm();
            frm.ShowDialog();
        }

        private void BtnSales_Click(
            object sender,
            EventArgs e)
        {
            SalesForm frm = new SalesForm();
            frm.ShowDialog();
        }
    }
}