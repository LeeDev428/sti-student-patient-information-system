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

        // New: container panels + icon picture boxes
        private Panel pnlEmail;
        private Panel pnlPassword;
        private PictureBox pbEmailIcon;
        private PictureBox pbPasswordIcon;

        // New: track current visibility state
        private bool _passwordVisible = false;

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
            panelMain = new Panel();
            lblTitle = new Label();

            // new containers + icons
            pnlEmail = new Panel();
            pbEmailIcon = new PictureBox();
            txtEmail = new TextBox();

            pnlPassword = new Panel();
            pbPasswordIcon = new PictureBox();
            txtPassword = new TextBox();
            btnShowPassword = new Button();

            btnLogin = new Button();
            lblForgotPassword = new Label();
            picLogo = new PictureBox();
            lblSubtitle = new Label();
            lblSubtitle2 = new Label();
            lblSubtitle3 = new Label();

            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbEmailIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();

            // panelMain
            panelMain.BackColor = Color.FromArgb(0, 74, 173);
            panelMain.Controls.Add(lblTitle);

            // add new panels (each contains its children)
            panelMain.Controls.Add(pnlEmail);
            panelMain.Controls.Add(pnlPassword);

            panelMain.Controls.Add(btnLogin);
            panelMain.Controls.Add(lblForgotPassword);
            panelMain.Controls.Add(picLogo);
            panelMain.Controls.Add(lblSubtitle);
            panelMain.Controls.Add(lblSubtitle2);
            panelMain.Controls.Add(lblSubtitle3);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1200, 700);
            panelMain.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 52F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 193, 7);
            lblTitle.Location = new Point(130, 120);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(459, 116);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\U0001fa7a LOGIN";

            // pnlEmail
            pnlEmail.BackColor = Color.White;
            pnlEmail.Location = new Point(130, 240);
            pnlEmail.Name = "pnlEmail";
            pnlEmail.Size = new Size(500, 50);
            pnlEmail.Padding = new Padding(48, 8, 12, 8);

            // pbEmailIcon
            pbEmailIcon.BackColor = Color.Transparent;
            pbEmailIcon.Location = new Point(12, 10);
            pbEmailIcon.Name = "pbEmailIcon";
            pbEmailIcon.Size = new Size(28, 28);
            pbEmailIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbEmailIcon.Image = LoadProjectImage("mail.png");
            pnlEmail.Controls.Add(pbEmailIcon);

            // txtEmail
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 16F);
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Dock = DockStyle.Fill;
            // Email can be single-line too for consistency
            txtEmail.AutoSize = false;
            txtEmail.Multiline = false;
            txtEmail.Height = 34;
            txtEmail.Name = "txtEmail";
            txtEmail.TabIndex = 1;
            txtEmail.Text = "Email Address:";
            txtEmail.Enter += txtEmail_Enter;
            txtEmail.Leave += txtEmail_Leave;
            pnlEmail.Controls.Add(txtEmail);

            // pnlPassword
            pnlPassword.BackColor = Color.White;
            pnlPassword.Location = new Point(130, 320);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(500, 50);
            pnlPassword.Padding = new Padding(48, 8, 44, 8);

            // pbPasswordIcon
            pbPasswordIcon.BackColor = Color.Transparent;
            pbPasswordIcon.Location = new Point(12, 10);
            pbPasswordIcon.Name = "pbPasswordIcon";
            pbPasswordIcon.Size = new Size(28, 28);
            pbPasswordIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbPasswordIcon.Image = LoadProjectImage("key.png");
            pnlPassword.Controls.Add(pbPasswordIcon);

            // txtPassword (must be single-line for masking to work)
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 16F);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.AutoSize = false;
            txtPassword.Multiline = false; // IMPORTANT
            txtPassword.Height = 34;       // fits 50px panel with 8px top/bottom padding
            txtPassword.Name = "txtPassword";
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Password:";
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            txtPassword.TextChanged += txtPassword_TextChanged; // keep mask synced with state
            pnlPassword.Controls.Add(txtPassword);

            // btnShowPassword (inside pnlPassword, on the right)
            btnShowPassword.BackColor = Color.White; // match panel background
            btnShowPassword.FlatAppearance.BorderSize = 0;
            btnShowPassword.FlatStyle = FlatStyle.Flat;
            btnShowPassword.Location = new Point(pnlPassword.Width - 36 - 6, 7);
            btnShowPassword.Size = new Size(36, 36);
            btnShowPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowPassword.TabIndex = 3;
            btnShowPassword.Cursor = Cursors.Hand;
            btnShowPassword.BackgroundImageLayout = ImageLayout.Zoom;
            btnShowPassword.BackgroundImage = LoadPasswordIcon(isHidden: true);
            btnShowPassword.Click += btnShowPassword_Click;
            pnlPassword.Controls.Add(btnShowPassword);

            // btnLogin
            btnLogin.BackColor = Color.FromArgb(255, 193, 7);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(230, 430);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 60);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;

            // lblForgotPassword
            lblForgotPassword.AutoSize = true;
            lblForgotPassword.Cursor = Cursors.Hand;
            lblForgotPassword.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            lblForgotPassword.ForeColor = Color.White;
            lblForgotPassword.Location = new Point(472, 373);
            lblForgotPassword.Name = "lblForgotPassword";
            lblForgotPassword.Size = new Size(158, 28);
            lblForgotPassword.TabIndex = 5;
            lblForgotPassword.Text = "Forget password";
            lblForgotPassword.Click += lblForgotPassword_Click;

            // picLogo
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(721, 149);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(350, 180);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 6;
            picLogo.TabStop = false;
            picLogo.Click += picLogo_Click;

            // lblSubtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 42F, FontStyle.Bold);
            lblSubtitle.ForeColor = Color.FromArgb(255, 193, 7);
            lblSubtitle.Location = new Point(730, 344);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(331, 93);
            lblSubtitle.TabIndex = 7;
            lblSubtitle.Text = "C.A.R.E.S";
            lblSubtitle.Click += lblSubtitle_Click;

            // lblSubtitle2
            lblSubtitle2.AutoSize = true;
            lblSubtitle2.BackColor = Color.Transparent;
            lblSubtitle2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSubtitle2.ForeColor = Color.FromArgb(255, 193, 7);
            lblSubtitle2.Location = new Point(722, 430);
            lblSubtitle2.Name = "lblSubtitle2";
            lblSubtitle2.Size = new Size(349, 37);
            lblSubtitle2.TabIndex = 8;
            lblSubtitle2.Text = "Clinic Automated Records";
            lblSubtitle2.Click += lblSubtitle2_Click;

            // lblSubtitle3
            lblSubtitle3.AutoSize = true;
            lblSubtitle3.BackColor = Color.Transparent;
            lblSubtitle3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSubtitle3.ForeColor = Color.FromArgb(255, 193, 7);
            lblSubtitle3.Location = new Point(801, 467);
            lblSubtitle3.Name = "lblSubtitle3";
            lblSubtitle3.Size = new Size(184, 37);
            lblSubtitle3.TabIndex = 9;
            lblSubtitle3.Text = "Entry System";
            lblSubtitle3.Click += lblSubtitle3_Click;

            // login (form)
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 74, 173);
            ClientSize = new Size(1200, 700);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "STI C.A.R.E.S - Login";
            Load += login_Load;

            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbEmailIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
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

                // User is about to type -> default to hidden
                _passwordVisible = false;
                txtPassword.UseSystemPasswordChar = true;
                btnShowPassword.BackgroundImage = LoadPasswordIcon(isHidden: true);
            }
            else
            {
                // Ensure mask reflects current visibility state
                txtPassword.UseSystemPasswordChar = !_passwordVisible;
                btnShowPassword.BackgroundImage = LoadPasswordIcon(isHidden: !_passwordVisible);
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password:";
                txtPassword.ForeColor = Color.Gray;

                // Placeholder state (not masking)
                _passwordVisible = false;
                txtPassword.UseSystemPasswordChar = false;
                btnShowPassword.BackgroundImage = LoadPasswordIcon(isHidden: true);
            }
        }

        // Keep mask in sync whenever user types
        private void txtPassword_TextChanged(object? sender, EventArgs e)
        {
            if (txtPassword.Text == "Password:" || string.IsNullOrEmpty(txtPassword.Text))
                return;

            txtPassword.UseSystemPasswordChar = !_passwordVisible;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password:" || string.IsNullOrWhiteSpace(txtPassword.Text))
                return;

            // Toggle visibility
            _passwordVisible = !_passwordVisible;
            txtPassword.UseSystemPasswordChar = !_passwordVisible;

            // Update icon: hidden when masked, show when visible
            btnShowPassword.BackgroundImage = LoadPasswordIcon(isHidden: !_passwordVisible);
        }

        private void login_Load(object? sender, EventArgs e)
        {
            // Initial icon should be "hidden"
            btnShowPassword.BackgroundImage = LoadPasswordIcon(isHidden: true);
        }

        // Load from Images folder or embedded resources
        private System.Drawing.Image LoadProjectImage(string fileName)
        {
            try
            {
                var baseDir = AppContext.BaseDirectory;
                var path = System.IO.Path.Combine(baseDir, "Images", fileName);
                if (System.IO.File.Exists(path))
                {
                    return System.Drawing.Image.FromFile(path);
                }

                var asm = typeof(login).Assembly;
                var key = System.IO.Path.GetFileNameWithoutExtension(fileName);

                foreach (var resName in asm.GetManifestResourceNames())
                {
                    if (resName.EndsWith(fileName, StringComparison.OrdinalIgnoreCase) ||
                        resName.Contains($"{key}.", StringComparison.OrdinalIgnoreCase) ||
                        resName.Contains($"{key}_", StringComparison.OrdinalIgnoreCase) ||
                        resName.EndsWith($"{key}", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = asm.GetManifestResourceStream(resName);
                        if (stream != null)
                        {
                            return System.Drawing.Image.FromStream(stream);
                        }
                    }
                }
            }
            catch
            {
                // ignore and fallback
            }

            return new System.Drawing.Bitmap(1, 1);
        }

        // Choose the correct password icon with graceful fallbacks
        private System.Drawing.Image LoadPasswordIcon(bool isHidden)
        {
            string[] candidates = isHidden
                ? new[] { "hidden.png", "hide.png", "visibility_off.png", "eye_slash.png" }
                : new[] { "show.png", "view.png", "visibility_on.png", "eye.png" };

            foreach (var name in candidates)
            {
                var img = LoadProjectImage(name);
                if (img.Width == 1 && img.Height == 1)
                {
                    img.Dispose();
                    continue;
                }
                return img;
            }

            return new System.Drawing.Bitmap(1, 1);
        }
    }
}