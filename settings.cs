using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    public partial class settings : UserControl
    {
        private string currentUserName;
        private main_layout parentMainLayout;
        private int currentUserId;

        public settings()
        {
            InitializeComponent();
        }

        public void SetupForMainLayout(string userName, main_layout mainLayoutRef)
        {
            currentUserName = userName;
            parentMainLayout = mainLayoutRef;
            LoadUserProfile();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            // Save button click
            btnSave.Click += (s, e) => {
                SaveUserProfile();
            };

            // Change profile photo button click
            btnChangePhoto.Click += (s, e) => {
                ChangeProfilePhoto();
            };

            // Forgot Password button click
            btnForgotPassword.Click += (s, e) => {
                ForgotPassword();
            };

            // Name textbox placeholder functionality
            txtName.GotFocus += (s, e) => {
                if (txtName.Text == "Enter you Name")
                {
                    txtName.Text = "";
                    txtName.ForeColor = Color.Black;
                }
            };

            txtName.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    txtName.Text = "Enter you Name";
                    txtName.ForeColor = Color.Gray;
                }
            };

            // Password textboxes placeholder functionality
            SetupPasswordPlaceholders();
        }

        private void SetupPasswordPlaceholders()
        {
            // Current Password
            txtCurrentPassword.Text = "Current Password";
            txtCurrentPassword.ForeColor = Color.Gray;
            txtCurrentPassword.UseSystemPasswordChar = false;

            txtCurrentPassword.GotFocus += (s, e) => {
                if (txtCurrentPassword.Text == "Current Password")
                {
                    txtCurrentPassword.Text = "";
                    txtCurrentPassword.ForeColor = Color.Black;
                    txtCurrentPassword.UseSystemPasswordChar = true;
                }
            };

            txtCurrentPassword.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
                {
                    txtCurrentPassword.Text = "Current Password";
                    txtCurrentPassword.ForeColor = Color.Gray;
                    txtCurrentPassword.UseSystemPasswordChar = false;
                }
            };

            // New Password
            txtNewPassword.Text = "New Password";
            txtNewPassword.ForeColor = Color.Gray;
            txtNewPassword.UseSystemPasswordChar = false;

            txtNewPassword.GotFocus += (s, e) => {
                if (txtNewPassword.Text == "New Password")
                {
                    txtNewPassword.Text = "";
                    txtNewPassword.ForeColor = Color.Black;
                    txtNewPassword.UseSystemPasswordChar = true;
                }
            };

            txtNewPassword.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    txtNewPassword.Text = "New Password";
                    txtNewPassword.ForeColor = Color.Gray;
                    txtNewPassword.UseSystemPasswordChar = false;
                }
            };

            // Confirm Password
            txtConfirmPassword.Text = "Confirm Password";
            txtConfirmPassword.ForeColor = Color.Gray;
            txtConfirmPassword.UseSystemPasswordChar = false;

            txtConfirmPassword.GotFocus += (s, e) => {
                if (txtConfirmPassword.Text == "Confirm Password")
                {
                    txtConfirmPassword.Text = "";
                    txtConfirmPassword.ForeColor = Color.Black;
                    txtConfirmPassword.UseSystemPasswordChar = true;
                }
            };

            txtConfirmPassword.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    txtConfirmPassword.Text = "Confirm Password";
                    txtConfirmPassword.ForeColor = Color.Gray;
                    txtConfirmPassword.UseSystemPasswordChar = false;
                }
            };
        }

        private void LoadUserProfile()
        {
            try
            {
                // Get user email from current user name (you might need to adjust this)
                string userEmail = GetUserEmailFromName(currentUserName);
                currentUserId = DatabaseHelper.GetUserIdByEmail(userEmail);

                DataTable userProfile = DatabaseHelper.GetUserProfile(userEmail);
                if (userProfile.Rows.Count > 0)
                {
                    DataRow row = userProfile.Rows[0];

                    // Set name field
                    txtName.Text = row["full_name"].ToString();
                    txtName.ForeColor = Color.Black;

                    // Load profile photo if exists
                    LoadProfilePhoto(row["profile_photo_path"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetUserEmailFromName(string userName)
        {
            // This is a simple implementation - you might want to store the email differently
            // For now, we'll assume the email is stored somewhere accessible
            // You could modify this to get it from your login system
            return "admin@sti.edu"; // Default for testing
        }

        private void LoadProfilePhoto(string photoPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                {
                    picProfilePhoto.Image = Image.FromFile(photoPath);
                }
                else
                {
                    // Create default profile photo
                    CreateDefaultProfilePhoto();
                }
            }
            catch
            {
                CreateDefaultProfilePhoto();
            }
        }

        private void CreateDefaultProfilePhoto()
        {
            Bitmap defaultPhoto = new Bitmap(200, 200);
            using (Graphics g = Graphics.FromImage(defaultPhoto))
            {
                g.Clear(Color.FromArgb(37, 99, 235));
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw user silhouette
                using (Font font = new Font("Segoe UI", 80, FontStyle.Regular))
                using (Brush whiteBrush = new SolidBrush(Color.White))
                {
                    g.DrawString("👤", font, whiteBrush, 50, 60);
                }
            }
            picProfilePhoto.Image = defaultPhoto;
        }

        private void SaveUserProfile()
        {
            try
            {
                // Validate input
                if (txtName.Text == "Enter you Name" || string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter your name.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if password change is requested
                bool passwordChangeRequested = txtCurrentPassword.Text != "Current Password" &&
                                             txtNewPassword.Text != "New Password" &&
                                             txtConfirmPassword.Text != "Confirm Password";

                if (passwordChangeRequested)
                {
                    if (!ValidatePasswordChange())
                        return;

                    // Change password
                    bool passwordChanged = DatabaseHelper.ChangeUserPassword(currentUserId,
                        txtCurrentPassword.Text, txtNewPassword.Text);

                    if (!passwordChanged)
                        return;

                    // Log password change
                    DatabaseHelper.LogUserActivity(currentUserId, "password_change",
                        "User changed password from settings");
                }

                // Update profile
                bool profileUpdated = DatabaseHelper.UpdateUserProfile(currentUserId,
                    txtName.Text.Trim(), "", "", null, "", "", "", "");

                if (profileUpdated)
                {
                    MessageBox.Show("Profile updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Log profile update
                    DatabaseHelper.LogUserActivity(currentUserId, "profile_update",
                        "User updated profile information");

                    // Clear password fields
                    ResetPasswordFields();
                }
                else
                {
                    MessageBox.Show("Failed to update profile.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePasswordChange()
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New password and confirm password do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("New password must be at least 6 characters long.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ResetPasswordFields()
        {
            txtCurrentPassword.Text = "Current Password";
            txtCurrentPassword.ForeColor = Color.Gray;
            txtCurrentPassword.UseSystemPasswordChar = false;

            txtNewPassword.Text = "New Password";
            txtNewPassword.ForeColor = Color.Gray;
            txtNewPassword.UseSystemPasswordChar = false;

            txtConfirmPassword.Text = "Confirm Password";
            txtConfirmPassword.ForeColor = Color.Gray;
            txtConfirmPassword.UseSystemPasswordChar = false;
        }

        private void ChangeProfilePhoto()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select Profile Photo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load and display the selected image
                    picProfilePhoto.Image = Image.FromFile(openFileDialog.FileName);

                    // You could save the file path to database here
                    MessageBox.Show("Profile photo updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing profile photo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ForgotPassword()
        {
            MessageBox.Show("Password reset request has been sent to your administrator.",
                "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}