using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    public partial class main_layout : Form
    {
        protected string currentUserName;
        protected Panel contentPanel;

        public main_layout()
        {
            InitializeComponent();
            CreateContentPanel();
        }

        public main_layout(string userName) : this()
        {
            currentUserName = userName;
            lblUserName.Text = userName;
            LoadImages();
            ApplyRoundedButtons();
            SetupButtonEvents();

            // Show dashboard by default
            ShowDashboardContent();
        }

        private void CreateContentPanel()
        {
            contentPanel = new Panel();
            contentPanel.BackColor = Color.FromArgb(240, 245, 251);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.AutoScroll = true;
            panelMain.Controls.Add(contentPanel);
        }

        public void SwitchContent(Control newContent)
        {
            contentPanel.Controls.Clear();
            newContent.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(newContent);
        }

        private void SetupButtonEvents()
        {
            btnDashboard.Click += (s, e) => {
                SetActiveButton(btnDashboard);
                ShowDashboardContent();
            };

            btnAddPatient.Click += (s, e) => {
                SetActiveButton(btnAddPatient);
                ShowAddPatientContent();
            };

            // UPDATED: Add Reports functionality
            btnReports.Click += (s, e) => {
                SetActiveButton(btnReports);
                ShowReportsContent();
            };

            // UPDATED: Add Inventory functionality
            btnInventory.Click += (s, e) => {
                SetActiveButton(btnInventory);
                ShowInventoryContent();
            };

            btnSettings.Click += (s, e) => {
                SetActiveButton(btnSettings);
                MessageBox.Show("Settings functionality coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btnLogout.Click += (s, e) => {
                DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    login loginForm = new login();
                    loginForm.Show();
                    loginForm.FormClosed += (sender, args) => Application.Exit();
                }
            };
        }

        private void ShowDashboardContent()
        {
            dashboard dashContent = new dashboard();
            dashContent.SetupForMainLayout(currentUserName);
            SwitchContent(dashContent);
        }

        private void ShowAddPatientContent()
        {
            add_patients addContent = new add_patients();
            addContent.SetupForMainLayout(currentUserName, this);
            SwitchContent(addContent);
        }

        private void ShowReportsContent()
        {
            report reportContent = new report();
            reportContent.SetupForMainLayout(currentUserName, this);
            SwitchContent(reportContent);
        }

     
        private void ShowInventoryContent()
        {
            inventory inventoryContent = new inventory();
            inventoryContent.SetupForMainLayout(currentUserName, this);
            SwitchContent(inventoryContent);
        }

        private void LoadImages()
        {
            try
            {
                string[] logoMains = {
                    Path.Combine(Application.StartupPath, "sti-logo.png"),
                    Path.Combine(Application.StartupPath, "Images", "sti-logo.png"),
                    Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName, "sti-logo.png")
                };

                foreach (string logoPath in logoMains)
                {
                    if (File.Exists(logoPath))
                    {
                        picLogo.Image = Image.FromFile(logoPath);
                        break;
                    }
                }

                CreateBellIcon();
                CreateUserAvatar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading images: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CreateBellIcon()
        {
            Bitmap bell = new Bitmap(40, 40);
            using (Graphics g = Graphics.FromImage(bell))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Brush yellowBrush = new SolidBrush(Color.FromArgb(252, 211, 77)))
                {
                    g.FillEllipse(yellowBrush, 5, 5, 30, 30);
                }

                using (Font font = new Font("Segoe UI", 16, FontStyle.Regular))
                using (Brush blackBrush = new SolidBrush(Color.Black))
                {
                    g.DrawString("🔔", font, blackBrush, 8, 8);
                }

                using (Brush redBrush = new SolidBrush(Color.FromArgb(220, 38, 38)))
                {
                    g.FillEllipse(redBrush, 25, 5, 12, 12);
                }
            }
            picBellIcon.Image = bell;
        }

        private void CreateUserAvatar()
        {
            Bitmap avatar = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(avatar))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.FillEllipse(Brushes.White, 0, 0, 50, 50);

                using (Brush blueBrush = new SolidBrush(Color.FromArgb(37, 99, 235)))
                {
                    g.FillEllipse(blueBrush, 3, 3, 44, 44);
                }

                using (Font font = new Font("Segoe UI", 20, FontStyle.Regular))
                using (Brush whiteBrush = new SolidBrush(Color.White))
                {
                    g.DrawString("👤", font, whiteBrush, 10, 10);
                }
            }
            picUserAvatar.Image = avatar;
        }

        private void ApplyRoundedButtons()
        {
            MakeRounded(btnDashboard, 25);
            MakeRounded(btnAddPatient, 25);
            MakeRounded(btnReports, 25);
            MakeRounded(btnInventory, 25);
            MakeRounded(btnSettings, 25);
            MakeRounded(btnLogout, 25);
        }

        protected void MakeRounded(Control control, int radius)
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

        public void SetActiveButton(Button activeButton)
        {
            Button[] buttons = { btnDashboard, btnAddPatient, btnReports, btnInventory, btnSettings, btnLogout };

            foreach (Button btn in buttons)
            {
                btn.BackColor = Color.FromArgb(209, 213, 219);
                btn.ForeColor = Color.Black;
            }

            activeButton.BackColor = Color.FromArgb(252, 211, 77);
            activeButton.ForeColor = Color.Black;
        }

        // ADD PUBLIC PROPERTIES TO ACCESS BUTTONS
        public Button DashboardButton => btnDashboard;
        public Button AddPatientButton => btnAddPatient;
        public Button ReportsButton => btnReports;
        public Button InventoryButton => btnInventory;
        public Button SettingsButton => btnSettings;
        public Button LogoutButton => btnLogout;
    }
}