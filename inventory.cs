using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    public partial class inventory : UserControl
    {
        private string currentUserName;
        private main_layout parentMainLayout;
    // Icons for DataGridView action buttons
    private Image editIcon;
    private Image deleteIcon;

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
            ApplyRoundedButtons();
        }

        private void SetupEventHandlers()
        {
            // Export Data button click
            btnExportData.Click += (s, e) => {
                ExportInventoryData();
            };

            // Edit button click (old method - can be removed if not needed)
            btnEdit.Click += (s, e) => {
                EditSelectedItem();
            };

            // Add Item button click
            btnAddItem.Click += (s, e) => {
                ShowAddItemModal();
            };

            // DataGridView cell click for buttons
            dgvInventory.CellClick += DgvInventory_CellClick;
            // Custom paint for button columns so text/icons remain visible on colored background
            dgvInventory.CellPainting += DgvInventory_CellPainting;
        }

        private void DgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dgvInventory.Columns[e.ColumnIndex].Name;

                if (columnName == "Edit")
                {
                    EditInventoryItem(e.RowIndex);
                }
                else if (columnName == "Delete")
                {
                    DeleteInventoryItem(e.RowIndex);
                }
            }
        }

        private void DgvInventory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Custom paint Edit/Delete button cells so text and icons remain readable on colored backgrounds
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var col = dgvInventory.Columns[e.ColumnIndex];
                if (col.Name == "Edit" || col.Name == "Delete")
                {
                    e.Handled = true;
                    // Paint cell background
                    e.PaintBackground(e.CellBounds, true);

                    // Choose colors
                    Color back = col.Name == "Edit" ? Color.FromArgb(34, 197, 94) : Color.FromArgb(239, 68, 68);
                    string text = col.Name == "Edit" ? "Edit" : "Delete";

                    // Load icons lazily from the app's Images folder (fallback to text if load fails)
                    if (editIcon == null || deleteIcon == null)
                    {
                        try
                        {
                            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                            string imagesDir = Path.Combine(baseDir, "Images");
                            string editPath = Path.Combine(imagesDir, "edit.png");
                            string deletePath = Path.Combine(imagesDir, "recycle-bin.png");
                            if (File.Exists(editPath)) editIcon = Image.FromFile(editPath);
                            if (File.Exists(deletePath)) deleteIcon = Image.FromFile(deletePath);
                        }
                        catch
                        {
                            // ignore and fall back to text
                        }
                    }

                    // Draw colored rectangle with small padding
                    Rectangle rect = new Rectangle(e.CellBounds.X + 6, e.CellBounds.Y + 6, e.CellBounds.Width - 12, e.CellBounds.Height - 12);
                    using (Brush b = new SolidBrush(back))
                    {
                        e.Graphics.FillRectangle(b, rect);
                    }

                    // Draw icon (if available) then text
                    Image icon = col.Name == "Edit" ? editIcon : deleteIcon;
                    int padding = 8;
                    Rectangle iconRect = Rectangle.Empty;
                    Rectangle textRect = Rectangle.Empty;
                    if (icon != null)
                    {
                        // scale icon to fit height- padding
                        int iconSize = Math.Max(16, rect.Height - padding * 2);
                        iconRect = new Rectangle(rect.X + padding, rect.Y + (rect.Height - iconSize) / 2, iconSize, iconSize);
                        // text area to the right of icon
                        textRect = new Rectangle(iconRect.Right + 6, rect.Y, rect.Width - (iconRect.Width + padding + 6), rect.Height);
                        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        e.Graphics.DrawImage(icon, iconRect);
                    }
                    else
                    {
                        // center text if no icon
                        textRect = rect;
                    }

                    // Draw text left-aligned in remaining space
                    TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.Left;
                    TextRenderer.DrawText(e.Graphics, text, new Font("Segoe UI", 9F, FontStyle.Bold), textRect, Color.White, flags);

                    // Draw cell border
                    using (Pen p = new Pen(Color.FromArgb(200, 200, 200)))
                    {
                        e.Graphics.DrawRectangle(p, rect);
                    }
                }
            }
        }

        private void EditInventoryItem(int rowIndex)
        {
            try
            {
                var row = dgvInventory.Rows[rowIndex];
                int itemId = Convert.ToInt32(row.Cells["id"].Value);

                using (var editForm = new EditInventoryItemForm(itemId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadInventoryData();
                        MessageBox.Show("Item updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteInventoryItem(int rowIndex)
        {
            try
            {
                var row = dgvInventory.Rows[rowIndex];
                int itemId = Convert.ToInt32(row.Cells["id"].Value);
                string itemName = row.Cells["Item Name"].Value?.ToString();

                var result = MessageBox.Show($"Are you sure you want to delete '{itemName}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (DatabaseHelper.DeleteInventoryItem(itemId))
                    {
                        LoadInventoryData();
                        MessageBox.Show("Item deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRoundedButtons()
        {
            MakeRounded(btnExportData, 20);
            MakeRounded(btnEdit, 20);
            MakeRounded(btnAddItem, 25);
        }

        private void LoadInventoryData()
        {
            try
            {
                DataTable inventoryData = DatabaseHelper.GetAllInventoryItemsWithStatus();
                dgvInventory.DataSource = inventoryData;

                StyleDataGridView();
                AddActionButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddActionButtons()
        {
            // Remove existing button columns if they exist
            if (dgvInventory.Columns.Contains("Edit"))
                dgvInventory.Columns.Remove("Edit");
            if (dgvInventory.Columns.Contains("Delete"))
                dgvInventory.Columns.Remove("Delete");

            // Add Edit button column
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Text = "Edit";
            // We'll custom paint the button cells so don't rely on the default text rendering
            editButtonColumn.UseColumnTextForButtonValue = false;
            editButtonColumn.Width = 80;
            editButtonColumn.FlatStyle = FlatStyle.Flat;
            dgvInventory.Columns.Add(editButtonColumn);

            // Add Delete button column
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = false;
            deleteButtonColumn.Width = 90;
            deleteButtonColumn.FlatStyle = FlatStyle.Flat;
            dgvInventory.Columns.Add(deleteButtonColumn);

            // Ensure action columns are placed at the far right and are fixed width so the Item Name column can take remaining space
            try
            {
                // Make sure the Item Name column exists and uses Fill
                if (dgvInventory.Columns.Contains("Item Name"))
                {
                    dgvInventory.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvInventory.Columns["Item Name"].FillWeight = 200; // large weight to keep it wide on first open
                }

                // Place Edit/Delete at the end and make them fixed width
                if (dgvInventory.Columns.Contains("Edit"))
                {
                    dgvInventory.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventory.Columns["Edit"].Width = 110;
                    dgvInventory.Columns["Edit"].DisplayIndex = dgvInventory.Columns.Count - 2;
                }
                if (dgvInventory.Columns.Contains("Delete"))
                {
                    dgvInventory.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventory.Columns["Delete"].Width = 110;
                    dgvInventory.Columns["Delete"].DisplayIndex = dgvInventory.Columns.Count - 1;
                }
            }
            catch
            {
                // ignore layout exceptions during initial population
            }

            // Style the button columns
            editButtonColumn.DefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
            editButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            editButtonColumn.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            deleteButtonColumn.DefaultCellStyle.BackColor = Color.FromArgb(239, 68, 68);
            deleteButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            deleteButtonColumn.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void StyleDataGridView()
        {
            if (dgvInventory.Columns.Count > 0)
            {
                // Hide the ID column
                if (dgvInventory.Columns.Contains("id"))
                    dgvInventory.Columns["id"].Visible = false;

                // Make columns fill available width and set reasonable ratios
                dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Give columns relative fill weights
                dgvInventory.Columns["Item Name"].FillWeight = 30; // wider
                dgvInventory.Columns["Quantity"].FillWeight = 8;
                dgvInventory.Columns["Quantity Remaining"].FillWeight = 10;
                dgvInventory.Columns["Received Date"].FillWeight = 12;
                dgvInventory.Columns["Expiration Date"].FillWeight = 12;
                dgvInventory.Columns["Status"].FillWeight = 8;

                // Hide optional columns that we don't want to display in the main grid
                if (dgvInventory.Columns.Contains("supplier"))
                    dgvInventory.Columns["supplier"].Visible = false;
                if (dgvInventory.Columns.Contains("cost_per_unit"))
                    dgvInventory.Columns["cost_per_unit"].Visible = false;
                if (dgvInventory.Columns.Contains("notes"))
                    dgvInventory.Columns["notes"].Visible = false;

                // Style Status column based on value
                StyleStatusColumn();

                // Style headers
                dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 99, 235);
                dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                dgvInventory.ColumnHeadersHeight = 40;

                // Ensure header and cell styles are applied consistently (avoid OS visual styles overriding colors)
                dgvInventory.EnableHeadersVisualStyles = false;

                // Style rows
                dgvInventory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                dgvInventory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 211, 77);
                dgvInventory.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvInventory.RowsDefaultCellStyle.BackColor = Color.White;
                dgvInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                dgvInventory.RowTemplate.Height = 40;

                // Make sure action columns (Edit/Delete) are narrow and placed at the far right
                if (dgvInventory.Columns.Contains("Edit"))
                {
                    dgvInventory.Columns["Edit"].FillWeight = 6;
                    dgvInventory.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventory.Columns["Edit"].Width = 90;
                }
                if (dgvInventory.Columns.Contains("Delete"))
                {
                    dgvInventory.Columns["Delete"].FillWeight = 6;
                    dgvInventory.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventory.Columns["Delete"].Width = 90;
                }

                // Style grid
                dgvInventory.GridColor = Color.FromArgb(229, 231, 235);
                dgvInventory.BorderStyle = BorderStyle.FixedSingle;
                dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
        }

        private void StyleStatusColumn()
        {
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    switch (status)
                    {
                        case "Low Stock":
                            row.Cells["Status"].Style.BackColor = Color.FromArgb(254, 226, 226); // Light red
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(185, 28, 28); // Dark red
                            break;
                        case "In Stock":
                            row.Cells["Status"].Style.BackColor = Color.FromArgb(254, 249, 195); // Light yellow
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(161, 98, 7); // Dark yellow
                            break;
                        case "High Stock":
                            row.Cells["Status"].Style.BackColor = Color.FromArgb(220, 252, 231); // Light green
                            row.Cells["Status"].Style.ForeColor = Color.FromArgb(21, 128, 61); // Dark green
                            break;
                    }
                    row.Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
            }
        }

        private void ShowAddItemModal()
        {
            using (var addItemForm = new AddInventoryItemForm())
            {
                if (addItemForm.ShowDialog() == DialogResult.OK)
                {
                    LoadInventoryData();
                    MessageBox.Show("Item added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EditSelectedItem()
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                EditInventoryItem(dgvInventory.SelectedRows[0].Index);
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
                saveDialog.FileName = $"Inventory_Report_{DateTime.Now:yyyyMMdd_HHmmss}";

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
                // Write headers (excluding button columns)
                var headers = new List<string>();
                foreach (DataGridViewColumn column in dgvInventory.Columns)
                {
                    if (column.Visible && column.Name != "Edit" && column.Name != "Delete")
                    {
                        headers.Add(column.HeaderText);
                    }
                }
                writer.WriteLine(string.Join(",", headers));

                // Write data rows
                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var rowData = new List<string>();
                        foreach (DataGridViewColumn column in dgvInventory.Columns)
                        {
                            if (column.Visible && column.Name != "Edit" && column.Name != "Delete")
                            {
                                string cellValue = row.Cells[column.Index].Value?.ToString() ?? "";
                                if (cellValue.Contains(",") || cellValue.Contains("\""))
                                {
                                    cellValue = $"\"{cellValue.Replace("\"", "\"\"")}\"";
                                }
                                rowData.Add(cellValue);
                            }
                        }
                        writer.WriteLine(string.Join(",", rowData));
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

    // Edit Inventory Item Form
    public partial class EditInventoryItemForm : Form
    {
        private int itemId;
        private TextBox txtItemName;
        private NumericUpDown nudQuantity;
        private NumericUpDown nudQuantityRemaining;
        private DateTimePicker dtpReceivedDate;
        private DateTimePicker dtpExpirationDate;
        private CheckBox chkNoExpiration;
        private TextBox txtSupplier;
        private NumericUpDown nudCostPerUnit;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;

        public EditInventoryItemForm(int id)
        {
            itemId = id;
            InitializeEditItemForm();
            LoadItemData();
        }

        private void InitializeEditItemForm()
        {
            this.Text = "Edit Inventory Item";
            this.Size = new Size(500, 600); // REDUCED HEIGHT since we removed category
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Edit Inventory Item";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 30);

            // Item Name
            Label lblItemName = new Label();
            lblItemName.Text = "Item Name *";
            lblItemName.Location = new Point(20, 70);
            lblItemName.Size = new Size(100, 20);
            lblItemName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            txtItemName = new TextBox();
            txtItemName.Location = new Point(20, 95);
            txtItemName.Size = new Size(450, 25);
            txtItemName.Font = new Font("Segoe UI", 10F);

            // Quantity
            Label lblQuantity = new Label();
            lblQuantity.Text = "Quantity *";
            lblQuantity.Location = new Point(20, 130);
            lblQuantity.Size = new Size(100, 20);
            lblQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            nudQuantity = new NumericUpDown();
            nudQuantity.Location = new Point(20, 155);
            nudQuantity.Size = new Size(200, 25);
            nudQuantity.Minimum = 0;
            nudQuantity.Maximum = 99999;
            nudQuantity.Font = new Font("Segoe UI", 10F);

            // Quantity Remaining
            Label lblQuantityRemaining = new Label();
            lblQuantityRemaining.Text = "Quantity Remaining *";
            lblQuantityRemaining.Location = new Point(250, 130);
            lblQuantityRemaining.Size = new Size(150, 20);
            lblQuantityRemaining.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            nudQuantityRemaining = new NumericUpDown();
            nudQuantityRemaining.Location = new Point(250, 155);
            nudQuantityRemaining.Size = new Size(220, 25);
            nudQuantityRemaining.Minimum = 0;
            nudQuantityRemaining.Maximum = 99999;
            nudQuantityRemaining.Font = new Font("Segoe UI", 10F);

            // Received Date
            Label lblReceivedDate = new Label();
            lblReceivedDate.Text = "Received Date *";
            lblReceivedDate.Location = new Point(20, 190);
            lblReceivedDate.Size = new Size(150, 20);
            lblReceivedDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dtpReceivedDate = new DateTimePicker();
            dtpReceivedDate.Location = new Point(20, 215);
            dtpReceivedDate.Size = new Size(200, 25);
            dtpReceivedDate.Font = new Font("Segoe UI", 10F);

            // Expiration Date
            Label lblExpirationDate = new Label();
            lblExpirationDate.Text = "Expiration Date";
            lblExpirationDate.Location = new Point(250, 190);
            lblExpirationDate.Size = new Size(150, 20);
            lblExpirationDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dtpExpirationDate = new DateTimePicker();
            dtpExpirationDate.Location = new Point(250, 215);
            dtpExpirationDate.Size = new Size(220, 25);
            dtpExpirationDate.Font = new Font("Segoe UI", 10F);

            chkNoExpiration = new CheckBox();
            chkNoExpiration.Text = "No Expiration Date";
            chkNoExpiration.Location = new Point(250, 245);
            chkNoExpiration.Size = new Size(150, 20);
            chkNoExpiration.Font = new Font("Segoe UI", 9F);
            chkNoExpiration.CheckedChanged += (s, e) => {
                dtpExpirationDate.Enabled = !chkNoExpiration.Checked;
            };

            // Supplier - MOVED UP to replace category position
            Label lblSupplier = new Label();
            lblSupplier.Text = "Supplier";
            lblSupplier.Location = new Point(20, 280);
            lblSupplier.Size = new Size(100, 20);
            lblSupplier.Font = new Font("Segoe UI", 10F);

            txtSupplier = new TextBox();
            txtSupplier.Location = new Point(20, 305);
            txtSupplier.Size = new Size(200, 25);
            txtSupplier.Font = new Font("Segoe UI", 10F);

            // Cost Per Unit - MOVED LEFT
            Label lblCostPerUnit = new Label();
            lblCostPerUnit.Text = "Cost Per Unit";
            lblCostPerUnit.Location = new Point(250, 280);
            lblCostPerUnit.Size = new Size(100, 20);
            lblCostPerUnit.Font = new Font("Segoe UI", 10F);

            nudCostPerUnit = new NumericUpDown();
            nudCostPerUnit.Location = new Point(250, 305);
            nudCostPerUnit.Size = new Size(220, 25);
            nudCostPerUnit.DecimalPlaces = 2;
            nudCostPerUnit.Minimum = 0;
            nudCostPerUnit.Maximum = 999999;
            nudCostPerUnit.Font = new Font("Segoe UI", 10F);

            // Notes - MOVED UP
            Label lblNotes = new Label();
            lblNotes.Text = "Notes";
            lblNotes.Location = new Point(20, 340);
            lblNotes.Size = new Size(100, 20);
            lblNotes.Font = new Font("Segoe UI", 10F);

            txtNotes = new TextBox();
            txtNotes.Location = new Point(20, 365);
            txtNotes.Size = new Size(450, 80);
            txtNotes.Multiline = true;
            txtNotes.Font = new Font("Segoe UI", 10F);

            // Buttons - MOVED UP
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(320, 470);
            btnCancel.Size = new Size(80, 35);
            btnCancel.BackColor = Color.FromArgb(107, 114, 128);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.DialogResult = DialogResult.Cancel;

            btnSave = new Button();
            btnSave.Text = "Update Item";
            btnSave.Location = new Point(410, 470);
            btnSave.Size = new Size(80, 35);
            btnSave.BackColor = Color.FromArgb(59, 130, 246);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Click += BtnSave_Click;

            // Add all controls to form - REMOVED txtCategory references
            this.Controls.AddRange(new Control[] {
                lblTitle, lblItemName, txtItemName, lblQuantity, nudQuantity,
                lblQuantityRemaining, nudQuantityRemaining, lblReceivedDate, dtpReceivedDate,
                lblExpirationDate, dtpExpirationDate, chkNoExpiration,
                lblSupplier, txtSupplier, lblCostPerUnit, nudCostPerUnit, lblNotes, txtNotes,
                btnSave, btnCancel
            });
        }

        private void LoadItemData()
        {
            try
            {
                DataTable itemData = DatabaseHelper.GetInventoryItemById(itemId);
                if (itemData.Rows.Count > 0)
                {
                    DataRow row = itemData.Rows[0];

                    txtItemName.Text = row["item_name"].ToString();
                    nudQuantity.Value = Convert.ToDecimal(row["quantity"]);
                    nudQuantityRemaining.Value = Convert.ToDecimal(row["quantity_remaining"]);
                    dtpReceivedDate.Value = Convert.ToDateTime(row["received_date"]);

                    if (row["expiration_date"] != DBNull.Value)
                    {
                        dtpExpirationDate.Value = Convert.ToDateTime(row["expiration_date"]);
                        chkNoExpiration.Checked = false;
                    }
                    else
                    {
                        chkNoExpiration.Checked = true;
                        dtpExpirationDate.Enabled = false;
                    }

                    // REMOVED: txtCategory.Text = row["category"]?.ToString() ?? "";
                    txtSupplier.Text = row["supplier"]?.ToString() ?? "";
                    nudCostPerUnit.Value = Convert.ToDecimal(row["cost_per_unit"] ?? 0);
                    txtNotes.Text = row["notes"]?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading item data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtItemName.Text))
                {
                    MessageBox.Show("Please enter an item name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtItemName.Focus();
                    return;
                }

                if (nudQuantity.Value <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudQuantity.Focus();
                    return;
                }

                if (nudQuantityRemaining.Value > nudQuantity.Value)
                {
                    MessageBox.Show("Quantity remaining cannot be greater than total quantity.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudQuantityRemaining.Focus();
                    return;
                }

                // Get expiration date (null if no expiration)
                DateTime? expirationDate = chkNoExpiration.Checked ? null : dtpExpirationDate.Value;

                // UPDATED: Update the item in database - REMOVED CATEGORY PARAMETER
                bool success = DatabaseHelper.UpdateInventoryItem(
                    itemId,
                    txtItemName.Text.Trim(),
                    (int)nudQuantity.Value,
                    (int)nudQuantityRemaining.Value,
                    dtpReceivedDate.Value,
                    expirationDate,
                    txtSupplier.Text.Trim(),
                    nudCostPerUnit.Value,
                    txtNotes.Text.Trim()
                );

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update inventory item. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating inventory item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Keep the existing AddInventoryItemForm class (no changes needed)
    public partial class AddInventoryItemForm : Form
    {
        private TextBox txtItemName;
        private NumericUpDown nudQuantity;
        private NumericUpDown nudQuantityRemaining;
        private DateTimePicker dtpReceivedDate;
        private DateTimePicker dtpExpirationDate;
        private CheckBox chkNoExpiration;
        private TextBox txtSupplier;
        private NumericUpDown nudCostPerUnit;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;

        public AddInventoryItemForm()
        {
            InitializeAddItemForm();
        }

        private void InitializeAddItemForm()
        {
            this.Text = "Add Inventory Item";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Add New Inventory Item";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(300, 30);

            // Item Name (Required)
            Label lblItemName = new Label();
            lblItemName.Text = "Item Name *";
            lblItemName.Location = new Point(20, 70);
            lblItemName.Size = new Size(100, 20);
            lblItemName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            txtItemName = new TextBox();
            txtItemName.Location = new Point(20, 95);
            txtItemName.Size = new Size(450, 25);
            txtItemName.Font = new Font("Segoe UI", 10F);

            // Quantity (Required)
            Label lblQuantity = new Label();
            lblQuantity.Text = "Quantity *";
            lblQuantity.Location = new Point(20, 130);
            lblQuantity.Size = new Size(100, 20);
            lblQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            nudQuantity = new NumericUpDown();
            nudQuantity.Location = new Point(20, 155);
            nudQuantity.Size = new Size(200, 25);
            nudQuantity.Minimum = 0;
            nudQuantity.Maximum = 99999;
            nudQuantity.Font = new Font("Segoe UI", 10F);

            // Quantity Remaining (Required)
            Label lblQuantityRemaining = new Label();
            lblQuantityRemaining.Text = "Quantity Rem*";
            lblQuantityRemaining.Location = new Point(250, 130);
            lblQuantityRemaining.Size = new Size(150, 20);
            lblQuantityRemaining.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            nudQuantityRemaining = new NumericUpDown();
            nudQuantityRemaining.Location = new Point(250, 155);
            nudQuantityRemaining.Size = new Size(220, 25);
            nudQuantityRemaining.Minimum = 0;
            nudQuantityRemaining.Maximum = 99999;
            nudQuantityRemaining.Font = new Font("Segoe UI", 10F);

            // Received Date (Required)
            Label lblReceivedDate = new Label();
            lblReceivedDate.Text = "Received Date *";
            lblReceivedDate.Location = new Point(20, 190);
            lblReceivedDate.Size = new Size(150, 20);
            lblReceivedDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dtpReceivedDate = new DateTimePicker();
            dtpReceivedDate.Location = new Point(20, 215);
            dtpReceivedDate.Size = new Size(200, 25);
            dtpReceivedDate.Font = new Font("Segoe UI", 10F);

            // Expiration Date (Required)
            Label lblExpirationDate = new Label();
            lblExpirationDate.Text = "Expiration Date *";
            lblExpirationDate.Location = new Point(250, 190);
            lblExpirationDate.Size = new Size(150, 20);
            lblExpirationDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dtpExpirationDate = new DateTimePicker();
            dtpExpirationDate.Location = new Point(250, 215);
            dtpExpirationDate.Size = new Size(220, 25);
            dtpExpirationDate.Font = new Font("Segoe UI", 10F);

            chkNoExpiration = new CheckBox();
            chkNoExpiration.Text = "No Expiration Date";
            chkNoExpiration.Location = new Point(250, 245);
            chkNoExpiration.Size = new Size(150, 20);
            chkNoExpiration.Font = new Font("Segoe UI", 9F);
            chkNoExpiration.CheckedChanged += (s, e) => {
                dtpExpirationDate.Enabled = !chkNoExpiration.Checked;
            };

            // Supplier (Optional)
            Label lblSupplier = new Label();
            lblSupplier.Text = "Supplier";
            lblSupplier.Location = new Point(250, 280);
            lblSupplier.Size = new Size(100, 20);
            lblSupplier.Font = new Font("Segoe UI", 10F);

            txtSupplier = new TextBox();
            txtSupplier.Location = new Point(250, 305);
            txtSupplier.Size = new Size(220, 25);
            txtSupplier.Font = new Font("Segoe UI", 10F);

            // Cost Per Unit (Optional)
            Label lblCostPerUnit = new Label();
            lblCostPerUnit.Text = "Cost Per Unit";
            lblCostPerUnit.Location = new Point(20, 340);
            lblCostPerUnit.Size = new Size(100, 20);
            lblCostPerUnit.Font = new Font("Segoe UI", 10F);

            nudCostPerUnit = new NumericUpDown();
            nudCostPerUnit.Location = new Point(20, 365);
            nudCostPerUnit.Size = new Size(200, 25);
            nudCostPerUnit.DecimalPlaces = 2;
            nudCostPerUnit.Minimum = 0;
            nudCostPerUnit.Maximum = 999999;
            nudCostPerUnit.Font = new Font("Segoe UI", 10F);

            // Notes (Optional)
            Label lblNotes = new Label();
            lblNotes.Text = "Notes";
            lblNotes.Location = new Point(20, 400);
            lblNotes.Size = new Size(100, 20);
            lblNotes.Font = new Font("Segoe UI", 10F);

            txtNotes = new TextBox();
            txtNotes.Location = new Point(20, 425);
            txtNotes.Size = new Size(450, 60);
            txtNotes.Multiline = true;
            txtNotes.Font = new Font("Segoe UI", 10F);

            // Buttons
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(320, 510);
            btnCancel.Size = new Size(80, 35);
            btnCancel.BackColor = Color.FromArgb(107, 114, 128);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.DialogResult = DialogResult.Cancel;

            btnSave = new Button();
            btnSave.Text = "Save Item";
            btnSave.Location = new Point(410, 510);
            btnSave.Size = new Size(80, 35);
            btnSave.BackColor = Color.FromArgb(34, 197, 94);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Click += BtnSave_Click;

            // Add all controls to form
            this.Controls.AddRange(new Control[] {
                lblTitle, lblItemName, txtItemName, lblQuantity, nudQuantity,
                lblQuantityRemaining, nudQuantityRemaining, lblReceivedDate, dtpReceivedDate,
                lblExpirationDate, dtpExpirationDate, chkNoExpiration,
                lblSupplier, txtSupplier, lblCostPerUnit, nudCostPerUnit, lblNotes, txtNotes,
                btnSave, btnCancel
            });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtItemName.Text))
                {
                    MessageBox.Show("Please enter an item name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtItemName.Focus();
                    return;
                }

                if (nudQuantity.Value <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudQuantity.Focus();
                    return;
                }

                if (nudQuantityRemaining.Value > nudQuantity.Value)
                {
                    MessageBox.Show("Quantity remaining cannot be greater than total quantity.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudQuantityRemaining.Focus();
                    return;
                }

                // Get expiration date (null if no expiration)
                DateTime? expirationDate = chkNoExpiration.Checked ? null : dtpExpirationDate.Value;

                // FIXED: Add the item to database with correct parameter count (9 parameters)
                bool success = DatabaseHelper.AddInventoryItem(
                    txtItemName.Text.Trim(),           // itemName
                    (int)nudQuantity.Value,            // quantity
                    (int)nudQuantityRemaining.Value,   // quantityRemaining
                    dtpReceivedDate.Value,             // receivedDate
                    expirationDate,                    // expirationDate
                    txtSupplier.Text.Trim(),           // supplier
                    nudCostPerUnit.Value,              // costPerUnit
                    txtNotes.Text.Trim(),              // notes
                    1                                  // createdBy (Default user ID)
                );

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add inventory item. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding inventory item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}