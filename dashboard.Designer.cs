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

        // New containers for responsive layout
        private TableLayoutPanel rootLayout;
    private TableLayoutPanel rightColumn;
        private TableLayoutPanel statsRow;

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
            lblWelcome = new Label();
            panelSearchContainer = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            rightColumn = new TableLayoutPanel();
            panelChart = new Panel();
            statsRow = new TableLayoutPanel();
            panelTodayStats = new Panel();
            lblTodayPatients = new Label();
            lblTodayCount = new Label();
            panelMonthlyStats = new Panel();
            lblMonthlyPatients = new Label();
            lblMonthlyCount = new Label();
            panelCalendar = new Panel();
            lblCalendarTitle = new Label();
            panelModernCalendar = new Panel();
            btnPrevMonth = new Button();
            lblCalendarMonth = new Label();
            btnNextMonth = new Button();
            panelCalendarGrid = new Panel();
            lstEvents = new ListBox();
            rootLayout = new TableLayoutPanel();
            panelSearchContainer.SuspendLayout();
            rightColumn.SuspendLayout();
            statsRow.SuspendLayout();
            panelTodayStats.SuspendLayout();
            panelMonthlyStats.SuspendLayout();
            panelCalendar.SuspendLayout();
            panelModernCalendar.SuspendLayout();
            rootLayout.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Black;
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(868, 62);
            lblWelcome.TabIndex = 3;
            lblWelcome.Text = "Welcome back, System Administrator!";
            // reduce bottom gap below welcome
            lblWelcome.Margin = new Padding(0, 0, 0, 8);
            // 
            // panelSearchContainer
            // 
            panelSearchContainer.BackColor = Color.FromArgb(255, 243, 196);
            panelSearchContainer.Controls.Add(txtSearch);
            panelSearchContainer.Controls.Add(btnSearch);
            panelSearchContainer.Dock = DockStyle.Top;
            panelSearchContainer.Location = new Point(0, 62);
            panelSearchContainer.Name = "panelSearchContainer";
            // pill-like padding (slightly reduced vertical padding)
            panelSearchContainer.Padding = new Padding(14, 10, 10, 10);
            panelSearchContainer.Size = new Size(880, 48);
            panelSearchContainer.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.BackColor = Color.FromArgb(255, 243, 196);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 14F);
            txtSearch.ForeColor = Color.FromArgb(107, 114, 128);
            txtSearch.Margin = new Padding(6, 6, 6, 6);
            txtSearch.Name = "txtSearch";
            // size will be controlled by docking
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Search ID Number, LastName, GivenName";
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Right;
            btnSearch.BackColor = Color.White;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 14F);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(48, 36);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // rightColumn as a TableLayoutPanel with explicit rows: Welcome, Search, Stats, Chart
            rightColumn.ColumnCount = 1;
            rightColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightColumn.RowCount = 4;
            // Welcome (Auto), Search (Auto), Stats (Absolute), Chart (Percent fill)
            rightColumn.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            // keep stats row consistent and slightly smaller for balance
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            // add controls into specific rows so layout is deterministic
            rightColumn.Controls.Add(lblWelcome, 0, 0);
            rightColumn.Controls.Add(panelSearchContainer, 0, 1);
            rightColumn.Controls.Add(statsRow, 0, 2);
            rightColumn.Controls.Add(panelChart, 0, 3);
            rightColumn.Dock = DockStyle.Fill;
            rightColumn.Location = new Point(447, 27);
            rightColumn.Name = "rightColumn";
            rightColumn.Size = new Size(880, 879);
            rightColumn.TabIndex = 1;
            // 
            // panelChart
            // 
            panelChart.BackColor = Color.White;
            panelChart.Dock = DockStyle.Fill;
            panelChart.Location = new Point(0, 290);
            // moderate top margin; painting also has internal padding
            panelChart.Margin = new Padding(0, 8, 0, 12);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(880, 600);
            panelChart.TabIndex = 0;
            panelChart.Paint += panelChart_Paint;
            // 
            // statsRow
            // 
            statsRow.ColumnCount = 2;
            statsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            statsRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            statsRow.Controls.Add(panelTodayStats, 0, 0);
            statsRow.Controls.Add(panelMonthlyStats, 1, 0);
            statsRow.Dock = DockStyle.Top;
            statsRow.Location = new Point(0, 118);
            statsRow.Name = "statsRow";
            statsRow.Padding = new Padding(0, 10, 0, 10);
            statsRow.RowCount = 1;
            // single-row layout inside the statsRow -- the container row in rightColumn controls height
            statsRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            statsRow.Size = new Size(880, 180);
            statsRow.TabIndex = 1;
            // 
            // panelTodayStats
            // 
            panelTodayStats.BackColor = Color.FromArgb(237, 239, 241);
            // add count first then header so header (Dock=Top) remains visible on top
            panelTodayStats.Controls.Add(lblTodayCount);
            panelTodayStats.Controls.Add(lblTodayPatients);
            panelTodayStats.Dock = DockStyle.Fill;
            panelTodayStats.Location = new Point(0, 12);
            // reduce horizontal gap between cards
            panelTodayStats.Margin = new Padding(0, 0, 8, 0);
            panelTodayStats.Name = "panelTodayStats";
            // card-like padding and rounded corners will be applied at runtime
            panelTodayStats.Padding = new Padding(20, 14, 20, 14);
            panelTodayStats.Size = new Size(440, 160);
            panelTodayStats.TabIndex = 0;
            // 
            // lblTodayPatients
            // 
            lblTodayPatients.AutoSize = false;
            lblTodayPatients.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTodayPatients.ForeColor = Color.FromArgb(34, 34, 34);
            lblTodayPatients.Name = "lblTodayPatients";
            lblTodayPatients.TabIndex = 0;
            lblTodayPatients.Text = "Today's Patient";
            lblTodayPatients.Dock = DockStyle.Top;
            lblTodayPatients.Padding = new Padding(12, 8, 12, 6);
            // 
            // lblTodayCount
            // 
            lblTodayCount.AutoSize = false;
            lblTodayCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblTodayCount.ForeColor = Color.FromArgb(37, 99, 235);
            lblTodayCount.Name = "lblTodayCount";
            lblTodayCount.TabIndex = 1;
            lblTodayCount.Text = "4";
            lblTodayCount.Dock = DockStyle.Fill;
            lblTodayCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelMonthlyStats
            // 
            panelMonthlyStats.BackColor = Color.FromArgb(237, 239, 241);
            // add count first then header so header (Dock=Top) remains visible on top
            panelMonthlyStats.Controls.Add(lblMonthlyCount);
            panelMonthlyStats.Controls.Add(lblMonthlyPatients);
            panelMonthlyStats.Location = new Point(448, 12);
            // reduce horizontal gap between cards
            panelMonthlyStats.Margin = new Padding(8, 0, 0, 0);
            panelMonthlyStats.Name = "panelMonthlyStats";
            panelMonthlyStats.Padding = new Padding(20, 14, 20, 14);
            panelMonthlyStats.Size = new Size(440, 160);
            panelMonthlyStats.TabIndex = 1;
            panelMonthlyStats.Paint += panelMonthlyStats_Paint;
            // 
            // lblMonthlyPatients
            // 
            lblMonthlyPatients.AutoSize = false;
            lblMonthlyPatients.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMonthlyPatients.ForeColor = Color.FromArgb(34, 34, 34);
            lblMonthlyPatients.Name = "lblMonthlyPatients";
            lblMonthlyPatients.TabIndex = 0;
            lblMonthlyPatients.Text = "Monthly Patient";
            lblMonthlyPatients.Dock = DockStyle.Top;
            lblMonthlyPatients.Padding = new Padding(12, 8, 12, 6);
            // 
            // lblMonthlyCount
            // 
            lblMonthlyCount.AutoSize = false;
            lblMonthlyCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblMonthlyCount.ForeColor = Color.FromArgb(37, 99, 235);
            lblMonthlyCount.Name = "lblMonthlyCount";
            lblMonthlyCount.TabIndex = 1;
            lblMonthlyCount.Text = "4";
            lblMonthlyCount.Dock = DockStyle.Fill;
            lblMonthlyCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCalendar
            // 
            panelCalendar.BackColor = Color.FromArgb(156, 163, 175);
            panelCalendar.Controls.Add(lblCalendarTitle);
            panelCalendar.Controls.Add(panelModernCalendar);
            panelCalendar.Controls.Add(lstEvents);
            panelCalendar.Dock = DockStyle.Fill;
            panelCalendar.Location = new Point(27, 27);
            panelCalendar.Name = "panelCalendar";
            panelCalendar.Padding = new Padding(16);
            panelCalendar.Size = new Size(414, 879);
            panelCalendar.TabIndex = 0;
            // 
            // lblCalendarTitle
            // 
            lblCalendarTitle.AutoSize = true;
            lblCalendarTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCalendarTitle.ForeColor = Color.Black;
            lblCalendarTitle.Location = new Point(20, 20);
            lblCalendarTitle.Name = "lblCalendarTitle";
            lblCalendarTitle.Size = new Size(176, 37);
            lblCalendarTitle.TabIndex = 0;
            lblCalendarTitle.Text = "📅 Calendar";
            // 
            // panelModernCalendar
            // 
            panelModernCalendar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelModernCalendar.BackColor = Color.White;
            panelModernCalendar.Controls.Add(btnPrevMonth);
            panelModernCalendar.Controls.Add(lblCalendarMonth);
            panelModernCalendar.Controls.Add(btnNextMonth);
            panelModernCalendar.Controls.Add(panelCalendarGrid);
            panelModernCalendar.Location = new Point(20, 60);
            panelModernCalendar.Name = "panelModernCalendar";
            panelModernCalendar.Size = new Size(634, 200);
            panelModernCalendar.TabIndex = 1;
            // 
            // btnPrevMonth
            // 
            btnPrevMonth.BackColor = Color.Transparent;
            btnPrevMonth.FlatAppearance.BorderSize = 0;
            btnPrevMonth.FlatStyle = FlatStyle.Flat;
            btnPrevMonth.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnPrevMonth.ForeColor = Color.FromArgb(107, 114, 128);
            btnPrevMonth.Location = new Point(11, 13);
            btnPrevMonth.Name = "btnPrevMonth";
            btnPrevMonth.Size = new Size(34, 40);
            btnPrevMonth.TabIndex = 0;
            btnPrevMonth.Text = "<";
            btnPrevMonth.UseVisualStyleBackColor = false;
            // 
            // lblCalendarMonth
            // 
            lblCalendarMonth.AutoSize = true;
            lblCalendarMonth.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCalendarMonth.ForeColor = Color.Black;
            lblCalendarMonth.Location = new Point(120, 20);
            lblCalendarMonth.Name = "lblCalendarMonth";
            lblCalendarMonth.Size = new Size(172, 32);
            lblCalendarMonth.TabIndex = 1;
            lblCalendarMonth.Text = "AUGUST 2025";
            // 
            // btnNextMonth
            // 
            btnNextMonth.BackColor = Color.Transparent;
            btnNextMonth.FlatAppearance.BorderSize = 0;
            btnNextMonth.FlatStyle = FlatStyle.Flat;
            btnNextMonth.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnNextMonth.ForeColor = Color.FromArgb(107, 114, 128);
            btnNextMonth.Location = new Point(420, 13);
            btnNextMonth.Name = "btnNextMonth";
            btnNextMonth.Size = new Size(34, 40);
            btnNextMonth.TabIndex = 2;
            btnNextMonth.Text = ">";
            btnNextMonth.UseVisualStyleBackColor = false;
            // 
            // panelCalendarGrid
            // 
            panelCalendarGrid.BackColor = Color.White;
            panelCalendarGrid.Location = new Point(11, 67);
            panelCalendarGrid.Name = "panelCalendarGrid";
            panelCalendarGrid.Size = new Size(420, 130);
            panelCalendarGrid.TabIndex = 3;
            panelCalendarGrid.Paint += panelCalendarGrid_Paint;
            // 
            // lstEvents
            // 
            lstEvents.BackColor = Color.White;
            lstEvents.BorderStyle = BorderStyle.None;
            lstEvents.Font = new Font("Segoe UI", 11F);
            lstEvents.ItemHeight = 25;
            lstEvents.Items.AddRange(new object[] { "📅 Today: 8/29/2025", "", "\U0001f7e1 10:30 - 11:00am", "   Seminar", "", "\U0001f7e1 12:30 - 1:00pm", "   Blood Donation Drive" });
            lstEvents.Location = new Point(20, 280);
            lstEvents.Name = "lstEvents";
            lstEvents.Size = new Size(420, 325);
            lstEvents.TabIndex = 2;
            // 
            // rootLayout
            // 
            rootLayout.BackColor = Color.Transparent;
            rootLayout.ColumnCount = 2;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 420F));
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(panelCalendar, 0, 0);
            rootLayout.Controls.Add(rightColumn, 1, 0);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(24);
            rootLayout.RowCount = 1;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.Size = new Size(1354, 933);
            rootLayout.TabIndex = 0;
            rootLayout.Paint += rootLayout_Paint;
            // 
            // dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 245, 251);
            Controls.Add(rootLayout);
            DoubleBuffered = true;
            Name = "dashboard";
            Size = new Size(1354, 933);
            panelSearchContainer.ResumeLayout(false);
            panelSearchContainer.PerformLayout();
            rightColumn.ResumeLayout(false);
            rightColumn.PerformLayout();
            statsRow.ResumeLayout(false);
            panelTodayStats.ResumeLayout(false);
            panelTodayStats.PerformLayout();
            panelMonthlyStats.ResumeLayout(false);
            panelMonthlyStats.PerformLayout();
            panelCalendar.ResumeLayout(false);
            panelCalendar.PerformLayout();
            panelModernCalendar.ResumeLayout(false);
            panelModernCalendar.PerformLayout();
            rootLayout.ResumeLayout(false);
            ResumeLayout(false);
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
                int x = 5 + (i * 44);
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
                    int x = 5 + (col * 44);
                    int y = 25 + (row * 18);

                    string day = calendar[row, col];
                    Brush textBrush = Brushes.Black;

                    // Highlight today (29th)
                    if (day == "29" && row == 0)
                    {
                        g.FillRectangle(Brushes.Blue, x + 10, y - 2, 22, 18);
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