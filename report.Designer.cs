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
        private ComboBox cmbSearchFilter;
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
            this.lblReportTitle = new Label();
            this.panelReportContainer = new Panel();
            this.dgvDailyReport = new DataGridView();
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
            this.panelStats = new Panel();
            this.lblTotalPatientsTitle = new Label();
            this.lblTotalPatients = new Label();
            this.lblTodayRegistrationsTitle = new Label();
            this.lblTodayRegistrations = new Label();

            this.panelReportContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyReport)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelDateRange.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();

            // Report Title
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblReportTitle.ForeColor = Color.Black;
            this.lblReportTitle.Location = new Point(50, 20);
            this.lblReportTitle.Text = "Daily Report";

            // Report Container Panel
            this.panelReportContainer.BackColor = Color.FromArgb(209, 213, 219);
            this.panelReportContainer.Location = new Point(50, 80);
            this.panelReportContainer.Size = new Size(650, 500);
            this.panelReportContainer.Controls.Add(this.dgvDailyReport);

            // DataGridView for report
            this.dgvDailyReport.AllowUserToAddRows = false;
            this.dgvDailyReport.AllowUserToDeleteRows = false;
            this.dgvDailyReport.BackgroundColor = Color.White;
            this.dgvDailyReport.BorderStyle = BorderStyle.None;
            this.dgvDailyReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailyReport.Dock = DockStyle.Fill;
            this.dgvDailyReport.Location = new Point(0, 0);
            this.dgvDailyReport.ReadOnly = true;
            this.dgvDailyReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDailyReport.Size = new Size(650, 500);

            // Filters Panel
            this.panelFilters.BackColor = Color.FromArgb(209, 213, 219);
            this.panelFilters.Location = new Point(720, 80);
            this.panelFilters.Size = new Size(300, 400);
            this.panelFilters.Controls.Add(this.lblSearchFilter);
            this.panelFilters.Controls.Add(this.cmbSearchFilter);
            this.panelFilters.Controls.Add(this.lblDateRange);
            this.panelFilters.Controls.Add(this.panelDateRange);
            this.panelFilters.Controls.Add(this.btnApply);
            this.panelFilters.Controls.Add(this.btnCancel);
            this.panelFilters.Controls.Add(this.btnExportData);

            // Search Filter Label
            this.lblSearchFilter.AutoSize = true;
            this.lblSearchFilter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblSearchFilter.ForeColor = Color.Black;
            this.lblSearchFilter.Location = new Point(20, 20);
            this.lblSearchFilter.Text = "Search Filter";

            // Search Filter ComboBox
            this.cmbSearchFilter.BackColor = Color.FromArgb(252, 211, 77);
            this.cmbSearchFilter.Font = new Font("Segoe UI", 11F);
            this.cmbSearchFilter.FormattingEnabled = true;
            this.cmbSearchFilter.Items.AddRange(new object[] { "Today", "This Week", "This Month", "Custom" });
            this.cmbSearchFilter.Location = new Point(20, 50);
            this.cmbSearchFilter.Size = new Size(260, 28);
            this.cmbSearchFilter.SelectedIndex = 0;

            // Date Range Label
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblDateRange.ForeColor = Color.Black;
            this.lblDateRange.Location = new Point(20, 100);
            this.lblDateRange.Text = "Date Range Picker:";

            // Date Range Panel
            this.panelDateRange.BackColor = Color.FromArgb(252, 211, 77);
            this.panelDateRange.Location = new Point(20, 130);
            this.panelDateRange.Size = new Size(260, 80);
            this.panelDateRange.Visible = false;
            this.panelDateRange.Controls.Add(this.dtpFromDate);
            this.panelDateRange.Controls.Add(this.lblToDate);
            this.panelDateRange.Controls.Add(this.dtpToDate);

            // From Date Picker
            this.dtpFromDate.Font = new Font("Segoe UI", 10F);
            this.dtpFromDate.Format = DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new Point(10, 10);
            this.dtpFromDate.Size = new Size(120, 25);
            this.dtpFromDate.Value = DateTime.Today;

            // To Label
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblToDate.ForeColor = Color.Black;
            this.lblToDate.Location = new Point(140, 13);
            this.lblToDate.Text = "-";

            // To Date Picker
            this.dtpToDate.Font = new Font("Segoe UI", 10F);
            this.dtpToDate.Format = DateTimePickerFormat.Short;
            this.dtpToDate.Location = new Point(160, 10);
            this.dtpToDate.Size = new Size(90, 25);
            this.dtpToDate.Value = DateTime.Today;

            // Apply Button
            this.btnApply.BackColor = Color.FromArgb(37, 99, 235);
            this.btnApply.FlatStyle = FlatStyle.Flat;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnApply.ForeColor = Color.White;
            this.btnApply.Location = new Point(20, 230);
            this.btnApply.Size = new Size(80, 35);
            this.btnApply.Text = "Apply";

            // Cancel Button
            this.btnCancel.BackColor = Color.FromArgb(37, 99, 235);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(110, 230);
            this.btnCancel.Size = new Size(80, 35);
            this.btnCancel.Text = "Cancel";

            // Export Data Button
            this.btnExportData.BackColor = Color.FromArgb(37, 99, 235);
            this.btnExportData.FlatStyle = FlatStyle.Flat;
            this.btnExportData.FlatAppearance.BorderSize = 0;
            this.btnExportData.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnExportData.ForeColor = Color.White;
            this.btnExportData.Location = new Point(20, 280);
            this.btnExportData.Size = new Size(100, 35);
            this.btnExportData.Text = "Export Data";

            // Stats Panel
            this.panelStats.BackColor = Color.FromArgb(209, 213, 219);
            this.panelStats.Location = new Point(720, 500);
            this.panelStats.Size = new Size(300, 120);
            this.panelStats.Controls.Add(this.lblTotalPatientsTitle);
            this.panelStats.Controls.Add(this.lblTotalPatients);
            this.panelStats.Controls.Add(this.lblTodayRegistrationsTitle);
            this.panelStats.Controls.Add(this.lblTodayRegistrations);

            // Total Patients Title
            this.lblTotalPatientsTitle.AutoSize = true;
            this.lblTotalPatientsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalPatientsTitle.ForeColor = Color.Black;
            this.lblTotalPatientsTitle.Location = new Point(20, 20);
            this.lblTotalPatientsTitle.Text = "Total Patients:";

            // Total Patients Count
            this.lblTotalPatients.AutoSize = true;
            this.lblTotalPatients.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTotalPatients.ForeColor = Color.FromArgb(37, 99, 235);
            this.lblTotalPatients.Location = new Point(150, 15);
            this.lblTotalPatients.Text = "0";

            // Today Registrations Title
            this.lblTodayRegistrationsTitle.AutoSize = true;
            this.lblTodayRegistrationsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTodayRegistrationsTitle.ForeColor = Color.Black;
            this.lblTodayRegistrationsTitle.Location = new Point(20, 60);
            this.lblTodayRegistrationsTitle.Text = "Today's Registrations:";

            // Today Registrations Count
            this.lblTodayRegistrations.AutoSize = true;
            this.lblTodayRegistrations.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTodayRegistrations.ForeColor = Color.FromArgb(37, 99, 235);
            this.lblTodayRegistrations.Location = new Point(200, 55);
            this.lblTodayRegistrations.Text = "0";

            // UserControl properties
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 245, 251);
            this.Size = new Size(1100, 650);

            // Add controls to UserControl
            this.Controls.Add(this.lblReportTitle);
            this.Controls.Add(this.panelReportContainer);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelStats);

            this.panelReportContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyReport)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelDateRange.ResumeLayout(false);
            this.panelDateRange.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}