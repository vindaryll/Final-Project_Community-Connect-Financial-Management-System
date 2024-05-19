using community_connect_finance_system.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pv = community_connect_finance_system.Classes.PublicVariables;
namespace community_connect_financial_system.Forms.Funds
{
    public partial class Form4_transfer : Form
    {
        // Create a new instance of the "Functions" class 
        Functions func = new Functions();
        Dbconnect dbcon = new Dbconnect();

        // Declare variables
        double amount;
        int toFundID;
        string date_time_db;
        string reason;

        public Form4_transfer()
        {
            InitializeComponent();

            // Set default values for the combo boxes
            selectComboDefault();

            // Display the fund amount in the label formatted as currency
            lbl_fundAmount.Text = "PHP " + Pv.fundbalance[Pv.fundIndex - 1].ToString("N2");

            // Display the fund name in the label in uppercase
            lbl_fundName.Text = Pv.fundName[Pv.fundIndex - 1].ToString().ToUpper();

            // To avoid transferring fund to itself
            if (Pv.fundIndex - 1 == 0)
            {
                combo_transferTo.SelectedIndex = 1;
            }
            else
            {
                combo_transferTo.SelectedIndex = 0;
            }
        }

        private void combo_transferTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // To avoid tranferring to itself
            if (combo_transferTo.SelectedIndex == Pv.fundIndex - 1) // If the selected index is the same as the current fund
            {
                // Show error message
                func.ShowErrorMessage("You cannot transfer fund to itself");

                // Set the selected index to the other fund if trying to transfer to itself
                if (Pv.fundIndex - 1 == 0) 
                {
                    combo_transferTo.SelectedIndex = 1;
                }
                else
                {
                    combo_transferTo.SelectedIndex = 0;
                }
                return;
            }
        }
        private void OpenForm(Form form)
        {
            // This function Open new form and hide the current form

            form.Show(); // Show new form
            this.Close(); // Close the current form
        }
        private void selectComboDefault()
        {
            // Set the first item as default for all of the combo box
            combo_mm.SelectedIndex = 0;
            combo_dd.SelectedIndex = 0;
            combo_yr.SelectedIndex = 0;
            combo_hr.SelectedIndex = 0;
            combo_min.SelectedIndex = 0;
            combo_period.SelectedIndex = 0;
        }

        private bool TryParseDateTimeFromComboBox(out DateTime result)
        {
            // Initialize result to the minimum value of DateTime
            result = DateTime.MinValue;

            // Construct the date and time string from the combo box selections
            string date_time_string = $"{combo_mm.Text}-{combo_dd.Text}-{combo_yr.Text} " +
                                      $"{combo_hr.Text}:{combo_min.Text} {combo_period.Text}";

            // Attempt to parse the constructed date and time string into a DateTime object
            // using the specified format, and return the result of the parsing operation
            return DateTime.TryParseExact(date_time_string, "MM-dd-yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out result);
        }
        private void checkBox_currtimestamp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_currtimestamp.Checked)
            {
                // Disable all the combo boxes if the checkbox is checked
                combo_mm.Enabled = false;
                combo_dd.Enabled = false;
                combo_yr.Enabled = false;
                combo_hr.Enabled = false;
                combo_min.Enabled = false;
                combo_period.Enabled = false;
            }
            else
            {
                // Enable all the combo boxes if the checkbox is unchecked
                combo_mm.Enabled = true;
                combo_dd.Enabled = true;
                combo_yr.Enabled = true;
                combo_hr.Enabled = true;
                combo_min.Enabled = true;
                combo_period.Enabled = true;
            }
        }

        private void updateComboBoxes()
        {
            // Get the selected month and year from the combo boxes
            string selectedMonth = combo_mm.Text;
            string selectedYearText = combo_yr.Text;

            // List of months with 31 days
            string[] monthsWith31Days = { "01", "03", "05", "07", "08", "10", "12" };

            // Check if the selected month has 31 days
            if (monthsWith31Days.Contains(selectedMonth))
            {
                // Add days 29, 30, and 31 to the day combo box if they don't already exist
                AddDayIfNotExists("29");
                AddDayIfNotExists("30");
                AddDayIfNotExists("31");
            }
            else if (selectedMonth == "02") // February
            {
                // Check if the selected year is valid
                if (int.TryParse(selectedYearText, out int selectedYear) && selectedYear <= 9999)
                {
                    // Check if the selected year is a leap year
                    if (DateTime.IsLeapYear(selectedYear))
                    {
                        // If the selected day is 29 or higher, set it to 29
                        if (GetSelectedDay(combo_dd) >= 29)
                        {
                            combo_dd.SelectedItem = "29";
                        }
                        // Ensure day 29 is available, and remove days 30 and 31
                        AddDayIfNotExists("29");
                        RemoveDayIfExists("30");
                        RemoveDayIfExists("31");

                    }
                    else
                    {
                        // If the selected day is 28 or higher, set it to 28
                        if (GetSelectedDay(combo_dd) >= 28)
                        {
                            combo_dd.SelectedItem = "28";
                        }
                        // Remove days 29, 30, and 31
                        RemoveDayIfExists("29");
                        RemoveDayIfExists("30");
                        RemoveDayIfExists("31");
                    }
                }
                else
                {
                    // invalid year
                    return;
                }
            }
            else
            {
                // For months with 30 days
                if (GetSelectedDay(combo_dd) >= 30)
                {
                    combo_dd.SelectedItem = "30";
                }
                // Ensure days 29 and 30 are available, and remove day 31
                AddDayIfNotExists("29");
                AddDayIfNotExists("30");
                RemoveDayIfExists("31");
            }
        }
        private int GetSelectedDay(ComboBox comboBox)
        {
            // Get the selected day from the combo box as an integer

            // Try parsing the text of the combo box to an integer
            if (int.TryParse(comboBox.Text, out int selectedDay))
            {
                // Return the parsed integer
                return selectedDay;
            }
            else
            {
                // Return 1 if parsing fails
                return 1;
            }
            
        }
        private void AddDayIfNotExists(string day)
        {
            // Add a day to the day combo box if it doesn't already exist

            if (!combo_dd.Items.Contains(day))
            {
                combo_dd.Items.Add(day);
            }
        }
        private void RemoveDayIfExists(string day)
        {
            // Remove a day from the day combo box if it exists

            if (combo_dd.Items.Contains(day))
            {
                combo_dd.Items.Remove(day);
            }
        }
        private void comboBoxesChecker()
        {
            // Check if combo box values are within range

            // Check the selected month
            if (!combo_mm.Items.Contains(combo_mm.Text))
            {
                func.ShowErrorMessage("Month is out of range");
                combo_mm.SelectedIndex = 0; // Set the selected index to the default value
                return;
            }

            // Check the selected day
            if (!combo_dd.Items.Contains(combo_dd.Text))
            {
                func.ShowErrorMessage("Day is out of range");
                combo_dd.SelectedIndex = 0; // Set the selected index to the default value
                return;
            }

            // Check the selected year
            if (!combo_yr.Items.Contains(combo_yr.Text))
            {
                func.ShowErrorMessage("Year is out of range");
                combo_yr.SelectedIndex = 0; // Set the selected index to the default value
                return;
            }

            // Check the selected hour
            if (!combo_hr.Items.Contains(combo_hr.Text))
            {
                func.ShowErrorMessage("Hour is out of range");
                combo_hr.SelectedIndex = 0; // Set the selected index to the default value
                return;
            }

            // Check the selected minute
            if (!combo_min.Items.Contains(combo_min.Text))
            {
                func.ShowErrorMessage("Minute is out of range");
                combo_min.SelectedIndex = 0; // Set the selected index to the default value
                return;
            }

            // Check the selected period
            if (!combo_period.Items.Contains(combo_period.Text))
            {
                func.ShowErrorMessage("Period is out of range");
                combo_period.SelectedIndex = 0; // Set the selected index to the default value
                return;
            }
        }
        private void ConvertTextToD2(ComboBox comboBox)
        {
            // Convert the text of the combo box to a two-digit format

            // Try parsing the text of the combo box to an integer
            if (int.TryParse(comboBox.Text, out int number))
            {
                // Convert the parsed integer to a two-digit string format and set it as the combo box text
                comboBox.Text = number.ToString("D2");
            }
        }

        private void combo_mm_Leave(object sender, EventArgs e)
        {
            // Convert the text of the month combo box to a two-digit format
            ConvertTextToD2(combo_mm);

            // Update the day combo box
            updateComboBoxes();

            // Check if combo box values are within range
            comboBoxesChecker();
        }

        private void combo_dd_Leave(object sender, EventArgs e)
        {
            // Convert the text of the day combo box to a two-digit format
            ConvertTextToD2(combo_dd);

            // Check if combo box values are within range
            comboBoxesChecker();
        }

        private void combo_yr_Leave(object sender, EventArgs e)
        {
            // Convert the text of the year combo box to a two-digit format
            ConvertTextToD2(combo_yr);

            // Update the day combo box
            updateComboBoxes();

            // Check if combo box values are within range
            comboBoxesChecker();
        }

        private void combo_hr_Leave(object sender, EventArgs e)
        {
            // Convert the text of the hour combo box to a two-digit format
            ConvertTextToD2(combo_hr);

            // Check if combo box values are within range
            comboBoxesChecker();
        }

        private void combo_min_Leave(object sender, EventArgs e)
        {
            // Convert the text of the minute combo box to a two-digit format
            ConvertTextToD2(combo_min);

            // Check if combo box values are within range
            comboBoxesChecker();
        }

        private void combo_period_Leave(object sender, EventArgs e)
        {
            // Convert the text to lowercase
            combo_period.Text = combo_period.Text.ToLower();

            // Check if combo box values are within range
            comboBoxesChecker();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            // Open Form2_AllocatedFundInfo
            OpenForm(new Form2_AllocatedFundInfo());
        }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            // Check if reason or amount fields are empty
            if (string.IsNullOrEmpty(txt_amount.Text) || string.IsNullOrEmpty(txt_reason.Text) || combo_transferTo.SelectedItem == null)
            {
                func.ShowErrorMessage("Please fill out everything");
                return;
            }

            // Check if the amount is a valid positive numeric value
            if (!double.TryParse(txt_amount.Text, out amount) || amount <= 0)
            {
                func.ShowErrorMessage("Invalid input. Please enter a positive numeric value for the amount");
                txt_amount.Text = string.Empty;
                return;
            }

            // Check if the amount exceeds the fund balance
            if (amount > Pv.fundbalance[Pv.fundIndex - 1])
            {
                func.ShowErrorMessage("Amount exceeds the fund balance");
                txt_amount.Text = string.Empty;
                return;
            }

            // Assign reason from text box
            reason = txt_reason.Text;

            // Get the fund id where the funds will be transferred to
            dbcon.OpenCon();
            string query = $"SELECT fundID FROM funds WHERE fundname = '{combo_transferTo.SelectedItem}'";
            MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                // Store value on the variable
                toFundID = reader.GetInt32(reader.GetOrdinal("fundID"));
                dbcon.CloseCon();
            }
            else
            {
                // Show error message
                func.ShowErrorMessage("Can't fetch data, go check the name of your funds in the database");
                dbcon.CloseCon();
                return;
            }


            if (checkBox_currtimestamp.Checked) // Check if current timestamp checkbox is checked
            {
                date_time_db = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                // Try parsing date and time from combo boxes
                if (!TryParseDateTimeFromComboBox(out DateTime date_time_inputted))
                    return;

                // Check if inputted date exceeds the current date and time
                if (date_time_inputted > DateTime.Now)
                {
                    func.ShowErrorMessage("Inputted date cannot exceed the current timestamp.");
                    return;
                }

                // Get date and time in the required format
                date_time_db = date_time_inputted.ToString("yyyy-MM-dd HH:mm:ss");
            }

            // Add "Transfer" record to the database
            func.transfer(amount, Pv.fundID[Pv.fundIndex - 1], toFundID, reason, date_time_db);

            // Update fund balance information
            func.getFundInfo();

            // Refresh UI elements
            lbl_fundAmount.Text = Pv.fundbalance[Pv.fundIndex - 1].ToString("N2");
            txt_amount.Text = string.Empty;
            txt_reason.Text = string.Empty;
            selectComboDefault();
            checkBox_currtimestamp.Checked = false;
        }
    }
}
