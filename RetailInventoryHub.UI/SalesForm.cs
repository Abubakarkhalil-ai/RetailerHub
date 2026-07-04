using System;
using System.Windows.Forms;

namespace RetailInventoryHub.UI
{
    public partial class SalesForm : Form
    {
        private TextBox txtSaleId;
        private TextBox txtProductId;
        private TextBox txtQty;
        private TextBox txtPrice;
        private TextBox txtTotal;

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;

        private DataGridView dgv;

        public SalesForm()
        {
            InitializeComponent();

            txtSaleId = new TextBox();
            txtProductId = new TextBox();
            txtQty = new TextBox();
            txtPrice = new TextBox();
            txtTotal = new TextBox();

            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            dgv = new DataGridView();

            dgv.Columns.Add("SaleId", "Sale Id");
            dgv.Columns.Add("ProductId", "Product Id");
            dgv.Columns.Add("Quantity", "Quantity");
            dgv.Columns.Add("Price", "Price");
            dgv.Columns.Add("Total", "Total");

            txtSaleId.SetBounds(20, 20, 200, 30);
            txtProductId.SetBounds(20, 60, 200, 30);
            txtQty.SetBounds(20, 100, 200, 30);
            txtPrice.SetBounds(20, 140, 200, 30);
            txtTotal.SetBounds(20, 180, 200, 30);

            btnAdd.Text = "Record Sale";
            btnUpdate.Text = "Update";
            btnDelete.Text = "Delete";

         

            btnAdd.SetBounds(20, 240, 200, 35);
            btnUpdate.SetBounds(20, 285, 200, 35);
            btnDelete.SetBounds(20, 330, 200, 35);

            dgv.SetBounds(260, 20, 500, 400);

            dgv.SetBounds(260, 20, 500, 350);

            Controls.Add(txtSaleId);
            Controls.Add(txtProductId);
            Controls.Add(txtQty);
            Controls.Add(txtPrice);
            Controls.Add(txtTotal);


            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);

            Controls.Add(dgv);

            Text = "Sales";
            Width = 800;
            Height = 450;

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dgv.CellClick += Dgv_CellClick;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            decimal price = decimal.Parse(txtPrice.Text);
            int qty = int.Parse(txtQty.Text);

            decimal total = price * qty;

            txtTotal.Text = total.ToString();

            dgv.Rows.Add(
                txtSaleId.Text,
                txtProductId.Text,
                txtQty.Text,
                txtPrice.Text,
                txtTotal.Text
            );

            MessageBox.Show("Sale recorded.");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow != null)
            {
                dgv.CurrentRow.Cells[0].Value = txtSaleId.Text;
                dgv.CurrentRow.Cells[1].Value = txtProductId.Text;
                dgv.CurrentRow.Cells[2].Value = txtQty.Text;
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
                txtSaleId.Text =
                    dgv.Rows[e.RowIndex].Cells[0].Value?.ToString();

                txtProductId.Text =
                    dgv.Rows[e.RowIndex].Cells[1].Value?.ToString();

                txtQty.Text =
                    dgv.Rows[e.RowIndex].Cells[2].Value?.ToString();
            }
        }
    }
}