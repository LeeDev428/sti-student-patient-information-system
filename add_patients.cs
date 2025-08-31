using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sti_student_patient_information_system
{
    public partial class add_patients : UserControl
    {
        private string currentUserName;
        private main_layout parentMainLayout; // Add reference to main layout

        public add_patients()
        {
            InitializeComponent();
        }

        public void SetupForMainLayout(string userName, main_layout mainLayoutRef)
        {
            currentUserName = userName;
            parentMainLayout = mainLayoutRef; // Store reference
            SetupEventHandlers();

            // ensure panels are centered when loaded and when the parent resizes
            CenterPanels();
            this.SizeChanged += (s, e) => CenterPanels();
            if (parentMainLayout != null)
                parentMainLayout.Resize += (s, e) => CenterPanels();

            // prefer top anchoring so we control horizontal centering programmatically
            if (panelMain != null) panelMain.Anchor = AnchorStyles.Top;
            if (panelMedical != null) panelMedical.Anchor = AnchorStyles.Top;
        }

        private void SetupEventHandlers()
        {
            // Age calculation when birthdate changes
            if (dtpBirthdate != null)
            {
                dtpBirthdate.ValueChanged += (s, e) => {
                    int age = DateTime.Now.Year - dtpBirthdate.Value.Year;
                    if (DateTime.Now.DayOfYear < dtpBirthdate.Value.DayOfYear)
                        age--;
                    if (txtAge != null)
                        txtAge.Text = age.ToString();
                };
            }
            }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                string category = rbStudent.Checked ? "Student" :
                                rbFaculty.Checked ? "Faculty" : "Staff";

                string gender = rbMale.Checked ? "Male" : "Female";

                string bloodType = GetSelectedBloodType();

                bool success = DatabaseHelper.RegisterPatientComplete(
                    category, txtLastName.Text.Trim(), txtGivenName.Text.Trim(),
                    txtMiddleName.Text.Trim(), txtSuffix.Text.Trim(), txtIdNumber.Text.Trim(),
                    string.IsNullOrEmpty(txtAge.Text) ? 0 : int.Parse(txtAge.Text),
                    gender, dtpBirthdate.Value, txtEmail.Text.Trim(), txtNationality.Text.Trim(),
                    txtCurrentAddress.Text.Trim(), txtHomeAddress.Text.Trim(), txtContactNumber.Text.Trim(),
                    txtFathersName.Text.Trim(), txtFathersContact.Text.Trim(),
                    txtMothersName.Text.Trim(), txtMothersContact.Text.Trim(),
                    txtGuardianName.Text.Trim(), txtGuardianContact.Text.Trim(),
                    txtEmergencyName.Text.Trim(), txtEmergencyNumber.Text.Trim(),
                    bloodType,
                    chkCovid19.Checked, chkMMR.Checked, chkTetanus.Checked,
                    chkHepa.Checked, chkHepaB.Checked, chkOther.Checked ? "Other immunizations" : "",
                    txtAllergyList.Text.Trim(),
                    chkChestXray.Checked, chkHepaLab.Checked, chkDrugTest.Checked,
                    txtMedicalConditions.Text.Trim(), txtDisabilities.Text.Trim(), txtEmergencyMedication.Text.Trim()
                );

                if (success)
                {
                    MessageBox.Show("Patient registered successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();

                    // FIXED: Use public properties instead of direct button access
                    if (parentMainLayout != null)
                    {
                        parentMainLayout.SetActiveButton(parentMainLayout.DashboardButton);
                        dashboard dashContent = new dashboard();
                        dashContent.SetupForMainLayout(currentUserName);
                        parentMainLayout.SwitchContent(dashContent);
                    }
                }
                else
                {
                    MessageBox.Show("Registration failed. Please check your input and try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
                private void CenterPanels()
                {
                    try
                    {
                        // center horizontally within the control's width
                        if (panelMain != null)
                        {
                            int x = Math.Max(10, (this.Width - panelMain.Width) / 2);
                            panelMain.Left = x;
                        }
                
                        if (panelMedical != null)
                        {
                            int x2 = Math.Max(10, (this.Width - panelMedical.Width) / 2);
                            panelMedical.Left = x2;
                        }
                    }
                    catch { /* swallow layout errors */ }
                }
        private string GetSelectedBloodType()
        {
            if (rbAPos.Checked) return "A+";
            if (rbANeg.Checked) return "A-";
            if (rbBPos.Checked) return "B+";
            if (rbBNeg.Checked) return "B-";
            if (rbABPos.Checked) return "AB+";
            if (rbABNeg.Checked) return "AB-";
            if (rbOPos.Checked) return "O+";
            if (rbONeg.Checked) return "O-";
            return "";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter the last name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGivenName.Text))
            {
                MessageBox.Show("Please enter the given name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGivenName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIdNumber.Text))
            {
                MessageBox.Show("Please enter the ID number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdNumber.Focus();
                return false;
            }

            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Please select a gender.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (DatabaseHelper.CheckIdNumberExists(txtIdNumber.Text.Trim()))
            {
                MessageBox.Show("This ID number already exists. Please enter a different ID number.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdNumber.Focus();
                return false;
            }

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            rbStudent.Checked = true;
            txtLastName.Clear();
            txtGivenName.Clear();
            txtMiddleName.Clear();
            txtSuffix.Clear();
            txtIdNumber.Clear();
            txtAge.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            dtpBirthdate.Value = DateTime.Today.AddYears(-18);
            txtEmail.Clear();
            txtNationality.Clear();
            txtCurrentAddress.Clear();
            txtContactNumber.Clear();
            txtHomeAddress.Clear();
            txtFathersName.Clear();
            txtFathersContact.Clear();
            txtMothersName.Clear();
            txtMothersContact.Clear();
            txtGuardianName.Clear();
            txtGuardianContact.Clear();
            txtEmergencyName.Clear();
            txtEmergencyNumber.Clear();

            // Clear medical info
            rbAPos.Checked = false;
            rbANeg.Checked = false;
            rbBPos.Checked = false;
            rbBNeg.Checked = false;
            rbABPos.Checked = false;
            rbABNeg.Checked = false;
            rbOPos.Checked = false;
            rbONeg.Checked = false;

            chkCovid19.Checked = false;
            chkMMR.Checked = false;
            chkTetanus.Checked = false;
            chkHepa.Checked = false;
            chkHepaB.Checked = false;
            chkOther.Checked = false;

            txtAllergyList.Clear();

            chkChestXray.Checked = false;
            chkHepaLab.Checked = false;
            chkDrugTest.Checked = false;

            txtMedicalConditions.Clear();
            txtDisabilities.Clear();
            txtEmergencyMedication.Clear();

            txtLastName.Focus();
        }
    }
}