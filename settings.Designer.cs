using System.Drawing;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    partial class settings
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblSettingsTitle;
        private Panel panelSettingsContainer;
        private PictureBox picProfilePhoto;
        private Button btnChangePhoto;
        private Label lblChangeUserInfo;
        private Label lblName;
        private TextBox txtName;
        private Label lblChangePassword;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
  
        private Button btnSave;

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
            this.lblSettingsTitle = new Label();
            this.panelSettingsContainer = new Panel();
            this.picProfilePhoto = new PictureBox();
            this.btnChangePhoto = new Button();
            this.lblChangeUserInfo = new Label();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblChangePassword = new Label();
            this.txtCurrentPassword = new TextBox();
            this.txtNewPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();
           
            this.btnSave = new Button();

            this.panelSettingsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePhoto)).BeginInit();
            this.SuspendLayout();

            // Settings Title
            this.lblSettingsTitle.AutoSize = true;
            this.lblSettingsTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblSettingsTitle.ForeColor = Color.Black;
            this.lblSettingsTitle.Location = new Point(50, 20);
            this.lblSettingsTitle.Text = "Settings";

            // Settings Container Panel - matches your image background
            this.panelSettingsContainer.BackColor = Color.FromArgb(209, 213, 219);
            this.panelSettingsContainer.Location = new Point(50, 80);
            this.panelSettingsContainer.Size = new Size(900, 450);

            // Profile Photo - matches your image (blue background with white silhouette)
            this.picProfilePhoto.BackColor = Color.FromArgb(37, 99, 235);
            this.picProfilePhoto.Location = new Point(50, 50);
            this.picProfilePhoto.Size = new Size(200, 250);
            this.picProfilePhoto.SizeMode = PictureBoxSizeMode.StretchImage;

            // Change Profile Photo Button - matches your image
            this.btnChangePhoto.BackColor = Color.Transparent;
            this.btnChangePhoto.FlatStyle = FlatStyle.Flat;
            this.btnChangePhoto.FlatAppearance.BorderSize = 0;
            this.btnChangePhoto.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            this.btnChangePhoto.ForeColor = Color.FromArgb(37, 99, 235);
            this.btnChangePhoto.Location = new Point(50, 320);
            this.btnChangePhoto.Size = new Size(150, 30);
            this.btnChangePhoto.Text = "📁 Change profile photo";
            this.btnChangePhoto.TextAlign = ContentAlignment.MiddleLeft;

            // Change User Information Label
            this.lblChangeUserInfo.AutoSize = true;
            this.lblChangeUserInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblChangeUserInfo.ForeColor = Color.Black;
            this.lblChangeUserInfo.Location = new Point(300, 50);
            this.lblChangeUserInfo.Text = "Change User Information";

            // Name Label
            this.lblName.AutoSize = true;
            this.lblName.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            this.lblName.ForeColor = Color.Black;
            this.lblName.Location = new Point(300, 90);
            this.lblName.Text = "Name:";

            // Name TextBox - matches your image
            this.txtName.Font = new Font("Segoe UI", 11F);
            this.txtName.Location = new Point(380, 88);
            this.txtName.Size = new Size(300, 27);
            this.txtName.Text = "Enter you Name";
            this.txtName.ForeColor = Color.Gray;

            // Change Password Label
            this.lblChangePassword.AutoSize = true;
            this.lblChangePassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblChangePassword.ForeColor = Color.Black;
            this.lblChangePassword.Location = new Point(300, 140);
            this.lblChangePassword.Text = "Change Password";

            // Current Password TextBox
            this.txtCurrentPassword.Font = new Font("Segoe UI", 11F);
            this.txtCurrentPassword.Location = new Point(380, 180);
            this.txtCurrentPassword.Size = new Size(250, 27);
            this.txtCurrentPassword.Text = "Current Password";
            this.txtCurrentPassword.ForeColor = Color.Gray;

            // New Password TextBox
            this.txtNewPassword.Font = new Font("Segoe UI", 11F);
            this.txtNewPassword.Location = new Point(380, 220);
            this.txtNewPassword.Size = new Size(250, 27);
            this.txtNewPassword.Text = "New Password";
            this.txtNewPassword.ForeColor = Color.Gray;

            // Confirm Password TextBox
            this.txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            this.txtConfirmPassword.Location = new Point(380, 260);
            this.txtConfirmPassword.Size = new Size(250, 27);
            this.txtConfirmPassword.Text = "Confirm Password";
            this.txtConfirmPassword.ForeColor = Color.Gray;

          

            // Save Button - matches your image
            this.btnSave.BackColor = Color.FromArgb(37, 99, 235);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(550, 320);
            this.btnSave.Size = new Size(80, 35);
            this.btnSave.Text = "Save";

            // Add controls to container panel
            this.panelSettingsContainer.Controls.Add(this.picProfilePhoto);
            this.panelSettingsContainer.Controls.Add(this.btnChangePhoto);
            this.panelSettingsContainer.Controls.Add(this.lblChangeUserInfo);
            this.panelSettingsContainer.Controls.Add(this.lblName);
            this.panelSettingsContainer.Controls.Add(this.txtName);
            this.panelSettingsContainer.Controls.Add(this.lblChangePassword);
            this.panelSettingsContainer.Controls.Add(this.txtCurrentPassword);
            this.panelSettingsContainer.Controls.Add(this.txtNewPassword);
            this.panelSettingsContainer.Controls.Add(this.txtConfirmPassword);
          
            this.panelSettingsContainer.Controls.Add(this.btnSave);

            // UserControl properties
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 245, 251);
            this.Size = new Size(1000, 650);

            // Add controls to UserControl
            this.Controls.Add(this.lblSettingsTitle);
            this.Controls.Add(this.panelSettingsContainer);

            this.panelSettingsContainer.ResumeLayout(false);
            this.panelSettingsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}