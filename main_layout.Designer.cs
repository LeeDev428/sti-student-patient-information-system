namespace sti_student_patient_information_system
{
    partial class main_layout
    {
        private System.ComponentModel.IContainer components = null;
        protected Panel panelSidebar;
        protected Panel panelMain;
        protected Panel panelHeader;
        protected Label lblUserName;
        public Button btnDashboard;
        public Button btnAddPatient;
        public Button btnReports;
        public Button btnInventory;
        public Button btnSettings;
        public Button btnLogout;
        protected PictureBox picUserAvatar;
    protected PictureBox picLogo;
    protected PictureBox picBellIcon;
    protected Panel panelUserCircle;
    protected Label lblBellBadge;

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
            this.panelSidebar = new Panel();
            this.panelMain = new Panel();
            this.panelHeader = new Panel();
            this.lblUserName = new Label();
            this.btnDashboard = new Button();
            this.btnAddPatient = new Button();
            this.btnReports = new Button();
            this.btnInventory = new Button();
            this.btnSettings = new Button();
            this.btnLogout = new Button();
            this.picUserAvatar = new PictureBox();
            this.picLogo = new PictureBox();
            this.picBellIcon = new PictureBox();
            this.panelUserCircle = new Panel();
            this.lblBellBadge = new Label();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBellIcon)).BeginInit();
            this.SuspendLayout();

            // Form - EXACT size as in image, not fullscreen
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 800);
            this.BackColor = Color.FromArgb(240, 245, 251);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "STI C.A.R.E.S";
            this.MinimumSize = new Size(1200, 700);

            // Header Panel - EXACT blue color from image
            this.panelHeader.BackColor = Color.FromArgb(0, 74, 173);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 80;
            this.panelHeader.Controls.Add(this.picBellIcon);
            this.panelHeader.Controls.Add(this.lblBellBadge);
            this.panelHeader.Controls.Add(this.panelUserCircle);
            this.panelHeader.Controls.Add(this.lblUserName);
            this.panelHeader.Controls.Add(this.picLogo);

            // Bell Icon - position and size matching screenshot
            this.picBellIcon.BackColor = Color.Transparent;
            this.picBellIcon.Location = new Point(18, 16);
            this.picBellIcon.Size = new Size(32, 32);
            this.picBellIcon.SizeMode = PictureBoxSizeMode.Zoom;
            // Load bell icon from Images folder
            try {
                this.picBellIcon.Image = sti_student_patient_information_system.Properties.Resources.bell;
            } catch { /* swallow - designer should still load */ }

            // Bell badge (red circle with count)
            this.lblBellBadge.BackColor = Color.FromArgb(239, 68, 68);
            this.lblBellBadge.ForeColor = Color.White;
            this.lblBellBadge.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblBellBadge.Text = "1";
            this.lblBellBadge.TextAlign = ContentAlignment.MiddleCenter;
            this.lblBellBadge.Size = new Size(16, 16);
            // position on top-right of bell icon
            this.lblBellBadge.Location = new Point(this.picBellIcon.Location.X + 22, this.picBellIcon.Location.Y + 4);
            // make circular
            try {
                var _gpBadge = new System.Drawing.Drawing2D.GraphicsPath();
                _gpBadge.AddEllipse(0, 0, this.lblBellBadge.Width, this.lblBellBadge.Height);
                this.lblBellBadge.Region = new Region(_gpBadge);
            } catch { }

            // User Avatar - EXACT position from image
            // User avatar will be placed inside a circular white panel to create a bordered circular avatar
            this.panelUserCircle.BackColor = Color.White;
            this.panelUserCircle.Location = new Point(54, 12);
            this.panelUserCircle.Size = new Size(44, 44);
            // make panel circular
            try {
                var _gpPanel = new System.Drawing.Drawing2D.GraphicsPath();
                _gpPanel.AddEllipse(0, 0, this.panelUserCircle.Width, this.panelUserCircle.Height);
                this.panelUserCircle.Region = new Region(_gpPanel);
            } catch { }

            this.picUserAvatar.BackColor = Color.Transparent;
            this.picUserAvatar.Location = new Point(2, 2); // inside panel
            this.picUserAvatar.Size = new Size(40, 40);
            this.picUserAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            // make avatar itself circular
            try {
                var _gpAvatar = new System.Drawing.Drawing2D.GraphicsPath();
                _gpAvatar.AddEllipse(0, 0, this.picUserAvatar.Width, this.picUserAvatar.Height);
                this.picUserAvatar.Region = new Region(_gpAvatar);
            } catch { }
            // Load user avatar from resources
            try {
                this.picUserAvatar.Image = sti_student_patient_information_system.Properties.Resources.user;
            } catch { /* swallow - designer should still load */ }

            // add avatar into circular panel
            this.panelUserCircle.Controls.Add(this.picUserAvatar);

            // User Name Label - EXACT position and font from image
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new Font("Segoe UI", 16F, FontStyle.Regular);
            this.lblUserName.ForeColor = Color.White;
            this.lblUserName.Location = new Point(112, 26);
            this.lblUserName.Text = "User's Name";

            // Header Logo - EXACT position from image
            this.picLogo.Location = new Point(1180, 10);
            this.picLogo.Size = new Size(200, 60);
            this.picLogo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // maintain aspect ratio and look good when header expands
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            try {
                this.picLogo.Image = sti_student_patient_information_system.Properties.Resources.logo;
            } catch { }

            // removed small std image per request

            // Sidebar Panel - EXACT blue and width from image
            this.panelSidebar.BackColor = Color.FromArgb(0, 74, 173);
            this.panelSidebar.Dock = DockStyle.Right;
            this.panelSidebar.Width = 280;
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnSettings);
            this.panelSidebar.Controls.Add(this.btnInventory);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnAddPatient);
            this.panelSidebar.Controls.Add(this.btnDashboard);

            // Dashboard Button - EXACT golden active state
            this.btnDashboard.BackColor = Color.FromArgb(252, 211, 77);
            this.btnDashboard.FlatStyle = FlatStyle.Flat;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            this.btnDashboard.ForeColor = Color.Black;
            this.btnDashboard.Location = new Point(20, 30);
            this.btnDashboard.Size = new Size(240, 50);
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;

            // Add Patient Button - EXACT gray inactive state
            this.btnAddPatient.BackColor = Color.FromArgb(209, 213, 219);
            this.btnAddPatient.FlatStyle = FlatStyle.Flat;
            this.btnAddPatient.FlatAppearance.BorderSize = 0;
            this.btnAddPatient.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            this.btnAddPatient.ForeColor = Color.Black;
            this.btnAddPatient.Location = new Point(20, 100);
            this.btnAddPatient.Size = new Size(240, 50);
            this.btnAddPatient.Text = "Add Patient";
            this.btnAddPatient.UseVisualStyleBackColor = false;

            // Report Button - EXACT gray inactive state
            this.btnReports.BackColor = Color.FromArgb(209, 213, 219);
            this.btnReports.FlatStyle = FlatStyle.Flat;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            this.btnReports.ForeColor = Color.Black;
            this.btnReports.Location = new Point(20, 170);
            this.btnReports.Size = new Size(240, 50);
            this.btnReports.Text = "Report";
            this.btnReports.UseVisualStyleBackColor = false;

            // Inventory Button - EXACT gray inactive state
            this.btnInventory.BackColor = Color.FromArgb(209, 213, 219);
            this.btnInventory.FlatStyle = FlatStyle.Flat;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            this.btnInventory.ForeColor = Color.Black;
            this.btnInventory.Location = new Point(20, 240);
            this.btnInventory.Size = new Size(240, 50);
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = false;

            // Settings Button - EXACT gray inactive state, positioned lower
            this.btnSettings.BackColor = Color.FromArgb(209, 213, 219);
            this.btnSettings.FlatStyle = FlatStyle.Flat;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            this.btnSettings.ForeColor = Color.Black;
            this.btnSettings.Location = new Point(20, 450);
            this.btnSettings.Size = new Size(240, 50);
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;

            // Logout Button - EXACT gray inactive state
            this.btnLogout.BackColor = Color.FromArgb(209, 213, 219);
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            this.btnLogout.ForeColor = Color.Black;
            this.btnLogout.Location = new Point(20, 520);
            this.btnLogout.Size = new Size(240, 50);
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);

            // Main Panel - EXACT light background from image
            this.panelMain.BackColor = Color.FromArgb(240, 245, 251);
            this.panelMain.Dock = DockStyle.Fill;

            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);

            this.panelSidebar.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBellIcon)).EndInit();
            this.ResumeLayout(false);
        }

        protected virtual void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                login loginForm = new login();
                loginForm.Show();
                loginForm.FormClosed += (s, args) => Application.Exit();
            }
        }
    }
}