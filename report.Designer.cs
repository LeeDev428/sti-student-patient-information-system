using System.Drawing;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    partial class report
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblReportTitle;
        private DataGridView dgvDailyReport;
        private Panel panelReportContainer;
        private Panel panelFilters;
        private Label lblSearchFilter;
        private Label lblDateRange;
        private Panel panelDateRange;
        private DateTimePicker dtpFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Button btnApply;
        private Button btnCancel;
        private Button btnExportData;
        private Panel panelStats;
        private Label lblTotalPatients;
        private Label lblTodayRegistrations;
        private Label lblTotalPatientsTitle;
        private Label lblTodayRegistrationsTitle;

        // NEW: Scrollable container
        private Panel panelScrollableContainer;

        // Modern Chart components
        private Panel panelChartsContainer;
        private Panel panelWeeklyChart;
        private Panel panelMonthlyChart;
        private Label lblWeeklyReport;
        private Label lblMonthlyReport;
        private Panel panelWeeklyControls;
        private Panel panelMonthlyControls;
        private DateTimePicker dtpWeeklyFrom;
        private DateTimePicker dtpWeeklyTo;
        private DateTimePicker dtpMonthlyFrom;
        private DateTimePicker dtpMonthlyTo;
        private Label lblWeeklyFromLabel;
        private Label lblWeeklyToLabel;
        private Label lblMonthlyFromLabel;
        private Label lblMonthlyToLabel;
        private Button btnWeeklyApply;
        private Button btnMonthlyApply;
        private ComboBox cmbSearchFilter;

        // Modern Chart Areas
        private Panel panelWeeklyChartArea;
        private Panel panelMonthlyChartArea;

        // Daily Report Section
        private Label lblDailyReportTitle;
        private Panel panelDailyReportHeader;

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
            // NEW: Create scrollable container first
            this.panelScrollableContainer = new Panel();

            this.lblReportTitle = new Label();

            // Charts Container
            this.panelChartsContainer = new Panel();
            this.panelWeeklyChart = new Panel();
            this.lblWeeklyReport = new Label();
            this.panelWeeklyControls = new Panel();
            this.lblWeeklyFromLabel = new Label();
            this.dtpWeeklyFrom = new DateTimePicker();
            this.lblWeeklyToLabel = new Label();
            this.dtpWeeklyTo = new DateTimePicker();
            this.btnWeeklyApply = new Button();
            this.panelWeeklyChartArea = new Panel();

            this.panelMonthlyChart = new Panel();
            this.lblMonthlyReport = new Label();
            this.panelMonthlyControls = new Panel();
            this.lblMonthlyFromLabel = new Label();
            this.dtpMonthlyFrom = new DateTimePicker();
            this.lblMonthlyToLabel = new Label();
            this.dtpMonthlyTo = new DateTimePicker();
            this.btnMonthlyApply = new Button();
            this.panelMonthlyChartArea = new Panel();

            // Daily Report Section
            this.panelDailyReportHeader = new Panel();
            this.lblDailyReportTitle = new Label();
            this.panelReportContainer = new Panel();
            this.dgvDailyReport = new DataGridView();

            // Filters Section
            this.panelFilters = new Panel();
            this.lblSearchFilter = new Label();
            this.cmbSearchFilter = new ComboBox();
            this.lblDateRange = new Label();
            this.panelDateRange = new Panel();
            this.dtpFromDate = new DateTimePicker();
            this.lblToDate = new Label();
            this.dtpToDate = new DateTimePicker();
            this.btnApply = new Button();
            this.btnCancel = new Button();
            this.btnExportData = new Button();

            // Stats
            this.panelStats = new Panel();
            this.lblTotalPatientsTitle = new Label();
            this.lblTotalPatients = new Label();
            this.lblTodayRegistrationsTitle = new Label();
            this.lblTodayRegistrations = new Label();

            this.panelScrollableContainer.SuspendLayout();
            this.panelChartsContainer.SuspendLayout();
            this.panelWeeklyChart.SuspendLayout();
            this.panelWeeklyControls.SuspendLayout();
            this.panelMonthlyChart.SuspendLayout();
            this.panelMonthlyControls.SuspendLayout();
            this.panelDailyReportHeader.SuspendLayout();
            this.panelReportContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyReport)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelDateRange.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();

            // ===== SCROLLABLE CONTAINER =====
            this.panelScrollableContainer.AutoScroll = true;
            this.panelScrollableContainer.BackColor = Color.FromArgb(248, 250, 252);
            this.panelScrollableContainer.Dock = DockStyle.Fill;
            this.panelScrollableContainer.Padding = new Padding(10);

            // ===== MAIN TITLE =====
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.lblReportTitle.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblReportTitle.Location = new Point(30, 20);
            this.lblReportTitle.Size = new Size(400, 51);
            this.lblReportTitle.Text = "Reports Dashboard";

            // ===== CHARTS CONTAINER =====
            this.panelChartsContainer.BackColor = Color.Transparent;
            this.panelChartsContainer.Location = new Point(30, 90);
            this.panelChartsContainer.Size = new Size(1220, 320);
            this.panelChartsContainer.Controls.Add(this.panelWeeklyChart);
            this.panelChartsContainer.Controls.Add(this.panelMonthlyChart);

            // ===== WEEKLY CHART PANEL =====
            this.panelWeeklyChart.BackColor = Color.White;
            this.panelWeeklyChart.Location = new Point(0, 0);
            this.panelWeeklyChart.Size = new Size(590, 320);
            this.panelWeeklyChart.BorderStyle = BorderStyle.None;
            // Add subtle shadow
            this.panelWeeklyChart.Paint += (s, e) => {
                var rect = this.panelWeeklyChart.ClientRectangle;
                rect.Width--; rect.Height--;
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(226, 232, 240), 1), rect);
            };

            // Weekly Chart Title
            this.lblWeeklyReport.AutoSize = true;
            this.lblWeeklyReport.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblWeeklyReport.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblWeeklyReport.Location = new Point(25, 20);
            this.lblWeeklyReport.Size = new Size(180, 32);
            this.lblWeeklyReport.Text = "Weekly Report";

            // Weekly Controls Panel
            this.panelWeeklyControls.BackColor = Color.FromArgb(248, 250, 252);
            this.panelWeeklyControls.Location = new Point(25, 60);
            this.panelWeeklyControls.Size = new Size(540, 50);

            // Weekly From Label
            this.lblWeeklyFromLabel.AutoSize = true;
            this.lblWeeklyFromLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblWeeklyFromLabel.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblWeeklyFromLabel.Location = new Point(15, 8);
            this.lblWeeklyFromLabel.Size = new Size(38, 19);
            this.lblWeeklyFromLabel.Text = "From:";

            // Weekly From Date Picker
            this.dtpWeeklyFrom.Font = new Font("Segoe UI", 10F);
            this.dtpWeeklyFrom.Format = DateTimePickerFormat.Short;
            this.dtpWeeklyFrom.Location = new Point(15, 25);
            this.dtpWeeklyFrom.Size = new Size(130, 25);
            this.dtpWeeklyFrom.Value = DateTime.Today.AddDays(-7);

            // Weekly To Label
            this.lblWeeklyToLabel.AutoSize = true;
            this.lblWeeklyToLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblWeeklyToLabel.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblWeeklyToLabel.Location = new Point(165, 8);
            this.lblWeeklyToLabel.Size = new Size(25, 19);
            this.lblWeeklyToLabel.Text = "To:";

            // Weekly To Date Picker
            this.dtpWeeklyTo.Font = new Font("Segoe UI", 10F);
            this.dtpWeeklyTo.Format = DateTimePickerFormat.Short;
            this.dtpWeeklyTo.Location = new Point(165, 25);
            this.dtpWeeklyTo.Size = new Size(130, 25);
            this.dtpWeeklyTo.Value = DateTime.Today;

            // Weekly Apply Button
            this.btnWeeklyApply.BackColor = Color.FromArgb(59, 130, 246);
            this.btnWeeklyApply.FlatStyle = FlatStyle.Flat;
            this.btnWeeklyApply.FlatAppearance.BorderSize = 0;
            this.btnWeeklyApply.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnWeeklyApply.ForeColor = Color.White;
            this.btnWeeklyApply.Location = new Point(315, 25);
            this.btnWeeklyApply.Size = new Size(80, 25);
            this.btnWeeklyApply.Text = "Apply";
            this.btnWeeklyApply.UseVisualStyleBackColor = false;

            // Weekly Chart Area
            this.panelWeeklyChartArea.BackColor = Color.White;
            this.panelWeeklyChartArea.Location = new Point(25, 120);
            this.panelWeeklyChartArea.Size = new Size(540, 180);
            this.panelWeeklyChartArea.BorderStyle = BorderStyle.FixedSingle;

            // Add controls to Weekly Controls Panel
            this.panelWeeklyControls.Controls.Add(this.lblWeeklyFromLabel);
            this.panelWeeklyControls.Controls.Add(this.dtpWeeklyFrom);
            this.panelWeeklyControls.Controls.Add(this.lblWeeklyToLabel);
            this.panelWeeklyControls.Controls.Add(this.dtpWeeklyTo);
            this.panelWeeklyControls.Controls.Add(this.btnWeeklyApply);

            // Add controls to Weekly Chart Panel
            this.panelWeeklyChart.Controls.Add(this.lblWeeklyReport);
            this.panelWeeklyChart.Controls.Add(this.panelWeeklyControls);
            this.panelWeeklyChart.Controls.Add(this.panelWeeklyChartArea);

            // ===== MONTHLY CHART PANEL =====
            this.panelMonthlyChart.BackColor = Color.White;
            this.panelMonthlyChart.Location = new Point(610, 0);
            this.panelMonthlyChart.Size = new Size(590, 320);
            this.panelMonthlyChart.BorderStyle = BorderStyle.None;
            // Add subtle shadow
            this.panelMonthlyChart.Paint += (s, e) => {
                var rect = this.panelMonthlyChart.ClientRectangle;
                rect.Width--; rect.Height--;
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(226, 232, 240), 1), rect);
            };

            // Monthly Chart Title
            this.lblMonthlyReport.AutoSize = true;
            this.lblMonthlyReport.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblMonthlyReport.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblMonthlyReport.Location = new Point(25, 20);
            this.lblMonthlyReport.Size = new Size(186, 32);
            this.lblMonthlyReport.Text = "Monthly Report";

            // Monthly Controls Panel
            this.panelMonthlyControls.BackColor = Color.FromArgb(248, 250, 252);
            this.panelMonthlyControls.Location = new Point(25, 60);
            this.panelMonthlyControls.Size = new Size(540, 50);

            // Monthly From Label
            this.lblMonthlyFromLabel.AutoSize = true;
            this.lblMonthlyFromLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblMonthlyFromLabel.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblMonthlyFromLabel.Location = new Point(15, 8);
            this.lblMonthlyFromLabel.Size = new Size(38, 19);
            this.lblMonthlyFromLabel.Text = "From:";

            // Monthly From Date Picker
            this.dtpMonthlyFrom.Font = new Font("Segoe UI", 10F);
            this.dtpMonthlyFrom.Format = DateTimePickerFormat.Short;
            this.dtpMonthlyFrom.Location = new Point(15, 25);
            this.dtpMonthlyFrom.Size = new Size(130, 25);
            this.dtpMonthlyFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            // Monthly To Label
            this.lblMonthlyToLabel.AutoSize = true;
            this.lblMonthlyToLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblMonthlyToLabel.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblMonthlyToLabel.Location = new Point(165, 8);
            this.lblMonthlyToLabel.Size = new Size(25, 19);
            this.lblMonthlyToLabel.Text = "To:";

            // Monthly To Date Picker
            this.dtpMonthlyTo.Font = new Font("Segoe UI", 10F);
            this.dtpMonthlyTo.Format = DateTimePickerFormat.Short;
            this.dtpMonthlyTo.Location = new Point(165, 25);
            this.dtpMonthlyTo.Size = new Size(130, 25);
            this.dtpMonthlyTo.Value = DateTime.Today;

            // Monthly Apply Button
            this.btnMonthlyApply.BackColor = Color.FromArgb(59, 130, 246);
            this.btnMonthlyApply.FlatStyle = FlatStyle.Flat;
            this.btnMonthlyApply.FlatAppearance.BorderSize = 0;
            this.btnMonthlyApply.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnMonthlyApply.ForeColor = Color.White;
            this.btnMonthlyApply.Location = new Point(315, 25);
            this.btnMonthlyApply.Size = new Size(80, 25);
            this.btnMonthlyApply.Text = "Apply";
            this.btnMonthlyApply.UseVisualStyleBackColor = false;

            // Monthly Chart Area
            this.panelMonthlyChartArea.BackColor = Color.White;
            this.panelMonthlyChartArea.Location = new Point(25, 120);
            this.panelMonthlyChartArea.Size = new Size(540, 180);
            this.panelMonthlyChartArea.BorderStyle = BorderStyle.FixedSingle;

            // Add controls to Monthly Controls Panel
            this.panelMonthlyControls.Controls.Add(this.lblMonthlyFromLabel);
            this.panelMonthlyControls.Controls.Add(this.dtpMonthlyFrom);
            this.panelMonthlyControls.Controls.Add(this.lblMonthlyToLabel);
            this.panelMonthlyControls.Controls.Add(this.dtpMonthlyTo);
            this.panelMonthlyControls.Controls.Add(this.btnMonthlyApply);

            // Add controls to Monthly Chart Panel
            this.panelMonthlyChart.Controls.Add(this.lblMonthlyReport);
            this.panelMonthlyChart.Controls.Add(this.panelMonthlyControls);
            this.panelMonthlyChart.Controls.Add(this.panelMonthlyChartArea);

            // ===== DAILY REPORT SECTION =====

            // Daily Report Header
            this.panelDailyReportHeader.BackColor = Color.White;
            this.panelDailyReportHeader.Location = new Point(30, 430);
            this.panelDailyReportHeader.Size = new Size(770, 60);
            this.panelDailyReportHeader.BorderStyle = BorderStyle.None;
            this.panelDailyReportHeader.Paint += (s, e) => {
                var rect = this.panelDailyReportHeader.ClientRectangle;
                rect.Width--; rect.Height--;
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(226, 232, 240), 1), rect);
            };

            // Daily Report Title
            this.lblDailyReportTitle.AutoSize = true;
            this.lblDailyReportTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblDailyReportTitle.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblDailyReportTitle.Location = new Point(25, 15);
            this.lblDailyReportTitle.Size = new Size(140, 32);
            this.lblDailyReportTitle.Text = "Daily Report";

            this.panelDailyReportHeader.Controls.Add(this.lblDailyReportTitle);

            // Daily Report Container
            this.panelReportContainer.BackColor = Color.White;
            this.panelReportContainer.Location = new Point(30, 495);
            this.panelReportContainer.Size = new Size(770, 280);
            this.panelReportContainer.BorderStyle = BorderStyle.None;
            this.panelReportContainer.Paint += (s, e) => {
                var rect = this.panelReportContainer.ClientRectangle;
                rect.Width--; rect.Height--;
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(226, 232, 240), 1), rect);
            };

            // DataGridView for daily report
            this.dgvDailyReport.AllowUserToAddRows = false;
            this.dgvDailyReport.AllowUserToDeleteRows = false;
            this.dgvDailyReport.BackgroundColor = Color.White;
            this.dgvDailyReport.BorderStyle = BorderStyle.None;
            this.dgvDailyReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailyReport.Location = new Point(15, 15);
            this.dgvDailyReport.Size = new Size(740, 250);
            this.dgvDailyReport.ReadOnly = true;
            this.dgvDailyReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDailyReport.GridColor = Color.FromArgb(226, 232, 240);
            this.dgvDailyReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            this.panelReportContainer.Controls.Add(this.dgvDailyReport);

            // ===== FILTERS PANEL =====
            this.panelFilters.BackColor = Color.White;
            this.panelFilters.Location = new Point(820, 430);
            this.panelFilters.Size = new Size(380, 345);
            this.panelFilters.BorderStyle = BorderStyle.None;
            this.panelFilters.Paint += (s, e) => {
                var rect = this.panelFilters.ClientRectangle;
                rect.Width--; rect.Height--;
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(226, 232, 240), 1), rect);
            };

            // Search Filter Label
            this.lblSearchFilter.AutoSize = true;
            this.lblSearchFilter.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblSearchFilter.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblSearchFilter.Location = new Point(25, 25);
            this.lblSearchFilter.Size = new Size(121, 25);
            this.lblSearchFilter.Text = "Search Filter";

            // Search Filter ComboBox
            this.cmbSearchFilter.BackColor = Color.FromArgb(249, 250, 251);
            this.cmbSearchFilter.Font = new Font("Segoe UI", 11F);
            this.cmbSearchFilter.FormattingEnabled = true;
            this.cmbSearchFilter.FlatStyle = FlatStyle.Flat;
            this.cmbSearchFilter.Items.AddRange(new object[] { "Today", "Yesterday", "This Week", "Last Week", "This Month", "Last Month", "Custom" });
            this.cmbSearchFilter.Location = new Point(25, 60);
            this.cmbSearchFilter.Size = new Size(330, 28);
            this.cmbSearchFilter.SelectedIndex = 0;

            // Date Range Label
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblDateRange.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblDateRange.Location = new Point(25, 110);
            this.lblDateRange.Size = new Size(161, 25);
            this.lblDateRange.Text = "Date Range Picker";

            // Date Range Panel
            this.panelDateRange.BackColor = Color.FromArgb(248, 250, 252);
            this.panelDateRange.Location = new Point(25, 145);
            this.panelDateRange.Size = new Size(330, 90);
            this.panelDateRange.Visible = false;
            this.panelDateRange.BorderStyle = BorderStyle.FixedSingle;

            // From Date Picker
            this.dtpFromDate.Font = new Font("Segoe UI", 10F);
            this.dtpFromDate.Format = DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new Point(15, 35);
            this.dtpFromDate.Size = new Size(130, 25);
            this.dtpFromDate.Value = DateTime.Today;

            // To Label
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblToDate.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblToDate.Location = new Point(155, 37);
            this.lblToDate.Size = new Size(19, 21);
            this.lblToDate.Text = "to";

            // To Date Picker
            this.dtpToDate.Font = new Font("Segoe UI", 10F);
            this.dtpToDate.Format = DateTimePickerFormat.Short;
            this.dtpToDate.Location = new Point(180, 35);
            this.dtpToDate.Size = new Size(130, 25);
            this.dtpToDate.Value = DateTime.Today;

            this.panelDateRange.Controls.Add(this.dtpFromDate);
            this.panelDateRange.Controls.Add(this.lblToDate);
            this.panelDateRange.Controls.Add(this.dtpToDate);

            // Buttons
            this.btnApply.BackColor = Color.FromArgb(34, 197, 94);
            this.btnApply.FlatStyle = FlatStyle.Flat;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnApply.ForeColor = Color.White;
            this.btnApply.Location = new Point(25, 260);
            this.btnApply.Size = new Size(85, 40);
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;

            this.btnCancel.BackColor = Color.FromArgb(107, 114, 128);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(120, 260);
            this.btnCancel.Size = new Size(85, 40);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;

            this.btnExportData.BackColor = Color.FromArgb(59, 130, 246);
            this.btnExportData.FlatStyle = FlatStyle.Flat;
            this.btnExportData.FlatAppearance.BorderSize = 0;
            this.btnExportData.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnExportData.ForeColor = Color.White;
            this.btnExportData.Location = new Point(215, 260);
            this.btnExportData.Size = new Size(140, 40);
            this.btnExportData.Text = "Export Data";
            this.btnExportData.UseVisualStyleBackColor = false;

            this.panelFilters.Controls.Add(this.lblSearchFilter);
            this.panelFilters.Controls.Add(this.cmbSearchFilter);
            this.panelFilters.Controls.Add(this.lblDateRange);
            this.panelFilters.Controls.Add(this.panelDateRange);
            this.panelFilters.Controls.Add(this.btnApply);
            this.panelFilters.Controls.Add(this.btnCancel);
            this.panelFilters.Controls.Add(this.btnExportData);

            // ===== STATS PANEL =====
            this.panelStats.BackColor = Color.White;
            this.panelStats.Location = new Point(1220, 430);
            this.panelStats.Size = new Size(220, 180);
            this.panelStats.BorderStyle = BorderStyle.None;
            this.panelStats.Paint += (s, e) => {
                var rect = this.panelStats.ClientRectangle;
                rect.Width--; rect.Height--;
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(226, 232, 240), 1), rect);
            };

            // Total Patients Title
            this.lblTotalPatientsTitle.AutoSize = true;
            this.lblTotalPatientsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTotalPatientsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblTotalPatientsTitle.Location = new Point(20, 25);
            this.lblTotalPatientsTitle.Size = new Size(113, 21);
            this.lblTotalPatientsTitle.Text = "Total Patients";

            // Total Patients Count
            this.lblTotalPatients.AutoSize = true;
            this.lblTotalPatients.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTotalPatients.ForeColor = Color.FromArgb(59, 130, 246);
            this.lblTotalPatients.Location = new Point(20, 50);
            this.lblTotalPatients.Size = new Size(37, 45);
            this.lblTotalPatients.Text = "0";

            // Today Registrations Title
            this.lblTodayRegistrationsTitle.AutoSize = true;
            this.lblTodayRegistrationsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTodayRegistrationsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblTodayRegistrationsTitle.Location = new Point(20, 105);
            this.lblTodayRegistrationsTitle.Size = new Size(130, 21);
            this.lblTodayRegistrationsTitle.Text = "Today's Patients";

            // Today Registrations Count
            this.lblTodayRegistrations.AutoSize = true;
            this.lblTodayRegistrations.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTodayRegistrations.ForeColor = Color.FromArgb(34, 197, 94);
            this.lblTodayRegistrations.Location = new Point(20, 130);
            this.lblTodayRegistrations.Size = new Size(37, 45);
            this.lblTodayRegistrations.Text = "0";

            this.panelStats.Controls.Add(this.lblTotalPatientsTitle);
            this.panelStats.Controls.Add(this.lblTotalPatients);
            this.panelStats.Controls.Add(this.lblTodayRegistrationsTitle);
            this.panelStats.Controls.Add(this.lblTodayRegistrations);

            // ===== ADD ALL CONTROLS TO SCROLLABLE CONTAINER =====
            this.panelScrollableContainer.Controls.Add(this.lblReportTitle);
            this.panelScrollableContainer.Controls.Add(this.panelChartsContainer);
            this.panelScrollableContainer.Controls.Add(this.panelDailyReportHeader);
            this.panelScrollableContainer.Controls.Add(this.panelReportContainer);
            this.panelScrollableContainer.Controls.Add(this.panelFilters);
            this.panelScrollableContainer.Controls.Add(this.panelStats);

            // ===== USER CONTROL PROPERTIES =====
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(248, 250, 252);

            // IMPORTANT: Add the scrollable container to the UserControl instead of individual controls
            this.Controls.Add(this.panelScrollableContainer);

            this.panelScrollableContainer.ResumeLayout(false);
            this.panelScrollableContainer.PerformLayout();
            this.panelChartsContainer.ResumeLayout(false);
            this.panelWeeklyChart.ResumeLayout(false);
            this.panelWeeklyChart.PerformLayout();
            this.panelWeeklyControls.ResumeLayout(false);
            this.panelWeeklyControls.PerformLayout();
            this.panelMonthlyChart.ResumeLayout(false);
            this.panelMonthlyChart.PerformLayout();
            this.panelMonthlyControls.ResumeLayout(false);
            this.panelMonthlyControls.PerformLayout();
            this.panelDailyReportHeader.ResumeLayout(false);
            this.panelDailyReportHeader.PerformLayout();
            this.panelReportContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyReport)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelDateRange.ResumeLayout(false);
            this.panelDateRange.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}