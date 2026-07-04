namespace RetailInventoryHub.UI
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Products
            this.btnProducts.Location =
                new System.Drawing.Point(50, 50);

            this.btnProducts.Size =
                new System.Drawing.Size(180, 50);

            this.btnProducts.Text =
                "Products";

            this.btnProducts.Click +=
                new System.EventHandler(
                    this.btnProducts_Click);

            // Exit
            this.btnExit.Location =
                new System.Drawing.Point(50, 120);

            this.btnExit.Size =
                new System.Drawing.Size(180, 50);

            this.btnExit.Text =
                "Exit";

            this.btnExit.Click +=
                new System.EventHandler(
                    this.btnExit_Click);

            // Dashboard
            this.ClientSize =
                new System.Drawing.Size(300, 250);

            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnExit);

            this.Name = "DashboardForm";
            this.Text = "Retail Inventory Hub";

            this.ResumeLayout(false);
        }
    }
}