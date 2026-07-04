using System;
using System.Linq;
using System.Windows.Forms;
using RetailInventoryHub.Data;

namespace RetailInventoryHub.UI
{
    public partial class ProductForm : Form
    {
        private TextBox txtId;
        private TextBox txtBarcode;
        private TextBox txtTitle;
        private TextBox txtPrice;
        private TextBox txtQty;

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;
        private Button btnBinary;

        private DataGridView dgv;

        public ProductForm()
        {
            InitializeComponent();

            this.Text = "Products";
            this.Width = 950;
            this.Height = 550;
            this.StartPosition = FormStartPosition.CenterScreen;

            txtId = new TextBox();
            txtBarcode = new TextBox();
            txtTitle = new TextBox();
            txtPrice = new TextBox();
            txtQty = new TextBox();

            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            btnBinary = new Button();

            dgv = new DataGridView();

            txtId.SetBounds(20, 20, 200, 30);
            txtBarcode.SetBounds(20, 60, 200, 30);
            txtTitle.SetBounds(20, 100, 200, 30);
            txtPrice.SetBounds(20, 140, 200, 30);
            txtQty.SetBounds(20, 180, 200, 30);

            btnAdd.Text = "Add";
            btnUpdate.Text = "Update";
            btnDelete.Text = "Delete";
            btnSearch.Text = "Search By ID";
            btnBinary.Text = "Search By Barcode";

            btnAdd.SetBounds(20, 240, 200, 35);
            btnUpdate.SetBounds(20, 285, 200, 35);
            btnDelete.SetBounds(20, 330, 200, 35);
            btnSearch.SetBounds(20, 375, 200, 35);
            btnBinary.SetBounds(20, 420, 200, 35);

            dgv.SetBounds(260, 20, 650, 450);
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            Controls.Add(txtId);
            Controls.Add(txtBarcode);
            Controls.Add(txtTitle);
            Controls.Add(txtPrice);
            Controls.Add(txtQty);

            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);
            Controls.Add(btnBinary);

            Controls.Add(dgv);
            using (var db = new RetailDbContext())
            {
                MessageBox.Show(db.Database.Connection.ConnectionString);
            }
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;
            btnBinary.Click += BtnBinary_Click;

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            using (var db = new RetailDbContext())
            {
                dgv.DataSource = null;
                dgv.DataSource = db.Products.ToList();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new RetailDbContext())
                {
                    Product p = new Product
                    {
                        Barcode = txtBarcode.Text,
                        Title = txtTitle.Text,
                        Price = decimal.Parse(txtPrice.Text),
                        QuantityInStock = int.Parse(txtQty.Text),

                        // Use existing records
                

                    };

                    db.Products.Add(p);
                    db.SaveChanges();
                }

                RefreshGrid();
                MessageBox.Show("Product saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.InnerException?.InnerException?.Message
                    ?? ex.ToString());
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                using (var db = new RetailDbContext())
                {
                    var p = db.Products.Find(id);

                    if (p == null)
                    {
                        MessageBox.Show("Product not found.");
                        return;
                    }

                    p.Barcode = txtBarcode.Text;
                    p.Title = txtTitle.Text;
                    p.Price = decimal.Parse(txtPrice.Text);
                    p.QuantityInStock = int.Parse(txtQty.Text);
              


                    db.SaveChanges();
                }

                RefreshGrid();
                MessageBox.Show("Updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.InnerException?.InnerException?.Message
                    ?? ex.ToString());
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Enter Product ID.");
                    return;
                }

                int id = int.Parse(txtId.Text);

                using (var db = new RetailDbContext())
                {
                    var p = db.Products.Find(id);

                    if (p != null)
                    {
                        db.Products.Remove(p);
                        db.SaveChanges();
                    }
                }

                RefreshGrid();
                MessageBox.Show("Product deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.InnerException?.InnerException?.Message
                    ?? ex.ToString());
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Enter Product ID.");
                    return;
                }

                int id = int.Parse(txtId.Text);

                using (var db = new RetailDbContext())
                {
                    var p = db.Products.Find(id);

                    if (p != null)
                    {
                        txtBarcode.Text = p.Barcode;
                        txtTitle.Text = p.Title;
                        txtPrice.Text = p.Price.ToString();
                        txtQty.Text = p.QuantityInStock.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.InnerException?.InnerException?.Message
                    ?? ex.ToString());
            }
        }

        private void BtnBinary_Click(object sender, EventArgs e)
        {
            try
            {
                string barcode = txtBarcode.Text;

                using (var db = new RetailDbContext())
                {
                    var p = db.Products
                              .FirstOrDefault(x => x.Barcode == barcode);

                    if (p != null)
                    {
                        txtId.Text = p.ProductId.ToString();
                        txtTitle.Text = p.Title;
                        txtPrice.Text = p.Price.ToString();
                        txtQty.Text = p.QuantityInStock.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.InnerException?.InnerException?.Message
                    ?? ex.ToString());
            }
        }
    }
}