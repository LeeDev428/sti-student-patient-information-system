namespace sti_student_patient_information_system
{
    partial class login
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblForgotPassword;
        private PictureBox picLogo;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblSubtitle2;
        private Label lblSubtitle3;
        private Panel panelMain;
        private Button btnShowPassword;

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
            this.panelMain = new Panel();
            this.txtEmail = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnShowPassword = new Button();
            this.lblForgotPassword = new Label();
            this.picLogo = new PictureBox();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblSubtitle2 = new Label();
            this.lblSubtitle3 = new Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.BackColor = Color.FromArgb(30, 100, 200); // Deep blue gradient background
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "STI C.A.R.E.S - Login";

            // Main Panel
            this.panelMain.BackColor = Color.FromArgb(30, 100, 200);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.txtEmail);
            this.panelMain.Controls.Add(this.txtPassword);
            this.panelMain.Controls.Add(this.btnShowPassword);
            this.panelMain.Controls.Add(this.btnLogin);
            this.panelMain.Controls.Add(this.lblForgotPassword);
            this.panelMain.Controls.Add(this.picLogo);
            this.panelMain.Controls.Add(this.lblSubtitle);
            this.panelMain.Controls.Add(this.lblSubtitle2);
            this.panelMain.Controls.Add(this.lblSubtitle3);

            // Title - Stethoscope + LOGIN
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 52F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(255, 193, 7); // Golden yellow
            this.lblTitle.Location = new Point(130, 120);
            this.lblTitle.Text = "🩺 LOGIN";
            this.lblTitle.BackColor = Color.Transparent;

            // Email TextBox - Rounded appearance
            this.txtEmail.Font = new Font("Segoe UI", 16F);
            this.txtEmail.Location = new Point(130, 240);
            this.txtEmail.Size = new Size(500, 50);
            this.txtEmail.Text = "Email Address:";
            this.txtEmail.ForeColor = Color.Gray;
            this.txtEmail.BackColor = Color.White;
            this.txtEmail.BorderStyle = BorderStyle.None;
            this.txtEmail.Multiline = true;
            this.txtEmail.TextAlign = HorizontalAlignment.Left;
            this.txtEmail.Padding = new Padding(15, 15, 15, 15);
            this.txtEmail.Enter += new EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new EventHandler(this.txtEmail_Leave);

            // Password TextBox - Rounded appearance
            this.txtPassword.Font = new Font("Segoe UI", 16F);
            this.txtPassword.Location = new Point(130, 320);
            this.txtPassword.Size = new Size(500, 50);
            this.txtPassword.Text = "Password:";
            this.txtPassword.ForeColor = Color.Gray;
            this.txtPassword.BackColor = Color.White;
            this.txtPassword.BorderStyle = BorderStyle.None;
            this.txtPassword.Multiline = true;
            this.txtPassword.TextAlign = HorizontalAlignment.Left;
            this.txtPassword.Padding = new Padding(15, 15, 50, 15);
            this.txtPassword.Enter += new EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new EventHandler(this.txtPassword_Leave);

            // Show/Hide Password Button
            this.btnShowPassword.BackColor = Color.Transparent;
            this.btnShowPassword.FlatStyle = FlatStyle.Flat;
            this.btnShowPassword.FlatAppearance.BorderSize = 0;
            this.btnShowPassword.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnShowPassword.ForeColor = Color.Black;
            this.btnShowPassword.Location = new Point(580, 335);
            this.btnShowPassword.Size = new Size(30, 20);
            this.btnShowPassword.Text = "👁";
            this.btnShowPassword.UseVisualStyleBackColor = false;
            this.btnShowPassword.Click += new EventHandler(this.btnShowPassword_Click);

            // Forgot Password Label
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            this.lblForgotPassword.ForeColor = Color.White;
            this.lblForgotPassword.Location = new Point(500, 385);
            this.lblForgotPassword.Text = "Forget password";
            this.lblForgotPassword.Cursor = Cursors.Hand;
            this.lblForgotPassword.Click += new EventHandler(this.lblForgotPassword_Click);

            // Login Button - Rounded golden button
            this.btnLogin.BackColor = Color.FromArgb(255, 193, 7);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.Black;
            this.btnLogin.Location = new Point(230, 430);
            this.btnLogin.Size = new Size(300, 60);
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // Logo PictureBox - STI College Logo
            this.picLogo.Location = new Point(700, 150);
            this.picLogo.Size = new Size(350, 180);
            this.picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picLogo.BackColor = Color.Transparent;

            // C.A.R.E.S Title
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 42F, FontStyle.Bold);
            this.lblSubtitle.ForeColor = Color.FromArgb(255, 193, 7);
            this.lblSubtitle.Location = new Point(700, 350);
            this.lblSubtitle.Text = "C.A.R.E.S";
            this.lblSubtitle.BackColor = Color.Transparent;

            // Clinic Automated Records
            this.lblSubtitle2.AutoSize = true;
            this.lblSubtitle2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblSubtitle2.ForeColor = Color.White;
            this.lblSubtitle2.Location = new Point(700, 420);
            this.lblSubtitle2.Text = "Clinic Automated Records";
            this.lblSubtitle2.BackColor = Color.Transparent;

            // Entry System
            this.lblSubtitle3.AutoSize = true;
            this.lblSubtitle3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblSubtitle3.ForeColor = Color.White;
            this.lblSubtitle3.Location = new Point(780, 450);
            this.lblSubtitle3.Text = "Entry System";
            this.lblSubtitle3.BackColor = Color.Transparent;

            this.Controls.Add(this.panelMain);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        // Event handlers for placeholder text
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email Address:")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email Address:";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password:")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password:";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "Password:" && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
                btnShowPassword.Text = txtPassword.UseSystemPasswordChar ? "👁" : "🙈";
            }
        }
    }
}