using System.Drawing;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    partial class inventory
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblInventoryTitle;
        private DataGridView dgvInventory;
        private Panel panelInventoryContainer;
        private Button btnExportData;
        private Button btnEdit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblInventoryTitle = new Label();
            this.panelInventoryContainer = new Panel();
            this.dgvInventory = new DataGridView();
            this.btnExportData = new Button();
            this.btnEdit = new Button();

            this.panelInventoryContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();

            // Inventory Title
            this.lblInventoryTitle.AutoSize = true;
            this.lblInventoryTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblInventoryTitle.ForeColor = Color.Black;
            this.lblInventoryTitle.Location = new Point(50, 20);
            this.lblInventoryTitle.Text = "Medical Supplies Inventory";

            // Inventory Container Panel - matches your image background
            this.panelInventoryContainer.BackColor = Color.FromArgb(209, 213, 219);
            this.panelInventoryContainer.Location = new Point(50, 80);
            this.panelInventoryContainer.Size = new Size(900, 450);
            this.panelInventoryContainer.Controls.Add(this.dgvInventory);

            // DataGridView for inventory - exactly like your image
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.BackgroundColor = Color.White;
            this.dgvInventory.BorderStyle = BorderStyle.FixedSingle;
            this.dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new Point(20, 20);
            this.dgvInventory.Size = new Size(860, 410);
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.dgvInventory.GridColor = Color.Black;

            // Export Data Button - matches your image
            this.btnExportData.BackColor = Color.FromArgb(37, 99, 235);
            this.btnExportData.FlatStyle = FlatStyle.Flat;
            this.btnExportData.FlatAppearance.BorderSize = 0;
            this.btnExportData.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnExportData.ForeColor = Color.White;
            this.btnExportData.Location = new Point(650, 550);
            this.btnExportData.Size = new Size(120, 40);
            this.btnExportData.Text = "Export Data";

            // Edit Button - matches your image
            this.btnEdit.BackColor = Color.FromArgb(37, 99, 235);
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Location = new Point(800, 550);
            this.btnEdit.Size = new Size(100, 40);
            this.btnEdit.Text = "Edit";

            // UserControl properties
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 245, 251);
            this.Size = new Size(1000, 650);

            // Add controls to UserControl
            this.Controls.Add(this.lblInventoryTitle);
            this.Controls.Add(this.panelInventoryContainer);
            this.Controls.Add(this.btnExportData);
            this.Controls.Add(this.btnEdit);

            this.panelInventoryContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}