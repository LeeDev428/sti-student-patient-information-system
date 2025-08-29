using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    public partial class inventory : UserControl
    {
        private string currentUserName;
        private main_layout parentMainLayout;

        public inventory()
        {
            InitializeComponent();
        }

        public void SetupForMainLayout(string userName, main_layout mainLayoutRef)
        {
            currentUserName = userName;
            parentMainLayout = mainLayoutRef;
            SetupEventHandlers();
            LoadInventoryData();
        }

        private void SetupEventHandlers()
        {
            // Export Data button click
            btnExportData.Click += (s, e) => {
                ExportInventoryData();
            };

            // Edit button click
            btnEdit.Click += (s, e) => {
                EditSelectedItem();
            };

            // Add search functionality if needed
            // You can add search textbox later
        }

        private void LoadInventoryData()
        {
            try
            {
                DataTable inventoryData = DatabaseHelper.GetAllInventoryItems();
                dgvInventory.DataSource = inventoryData;

                // Style the DataGridView
                StyleDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView()
        {
            if (dgvInventory.Columns.Count > 0)
            {
                // Set column widths to match your image
                dgvInventory.Columns["Item Name"].Width = 250;
                dgvInventory.Columns["Quantity"].Width = 120;
                dgvInventory.Columns["Quantity Remaining"].Width = 150;
                dgvInventory.Columns["Received Date"].Width = 140;
                dgvInventory.Columns["Expiration Date"].Width = 140;

                // Style headers
                dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 99, 235);
                dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                dgvInventory.ColumnHeadersHeight = 40;

                // Style rows
                dgvInventory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                dgvInventory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 211, 77);
                dgvInventory.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvInventory.RowsDefaultCellStyle.BackColor = Color.White;
                dgvInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                dgvInventory.RowTemplate.Height = 35;

                // Style grid
                dgvInventory.GridColor = Color.FromArgb(229, 231, 235);
                dgvInventory.BorderStyle = BorderStyle.FixedSingle;
                dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
        }

        private void EditSelectedItem()
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                MessageBox.Show("Edit functionality will be implemented here.", "Edit Item",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // You can implement edit form later
            }
            else
            {
                MessageBox.Show("Please select an item to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportInventoryData()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx";
                saveDialog.DefaultExt = "csv";
                saveDialog.FileName = $"Inventory_Report_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportDataToCSV(saveDialog.FileName);
                    MessageBox.Show("Inventory exported successfully!", "Export Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting inventory: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportDataToCSV(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
            {
                // Write headers
                string headers = "";
                for (int i = 0; i < dgvInventory.Columns.Count; i++)
                {
                    headers += dgvInventory.Columns[i].HeaderText;
                    if (i < dgvInventory.Columns.Count - 1)
                        headers += ",";
                }
                writer.WriteLine(headers);

                // Write data rows
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string rowData = "";
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            string cellValue = row.Cells[i].Value?.ToString() ?? "";
                            // Escape commas and quotes
                            if (cellValue.Contains(",") || cellValue.Contains("\""))
                            {
                                cellValue = "\"" + cellValue.Replace("\"", "\"\"") + "\"";
                            }
                            rowData += cellValue;
                            if (i < row.Cells.Count - 1)
                                rowData += ",";
                        }
                        writer.WriteLine(rowData);
                    }
                }
            }
        }

        private void MakeRounded(Control control, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                control.Region = new Region(path);
            }
        }
    }
}