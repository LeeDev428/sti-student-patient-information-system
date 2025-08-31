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
        private Button btnAddItem; // NEW: Add item button

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
            this.btnAddItem = new Button(); // NEW: Initialize add button

            this.panelInventoryContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();

            // Inventory Title
            this.lblInventoryTitle.AutoSize = true;
            this.lblInventoryTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblInventoryTitle.ForeColor = Color.Black;
            this.lblInventoryTitle.Location = new Point(50, 20);
            this.lblInventoryTitle.Text = "Medical Supplies Inventory";

            // NEW: Add Item Button - positioned in upper right
            this.btnAddItem.BackColor = Color.FromArgb(34, 197, 94); // Green color
            this.btnAddItem.FlatStyle = FlatStyle.Flat;
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.btnAddItem.ForeColor = Color.White;
            this.btnAddItem.Location = new Point(900, 20); // Upper right position
            this.btnAddItem.Size = new Size(50, 50); // Square button
            this.btnAddItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnAddItem.Text = "+";
            this.btnAddItem.UseVisualStyleBackColor = false;

            // Inventory Container Panel - matches your image background
            this.panelInventoryContainer.BackColor = Color.FromArgb(209, 213, 219);
            this.panelInventoryContainer.Location = new Point(50, 80);
            this.panelInventoryContainer.Size = new Size(900, 450);
            // Make the container resize with the control
            this.panelInventoryContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.panelInventoryContainer.Controls.Add(this.dgvInventory);

            // DataGridView for inventory - exactly like your image
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.BackgroundColor = Color.White;
            this.dgvInventory.BorderStyle = BorderStyle.FixedSingle;
            this.dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // Let the grid fill the panel so it automatically resizes
            this.dgvInventory.Dock = DockStyle.Fill;
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
            this.btnExportData.Location = new Point(420, 550);
            this.btnExportData.Size = new Size(120, 40);
            // Anchor to bottom so it stays at same vertical distance; positioned nearer center
            this.btnExportData.Anchor = AnchorStyles.Bottom;
            this.btnExportData.Text = "Export Data";

            // Edit Button - matches your image
            // Edit button made green for better visibility
            this.btnEdit.BackColor = Color.FromArgb(34, 197, 94);
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Location = new Point(550, 550);
            this.btnEdit.Size = new Size(100, 40);
            // Anchor to bottom so it stays aligned with Export when resizing horizontally
            this.btnEdit.Anchor = AnchorStyles.Bottom;
            this.btnEdit.Text = "Edit";


            // UserControl properties
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 245, 251);
            this.Size = new Size(1000, 650);

            // Add controls to UserControl
            this.Controls.Add(this.lblInventoryTitle);
            this.Controls.Add(this.btnAddItem); // NEW: Add the button to controls
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