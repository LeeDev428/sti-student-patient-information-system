using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace sti_student_patient_information_system
{
    public partial class report : UserControl
    {
        private string currentUserName;
        private main_layout parentMainLayout;
        private DataTable weeklyChartData;
        private DataTable monthlyChartData;

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
            ApplyModernStyling();
            SetupScrollableContent(); // Add this line
        }

        private void SetupEventHandlers()
        {
            // Daily report Apply button click
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

            // Weekly Apply button click
            btnWeeklyApply.Click += (s, e) => {
                LoadWeeklyChartData();
                panelWeeklyChartArea.Invalidate();
            };

            // Monthly Apply button click
            btnMonthlyApply.Click += (s, e) => {
                LoadMonthlyChartData();
                panelMonthlyChartArea.Invalidate();
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

            // Weekly date range validation
            dtpWeeklyFrom.ValueChanged += (s, e) => {
                if (dtpWeeklyFrom.Value > dtpWeeklyTo.Value)
                {
                    dtpWeeklyTo.Value = dtpWeeklyFrom.Value;
                }
            };

            dtpWeeklyTo.ValueChanged += (s, e) => {
                if (dtpWeeklyTo.Value < dtpWeeklyFrom.Value)
                {
                    dtpWeeklyFrom.Value = dtpWeeklyTo.Value;
                }
            };

            // Monthly date range validation
            dtpMonthlyFrom.ValueChanged += (s, e) => {
                if (dtpMonthlyFrom.Value > dtpMonthlyTo.Value)
                {
                    dtpMonthlyTo.Value = dtpMonthlyFrom.Value;
                }
            };

            dtpMonthlyTo.ValueChanged += (s, e) => {
                if (dtpMonthlyTo.Value < dtpMonthlyFrom.Value)
                {
                    dtpMonthlyFrom.Value = dtpMonthlyTo.Value;
                }
            };

            // Setup modern chart paint events
            panelWeeklyChartArea.Paint += WeeklyChart_Paint;
            panelMonthlyChartArea.Paint += MonthlyChart_Paint;
        }

        private void ApplyModernStyling()
        {
            // Apply rounded corners and shadows to buttons
            MakeRounded(btnWeeklyApply, 8);
            MakeRounded(btnMonthlyApply, 8);
            MakeRounded(btnApply, 8);
            MakeRounded(btnCancel, 8);
            MakeRounded(btnExportData, 8);

            // Apply rounded corners to panels
            MakeRounded(panelWeeklyChart, 12);
            MakeRounded(panelMonthlyChart, 12);
            MakeRounded(panelReportContainer, 12);
            MakeRounded(panelFilters, 12);
            MakeRounded(panelStats, 12);
            MakeRounded(panelDailyReportHeader, 12);
        }

        private void LoadReportData()
        {
            try
            {
                LoadDailyReport();
                LoadWeeklyChartData();
                LoadMonthlyChartData();
                UpdateSummaryStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWeeklyChartData()
        {
            try
            {
                DateTime fromDate = dtpWeeklyFrom.Value;
                DateTime toDate = dtpWeeklyTo.Value;

                weeklyChartData = DatabaseHelper.GetWeeklyReport(fromDate, toDate);
                panelWeeklyChartArea.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading weekly chart data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonthlyChartData()
        {
            try
            {
                DateTime fromDate = dtpMonthlyFrom.Value;
                DateTime toDate = dtpMonthlyTo.Value;

                monthlyChartData = DatabaseHelper.GetMonthlyReport(fromDate, toDate);
                panelMonthlyChartArea.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly chart data: {ex.Message}", "Error",
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

                StyleDataGridView();
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
                // Modern DataGridView styling
                dgvDailyReport.Columns["Name"].Width = 200;
                dgvDailyReport.Columns["Section"].Width = 150;
                dgvDailyReport.Columns["Time"].Width = 120;
                dgvDailyReport.Columns["Reason of Visit"].Width = 300;

                // Modern header style
                dgvDailyReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
                dgvDailyReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvDailyReport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                dgvDailyReport.ColumnHeadersHeight = 45;
                dgvDailyReport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Modern row styling
                dgvDailyReport.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                dgvDailyReport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
                dgvDailyReport.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
                dgvDailyReport.RowsDefaultCellStyle.BackColor = Color.White;
                dgvDailyReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                dgvDailyReport.RowTemplate.Height = 40;
                dgvDailyReport.DefaultCellStyle.Padding = new Padding(5);

                // Remove harsh borders
                dgvDailyReport.GridColor = Color.FromArgb(226, 232, 240);
                dgvDailyReport.BorderStyle = BorderStyle.None;
                dgvDailyReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            }
        }

        private void UpdateSummaryStats()
        {
            try
            {
                int totalPatients = DatabaseHelper.GetTotalPatients();
                int todayRegistrations = DatabaseHelper.GetTodayRegistrations();

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
            bool showDateRange = selectedFilter == "Custom";

            panelDateRange.Visible = showDateRange;

            if (!showDateRange)
            {
                switch (selectedFilter)
                {
                    case "Today":
                        dtpFromDate.Value = DateTime.Today;
                        dtpToDate.Value = DateTime.Today;
                        break;
                    case "Yesterday":
                        dtpFromDate.Value = DateTime.Today.AddDays(-1);
                        dtpToDate.Value = DateTime.Today.AddDays(-1);
                        break;
                    case "This Week":
                        dtpFromDate.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                        dtpToDate.Value = DateTime.Today;
                        break;
                    case "Last Week":
                        DateTime lastWeekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek - 7);
                        dtpFromDate.Value = lastWeekStart;
                        dtpToDate.Value = lastWeekStart.AddDays(6);
                        break;
                    case "This Month":
                        dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        dtpToDate.Value = DateTime.Today;
                        break;
                    case "Last Month":
                        DateTime lastMonth = DateTime.Today.AddMonths(-1);
                        dtpFromDate.Value = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                        dtpToDate.Value = new DateTime(lastMonth.Year, lastMonth.Month, DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month));
                        break;
                }
                LoadDailyReport();
            }
        }

        private void ResetFilters()
        {
            cmbSearchFilter.SelectedIndex = 0;
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;
        }

        // MODERN WEEKLY CHART PAINTING
        private void WeeklyChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle chartArea = new Rectangle(30, 20, panelWeeklyChartArea.Width - 60, panelWeeklyChartArea.Height - 50);

            if (weeklyChartData != null && weeklyChartData.Rows.Count > 0)
            {
                DrawModernWeeklyChart(g, chartArea);
            }
            else
            {
                DrawNoDataMessage(g, chartArea, "No weekly data available");
            }
        }

        // MODERN MONTHLY CHART PAINTING
        private void MonthlyChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle chartArea = new Rectangle(30, 20, panelMonthlyChartArea.Width - 60, panelMonthlyChartArea.Height - 50);

            if (monthlyChartData != null && monthlyChartData.Rows.Count > 0)
            {
                DrawModernMonthlyChart(g, chartArea);
            }
            else
            {
                DrawNoDataMessage(g, chartArea, "No monthly data available");
            }
        }

        private void DrawModernWeeklyChart(Graphics g, Rectangle chartArea)
        {
            // Modern gradient colors
            Color[] modernColors = {
                Color.FromArgb(99, 102, 241),   // Indigo
                Color.FromArgb(59, 130, 246),   // Blue
                Color.FromArgb(16, 185, 129),   // Emerald
                Color.FromArgb(245, 158, 11),   // Amber
                Color.FromArgb(239, 68, 68),    // Red
                Color.FromArgb(168, 85, 247),   // Purple
                Color.FromArgb(34, 197, 94)     // Green
            };

            int maxValue = 0;
            List<int> values = new List<int>();
            List<string> labels = new List<string>();

            foreach (DataRow row in weeklyChartData.Rows)
            {
                int count = Convert.ToInt32(row["Count"]);
                values.Add(count);
                labels.Add(row["DayName"].ToString().Substring(0, 3)); // Abbreviated day names
                if (count > maxValue) maxValue = count;
            }

            if (maxValue == 0) maxValue = 10;

            // Draw modern grid
            DrawModernGrid(g, chartArea, maxValue);

            // Calculate bar dimensions
            int barWidth = Math.Max(30, (chartArea.Width - 40) / Math.Max(values.Count, 1) - 15);
            int startX = chartArea.X + 30;

            for (int i = 0; i < values.Count; i++)
            {
                int barHeight = (int)((double)values[i] / maxValue * (chartArea.Height - 40));
                int barX = startX + i * (barWidth + 15);
                int barY = chartArea.Y + chartArea.Height - 30 - barHeight;

                // Create gradient brush for modern look
                using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new Rectangle(barX, barY, barWidth, barHeight),
                    modernColors[i % modernColors.Length],
                    Color.FromArgb(200, modernColors[i % modernColors.Length]),
                    LinearGradientMode.Vertical))
                {
                    // Draw rounded rectangle bar
                    using (GraphicsPath barPath = CreateRoundedRectangle(barX, barY, barWidth, barHeight, 4))
                    {
                        g.FillPath(gradientBrush, barPath);
                        g.DrawPath(new Pen(modernColors[i % modernColors.Length], 1), barPath);
                    }
                }

                // Draw value labels with modern styling
                using (Font valueFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.FromArgb(71, 85, 105)))
                {
                    string valueText = values[i].ToString();
                    SizeF textSize = g.MeasureString(valueText, valueFont);
                    g.DrawString(valueText, valueFont, textBrush,
                        barX + (barWidth - textSize.Width) / 2,
                        barY - textSize.Height - 5);
                }

                // Draw day labels
                using (Font labelFont = new Font("Segoe UI", 9F, FontStyle.Regular))
                using (Brush labelBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    string labelText = labels[i];
                    SizeF textSize = g.MeasureString(labelText, labelFont);
                    g.DrawString(labelText, labelFont, labelBrush,
                        barX + (barWidth - textSize.Width) / 2,
                        chartArea.Y + chartArea.Height - 25);
                }
            }
        }

        private void DrawModernMonthlyChart(Graphics g, Rectangle chartArea)
        {
            // Modern gradient colors for months
            Color[] monthColors = {
                Color.FromArgb(236, 72, 153),   // Pink
                Color.FromArgb(168, 85, 247),   // Purple
                Color.FromArgb(99, 102, 241),   // Indigo
                Color.FromArgb(59, 130, 246),   // Blue
                Color.FromArgb(14, 165, 233),   // Sky
                Color.FromArgb(6, 182, 212),    // Cyan
                Color.FromArgb(16, 185, 129),   // Emerald
                Color.FromArgb(34, 197, 94),    // Green
                Color.FromArgb(101, 163, 13),   // Lime
                Color.FromArgb(245, 158, 11),   // Amber
                Color.FromArgb(249, 115, 22),   // Orange
                Color.FromArgb(239, 68, 68)     // Red
            };

            int maxValue = 0;
            List<int> values = new List<int>();
            List<string> labels = new List<string>();

            foreach (DataRow row in monthlyChartData.Rows)
            {
                int count = Convert.ToInt32(row["Count"]);
                values.Add(count);
                labels.Add(row["MonthName"].ToString().Substring(0, 3)); // Abbreviated month names
                if (count > maxValue) maxValue = count;
            }

            if (maxValue == 0) maxValue = 10;

            // Draw modern grid
            DrawModernGrid(g, chartArea, maxValue);

            // Calculate bar dimensions
            int barWidth = Math.Max(25, (chartArea.Width - 40) / Math.Max(values.Count, 1) - 12);
            int startX = chartArea.X + 30;

            for (int i = 0; i < values.Count; i++)
            {
                int barHeight = (int)((double)values[i] / maxValue * (chartArea.Height - 40));
                int barX = startX + i * (barWidth + 12);
                int barY = chartArea.Y + chartArea.Height - 30 - barHeight;

                // Create gradient brush for modern look
                using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new Rectangle(barX, barY, barWidth, barHeight),
                    monthColors[i % monthColors.Length],
                    Color.FromArgb(200, monthColors[i % monthColors.Length]),
                    LinearGradientMode.Vertical))
                {
                    // Draw rounded rectangle bar
                    using (GraphicsPath barPath = CreateRoundedRectangle(barX, barY, barWidth, barHeight, 4))
                    {
                        g.FillPath(gradientBrush, barPath);
                        g.DrawPath(new Pen(monthColors[i % monthColors.Length], 1), barPath);
                    }
                }

                // Draw value labels
                using (Font valueFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.FromArgb(71, 85, 105)))
                {
                    string valueText = values[i].ToString();
                    SizeF textSize = g.MeasureString(valueText, valueFont);
                    g.DrawString(valueText, valueFont, textBrush,
                        barX + (barWidth - textSize.Width) / 2,
                        barY - textSize.Height - 5);
                }

                // Draw month labels
                using (Font labelFont = new Font("Segoe UI", 8F, FontStyle.Regular))
                using (Brush labelBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    string labelText = labels[i];
                    SizeF textSize = g.MeasureString(labelText, labelFont);
                    g.DrawString(labelText, labelFont, labelBrush,
                        barX + (barWidth - textSize.Width) / 2,
                        chartArea.Y + chartArea.Height - 25);
                }
            }
        }

        private void DrawModernGrid(Graphics g, Rectangle chartArea, int maxValue)
        {
            using (Pen gridPen = new Pen(Color.FromArgb(241, 245, 249), 1))
            using (Font gridFont = new Font("Segoe UI", 8F))
            using (Brush gridBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
            {
                // Draw horizontal grid lines
                for (int i = 0; i <= 5; i++)
                {
                    int value = (maxValue * i) / 5;
                    int y = chartArea.Y + chartArea.Height - 30 - (i * (chartArea.Height - 40) / 5);

                    g.DrawLine(gridPen, chartArea.X + 25, y, chartArea.X + chartArea.Width - 10, y);
                    g.DrawString(value.ToString(), gridFont, gridBrush, chartArea.X - 5, y - 8);
                }
            }
        }

        private void DrawNoDataMessage(Graphics g, Rectangle chartArea, string message)
        {
            using (Font font = new Font("Segoe UI", 14F, FontStyle.Regular))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
            {
                SizeF textSize = g.MeasureString(message, font);
                PointF textLocation = new PointF(
                    chartArea.X + (chartArea.Width - textSize.Width) / 2,
                    chartArea.Y + (chartArea.Height - textSize.Height) / 2
                );
                g.DrawString(message, font, textBrush, textLocation);
            }
        }

        private GraphicsPath CreateRoundedRectangle(int x, int y, int width, int height, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            path.AddArc(x + width - radius * 2, y, radius * 2, radius * 2, 270, 90);
            path.AddArc(x + width - radius * 2, y + height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(x, y + height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        private void ExportReportData()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx";
                saveDialog.DefaultExt = "csv";
                saveDialog.FileName = $"Patient_Report_{DateTime.Now:yyyyMMdd_HHmmss}";

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
                string headers = string.Join(",", dgvDailyReport.Columns.Cast<DataGridViewColumn>().Select(col => col.HeaderText));
                writer.WriteLine(headers);

                // Write data rows
                foreach (DataGridViewRow row in dgvDailyReport.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var rowData = row.Cells.Cast<DataGridViewCell>().Select(cell => {
                            string cellValue = cell.Value?.ToString() ?? "";
                            return cellValue.Contains(",") || cellValue.Contains("\"") ?
                                   $"\"{cellValue.Replace("\"", "\"\"")}\"" : cellValue;
                        });
                        writer.WriteLine(string.Join(",", rowData));
                    }
                }
            }
        }

        private void MakeRounded(Control control, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(control.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(control.Width - radius * 2, control.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(0, control.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseAllFigures();
                control.Region = new Region(path);
            }
        }

        private void SetupScrollableContent()
        {
            // Set minimum size for the scrollable container content
            // This ensures horizontal scrolling when content is wider than container
            panelScrollableContainer.AutoScrollMinSize = new Size(1460, 800);
            
            // Enable smooth scrolling
            panelScrollableContainer.AutoScroll = true;
            
            // Set scroll bar appearance
            panelScrollableContainer.HorizontalScroll.Visible = true;
            panelScrollableContainer.VerticalScroll.Visible = true;
            
            // Adjust scroll increments for better user experience
            panelScrollableContainer.AutoScrollMargin = new Size(20, 20);
        }
    }
}