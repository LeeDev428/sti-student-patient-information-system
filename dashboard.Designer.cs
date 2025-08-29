using System.Drawing.Drawing2D;

namespace sti_student_patient_information_system
{
    partial class dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panelCalendar;
        private Panel panelChart;
        private Label lblTodayPatients;
        private Label lblMonthlyPatients;
        private Label lblTodayCount;
        private Label lblMonthlyCount;
        private Panel panelModernCalendar;
        private ListBox lstEvents;
        private Label lblCalendarTitle;
        private Panel panelTodayStats;
        private Panel panelMonthlyStats;
        private Panel panelSearchContainer;
        private Label lblCalendarMonth;
        private Button btnPrevMonth;
        private Button btnNextMonth;
        private Panel panelCalendarGrid;

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
            this.lblWelcome = new Label();
            this.panelSearchContainer = new Panel();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.panelCalendar = new Panel();
            this.panelChart = new Panel();
            this.lblTodayPatients = new Label();
            this.lblMonthlyPatients = new Label();
            this.lblTodayCount = new Label();
            this.lblMonthlyCount = new Label();
            this.panelModernCalendar = new Panel();
            this.lstEvents = new ListBox();
            this.lblCalendarTitle = new Label();
            this.panelTodayStats = new Panel();
            this.panelMonthlyStats = new Panel();
            this.lblCalendarMonth = new Label();
            this.btnPrevMonth = new Button();
            this.btnNextMonth = new Button();
            this.panelCalendarGrid = new Panel();
            this.panelSearchContainer.SuspendLayout();
            this.panelCalendar.SuspendLayout();
            this.panelModernCalendar.SuspendLayout();
            this.panelTodayStats.SuspendLayout();
            this.panelMonthlyStats.SuspendLayout();
            this.SuspendLayout();

            // Welcome Label - MOVED BACK and repositioned
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.Black;
            this.lblWelcome.Location = new Point(80, 20);
            this.lblWelcome.Text = "Welcome back, System Administrator!";

            // Search Container Panel - REPOSITIONED higher
            this.panelSearchContainer.BackColor = Color.FromArgb(252, 211, 77);
            this.panelSearchContainer.Location = new Point(80, 80);
            this.panelSearchContainer.Size = new Size(520, 50);
            this.panelSearchContainer.Controls.Add(this.txtSearch);
            this.panelSearchContainer.Controls.Add(this.btnSearch);

            // Search TextBox - Better positioning
            this.txtSearch.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            this.txtSearch.Location = new Point(15, 12);
            this.txtSearch.Size = new Size(450, 26);
            this.txtSearch.Text = "Search ID Number, LastName, GivenName";
            this.txtSearch.ForeColor = Color.FromArgb(107, 114, 128);
            this.txtSearch.BackColor = Color.FromArgb(252, 211, 77);
            this.txtSearch.BorderStyle = BorderStyle.None;
            this.txtSearch.Enter += new EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new EventHandler(this.txtSearch_Leave);

            // Search Button - Fixed positioning
            this.btnSearch.BackColor = Color.Transparent;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new Font("Segoe UI", 16F);
            this.btnSearch.ForeColor = Color.Black;
            this.btnSearch.Location = new Point(470, 10);
            this.btnSearch.Size = new Size(30, 30);
            this.btnSearch.Text = "🔍";
            this.btnSearch.UseVisualStyleBackColor = false;

            // Calendar Panel - MODERN DESIGN
            this.panelCalendar.BackColor = Color.FromArgb(156, 163, 175);
            this.panelCalendar.Location = new Point(50, 160);
            this.panelCalendar.Size = new Size(350, 500);
            this.panelCalendar.Controls.Add(this.lblCalendarTitle);
            this.panelCalendar.Controls.Add(this.panelModernCalendar);
            this.panelCalendar.Controls.Add(this.lstEvents);

            // Calendar Title
            this.lblCalendarTitle.AutoSize = true;
            this.lblCalendarTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblCalendarTitle.ForeColor = Color.Black;
            this.lblCalendarTitle.Location = new Point(20, 20);
            this.lblCalendarTitle.Text = "📅 Calendar";

            // MODERN CALENDAR PANEL
            this.panelModernCalendar.BackColor = Color.White;
            this.panelModernCalendar.Location = new Point(20, 60);
            this.panelModernCalendar.Size = new Size(310, 180);
            this.panelModernCalendar.Controls.Add(this.btnPrevMonth);
            this.panelModernCalendar.Controls.Add(this.lblCalendarMonth);
            this.panelModernCalendar.Controls.Add(this.btnNextMonth);
            this.panelModernCalendar.Controls.Add(this.panelCalendarGrid);

            // Previous Month Button
            this.btnPrevMonth.BackColor = Color.Transparent;
            this.btnPrevMonth.FlatStyle = FlatStyle.Flat;
            this.btnPrevMonth.FlatAppearance.BorderSize = 0;
            this.btnPrevMonth.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnPrevMonth.ForeColor = Color.FromArgb(107, 114, 128);
            this.btnPrevMonth.Location = new Point(10, 10);
            this.btnPrevMonth.Size = new Size(30, 30);
            this.btnPrevMonth.Text = "<";
            this.btnPrevMonth.UseVisualStyleBackColor = false;

            // Calendar Month Label
            this.lblCalendarMonth.AutoSize = true;
            this.lblCalendarMonth.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblCalendarMonth.ForeColor = Color.Black;
            this.lblCalendarMonth.Location = new Point(115, 15);
            this.lblCalendarMonth.Text = "AUGUST 2025";

            // Next Month Button
            this.btnNextMonth.BackColor = Color.Transparent;
            this.btnNextMonth.FlatStyle = FlatStyle.Flat;
            this.btnNextMonth.FlatAppearance.BorderSize = 0;
            this.btnNextMonth.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnNextMonth.ForeColor = Color.FromArgb(107, 114, 128);
            this.btnNextMonth.Location = new Point(270, 10);
            this.btnNextMonth.Size = new Size(30, 30);
            this.btnNextMonth.Text = ">";
            this.btnNextMonth.UseVisualStyleBackColor = false;

            // Calendar Grid Panel
            this.panelCalendarGrid.BackColor = Color.White;
            this.panelCalendarGrid.Location = new Point(10, 50);
            this.panelCalendarGrid.Size = new Size(290, 120);
            this.panelCalendarGrid.Paint += new PaintEventHandler(this.panelCalendarGrid_Paint);

            // Events List - Modern styling
            this.lstEvents.Location = new Point(20, 260);
            this.lstEvents.Size = new Size(310, 220);
            this.lstEvents.BackColor = Color.White;
            this.lstEvents.BorderStyle = BorderStyle.None;
            this.lstEvents.Font = new Font("Segoe UI", 11F);
            this.lstEvents.Items.Add("📅 Today: 8/29/2025");
            this.lstEvents.Items.Add("");
            this.lstEvents.Items.Add("🟡 10:30 - 11:00am");
            this.lstEvents.Items.Add("   Seminar");
            this.lstEvents.Items.Add("");
            this.lstEvents.Items.Add("🟡 12:30 - 1:00pm");
            this.lstEvents.Items.Add("   Blood Donation Drive");

            // Today's Patient Stats Panel
            this.panelTodayStats.BackColor = Color.FromArgb(209, 213, 219);
            this.panelTodayStats.Location = new Point(440, 160);
            this.panelTodayStats.Size = new Size(240, 120);
            this.panelTodayStats.Controls.Add(this.lblTodayPatients);
            this.panelTodayStats.Controls.Add(this.lblTodayCount);

            // Today's Patient Label
            this.lblTodayPatients.AutoSize = true;
            this.lblTodayPatients.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTodayPatients.ForeColor = Color.Black;
            this.lblTodayPatients.Location = new Point(20, 20);
            this.lblTodayPatients.Text = "Today's Patient";

            // Today's Count
            this.lblTodayCount.AutoSize = true;
            this.lblTodayCount.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            this.lblTodayCount.ForeColor = Color.FromArgb(37, 99, 235);
            this.lblTodayCount.Location = new Point(80, 45);
            this.lblTodayCount.Text = "4";

            // Monthly Patient Stats Panel
            this.panelMonthlyStats.BackColor = Color.FromArgb(209, 213, 219);
            this.panelMonthlyStats.Location = new Point(720, 160);
            this.panelMonthlyStats.Size = new Size(240, 120);
            this.panelMonthlyStats.Controls.Add(this.lblMonthlyPatients);
            this.panelMonthlyStats.Controls.Add(this.lblMonthlyCount);

            // Monthly Patient Label
            this.lblMonthlyPatients.AutoSize = true;
            this.lblMonthlyPatients.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblMonthlyPatients.ForeColor = Color.Black;
            this.lblMonthlyPatients.Location = new Point(20, 20);
            this.lblMonthlyPatients.Text = "Monthly Patient";

            // Monthly Count
            this.lblMonthlyCount.AutoSize = true;
            this.lblMonthlyCount.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            this.lblMonthlyCount.ForeColor = Color.FromArgb(37, 99, 235);
            this.lblMonthlyCount.Location = new Point(80, 45);
            this.lblMonthlyCount.Text = "4";

            // Chart Panel
            this.panelChart.BackColor = Color.White;
            this.panelChart.Location = new Point(440, 310);
            this.panelChart.Size = new Size(520, 350);
            this.panelChart.Paint += new PaintEventHandler(this.panelChart_Paint);

            // ADD CONTROLS TO THE USERCONTROL (NOT panelMain)
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.panelSearchContainer);
            this.Controls.Add(this.panelCalendar);
            this.Controls.Add(this.panelTodayStats);
            this.Controls.Add(this.panelMonthlyStats);
            this.Controls.Add(this.panelChart);

            // UserControl properties
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 245, 251);
            this.Size = new Size(1000, 700);

            this.panelSearchContainer.ResumeLayout(false);
            this.panelSearchContainer.PerformLayout();
            this.panelCalendar.ResumeLayout(false);
            this.panelCalendar.PerformLayout();
            this.panelModernCalendar.ResumeLayout(false);
            this.panelModernCalendar.PerformLayout();
            this.panelTodayStats.ResumeLayout(false);
            this.panelTodayStats.PerformLayout();
            this.panelMonthlyStats.ResumeLayout(false);
            this.panelMonthlyStats.PerformLayout();
            this.ResumeLayout(false);
        }

        // Search placeholder functionality
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search ID Number, LastName, GivenName")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search ID Number, LastName, GivenName";
                txtSearch.ForeColor = Color.FromArgb(107, 114, 128);
            }
        }

        // Modern Calendar Grid Paint Event
        private void panelCalendarGrid_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Days of week headers
            string[] dayHeaders = { "S", "M", "T", "W", "T", "F", "S" };
            Font headerFont = new Font("Segoe UI", 9F, FontStyle.Bold);

            for (int i = 0; i < 7; i++)
            {
                int x = 5 + (i * 40);
                g.DrawString(dayHeaders[i], headerFont, Brushes.Gray, x + 15, 5);
            }

            // Calendar days - August 2025
            string[,] calendar = {
                {"27", "28", "29", "30", "31", "1", "2"},
                {"3", "4", "5", "6", "7", "8", "9"},
                {"10", "11", "12", "13", "14", "15", "16"},
                {"17", "18", "19", "20", "21", "22", "23"},
                {"24", "25", "26", "27", "28", "29", "30"},
                {"31", "1", "2", "3", "4", "5", "6"}
            };

            Font dayFont = new Font("Segoe UI", 9F);

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    int x = 5 + (col * 40);
                    int y = 25 + (row * 15);

                    string day = calendar[row, col];
                    Brush textBrush = Brushes.Black;

                    // Highlight today (29th)
                    if (day == "29" && row == 0)
                    {
                        g.FillRectangle(Brushes.Blue, x + 10, y - 2, 20, 16);
                        textBrush = Brushes.White;
                    }
                    // Gray out previous/next month days
                    else if ((row == 0 && int.Parse(day) > 25) || (row == 5 && int.Parse(day) < 10))
                    {
                        textBrush = Brushes.LightGray;
                    }

                    g.DrawString(day, dayFont, textBrush, x + 15, y);
                }
            }
        }
    }
}