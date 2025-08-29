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
        private string currentUserEmail; // Add this to store email

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
                // FIXED: Get user email from current user name properly
                currentUserEmail = DatabaseHelper.GetUserEmailByName(currentUserName);

                if (string.IsNullOrEmpty(currentUserEmail))
                {
                    MessageBox.Show("Could not find user email. Please contact administrator.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentUserId = DatabaseHelper.GetUserIdByEmail(currentUserEmail);

                DataTable userProfile = DatabaseHelper.GetUserProfile(currentUserEmail);
                if (userProfile.Rows.Count > 0)
                {
                    DataRow row = userProfile.Rows[0];

                    // Set name field
                    string fullName = row["full_name"].ToString();
                    if (!string.IsNullOrEmpty(fullName))
                    {
                        txtName.Text = fullName;
                        txtName.ForeColor = Color.Black;
                    }

                    // Load profile photo if exists
                    string photoPath = row["profile_photo_path"].ToString();
                    LoadProfilePhoto(photoPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProfilePhoto(string photoPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                {
                    // Dispose of previous image if any
                    if (picProfilePhoto.Image != null)
                    {
                        picProfilePhoto.Image.Dispose();
                    }
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
            // Dispose of previous image if any
            if (picProfilePhoto.Image != null)
            {
                picProfilePhoto.Image.Dispose();
            }

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
                                             txtConfirmPassword.Text != "Confirm Password" &&
                                             !string.IsNullOrWhiteSpace(txtCurrentPassword.Text) &&
                                             !string.IsNullOrWhiteSpace(txtNewPassword.Text) &&
                                             !string.IsNullOrWhiteSpace(txtConfirmPassword.Text);

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

                // Update profile (name only for now - you can extend this to include other fields)
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
                    // Create a directory for profile photos if it doesn't exist
                    string profilePhotosDir = Path.Combine(Application.StartupPath, "ProfilePhotos");
                    if (!Directory.Exists(profilePhotosDir))
                    {
                        Directory.CreateDirectory(profilePhotosDir);
                    }

                    // Generate unique filename
                    string fileExtension = Path.GetExtension(openFileDialog.FileName);
                    string newFileName = $"user_{currentUserId}_{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";
                    string newFilePath = Path.Combine(profilePhotosDir, newFileName);

                    // Copy the selected file to our profile photos directory
                    File.Copy(openFileDialog.FileName, newFilePath, true);

                    // Load and display the selected image
                    LoadProfilePhoto(newFilePath);

                    // Save the file path to database
                    bool photoUpdated = DatabaseHelper.UpdateUserProfilePhoto(currentUserId, newFilePath);

                    if (photoUpdated)
                    {
                        MessageBox.Show("Profile photo updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Log photo update
                        DatabaseHelper.LogUserActivity(currentUserId, "profile_update",
                            "User updated profile photo");
                    }
                    else
                    {
                        MessageBox.Show("Failed to save profile photo to database.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing profile photo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}