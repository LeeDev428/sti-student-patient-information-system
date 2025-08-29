using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    public partial class report : UserControl
    {
        private string currentUserName;
        private main_layout parentMainLayout;

        public report()
        {
            InitializeComponent();
        }

        public void SetupForMainLayout(string userName, main_layout mainLayoutRef)
        {
            currentUserName = userName;
            parentMainLayout = mainLayoutRef;
            SetupEventHandlers();
            LoadReportData();
        }

        private void SetupEventHandlers()
        {
            // Apply button click
            btnApply.Click += (s, e) => {
                LoadDailyReport();
            };

            // Cancel button click
            btnCancel.Click += (s, e) => {
                ResetFilters();
                LoadReportData();
            };

            // Export Data button click
            btnExportData.Click += (s, e) => {
                ExportReportData();
            };

            // Search filter dropdown
            cmbSearchFilter.SelectedIndexChanged += (s, e) => {
                UpdateDateRangeVisibility();
            };

            // Date range picker events
            dtpFromDate.ValueChanged += (s, e) => {
                if (dtpFromDate.Value > dtpToDate.Value)
                {
                    dtpToDate.Value = dtpFromDate.Value;
                }
            };

            dtpToDate.ValueChanged += (s, e) => {
                if (dtpToDate.Value < dtpFromDate.Value)
                {
                    dtpFromDate.Value = dtpToDate.Value;
                }
            };
        }

        private void LoadReportData()
        {
            try
            {
                // Load default daily report (today)
                LoadDailyReport();

                // Update summary stats
                UpdateSummaryStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDailyReport()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;

                DataTable reportData = DatabaseHelper.GetDailyReport(fromDate, toDate);
                dgvDailyReport.DataSource = reportData;

                // Update grid appearance
                StyleDataGridView();

                // Update title with date range
                if (fromDate.Date == toDate.Date)
                {
                    lblReportTitle.Text = $"Daily Report - {fromDate.ToString("MMMM dd, yyyy")}";
                }
                else
                {
                    lblReportTitle.Text = $"Report - {fromDate.ToString("MMM dd")} to {toDate.ToString("MMM dd, yyyy")}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading daily report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView()
        {
            if (dgvDailyReport.Columns.Count > 0)
            {
                // Set column widths
                dgvDailyReport.Columns["Name"].Width = 200;
                dgvDailyReport.Columns["Section"].Width = 120;
                dgvDailyReport.Columns["Time"].Width = 100;
                dgvDailyReport.Columns["Reason of Visit"].Width = 250;

                // Style headers
                dgvDailyReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 99, 235);
                dgvDailyReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvDailyReport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                dgvDailyReport.ColumnHeadersHeight = 40;

                // Style rows
                dgvDailyReport.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                dgvDailyReport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 211, 77);
                dgvDailyReport.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvDailyReport.RowsDefaultCellStyle.BackColor = Color.White;
                dgvDailyReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                dgvDailyReport.RowTemplate.Height = 35;

                // Remove grid lines
                dgvDailyReport.GridColor = Color.FromArgb(229, 231, 235);
                dgvDailyReport.BorderStyle = BorderStyle.None;
            }
        }

        private void UpdateSummaryStats()
        {
            try
            {
                int totalPatients = DatabaseHelper.GetTotalPatients();
                int todayRegistrations = DatabaseHelper.GetTodayRegistrations();

                // Update labels if they exist
                if (lblTotalPatients != null)
                    lblTotalPatients.Text = totalPatients.ToString();

                if (lblTodayRegistrations != null)
                    lblTodayRegistrations.Text = todayRegistrations.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating summary stats: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDateRangeVisibility()
        {
            string selectedFilter = cmbSearchFilter.SelectedItem?.ToString();
            bool showDateRange = selectedFilter == "Custom" || selectedFilter == "Date Range";

            panelDateRange.Visible = showDateRange;

            if (!showDateRange)
            {
                // Set predefined date ranges
                switch (selectedFilter)
                {
                    case "Today":
                        dtpFromDate.Value = DateTime.Today;
                        dtpToDate.Value = DateTime.Today;
                        break;
                    case "This Week":
                        dtpFromDate.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                        dtpToDate.Value = DateTime.Today;
                        break;
                    case "This Month":
                        dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        dtpToDate.Value = DateTime.Today;
                        break;
                }
                LoadDailyReport();
            }
        }

        private void ResetFilters()
        {
            cmbSearchFilter.SelectedIndex = 0; // Reset to first item
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;
        }

        private void ExportReportData()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx";
                saveDialog.DefaultExt = "csv";
                saveDialog.FileName = $"Patient_Report_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportDataToCSV(saveDialog.FileName);
                    MessageBox.Show("Report exported successfully!", "Export Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportDataToCSV(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
            {
                // Write headers
                string headers = "";
                for (int i = 0; i < dgvDailyReport.Columns.Count; i++)
                {
                    headers += dgvDailyReport.Columns[i].HeaderText;
                    if (i < dgvDailyReport.Columns.Count - 1)
                        headers += ",";
                }
                writer.WriteLine(headers);

                // Write data rows
                foreach (DataGridViewRow row in dgvDailyReport.Rows)
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