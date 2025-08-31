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
            StyleSearchBar();
            StyleInfoCard(panelTodayStats);
            StyleInfoCard(panelMonthlyStats);
            UpdateCalendarDisplay();
        }

        private void SetupDashboardEvents()
        {
            // Calendar navigation
            if (btnPrevMonth != null)
            {
                btnPrevMonth.Click += (s, e) =>
                {
                    currentDate = currentDate.AddMonths(-1);
                    UpdateCalendarDisplay();
                };
            }

            if (btnNextMonth != null)
            {
                btnNextMonth.Click += (s, e) =>
                {
                    currentDate = currentDate.AddMonths(1);
                    UpdateCalendarDisplay();
                };
            }

            // Search functionality
            if (btnSearch != null)
            {
                btnSearch.Click += (s, e) =>
                {
                    PerformSearch();
                };
            }

            if (txtSearch != null)
            {
                txtSearch.KeyPress += (s, e) =>
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        PerformSearch();
                    }
                };
            }

            // Redraw chart when resized so it always fills the panel
            if (panelChart != null)
            {
                // Reapply rounded region on resize to avoid clipping, then trigger repaint
                panelChart.Resize += (s, e) =>
                {
                    try
                    {
                        // keep the same radius used in ApplyRoundedPanels
                        MakeRounded(panelChart, 20);
                    }
                    catch
                    {
                        // ignore sizing edge-cases during layout
                    }
                    panelChart.Invalidate();
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

        // new: style search bar to match example (size, spacing, placeholder)
        private void StyleSearchBar()
        {
            if (panelSearchContainer == null) return;

            panelSearchContainer.Padding = new Padding(14);
            panelSearchContainer.Margin = new Padding(10);
            panelSearchContainer.BackColor = Color.FromArgb(255, 243, 196); // soft yellow
            MakeRounded(panelSearchContainer, 25);

            if (txtSearch != null)
            {
                txtSearch.Font = new Font("Segoe UI", 12F);
                txtSearch.BorderStyle = BorderStyle.None;
                txtSearch.ForeColor = Color.FromArgb(34, 34, 34);
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search ID Number, LastName, GivenName";
                    txtSearch.Tag = "placeholder";
                    txtSearch.ForeColor = Color.FromArgb(130, 130, 130);
                }

                // ensure single wiring of handlers
                txtSearch.Enter -= TxtSearch_Enter;
                txtSearch.Leave -= TxtSearch_Leave;
                txtSearch.Enter += TxtSearch_Enter;
                txtSearch.Leave += TxtSearch_Leave;
            }

            if (btnSearch != null)
            {
                btnSearch.FlatStyle = FlatStyle.Flat;
                btnSearch.FlatAppearance.BorderSize = 0;
                btnSearch.BackColor = Color.Transparent;
                btnSearch.Cursor = Cursors.Hand;
                btnSearch.Padding = new Padding(6);
                btnSearch.Width = 40;
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox t && t.Tag?.ToString() == "placeholder")
            {
                t.Text = "";
                t.Tag = null;
                t.ForeColor = Color.FromArgb(34, 34, 34);
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox t && string.IsNullOrWhiteSpace(t.Text))
            {
                t.Text = "Search ID Number, LastName, GivenName";
                t.Tag = "placeholder";
                t.ForeColor = Color.FromArgb(130, 130, 130);
            }
        }

        // new: style info cards (size, spacing, fonts, rounded corners)
        private void StyleInfoCard(Control card)
        {
            if (card == null) return;

            // card visual adjustments for closer match to reference
            card.BackColor = Color.FromArgb(237, 239, 241); // slightly lighter card bg
            card.Padding = new Padding(20, 14, 20, 14);
            card.Margin = new Padding(12);
            card.MinimumSize = new Size(260, 160); // reasonable card height to fit numbers cleanly
            MakeRounded(card, 18);

            foreach (Control c in card.Controls)
            {
                if (c is Label lbl)
                {
                    // big numeric label convention: contains "count" or small font initially
                    if (lbl.Name != null && lbl.Name.ToLower().Contains("count"))
                    {
                        // prominent but not overflowing numeric label
                        lbl.Font = new Font("Segoe UI", 42F, FontStyle.Bold);
                        lbl.ForeColor = Color.FromArgb(37, 99, 235); // rich blue
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        // header label, aligned to top-left inside the card like the reference
                        lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                        lbl.ForeColor = Color.FromArgb(34, 34, 34);
                        lbl.Dock = DockStyle.Top;
                        lbl.TextAlign = ContentAlignment.MiddleLeft;
                        // ensure top padding remains visible
                        lbl.Padding = new Padding(16, 8, 12, 6);
                        // make sure header renders above any DockFill numeric label
                        try { lbl.BringToFront(); } catch { }
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

        // Fit-to-panel chart rendering (responsive)
        private void panelChart_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var client = panelChart.ClientRectangle;
            if (client.Width <= 0 || client.Height <= 0) return;

            Color[] chartColors =
            {
                Color.FromArgb(45, 212, 191),
                Color.FromArgb(56, 189, 248),
                Color.FromArgb(34, 197, 94),
                Color.FromArgb(59, 130, 246),
                Color.FromArgb(99, 102, 241)
            };

            int[] values = { 8, 13, 17, 20, 35 };
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            int barCount = days.Length;

            using (var titleFont = new Font("Segoe UI", 14F, FontStyle.Bold))
            using (var legendFont = new Font("Segoe UI", 7F))
            using (var yLabelFont = new Font("Segoe UI", 9F))
            {
                // measure title + legend
                const string title = "Weekly Patient Visits";
                var titleSize = g.MeasureString(title, titleFont);
                float legendItemGap = 18f;
                float circleSize = 10f;

                // compute total legend width
                float totalLegendWidth = 0f;
                for (int i = 0; i < barCount; i++)
                {
                    var txtSize = g.MeasureString(days[i], legendFont);
                    totalLegendWidth += circleSize + 4f + txtSize.Width;
                    if (i < barCount - 1) totalLegendWidth += legendItemGap;
                }

                // layout top area with extra padding so title/legend don't touch stats
                float topPadding = 12f;
                float extraTopPadding = 24f;
                float titleY = client.Top + topPadding + extraTopPadding;
                float legendY = titleY + titleSize.Height + 6f;
                float chartTop = legendY + legendFont.GetHeight(g) + 10f + 6f;

                // draw title centered
                float titleX = client.Left + (client.Width - titleSize.Width) / 2f;
                g.DrawString(title, titleFont, Brushes.Black, titleX, titleY);

                // draw legend centered
                float legendStartX = client.Left + (client.Width - totalLegendWidth) / 2f;
                float lx = legendStartX;
                for (int i = 0; i < barCount; i++)
                {
                    using (var brush = new SolidBrush(chartColors[i]))
                    {
                        g.FillEllipse(brush, lx, legendY, circleSize, circleSize);
                    }
                    g.DrawString(days[i], legendFont, Brushes.Gray, lx + circleSize + 4f, legendY - 2f);
                    var txtSize = g.MeasureString(days[i], legendFont);
                    lx += circleSize + 4f + txtSize.Width + legendItemGap;
                    // stop if legend would overflow horizontally
                    if (lx > client.Right - 20f) break;
                }

                // chart area inside panel (leave room for y labels and bottom labels)
                int marginLeft = 60;
                int marginRight = 36;
                int marginBottom = 56;
                var chartAreaF = new RectangleF(
                    client.Left + marginLeft,
                    client.Top + chartTop,
                    client.Width - marginLeft - marginRight,
                    client.Bottom - chartTop - marginBottom
                );
                if (chartAreaF.Width <= 0 || chartAreaF.Height <= 0) return;

                // draw grid & y labels
                int maxVal = 35;
                int gridLines = 7;
                using (var gridPen = new Pen(Color.FromArgb(229, 231, 235), 1f))
                {
                    for (int i = 0; i <= gridLines; i++)
                    {
                        float y = chartAreaF.Bottom - (i / (float)gridLines) * chartAreaF.Height;
                        g.DrawLine(gridPen, chartAreaF.Left, y, chartAreaF.Right, y);
                        string lbl = ((int)(i * maxVal / (float)gridLines)).ToString();
                        var lblSize = g.MeasureString(lbl, yLabelFont);
                        g.DrawString(lbl, yLabelFont, Brushes.Gray, chartAreaF.Left - lblSize.Width - 8f, y - lblSize.Height / 2f);
                    }
                }

                // compute bars widths & spacing (use floats)
                float rightSafePadding = 10f; // keep last bar from touching rounded corner
                float usableWidth = chartAreaF.Width - rightSafePadding;
                float totalBarArea = usableWidth * 0.75f; // portion for bars
                float barWidth = Math.Max(22f, totalBarArea / barCount);
                float spacing = (usableWidth - totalBarArea) / (barCount + 1);

                // ensure minimum spacing and recalc if necessary
                if (spacing < 6f)
                {
                    spacing = 6f;
                    float needed = spacing * (barCount + 1) + barCount * barWidth;
                    if (needed > usableWidth)
                    {
                        barWidth = Math.Max(18f, (usableWidth - spacing * (barCount + 1)) / barCount);
                    }
                }

                for (int i = 0; i < barCount; i++)
                {
                    float barHeight = (values[i] / (float)maxVal) * chartAreaF.Height;
                    float x = chartAreaF.Left + spacing + i * (barWidth + spacing);
                    // clip barWidth to remain inside area
                    float effectiveBarWidth = Math.Min(barWidth, chartAreaF.Right - rightSafePadding - x);
                    if (effectiveBarWidth <= 0) continue;

                    float y = chartAreaF.Bottom - barHeight;
                    var rect = new RectangleF(x, y, effectiveBarWidth, barHeight);

                    using (var barBrush = new SolidBrush(chartColors[i]))
                    using (var path = new GraphicsPath())
                    {
                        float radius = Math.Min(12f, rect.Height / 3f);
                        // top-left arc
                        path.AddArc(rect.Left, rect.Top, radius * 2f, radius * 2f, 180f, 90f);
                        // top-right arc
                        path.AddArc(rect.Right - radius * 2f, rect.Top, radius * 2f, radius * 2f, 270f, 90f);
                        // sides & bottom
                        path.AddLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom);
                        path.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
                        path.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top + radius);
                        path.CloseFigure();

                        g.FillPath(barBrush, path);
                    }

                    // draw day label centered under bar
                    using (var labelFont = new Font("Segoe UI", 10F))
                    {
                        var labelSize = g.MeasureString(days[i], labelFont);
                        float labelX = x + (effectiveBarWidth - labelSize.Width) / 2f;
                        float labelY = chartAreaF.Bottom + 8f;
                        g.DrawString(days[i], labelFont, Brushes.Black, labelX, labelY);
                    }
                }
            }
        }

        private void panelMonthlyStats_Paint(object sender, PaintEventArgs e)
        {
        }

        private void rootLayout_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}