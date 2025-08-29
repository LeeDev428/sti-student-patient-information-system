using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    public partial class dashboard : UserControl
    {
        private string currentUserName;
        private DateTime currentDate = DateTime.Now;

        public dashboard()
        {
            InitializeComponent();
        }

        public void SetupForMainLayout(string userName)
        {
            currentUserName = userName;
            LoadDashboardData();
            SetupDashboardEvents();
            ApplyRoundedPanels();
            UpdateCalendarDisplay();
        }

        private void SetupDashboardEvents()
        {
            // Calendar navigation
            if (btnPrevMonth != null)
            {
                btnPrevMonth.Click += (s, e) => {
                    currentDate = currentDate.AddMonths(-1);
                    UpdateCalendarDisplay();
                };
            }

            if (btnNextMonth != null)
            {
                btnNextMonth.Click += (s, e) => {
                    currentDate = currentDate.AddMonths(1);
                    UpdateCalendarDisplay();
                };
            }

            // Search functionality
            if (btnSearch != null)
            {
                btnSearch.Click += (s, e) => {
                    PerformSearch();
                };
            }

            if (txtSearch != null)
            {
                txtSearch.KeyPress += (s, e) => {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        PerformSearch();
                    }
                };
            }
        }

        private void PerformSearch()
        {
            string searchTerm = txtSearch?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm == "Search ID Number, LastName, GivenName")
            {
                MessageBox.Show("Please enter a search term.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DataTable results = DatabaseHelper.SearchPatients(searchTerm);
                if (results.Rows.Count > 0)
                {
                    ShowSearchResults(results);
                }
                else
                {
                    MessageBox.Show("No patients found matching your search criteria.", "Search Results",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching patients: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSearchResults(DataTable results)
        {
            Form searchForm = new Form();
            searchForm.Text = "Search Results";
            searchForm.Size = new Size(800, 600);
            searchForm.StartPosition = FormStartPosition.CenterParent;

            DataGridView dgv = new DataGridView();
            dgv.DataSource = results;
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            searchForm.Controls.Add(dgv);
            searchForm.ShowDialog(this);
        }

        private void UpdateCalendarDisplay()
        {
            if (lblCalendarMonth != null)
            {
                lblCalendarMonth.Text = currentDate.ToString("MMMM yyyy").ToUpper();
            }

            if (panelCalendarGrid != null)
            {
                panelCalendarGrid.Invalidate();
            }
        }

        private void ApplyRoundedPanels()
        {
            // Apply rounded corners to dashboard-specific panels
            if (panelSearchContainer != null) MakeRounded(panelSearchContainer, 25);
            if (panelCalendar != null) MakeRounded(panelCalendar, 20);
            if (panelModernCalendar != null) MakeRounded(panelModernCalendar, 15);
            if (panelTodayStats != null) MakeRounded(panelTodayStats, 20);
            if (panelMonthlyStats != null) MakeRounded(panelMonthlyStats, 20);
            if (panelChart != null) MakeRounded(panelChart, 20);
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

        private void LoadDashboardData()
        {
            try
            {
                DataTable data = DatabaseHelper.GetDashboardData();
                if (data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];
                    if (lblTodayCount != null)
                        lblTodayCount.Text = row["today_patients"].ToString();
                    if (lblMonthlyCount != null)
                        lblMonthlyCount.Text = row["monthly_patients"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void RefreshDashboardData()
        {
            LoadDashboardData();
        }

        private void panelChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color[] chartColors = {
                Color.FromArgb(45, 212, 191),
                Color.FromArgb(59, 130, 246),
                Color.FromArgb(16, 185, 129),
                Color.FromArgb(79, 70, 229),
                Color.FromArgb(107, 114, 128)
            };

            int[] heights = { 60, 80, 150, 120, 200 };
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri" };

            using (Font titleFont = new Font("Segoe UI", 14F, FontStyle.Bold))
            {
                g.DrawString("Weekly Patient Visits", titleFont, Brushes.Black, 20, 10);
            }

            for (int i = 0; i < days.Length; i++)
            {
                using (Brush brush = new SolidBrush(chartColors[i]))
                {
                    g.FillEllipse(brush, 30 + (i * 90), 40, 8, 8);
                    using (Font font = new Font("Segoe UI", 8F))
                    {
                        g.DrawString(days[i], font, Brushes.Black, 45 + (i * 90), 37);
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                int x = 50 + (i * 90);
                int y = 250 - heights[i];

                using (Brush brush = new SolidBrush(chartColors[i]))
                {
                    g.FillRectangle(brush, x, y, 50, heights[i]);
                }

                using (Font font = new Font("Segoe UI", 9F))
                {
                    g.DrawString(days[i], font, Brushes.Black, x + 15, 260);
                }
            }

            using (Pen gridPen = new Pen(Color.FromArgb(229, 231, 235), 1))
            {
                for (int i = 0; i <= 25; i += 5)
                {
                    int y = 250 - (i * 8);
                    g.DrawLine(gridPen, 40, y, 480, y);

                    using (Font font = new Font("Segoe UI", 8F))
                    {
                        g.DrawString(i.ToString(), font, Brushes.Gray, 20, y - 5);
                    }
                }
            }
        }
    }
}