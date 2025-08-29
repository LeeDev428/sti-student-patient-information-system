using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace sti_student_patient_information_system
{
    public class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=sti_clinic;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateUser(string email, string password)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE email = @email AND password = @password";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string GetUserFullName(string email)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT full_name FROM users WHERE email = @email";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        object result = command.ExecuteScalar();
                        return result?.ToString() ?? "User";
                    }
                }
            }
            catch
            {
                return "User";
            }
        }

        public static bool RegisterPatient(string firstName, string lastName, string idNumber, string email,
            string phone, string address, DateTime birthDate, string gender, string emergencyContact)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO patients (first_name, last_name, id_number, email, phone, 
                                   address, birth_date, gender, emergency_contact) 
                                   VALUES (@firstName, @lastName, @idNumber, @email, @phone, @address, 
                                   @birthDate, @gender, @emergencyContact)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@idNumber", idNumber);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@birthDate", birthDate);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@emergencyContact", emergencyContact);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable GetDashboardData()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                                    (SELECT COUNT(*) FROM patients WHERE DATE(registration_date) = CURDATE()) as today_patients,
                                    (SELECT COUNT(*) FROM patients WHERE MONTH(registration_date) = MONTH(CURDATE()) AND YEAR(registration_date) = YEAR(CURDATE())) as monthly_patients,
                                    (SELECT COUNT(*) FROM medical_records WHERE DATE(visit_date) = CURDATE()) as today_visits";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        // CORRECTED METHOD - MATCHES YOUR ACTUAL DATABASE TABLE
        public static bool RegisterPatientComplete(
            string category, string lastName, string givenName, string middleName, string suffix,
            string idNumber, int age, string gender, DateTime birthDate, string email, string nationality,
            string currentAddress, string homeAddress, string contactNumber,
            string fathersName, string fathersContact, string mothersName, string mothersContact,
            string guardianName, string guardianContact, string emergencyName, string emergencyNumber,
            string bloodType,
            // INDIVIDUAL IMMUNIZATION FIELDS - MATCHES YOUR TABLE
            bool immunizationCovid19, bool immunizationMMR, bool immunizationTetanus,
            bool immunizationHepa, bool immunizationHepaB, string immunizationOther,
            string allergyList,
            // INDIVIDUAL LAB TEST FIELDS - MATCHES YOUR TABLE  
            bool labChestXray, bool labHepa, bool labDrugTest,
            string medicalConditions, string disabilities, string emergencyMedication)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO patients (
                        category, last_name, given_name, middle_name, suffix, id_number, age, gender, 
                        birth_date, email, nationality, current_address, home_address, contact_number,
                        fathers_name, fathers_contact, mothers_name, mothers_contact,
                        guardian_name, guardian_contact, emergency_contact_name, emergency_contact_number,
                        blood_type, 
                        immunization_covid19, immunization_mmr, immunization_tetanus, 
                        immunization_hepa, immunization_hepa_b, immunization_other,
                        allergy_list,
                        lab_chest_xray, lab_hepa, lab_drug_test,
                        medical_conditions, disabilities_special_needs, emergency_medication
                    ) VALUES (
                        @category, @lastName, @givenName, @middleName, @suffix, @idNumber, @age, @gender,
                        @birthDate, @email, @nationality, @currentAddress, @homeAddress, @contactNumber,
                        @fathersName, @fathersContact, @mothersName, @mothersContact,
                        @guardianName, @guardianContact, @emergencyName, @emergencyNumber,
                        @bloodType,
                        @immunizationCovid19, @immunizationMMR, @immunizationTetanus,
                        @immunizationHepa, @immunizationHepaB, @immunizationOther,
                        @allergyList,
                        @labChestXray, @labHepa, @labDrugTest,
                        @medicalConditions, @disabilities, @emergencyMedication
                    )";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // BASIC INFO
                        command.Parameters.AddWithValue("@category", category);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@givenName", givenName);
                        command.Parameters.AddWithValue("@middleName", middleName);
                        command.Parameters.AddWithValue("@suffix", suffix);
                        command.Parameters.AddWithValue("@idNumber", idNumber);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@birthDate", birthDate);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@nationality", nationality);
                        command.Parameters.AddWithValue("@currentAddress", currentAddress);
                        command.Parameters.AddWithValue("@homeAddress", homeAddress);
                        command.Parameters.AddWithValue("@contactNumber", contactNumber);

                        // CONTACT INFO
                        command.Parameters.AddWithValue("@fathersName", fathersName);
                        command.Parameters.AddWithValue("@fathersContact", fathersContact);
                        command.Parameters.AddWithValue("@mothersName", mothersName);
                        command.Parameters.AddWithValue("@mothersContact", mothersContact);
                        command.Parameters.AddWithValue("@guardianName", guardianName);
                        command.Parameters.AddWithValue("@guardianContact", guardianContact);
                        command.Parameters.AddWithValue("@emergencyName", emergencyName);
                        command.Parameters.AddWithValue("@emergencyNumber", emergencyNumber);

                        // MEDICAL INFO - MATCHES YOUR ACTUAL TABLE STRUCTURE
                        command.Parameters.AddWithValue("@bloodType", string.IsNullOrEmpty(bloodType) ? (object)DBNull.Value : bloodType);

                        // INDIVIDUAL IMMUNIZATION FIELDS
                        command.Parameters.AddWithValue("@immunizationCovid19", immunizationCovid19);
                        command.Parameters.AddWithValue("@immunizationMMR", immunizationMMR);
                        command.Parameters.AddWithValue("@immunizationTetanus", immunizationTetanus);
                        command.Parameters.AddWithValue("@immunizationHepa", immunizationHepa);
                        command.Parameters.AddWithValue("@immunizationHepaB", immunizationHepaB);
                        command.Parameters.AddWithValue("@immunizationOther", immunizationOther);

                        command.Parameters.AddWithValue("@allergyList", allergyList);

                        // INDIVIDUAL LAB TEST FIELDS
                        command.Parameters.AddWithValue("@labChestXray", labChestXray);
                        command.Parameters.AddWithValue("@labHepa", labHepa);
                        command.Parameters.AddWithValue("@labDrugTest", labDrugTest);

                        command.Parameters.AddWithValue("@medicalConditions", medicalConditions);
                        command.Parameters.AddWithValue("@disabilities", disabilities);
                        command.Parameters.AddWithValue("@emergencyMedication", emergencyMedication);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Complete Registration error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ADDITIONAL HELPER METHODS
        public static DataTable GetAllPatients()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                                    id, category, last_name, given_name, middle_name, id_number, 
                                    age, gender, email, contact_number, registration_date
                                    FROM patients 
                                    WHERE status = 'active' 
                                    ORDER BY registration_date DESC";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static DataTable SearchPatients(string searchTerm)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                                    id, category, last_name, given_name, middle_name, id_number, 
                                    age, gender, email, contact_number, registration_date
                                    FROM patients 
                                    WHERE status = 'active' 
                                    AND (last_name LIKE @search 
                                         OR given_name LIKE @search 
                                         OR id_number LIKE @search
                                         OR CONCAT(given_name, ' ', last_name) LIKE @search)
                                    ORDER BY registration_date DESC";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@search", $"%{searchTerm}%");
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching patients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static bool CheckIdNumberExists(string idNumber, int excludePatientId = 0)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM patients WHERE id_number = @idNumber AND id != @excludeId AND status = 'active'";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idNumber", idNumber);
                        command.Parameters.AddWithValue("@excludeId", excludePatientId);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // ADD THESE METHODS TO DatabaseHelper.cs:

        public static DataTable GetDailyReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                                    CONCAT(given_name, ' ', last_name) as Name,
                                    category as Section,
                                    TIME(registration_date) as Time,
                                    CASE 
                                        WHEN medical_conditions IS NOT NULL AND medical_conditions != '' THEN medical_conditions
                                        ELSE 'Regular Checkup'
                                    END as 'Reason of Visit'
                                    FROM patients 
                                    WHERE DATE(registration_date) BETWEEN @fromDate AND @toDate
                                    AND status = 'active'
                                    ORDER BY registration_date DESC";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate.Date);
                        adapter.SelectCommand.Parameters.AddWithValue("@toDate", toDate.Date);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading daily report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static DataTable GetPatientsByCategory()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                                    category as Category,
                                    COUNT(*) as Count,
                                    ROUND((COUNT(*) * 100.0 / (SELECT COUNT(*) FROM patients WHERE status = 'active')), 2) as Percentage
                                    FROM patients 
                                    WHERE status = 'active'
                                    GROUP BY category
                                    ORDER BY Count DESC";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading category report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static DataTable GetMonthlyRegistrations()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                                    MONTHNAME(registration_date) as Month,
                                    YEAR(registration_date) as Year,
                                    COUNT(*) as Registrations
                                    FROM patients 
                                    WHERE status = 'active'
                                    AND registration_date >= DATE_SUB(CURDATE(), INTERVAL 12 MONTH)
                                    GROUP BY YEAR(registration_date), MONTH(registration_date)
                                    ORDER BY YEAR(registration_date) DESC, MONTH(registration_date) DESC
                                    LIMIT 12";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static int GetTotalPatients()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM patients WHERE status = 'active'";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public static int GetTodayRegistrations()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM patients WHERE DATE(registration_date) = CURDATE() AND status = 'active'";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        // ADD THESE METHODS TO DatabaseHelper.cs:

        public static DataTable GetAllInventoryItems()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                            item_name as 'Item Name',
                            quantity as 'Quantity',
                            quantity_remaining as 'Quantity Remaining',
                            received_date as 'Received Date',
                            expiration_date as 'Expiration Date'
                            FROM inventory 
                            WHERE status != 'discontinued'
                            ORDER BY item_name ASC";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static bool AddInventoryItem(string itemName, int quantity, int quantityRemaining, 
            DateTime receivedDate, DateTime? expirationDate, string category, string supplier, 
            decimal costPerUnit, string notes, int createdBy)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO inventory (
                            item_name, quantity, quantity_remaining, received_date, 
                            expiration_date, category, supplier, cost_per_unit, notes, created_by
                            ) VALUES (
                            @itemName, @quantity, @quantityRemaining, @receivedDate,
                            @expirationDate, @category, @supplier, @costPerUnit, @notes, @createdBy
                            )";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@itemName", itemName);
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@quantityRemaining", quantityRemaining);
                        command.Parameters.AddWithValue("@receivedDate", receivedDate);
                        command.Parameters.AddWithValue("@expirationDate", expirationDate?.Date ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@category", category);
                        command.Parameters.AddWithValue("@supplier", supplier);
                        command.Parameters.AddWithValue("@costPerUnit", costPerUnit);
                        command.Parameters.AddWithValue("@notes", notes);
                        command.Parameters.AddWithValue("@createdBy", createdBy);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding inventory item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable SearchInventoryItems(string searchTerm)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                            item_name as 'Item Name',
                            quantity as 'Quantity',
                            quantity_remaining as 'Quantity Remaining',
                            received_date as 'Received Date',
                            expiration_date as 'Expiration Date'
                            FROM inventory 
                            WHERE status != 'discontinued'
                            AND item_name LIKE @search
                            ORDER BY item_name ASC";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@search", $"%{searchTerm}%");
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // ADD THESE METHODS TO DatabaseHelper.cs:

        public static DataTable GetUserProfile(string email)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT id, full_name, email, phone, address, date_of_birth, 
                            gender, position, department, profile_photo_path, role, created_date 
                            FROM users WHERE email = @email";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@email", email);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static bool UpdateUserProfile(int userId, string fullName, string phone, string address, 
            DateTime? dateOfBirth, string gender, string position, string department, string profilePhotoPath)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE users SET 
                            full_name = @fullName, 
                            phone = @phone, 
                            address = @address,
                            date_of_birth = @dateOfBirth,
                            gender = @gender,
                            position = @position,
                            department = @department,
                            profile_photo_path = @profilePhotoPath
                            WHERE id = @userId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@fullName", fullName);
                        command.Parameters.AddWithValue("@phone", phone ?? "");
                        command.Parameters.AddWithValue("@address", address ?? "");
                        command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth?.Date ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@gender", gender ?? "");
                        command.Parameters.AddWithValue("@position", position ?? "");
                        command.Parameters.AddWithValue("@department", department ?? "");
                        command.Parameters.AddWithValue("@profilePhotoPath", profilePhotoPath ?? "");

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool ChangeUserPassword(int userId, string currentPassword, string newPassword)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
            
                    // First verify current password
                    string verifyQuery = "SELECT password FROM users WHERE id = @userId";
                    using (var verifyCommand = new MySqlCommand(verifyQuery, connection))
                    {
                        verifyCommand.Parameters.AddWithValue("@userId", userId);
                        string storedPassword = verifyCommand.ExecuteScalar()?.ToString();
                
                        if (storedPassword != currentPassword)
                        {
                            MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
            
                    // Update password
                    string updateQuery = "UPDATE users SET password = @newPassword WHERE id = @userId";
                    using (var updateCommand = new MySqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@userId", userId);
                        updateCommand.Parameters.AddWithValue("@newPassword", newPassword);
                
                        int result = updateCommand.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static int GetUserIdByEmail(string email)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id FROM users WHERE email = @email";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        object result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public static bool LogUserActivity(int userId, string actionType, string description, string ipAddress = "")
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO activity_logs (user_id, action_type, description, ip_address) 
                            VALUES (@userId, @actionType, @description, @ipAddress)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@actionType", actionType);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@ipAddress", ipAddress);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}