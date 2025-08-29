namespace sti_student_patient_information_system
{
    partial class add_patients
    {
        private System.ComponentModel.IContainer components = null;

        // CATEGORY SECTION
        private Label lblTitle;
        private Label lblCategory;
        private RadioButton rbStudent;
        private RadioButton rbFaculty;
        private RadioButton rbStaff;

        // PERSONAL INFO SECTION
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblGivenName;
        private TextBox txtGivenName;
        private Label lblMiddleName;
        private TextBox txtMiddleName;
        private Label lblSuffix;
        private TextBox txtSuffix;
        private Label lblIdNumber;
        private TextBox txtIdNumber;

        // BASIC DETAILS SECTION
        private Label lblAge;
        private TextBox txtAge;
        private Label lblGender;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private Label lblBirthdate;
        private DateTimePicker dtpBirthdate;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblNationality;
        private TextBox txtNationality;
        private Label lblCurrentAddress;
        private TextBox txtCurrentAddress;
        private Label lblContactNumber;
        private TextBox txtContactNumber;
        private Label lblHomeAddress;
        private TextBox txtHomeAddress;

        // CONTACT INFO SECTION
        private Label lblContactInfo;
        private Label lblFathersName;
        private TextBox txtFathersName;
        private Label lblFathersContact;
        private TextBox txtFathersContact;
        private Label lblMothersName;
        private TextBox txtMothersName;
        private Label lblMothersContact;
        private TextBox txtMothersContact;
        private Label lblGuardianName;
        private TextBox txtGuardianName;
        private Label lblGuardianContact;
        private TextBox txtGuardianContact;

        // EMERGENCY CONTACT SECTION
        private Label lblEmergencyContact;
        private Label lblEmergencyName;
        private TextBox txtEmergencyName;
        private Label lblEmergencyNumber;
        private TextBox txtEmergencyNumber;

        // MEDICAL INFO SECTION
        private Label lblMedicalInfo;
        private Label lblBloodType;
        private RadioButton rbAPos;
        private RadioButton rbANeg;
        private RadioButton rbBPos;
        private RadioButton rbBNeg;
        private RadioButton rbABPos;
        private RadioButton rbABNeg;
        private RadioButton rbOPos;
        private RadioButton rbONeg;

        // IMMUNIZATION SECTION
        private Label lblImmunization;
        private CheckBox chkCovid19;
        private CheckBox chkMMR;
        private CheckBox chkTetanus;
        private CheckBox chkHepa;
        private CheckBox chkHepaB;
        private CheckBox chkOther;

        // ALLERGY SECTION
        private Label lblAllergyList;
        private TextBox txtAllergyList;

        // LABORATORY SECTION
        private Label lblLaboratory;
        private CheckBox chkChestXray;
        private CheckBox chkHepaLab;
        private CheckBox chkDrugTest;

        // MEDICAL CONDITIONS SECTION
        private Label lblMedicalConditions;
        private TextBox txtMedicalConditions;
        private Label lblDisabilities;
        private TextBox txtDisabilities;
        private Label lblEmergencyMedication;
        private TextBox txtEmergencyMedication;

        // BUTTONS
        private Button btnSave;
        private Button btnClear;

        // PANELS
        private Panel panelMain;
        private Panel panelMedical;

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
            // Initialize all components
            this.lblTitle = new Label();
            this.panelMain = new Panel();
            this.panelMedical = new Panel();

            this.lblCategory = new Label();
            this.rbStudent = new RadioButton();
            this.rbFaculty = new RadioButton();
            this.rbStaff = new RadioButton();

            this.lblLastName = new Label();
            this.txtLastName = new TextBox();
            this.lblGivenName = new Label();
            this.txtGivenName = new TextBox();
            this.lblMiddleName = new Label();
            this.txtMiddleName = new TextBox();
            this.lblSuffix = new Label();
            this.txtSuffix = new TextBox();
            this.lblIdNumber = new Label();
            this.txtIdNumber = new TextBox();

            this.lblAge = new Label();
            this.txtAge = new TextBox();
            this.lblGender = new Label();
            this.rbMale = new RadioButton();
            this.rbFemale = new RadioButton();
            this.lblBirthdate = new Label();
            this.dtpBirthdate = new DateTimePicker();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblNationality = new Label();
            this.txtNationality = new TextBox();
            this.lblCurrentAddress = new Label();
            this.txtCurrentAddress = new TextBox();
            this.lblContactNumber = new Label();
            this.txtContactNumber = new TextBox();
            this.lblHomeAddress = new Label();
            this.txtHomeAddress = new TextBox();

            this.lblContactInfo = new Label();
            this.lblFathersName = new Label();
            this.txtFathersName = new TextBox();
            this.lblFathersContact = new Label();
            this.txtFathersContact = new TextBox();
            this.lblMothersName = new Label();
            this.txtMothersName = new TextBox();
            this.lblMothersContact = new Label();
            this.txtMothersContact = new TextBox();
            this.lblGuardianName = new Label();
            this.txtGuardianName = new TextBox();
            this.lblGuardianContact = new Label();
            this.txtGuardianContact = new TextBox();

            this.lblEmergencyContact = new Label();
            this.lblEmergencyName = new Label();
            this.txtEmergencyName = new TextBox();
            this.lblEmergencyNumber = new Label();
            this.txtEmergencyNumber = new TextBox();

            this.lblMedicalInfo = new Label();
            this.lblBloodType = new Label();
            this.rbAPos = new RadioButton();
            this.rbANeg = new RadioButton();
            this.rbBPos = new RadioButton();
            this.rbBNeg = new RadioButton();
            this.rbABPos = new RadioButton();
            this.rbABNeg = new RadioButton();
            this.rbOPos = new RadioButton();
            this.rbONeg = new RadioButton();

            this.lblImmunization = new Label();
            this.chkCovid19 = new CheckBox();
            this.chkMMR = new CheckBox();
            this.chkTetanus = new CheckBox();
            this.chkHepa = new CheckBox();
            this.chkHepaB = new CheckBox();
            this.chkOther = new CheckBox();

            this.lblAllergyList = new Label();
            this.txtAllergyList = new TextBox();

            this.lblLaboratory = new Label();
            this.chkChestXray = new CheckBox();
            this.chkHepaLab = new CheckBox();
            this.chkDrugTest = new CheckBox();

            this.lblMedicalConditions = new Label();
            this.txtMedicalConditions = new TextBox();
            this.lblDisabilities = new Label();
            this.txtDisabilities = new TextBox();
            this.lblEmergencyMedication = new Label();
            this.txtEmergencyMedication = new TextBox();

            this.btnSave = new Button();
            this.btnClear = new Button();

            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 245, 251);
            this.Size = new Size(1200, 800);
            this.AutoScroll = true;

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Text = "Add New Patient";

            // Main Panel - First Section
            this.panelMain.BackColor = Color.FromArgb(209, 213, 219);
            this.panelMain.Location = new Point(30, 80);
            this.panelMain.Size = new Size(800, 400);

            // CATEGORY SECTION - EXACT FROM IMAGE
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblCategory.ForeColor = Color.Black;
            this.lblCategory.Location = new Point(30, 20);
            this.lblCategory.Text = "CATEGORY:";

            this.rbStudent.AutoSize = true;
            this.rbStudent.Font = new Font("Segoe UI", 12F);
            this.rbStudent.Location = new Point(150, 22);
            this.rbStudent.Text = "● Student";
            this.rbStudent.Checked = true;

            this.rbFaculty.AutoSize = true;
            this.rbFaculty.Font = new Font("Segoe UI", 12F);
            this.rbFaculty.Location = new Point(280, 22);
            this.rbFaculty.Text = "● Faculty";

            this.rbStaff.AutoSize = true;
            this.rbStaff.Font = new Font("Segoe UI", 12F);
            this.rbStaff.Location = new Point(410, 22);
            this.rbStaff.Text = "● Staff";

            // PERSONAL INFO - ROW 1
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblLastName.Location = new Point(30, 70);
            this.lblLastName.Text = "LastName:";

            this.txtLastName.Font = new Font("Segoe UI", 11F);
            this.txtLastName.Location = new Point(120, 67);
            this.txtLastName.Size = new Size(200, 27);
            this.txtLastName.PlaceholderText = "Enter text here...";

            this.lblGivenName.AutoSize = true;
            this.lblGivenName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblGivenName.Location = new Point(350, 70);
            this.lblGivenName.Text = "GivenName:";

            this.txtGivenName.Font = new Font("Segoe UI", 11F);
            this.txtGivenName.Location = new Point(450, 67);
            this.txtGivenName.Size = new Size(200, 27);
            this.txtGivenName.PlaceholderText = "Enter text here...";

            // PERSONAL INFO - ROW 2
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblMiddleName.Location = new Point(30, 110);
            this.lblMiddleName.Text = "MiddleName:";

            this.txtMiddleName.Font = new Font("Segoe UI", 11F);
            this.txtMiddleName.Location = new Point(120, 107);
            this.txtMiddleName.Size = new Size(200, 27);
            this.txtMiddleName.PlaceholderText = "Enter text here...";

            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblSuffix.Location = new Point(350, 110);
            this.lblSuffix.Text = "Suffix:";

            this.txtSuffix.Font = new Font("Segoe UI", 11F);
            this.txtSuffix.Location = new Point(450, 107);
            this.txtSuffix.Size = new Size(200, 27);
            this.txtSuffix.PlaceholderText = "Enter text here...";

            // ID NUMBER - FULL WIDTH
            this.lblIdNumber.AutoSize = true;
            this.lblIdNumber.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblIdNumber.Location = new Point(30, 150);
            this.lblIdNumber.Text = "ID Number:";

            this.txtIdNumber.Font = new Font("Segoe UI", 11F);
            this.txtIdNumber.Location = new Point(120, 147);
            this.txtIdNumber.Size = new Size(530, 27);
            this.txtIdNumber.PlaceholderText = "Enter text here...";

            // BASIC DETAILS - ROW 1
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblAge.Location = new Point(30, 190);
            this.lblAge.Text = "Age:";

            this.txtAge.Font = new Font("Segoe UI", 11F);
            this.txtAge.Location = new Point(120, 187);
            this.txtAge.Size = new Size(200, 27);
            this.txtAge.PlaceholderText = "Enter text here...";

            this.lblGender.AutoSize = true;
            this.lblGender.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblGender.Location = new Point(350, 190);
            this.lblGender.Text = "Gender:";

            this.rbMale.AutoSize = true;
            this.rbMale.Font = new Font("Segoe UI", 11F);
            this.rbMale.Location = new Point(420, 190);
            this.rbMale.Text = "● Male";

            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new Font("Segoe UI", 11F);
            this.rbFemale.Location = new Point(520, 190);
            this.rbFemale.Text = "● Female";

            // BASIC DETAILS - ROW 2
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblBirthdate.Location = new Point(30, 230);
            this.lblBirthdate.Text = "Birthdate:";

            this.dtpBirthdate.Font = new Font("Segoe UI", 11F);
            this.dtpBirthdate.Location = new Point(120, 227);
            this.dtpBirthdate.Size = new Size(200, 27);
            this.dtpBirthdate.Format = DateTimePickerFormat.Short;

            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblEmail.Location = new Point(350, 230);
            this.lblEmail.Text = "Email:";

            this.txtEmail.Font = new Font("Segoe UI", 11F);
            this.txtEmail.Location = new Point(420, 227);
            this.txtEmail.Size = new Size(230, 27);
            this.txtEmail.PlaceholderText = "Enter text here...";

            // BASIC DETAILS - ROW 3
            this.lblNationality.AutoSize = true;
            this.lblNationality.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblNationality.Location = new Point(30, 270);
            this.lblNationality.Text = "Nationality:";

            this.txtNationality.Font = new Font("Segoe UI", 11F);
            this.txtNationality.Location = new Point(120, 267);
            this.txtNationality.Size = new Size(200, 27);
            this.txtNationality.PlaceholderText = "Enter text here...";

            this.lblCurrentAddress.AutoSize = true;
            this.lblCurrentAddress.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblCurrentAddress.Location = new Point(350, 270);
            this.lblCurrentAddress.Text = "Current Address:";

            this.txtCurrentAddress.Font = new Font("Segoe UI", 11F);
            this.txtCurrentAddress.Location = new Point(480, 267);
            this.txtCurrentAddress.Size = new Size(170, 27);
            this.txtCurrentAddress.PlaceholderText = "Enter text here...";

            // BASIC DETAILS - ROW 4
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblContactNumber.Location = new Point(30, 310);
            this.lblContactNumber.Text = "Contact Number:";

            this.txtContactNumber.Font = new Font("Segoe UI", 11F);
            this.txtContactNumber.Location = new Point(160, 307);
            this.txtContactNumber.Size = new Size(160, 27);
            this.txtContactNumber.PlaceholderText = "Enter text here...";

            this.lblHomeAddress.AutoSize = true;
            this.lblHomeAddress.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblHomeAddress.Location = new Point(350, 310);
            this.lblHomeAddress.Text = "Home Address:";

            this.txtHomeAddress.Font = new Font("Segoe UI", 11F);
            this.txtHomeAddress.Location = new Point(480, 307);
            this.txtHomeAddress.Size = new Size(170, 27);
            this.txtHomeAddress.PlaceholderText = "Enter text here...";

            // CONTACT INFO SECTION
            this.lblContactInfo.AutoSize = true;
            this.lblContactInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblContactInfo.ForeColor = Color.Black;
            this.lblContactInfo.Location = new Point(30, 350);
            this.lblContactInfo.Text = "Contact Information:";

            // Add all first panel controls
            this.panelMain.Controls.Add(this.lblCategory);
            this.panelMain.Controls.Add(this.rbStudent);
            this.panelMain.Controls.Add(this.rbFaculty);
            this.panelMain.Controls.Add(this.rbStaff);
            this.panelMain.Controls.Add(this.lblLastName);
            this.panelMain.Controls.Add(this.txtLastName);
            this.panelMain.Controls.Add(this.lblGivenName);
            this.panelMain.Controls.Add(this.txtGivenName);
            this.panelMain.Controls.Add(this.lblMiddleName);
            this.panelMain.Controls.Add(this.txtMiddleName);
            this.panelMain.Controls.Add(this.lblSuffix);
            this.panelMain.Controls.Add(this.txtSuffix);
            this.panelMain.Controls.Add(this.lblIdNumber);
            this.panelMain.Controls.Add(this.txtIdNumber);
            this.panelMain.Controls.Add(this.lblAge);
            this.panelMain.Controls.Add(this.txtAge);
            this.panelMain.Controls.Add(this.lblGender);
            this.panelMain.Controls.Add(this.rbMale);
            this.panelMain.Controls.Add(this.rbFemale);
            this.panelMain.Controls.Add(this.lblBirthdate);
            this.panelMain.Controls.Add(this.dtpBirthdate);
            this.panelMain.Controls.Add(this.lblEmail);
            this.panelMain.Controls.Add(this.txtEmail);
            this.panelMain.Controls.Add(this.lblNationality);
            this.panelMain.Controls.Add(this.txtNationality);
            this.panelMain.Controls.Add(this.lblCurrentAddress);
            this.panelMain.Controls.Add(this.txtCurrentAddress);
            this.panelMain.Controls.Add(this.lblContactNumber);
            this.panelMain.Controls.Add(this.txtContactNumber);
            this.panelMain.Controls.Add(this.lblHomeAddress);
            this.panelMain.Controls.Add(this.txtHomeAddress);
            this.panelMain.Controls.Add(this.lblContactInfo);

            // MEDICAL PANEL - Second Section
            this.panelMedical.BackColor = Color.FromArgb(209, 213, 219);
            this.panelMedical.Location = new Point(30, 500);
            this.panelMedical.Size = new Size(800, 500);

            // Continue with second panel controls in the medical panel...
            this.SetupMedicalPanel();

            // Buttons
            this.btnSave.BackColor = Color.FromArgb(37, 99, 235);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(730, 1020);
            this.btnSave.Size = new Size(100, 40);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            this.btnClear.BackColor = Color.FromArgb(37, 99, 235);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(610, 1020);
            this.btnClear.Size = new Size(100, 40);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMedical);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupMedicalPanel()
        {
            // FATHER'S INFO
            this.lblFathersName.AutoSize = true;
            this.lblFathersName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblFathersName.Location = new Point(30, 20);
            this.lblFathersName.Text = "Father's Name:";

            this.txtFathersName.Font = new Font("Segoe UI", 11F);
            this.txtFathersName.Location = new Point(150, 17);
            this.txtFathersName.Size = new Size(200, 27);
            this.txtFathersName.PlaceholderText = "Enter text here...";

            this.lblFathersContact.AutoSize = true;
            this.lblFathersContact.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblFathersContact.Location = new Point(380, 20);
            this.lblFathersContact.Text = "Contact Number:";

            this.txtFathersContact.Font = new Font("Segoe UI", 11F);
            this.txtFathersContact.Location = new Point(510, 17);
            this.txtFathersContact.Size = new Size(140, 27);
            this.txtFathersContact.PlaceholderText = "Enter text here...";

            // MOTHER'S INFO
            this.lblMothersName.AutoSize = true;
            this.lblMothersName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblMothersName.Location = new Point(30, 60);
            this.lblMothersName.Text = "Mother's Name:";

            this.txtMothersName.Font = new Font("Segoe UI", 11F);
            this.txtMothersName.Location = new Point(150, 57);
            this.txtMothersName.Size = new Size(200, 27);
            this.txtMothersName.PlaceholderText = "Enter text here...";

            this.lblMothersContact.AutoSize = true;
            this.lblMothersContact.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblMothersContact.Location = new Point(380, 60);
            this.lblMothersContact.Text = "Contact Number:";

            this.txtMothersContact.Font = new Font("Segoe UI", 11F);
            this.txtMothersContact.Location = new Point(510, 57);
            this.txtMothersContact.Size = new Size(140, 27);
            this.txtMothersContact.PlaceholderText = "Enter text here...";

            // GUARDIAN INFO
            this.lblGuardianName.AutoSize = true;
            this.lblGuardianName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblGuardianName.Location = new Point(30, 100);
            this.lblGuardianName.Text = "Guardian Name:";

            this.txtGuardianName.Font = new Font("Segoe UI", 11F);
            this.txtGuardianName.Location = new Point(150, 97);
            this.txtGuardianName.Size = new Size(200, 27);
            this.txtGuardianName.PlaceholderText = "Enter text here...";

            this.lblGuardianContact.AutoSize = true;
            this.lblGuardianContact.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblGuardianContact.Location = new Point(380, 100);
            this.lblGuardianContact.Text = "Contact Number:";

            this.txtGuardianContact.Font = new Font("Segoe UI", 11F);
            this.txtGuardianContact.Location = new Point(510, 97);
            this.txtGuardianContact.Size = new Size(140, 27);
            this.txtGuardianContact.PlaceholderText = "Enter text here...";

            // EMERGENCY CONTACT
            this.lblEmergencyContact.AutoSize = true;
            this.lblEmergencyContact.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblEmergencyContact.ForeColor = Color.Black;
            this.lblEmergencyContact.Location = new Point(30, 150);
            this.lblEmergencyContact.Text = "Emergency Contact Person:";

            this.lblEmergencyName.AutoSize = true;
            this.lblEmergencyName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblEmergencyName.Location = new Point(30, 180);
            this.lblEmergencyName.Text = "Name:";

            this.txtEmergencyName.Font = new Font("Segoe UI", 11F);
            this.txtEmergencyName.Location = new Point(90, 177);
            this.txtEmergencyName.Size = new Size(260, 27);
            this.txtEmergencyName.PlaceholderText = "Enter text here...";

            this.lblEmergencyNumber.AutoSize = true;
            this.lblEmergencyNumber.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblEmergencyNumber.Location = new Point(380, 180);
            this.lblEmergencyNumber.Text = "Contact Number:";

            this.txtEmergencyNumber.Font = new Font("Segoe UI", 11F);
            this.txtEmergencyNumber.Location = new Point(510, 177);
            this.txtEmergencyNumber.Size = new Size(140, 27);
            this.txtEmergencyNumber.PlaceholderText = "Enter text here...";

            // MEDICAL INFORMATION
            this.lblMedicalInfo.AutoSize = true;
            this.lblMedicalInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblMedicalInfo.ForeColor = Color.Black;
            this.lblMedicalInfo.Location = new Point(30, 220);
            this.lblMedicalInfo.Text = "Medical Information:";

            // BLOOD TYPE
            this.lblBloodType.AutoSize = true;
            this.lblBloodType.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblBloodType.Location = new Point(30, 250);
            this.lblBloodType.Text = "Blood Type:";

            this.rbAPos.AutoSize = true;
            this.rbAPos.Font = new Font("Segoe UI", 10F);
            this.rbAPos.Location = new Point(120, 252);
            this.rbAPos.Text = "● A+";

            this.rbANeg.AutoSize = true;
            this.rbANeg.Font = new Font("Segoe UI", 10F);
            this.rbANeg.Location = new Point(180, 252);
            this.rbANeg.Text = "● A-";

            this.rbBPos.AutoSize = true;
            this.rbBPos.Font = new Font("Segoe UI", 10F);
            this.rbBPos.Location = new Point(240, 252);
            this.rbBPos.Text = "● B+";

            this.rbBNeg.AutoSize = true;
            this.rbBNeg.Font = new Font("Segoe UI", 10F);
            this.rbBNeg.Location = new Point(300, 252);
            this.rbBNeg.Text = "● B-";

            this.rbABPos.AutoSize = true;
            this.rbABPos.Font = new Font("Segoe UI", 10F);
            this.rbABPos.Location = new Point(360, 252);
            this.rbABPos.Text = "● AB+";

            this.rbABNeg.AutoSize = true;
            this.rbABNeg.Font = new Font("Segoe UI", 10F);
            this.rbABNeg.Location = new Point(430, 252);
            this.rbABNeg.Text = "● AB-";

            this.rbOPos.AutoSize = true;
            this.rbOPos.Font = new Font("Segoe UI", 10F);
            this.rbOPos.Location = new Point(500, 252);
            this.rbOPos.Text = "● O+";

            this.rbONeg.AutoSize = true;
            this.rbONeg.Font = new Font("Segoe UI", 10F);
            this.rbONeg.Location = new Point(560, 252);
            this.rbONeg.Text = "● O-";

            // IMMUNIZATION
            this.lblImmunization.AutoSize = true;
            this.lblImmunization.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblImmunization.Location = new Point(30, 290);
            this.lblImmunization.Text = "Immunization:";

            this.chkCovid19.AutoSize = true;
            this.chkCovid19.Font = new Font("Segoe UI", 10F);
            this.chkCovid19.Location = new Point(30, 320);
            this.chkCovid19.Text = "☐ Covid - 19";

            this.chkMMR.AutoSize = true;
            this.chkMMR.Font = new Font("Segoe UI", 10F);
            this.chkMMR.Location = new Point(30, 350);
            this.chkMMR.Text = "☐ MMR";

            this.chkTetanus.AutoSize = true;
            this.chkTetanus.Font = new Font("Segoe UI", 10F);
            this.chkTetanus.Location = new Point(30, 380);
            this.chkTetanus.Text = "☐ Tetanus";

            this.chkHepa.AutoSize = true;
            this.chkHepa.Font = new Font("Segoe UI", 10F);
            this.chkHepa.Location = new Point(30, 410);
            this.chkHepa.Text = "☐ Hepa";

            this.chkHepaB.AutoSize = true;
            this.chkHepaB.Font = new Font("Segoe UI", 10F);
            this.chkHepaB.Location = new Point(30, 440);
            this.chkHepaB.Text = "☐ Hepa B";

            this.chkOther.AutoSize = true;
            this.chkOther.Font = new Font("Segoe UI", 10F);
            this.chkOther.Location = new Point(30, 470);
            this.chkOther.Text = "☐ More...";

            // ALLERGY LIST
            this.lblAllergyList.AutoSize = true;
            this.lblAllergyList.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblAllergyList.Location = new Point(200, 290);
            this.lblAllergyList.Text = "Allergy List:";

            this.txtAllergyList.Font = new Font("Segoe UI", 11F);
            this.txtAllergyList.Location = new Point(200, 320);
            this.txtAllergyList.Size = new Size(150, 80);
            this.txtAllergyList.Multiline = true;
            this.txtAllergyList.PlaceholderText = "Enter text here...";

            // LABORATORY
            this.lblLaboratory.AutoSize = true;
            this.lblLaboratory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblLaboratory.Location = new Point(400, 290);
            this.lblLaboratory.Text = "Laboratory:";

            this.chkChestXray.AutoSize = true;
            this.chkChestXray.Font = new Font("Segoe UI", 10F);
            this.chkChestXray.Location = new Point(400, 320);
            this.chkChestXray.Text = "☐ Chest X-ray";

            this.chkHepaLab.AutoSize = true;
            this.chkHepaLab.Font = new Font("Segoe UI", 10F);
            this.chkHepaLab.Location = new Point(400, 350);
            this.chkHepaLab.Text = "☐ Hepa";

            this.chkDrugTest.AutoSize = true;
            this.chkDrugTest.Font = new Font("Segoe UI", 10F);
            this.chkDrugTest.Location = new Point(400, 380);
            this.chkDrugTest.Text = "☐ Drug Test";

            // MEDICAL CONDITIONS
            this.lblMedicalConditions.AutoSize = true;
            this.lblMedicalConditions.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblMedicalConditions.Location = new Point(200, 420);
            this.lblMedicalConditions.Text = "Medical Conditions:";

            this.txtMedicalConditions.Font = new Font("Segoe UI", 11F);
            this.txtMedicalConditions.Location = new Point(350, 417);
            this.txtMedicalConditions.Size = new Size(200, 27);
            this.txtMedicalConditions.PlaceholderText = "Enter text here...";

            // DISABILITIES
            this.lblDisabilities.AutoSize = true;
            this.lblDisabilities.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDisabilities.Location = new Point(200, 450);
            this.lblDisabilities.Text = "Disabilities/Special Needs:";

            this.txtDisabilities.Font = new Font("Segoe UI", 11F);
            this.txtDisabilities.Location = new Point(380, 447);
            this.txtDisabilities.Size = new Size(170, 27);
            this.txtDisabilities.PlaceholderText = "Enter text here...";

            // EMERGENCY MEDICATION
            this.lblEmergencyMedication.AutoSize = true;
            this.lblEmergencyMedication.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblEmergencyMedication.Location = new Point(200, 480);
            this.lblEmergencyMedication.Text = "Emergency Medication:";

            this.txtEmergencyMedication.Font = new Font("Segoe UI", 11F);
            this.txtEmergencyMedication.Location = new Point(370, 477);
            this.txtEmergencyMedication.Size = new Size(180, 27);
            this.txtEmergencyMedication.PlaceholderText = "Enter text here...";

            // Add all medical panel controls
            this.panelMedical.Controls.Add(this.lblFathersName);
            this.panelMedical.Controls.Add(this.txtFathersName);
            this.panelMedical.Controls.Add(this.lblFathersContact);
            this.panelMedical.Controls.Add(this.txtFathersContact);
            this.panelMedical.Controls.Add(this.lblMothersName);
            this.panelMedical.Controls.Add(this.txtMothersName);
            this.panelMedical.Controls.Add(this.lblMothersContact);
            this.panelMedical.Controls.Add(this.txtMothersContact);
            this.panelMedical.Controls.Add(this.lblGuardianName);
            this.panelMedical.Controls.Add(this.txtGuardianName);
            this.panelMedical.Controls.Add(this.lblGuardianContact);
            this.panelMedical.Controls.Add(this.txtGuardianContact);
            this.panelMedical.Controls.Add(this.lblEmergencyContact);
            this.panelMedical.Controls.Add(this.lblEmergencyName);
            this.panelMedical.Controls.Add(this.txtEmergencyName);
            this.panelMedical.Controls.Add(this.lblEmergencyNumber);
            this.panelMedical.Controls.Add(this.txtEmergencyNumber);
            this.panelMedical.Controls.Add(this.lblMedicalInfo);
            this.panelMedical.Controls.Add(this.lblBloodType);
            this.panelMedical.Controls.Add(this.rbAPos);
            this.panelMedical.Controls.Add(this.rbANeg);
            this.panelMedical.Controls.Add(this.rbBPos);
            this.panelMedical.Controls.Add(this.rbBNeg);
            this.panelMedical.Controls.Add(this.rbABPos);
            this.panelMedical.Controls.Add(this.rbABNeg);
            this.panelMedical.Controls.Add(this.rbOPos);
            this.panelMedical.Controls.Add(this.rbONeg);
            this.panelMedical.Controls.Add(this.lblImmunization);
            this.panelMedical.Controls.Add(this.chkCovid19);
            this.panelMedical.Controls.Add(this.chkMMR);
            this.panelMedical.Controls.Add(this.chkTetanus);
            this.panelMedical.Controls.Add(this.chkHepa);
            this.panelMedical.Controls.Add(this.chkHepaB);
            this.panelMedical.Controls.Add(this.chkOther);
            this.panelMedical.Controls.Add(this.lblAllergyList);
            this.panelMedical.Controls.Add(this.txtAllergyList);
            this.panelMedical.Controls.Add(this.lblLaboratory);
            this.panelMedical.Controls.Add(this.chkChestXray);
            this.panelMedical.Controls.Add(this.chkHepaLab);
            this.panelMedical.Controls.Add(this.chkDrugTest);
            this.panelMedical.Controls.Add(this.lblMedicalConditions);
            this.panelMedical.Controls.Add(this.txtMedicalConditions);
            this.panelMedical.Controls.Add(this.lblDisabilities);
            this.panelMedical.Controls.Add(this.txtDisabilities);
            this.panelMedical.Controls.Add(this.lblEmergencyMedication);
            this.panelMedical.Controls.Add(this.txtEmergencyMedication);
        }
    }
}