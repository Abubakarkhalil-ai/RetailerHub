namespace RetailInventoryHub.UI
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new System.Drawing.Size(800, 450);
            Name = "SalesForm";
            Text = "Sales";
            ResumeLayout(false);
        }
    }
}