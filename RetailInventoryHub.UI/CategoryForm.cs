using System;
using System.Windows.Forms;

namespace RetailInventoryHub.UI
{
    public partial class CategoryForm : Form
    {
        private TextBox txtId;
        private TextBox txtName;

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;

        private DataGridView dgv;

        public CategoryForm()
        {
            InitializeComponent();

            txtId = new TextBox();
            txtName = new TextBox();

            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            dgv = new DataGridView();

            dgv.Columns.Add("Id", "Id");
            dgv.Columns.Add("Name", "Name");

            txtId.SetBounds(20, 20, 200, 30);
            txtName.SetBounds(20, 60, 200, 30);

            btnAdd.Text = "Add";
            btnUpdate.Text = "Update";
            btnDelete.Text = "Delete";

            btnAdd.SetBounds(20, 120, 200, 35);
            btnUpdate.SetBounds(20, 165, 200, 35);
            btnDelete.SetBounds(20, 210, 200, 35);

            dgv.SetBounds(260, 20, 500, 350);

            Controls.Add(txtId);
            Controls.Add(txtName);

            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);

            Controls.Add(dgv);

            Text = "Categories";
            Width = 800;
            Height = 450;

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dgv.CellClick += Dgv_CellClick;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dgv.Rows.Add(
                txtId.Text,
                txtName.Text
            );
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow != null)
            {
                dgv.CurrentRow.Cells[0].Value = txtId.Text;
                dgv.CurrentRow.Cells[1].Value = txtName.Text;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow != null)
            {
                dgv.Rows.Remove(dgv.CurrentRow);
            }
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text =
                    dgv.Rows[e.RowIndex].Cells[0].Value?.ToString();

                txtName.Text =
                    dgv.Rows[e.RowIndex].Cells[1].Value?.ToString();
            }
        }
    }
}