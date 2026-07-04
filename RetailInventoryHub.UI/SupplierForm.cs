using System;
using System.Windows.Forms;

namespace RetailInventoryHub.UI
{
    public partial class SupplierForm : Form
    {
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtPhone;

        private Button btnAdd;

        private DataGridView dgv;

        public SupplierForm()
        {
            InitializeComponent();

            txtId = new TextBox();
            txtName = new TextBox();
            txtPhone = new TextBox();

            btnAdd = new Button();

            dgv = new DataGridView();

            // GRID COLUMNS
            dgv.Columns.Add("Id", "Id");
            dgv.Columns.Add("Name", "Name");
            dgv.Columns.Add("Phone", "Phone");

            txtId.SetBounds(20, 20, 200, 30);
            txtName.SetBounds(20, 60, 200, 30);
            txtPhone.SetBounds(20, 100, 200, 30);

            btnAdd.Text = "Add Supplier";
            btnAdd.SetBounds(20, 150, 200, 35);

            dgv.SetBounds(260, 20, 500, 350);

            Controls.Add(txtId);
            Controls.Add(txtName);
            Controls.Add(txtPhone);

            Controls.Add(btnAdd);
            Controls.Add(dgv);

            Text = "Suppliers";
            Width = 800;
            Height = 450;

            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dgv.Rows.Add(
                txtId.Text,
                txtName.Text,
                txtPhone.Text
            );

            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
        }
    }
}