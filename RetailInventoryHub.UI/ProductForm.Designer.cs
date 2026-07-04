namespace RetailInventoryHub.UI
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize =
                new System.Drawing.Size(
                    800,
                    450);

            this.Name =
                "ProductForm";

            this.Text =
                "Products";

            this.ResumeLayout(false);
        }
    }
}