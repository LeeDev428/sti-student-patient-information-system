using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    public partial class login : Form
    {
        private bool isPasswordVisible = false;

        public login()
        {
            InitializeComponent();
            LoadLogo();
            SetupRoundedControls();
        }

        private void LoadLogo()
        {
            try
            {
                // Multiple possible paths for the logo
                string[] possiblePaths = {
                    Path.Combine(Application.StartupPath, "std.png"),
                    Path.Combine(Application.StartupPath, "Images", "std.png"),
                    Path.Combine(Application.StartupPath, "Resources", "sti-logo.png"),
                    Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName, "sti-logo.png"),
                    Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName, "Images", "sti-logo.png")
                };

                foreach (string logoPath in possiblePaths)
                {
                    if (File.Exists(logoPath))
                    {
                        picLogo.Image = Image.FromFile(logoPath);
                        return;
                    }
                }

                // If no logo found, create a placeholder
                CreateLogoPlaceholder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading logo: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CreateLogoPlaceholder();
            }
        }

        private void CreateLogoPlaceholder()
        {
            // Create STI logo placeholder
            Bitmap placeholder = new Bitmap(350, 180);
            using (Graphics g = Graphics.FromImage(placeholder))
            {
                g.Clear(Color.Transparent);

                // Draw orange globe-like shape
                using (Brush orangeBrush = new SolidBrush(Color.FromArgb(255, 165, 0)))
                {
                    g.FillEllipse(orangeBrush, 10, 10, 80, 80);
                }

                // Draw STI text
                using (Font font = new Font("Arial", 24, FontStyle.Bold))
                using (Brush blackBrush = new SolidBrush(Color.Black))
                using (Brush grayBrush = new SolidBrush(Color.Gray))
                {
                    g.DrawString("STI", font, blackBrush, 100, 20);
                    g.DrawString("College", new Font("Arial", 12), grayBrush, 100, 55);
                }
            }
            picLogo.Image = placeholder;
        }

        private void SetupRoundedControls()
        {
            // Make textboxes and button rounded
            MakeRounded(txtEmail, 25);
            MakeRounded(txtPassword, 25);
            MakeRounded(btnLogin, 30);
        }

        private void MakeRounded(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            control.Region = new Region(path);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text == "Email Address:" ? "" : txtEmail.Text.Trim();
            string password = txtPassword.Text == "Password:" ? "" : txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DatabaseHelper.ValidateUser(email, password))
            {
                string userName = DatabaseHelper.GetUserFullName(email);
                this.Hide();
                main_layout mainForm = new main_layout(userName); // CHANGED: Use main_layout
                mainForm.Show();
                mainForm.FormClosed += (s, args) => this.Close(); // FIXED: main_layout is a Form
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtPassword.Text != "Password:")
                {
                    txtPassword.Text = "Password:";
                    txtPassword.ForeColor = Color.Gray;
                    txtPassword.UseSystemPasswordChar = false;
                }
                txtEmail.Focus();
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact the system administrator to reset your password.", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, EventArgs.Empty);
            }
            base.OnKeyDown(e);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void lblSubtitle2_Click(object sender, EventArgs e)
        {

        }

        private void lblSubtitle3_Click(object sender, EventArgs e)
        {

        }
    }
}