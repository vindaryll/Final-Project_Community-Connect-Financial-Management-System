using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using Google.Protobuf.WellKnownTypes;
using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Color = System.Drawing.Color;
using Pv = community_connect_finance_system.Classes.PublicVariables;

namespace community_connect_finance_system.Classes
{
    public class Functions
    {
        Dbconnect dbcon = new Dbconnect();

        public void populatePieChart(LiveCharts.WinForms.PieChart chart, Panel legendPanel)
        {
            try
            {
                // Fetching values from the database
                dbcon.OpenCon();
                string query = "SELECT allocated_percentage, fundname FROM funds WHERE fundName != 'Unallocated Fund'";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                adapt.Fill(dt);

                // Clear any existing series in the chart
                chart.Series.Clear();

                // Create a new series collection for the chart
                SeriesCollection seriesCollection = new SeriesCollection();

                Color[] colors = new Color[] { Color.Blue, Color.Green, Color.Red, Color.Yellow, Color.Orange, Color.Purple, Color.Cyan, Color.Magenta, Color.Brown };
                int initial_y = 20, y = 0; // reference for legend's location
                foreach (DataRow row in dt.Rows)
                {
                    double percentage = Convert.ToDouble(row["allocated_percentage"]);
                    string fundName = row["fundname"].ToString();
                    int index = seriesCollection.Count; // Index to select color from the array

                    PieSeries pieSeries = new PieSeries
                    {
                        Title = fundName,
                        Values = new ChartValues<double> { percentage },
                        DataLabels = false,
                        Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(colors[index].R, colors[index].G, colors[index].B)),
                        LabelPoint = chartPoint => " "
                    };
                    seriesCollection.Add(pieSeries);

                    // Create a label for the legend entry
                    Label legendLabel = new Label();
                    legendLabel.Text = fundName;
                    legendLabel.Size = new Size(339, 36);
                    legendLabel.Location = new Point(38, initial_y + y); 
                    legendLabel.AutoSize = false;
                    legendLabel.TextAlign = ContentAlignment.TopLeft;
                    legendLabel.Font = new Font("Arial Rounded MT Bold", 12, FontStyle.Regular);
                    legendLabel.ForeColor = Color.FromArgb(0, 41, 96);


                    // Create a colored rectangle for the legend entry
                    Panel colorPanel = new Panel();
                    colorPanel.Size = new Size(18, 18);
                    colorPanel.BackColor = colors[index];
                    colorPanel.Location = new Point(17, initial_y + y); 

                    y += 43;

                    // Add controls to the legend panel
                    legendPanel.Controls.Add(legendLabel);
                    legendPanel.Controls.Add(colorPanel);

                }
                chart.Series = seriesCollection;


            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage($"An error occurred: {ex.Message}");
            }
        }

        public void getAccountInfo()
        {
            try
            {
                // Fetch data from the database
                dbcon.OpenCon();
                string query = $"SELECT username, email, password FROM management WHERE managementID = 1;";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                // Store data on variables
                Pv.username = reader.GetString(reader.GetOrdinal("username"));
                Pv.email = reader.GetString(reader.GetOrdinal("email"));
                Pv.password = reader.GetString(reader.GetOrdinal("password"));
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);
            }
            finally
            {
                dbcon.CloseCon();
            }
        }

        public void getFundInfo()
        {
            int i = 0;
            int rowCount = 0;
            try
            {
                // Fetch data from the database
                dbcon.OpenCon();
                string query = $"SELECT fundID, fundname, balance FROM funds;";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    // Count the number of rows returned
                    while (reader.Read())
                    {
                        rowCount++;
                    }

                    // Initialized arrays based on the row count
                    Pv.fundID = new int[rowCount];
                    Pv.fundName = new string[rowCount];
                    Pv.fundbalance = new double[rowCount];

                    reader.Close();

                    reader = cmd.ExecuteReader();

                    // Populate arrays and store each column value
                    while (reader.Read())
                    {
                        Pv.fundID[i] = reader.GetInt32(reader.GetOrdinal("fundID"));
                        Pv.fundName[i] = reader.GetString(reader.GetOrdinal("fundname"));
                        Pv.fundbalance[i] = reader.GetDouble(reader.GetOrdinal("balance"));
                        i++;
                    }
                }              
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);
            }
            finally
            {
                dbcon.CloseCon();
            }
        }

        public void login(string usernameOrEmail, string password)
        {
            // Check if the provided username or email matches the stored username or email
            // and if the provided password matches the stored password
            if ((Pv.username == usernameOrEmail || Pv.email == usernameOrEmail) && Pv.password == password)
            {
                // If both conditions are true
                Pv.log = true;
            }
            else
            {
                // If both conditions are false
                Pv.log = false;
            }
        }

        public void resetPassOTP(string email)
        {
            string from, pass, messageBody, to;

            // Generate a random code for OTP
            Random rand = new Random();
            Pv.randomCode = (rand.Next(999999)).ToString();

            MailMessage message = new MailMessage();

            // Configure the SMTP client for Gmail
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            // Set the recipient email address
            to = email;

            // Set the sender email address (server email)
            from = "brgyotpcode@gmail.com";

            // Set the sender email password (app-password of server email)
            pass = "ygjdvqufmlewbmgb";

            // Compose the email body with the OTP code
            messageBody = $"Ignore this message if you didn't reset your password \n\n\tYour code is \"{Pv.randomCode}\". ";

            // Set the email details: recipient, sender, body, and subject
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password reseting code for barangay financial management system";

            // Configure the SMTP client settings
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            smtp.EnableSsl = true;
            try
            {
                // Send the email
                smtp.Send(message);

                // Inform the user that the verification code has been sent
                MessageBox.Show($"The verification code has been successfully sent to your email: {email}\n\nPlease check your inbox for the message. If you don't see it, please also check your spam or junk folder.", "Verification Code Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Set it true indicating that the OTP has been sent
                Pv.otpsent = true;
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);
            }
        }

        public void resetPass(string password)
        {
            try
            {
                // Update the password on the database
                dbcon.OpenCon();
                string query = $"UPDATE management SET password = '{password}' WHERE username = '{Pv.username}';";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();

                // Inform the user that the password has been successfully changed
                ShowSuccessfulMessage("Your password has been successfully changed");
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);
            }
            finally
            {
                dbcon.CloseCon();
            }
        }

        public void changeEmailOTP(string email)
        {
            string from, pass, messageBody, to;

            // Generate a random code for OTP
            Random rand = new Random();
            Pv.randomCode = (rand.Next(999999)).ToString();

            MailMessage message = new MailMessage();

            // Configure the SMTP client for Gmail
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            // Set the recipient email address
            to = email;

            // Set the sender email address (server email)
            from = "brgyotpcode@gmail.com";

            // Set the sender email password (app-password of server email)
            pass = "ygjdvqufmlewbmgb";

            // Compose the email body with the OTP code
            messageBody = $"This code is for changing admin email address, Ignore this message if you didn't do this transaction \n\n\tYour code is \"{Pv.randomCode}\". ";

            // Set the email details: recipient, sender, body, and subject
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Changing email code for barangay financial management system";

            // Configure the SMTP client settings
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            smtp.EnableSsl = true;
            try
            {
                // Send the email
                smtp.Send(message);

                // Inform the user that the verification code has been sent
                MessageBox.Show($"The verification code has been successfully sent to your email: {email}\n\nPlease check your inbox for the message. If you don't see it, please also check your spam or junk folder.", "Verification Code Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Set it true indicating that the OTP has been sent
                Pv.otpsent = true;
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);
            }
        }

        public void changeEmail(string email)
        {
            try
            {
                // Update the email on the database
                dbcon.OpenCon();
                string query = $"UPDATE management SET email = '{email}' WHERE username = '{Pv.username}';";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();

                // Inform the user that the email has been successfully changed
                ShowSuccessfulMessage("The email has been successfully changed");
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);
            }
            finally
            {
                dbcon.CloseCon();
            }
        }

        public void changeUsername(string username)
        {
            try
            {
                // Update the username on the database
                dbcon.OpenCon();
                string query = $"UPDATE management SET username = '{username}' WHERE username = '{Pv.username}';";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();

                // Inform the user that the email has been successfully changed
                ShowSuccessfulMessage("The username has been successfully changed");
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);
            }
            finally
            {
                dbcon.CloseCon();
            }
        }

        public void getTotalAllocatedFunds()
        {
            try
            {
                // Fetch the total balance of all allocated funds
                dbcon.OpenCon();
                string query = $"SELECT SUM(balance) AS total_balance FROM funds\r\nWHERE fundname != 'Unallocated Fund';";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                // Store data on the variable
                Pv.totalAllocated = reader.GetDouble(reader.GetOrdinal("total_balance"));
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);
            }
            finally
            {
                dbcon.CloseCon();
            }
        }

        // USE TO RETRIEVE DATA IN TRANSACTION ORDERS: VIEW MORE
        public void fetchOrderTransaction(int orderID, string transaction_type)
        {
            try
            {
                // Fetch the executed_timestamp of the transaction
                dbcon.OpenCon();
                string query = $"SELECT executed_timestamp FROM transactions_order WHERE orderID = {orderID}";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                // Retrieve executed_timestamp and format it
                if (reader.HasRows)
                {
                    // Store it on a variable
                    DateTime dt_executed_timestamp = reader.GetDateTime(reader.GetOrdinal("executed_timestamp"));
                    Pv.executed_timestamp = dt_executed_timestamp.ToString("yyyy-MM-dd hh:mm tt");
                }
                dbcon.CloseCon();

                // Perform actions based on transaction type
                switch (transaction_type)
                {
                    case "cashin":
                        // Retrieve Cash in(Add balance) information from the database
                        dbcon.OpenCon();
                        query = $"SELECT a.cashin_date, a.cashin_amount, a.source FROM cashin_history a JOIN transactions_order b ON b.orderID = a.orderID WHERE b.orderID = {orderID}";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            // Store values on variables
                            double dt_cashin_amount = reader.GetDouble(reader.GetOrdinal("cashin_amount"));
                            Pv.cashin_amount += dt_cashin_amount.ToString("N2");

                            Pv.cashin_source = reader.GetString(reader.GetOrdinal("source"));

                            DateTime dt_cashin_date = reader.GetDateTime(reader.GetOrdinal("cashin_date"));
                            Pv.cashin_date = dt_cashin_date.ToString("yyyy-MM-dd hh:mm tt");
                        }

                        break;

                    case "distribution":
                        // Retrieve Distribution information from the database
                        dbcon.OpenCon();
                        query = $"SELECT a.distribution_date, a.distributed_amount FROM distribution_history a JOIN transactions_order b ON b.orderID = a.orderID WHERE b.orderID = {orderID}";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            // Store values on variables
                            double dt_distributed_amount = reader.GetDouble(reader.GetOrdinal("distributed_amount"));
                            Pv.distributed_amount += dt_distributed_amount.ToString("N2");

                            DateTime dt_distribution_date = reader.GetDateTime(reader.GetOrdinal("distribution_date"));
                            Pv.distribution_date = dt_distribution_date.ToString("yyyy-MM-dd hh:mm tt");
                        }

                        break;

                    case "expenses":
                        // Retrieve Expense information from the database
                        dbcon.OpenCon();
                        query = $"SELECT a.fundname, b.expense_date, b.expense_amount, b.reason FROM funds a JOIN expenses_history b ON b.fundID = a.fundID JOIN transactions_order c ON c.orderID = b.orderID WHERE c.orderID = {orderID}";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            // Store values on variables
                            Pv.expense_fundName = reader.GetString(reader.GetOrdinal("fundName"));
                            Pv.expense_reason = reader.GetString(reader.GetOrdinal("reason"));

                            double dt_expense_amount = reader.GetDouble(reader.GetOrdinal("expense_amount"));
                            Pv.expense_amount += dt_expense_amount.ToString("N2");

                            DateTime dt_expense_date = reader.GetDateTime(reader.GetOrdinal("expense_date"));
                            Pv.expense_date = dt_expense_date.ToString("yyyy-MM-dd hh:mm tt");
                        }

                        break;

                    case "transfer":
                        // Retrieve Transfer information from the database
                        dbcon.OpenCon();
                        query = $"SELECT DISTINCT    (SELECT fundname FROM funds WHERE fundID = b.from_fundID) AS from_fund_name,    (SELECT fundname FROM funds WHERE fundID = c.to_fundID) AS to_fund_name,    b.transfer_date,    b.transfer_amount,    b.reason FROM    transfer_history b JOIN    transfer_history c ON c.to_fundID = b.to_fundID JOIN   transactions_order d ON c.orderID = b.orderID WHERE    c.orderID = {orderID}";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            // Store values on variables
                            Pv.from_fundName = reader.GetString(reader.GetOrdinal("from_fund_name"));
                            Pv.to_fundName = reader.GetString(reader.GetOrdinal("to_fund_name"));
                            Pv.transfer_reason = reader.GetString(reader.GetOrdinal("reason"));

                            double dt_transfer_amount = reader.GetDouble(reader.GetOrdinal("transfer_amount"));
                            Pv.transfer_amount += dt_transfer_amount.ToString("N2");

                            DateTime dt_transfer_date = reader.GetDateTime(reader.GetOrdinal("transfer_date"));
                            Pv.transfer_date = dt_transfer_date.ToString("yyyy-MM-dd hh:mm tt");
                        }
                        break;
                    default:
                        // Message box function for error display
                        ShowErrorMessage($"Undefined transaction type: {transaction_type}");
                        break;

                }
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);
            }
        }

        // USED FOR MESSAGE BOX: UNDO TRANSACTION
        public string getLatestTransaction()
        {
            string transactionDetails;
            try
            {
                string transaction_type = "";
                string executed_timestamp = "";

                // Retrieve transaction details from the database
                dbcon.OpenCon();
                string query = $"SELECT orderID, transaction_type, executed_timestamp FROM transactions_order ORDER BY orderID DESC LiMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    // Store values on variables
                    transaction_type = reader.GetString(reader.GetOrdinal("transaction_type"));
                    DateTime dt_executed_timestamp = reader.GetDateTime(reader.GetOrdinal("executed_timestamp"));
                    executed_timestamp = dt_executed_timestamp.ToString("yyyy-MM-dd hh:mm tt");
                }
                dbcon.CloseCon();

                // Process based on transaction type
                switch (transaction_type)
                {
                    
                    case "cashin":
                        // Retrieve Cash in(Add balance) information from the database
                        string cashin_date = "", cashin_amount = "", source = "";

                        dbcon.OpenCon();
                        query = $"SELECT a.cashin_date, a.cashin_amount, a.source FROM cashin_history a JOIN transactions_order b ON b.orderID = a.orderID WHERE b.orderID = (SELECT MAX(orderID) FROM transactions_order)";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            // Store values on variables
                            double dt_cashin_amount = reader.GetDouble(reader.GetOrdinal("cashin_amount"));
                            cashin_amount += dt_cashin_amount.ToString("N2");

                            source = reader.GetString(reader.GetOrdinal("source"));

                            DateTime dt_cashin_date = reader.GetDateTime(reader.GetOrdinal("cashin_date"));
                            cashin_date = dt_cashin_date.ToString("yyyy-MM-dd hh:mm tt");
                        }

                        // Construct transaction details string
                        transactionDetails = $"DO YOU WANNA UNDO THE LATEST TRANSACTION?\n\n Transaction Type: {transaction_type}\n Executed Timestamp: {executed_timestamp}\n Cash in Date: {cashin_date}\n Amount: PHP {cashin_amount}\n Source: {source}\n";
                        
                        break;
                    case "distribution":
                        // Retrieve Distribution information from the database
                        string distribution_date = "", distributed_amount = "";

                        dbcon.OpenCon();
                        query = $"SELECT a.distribution_date, a.distributed_amount FROM distribution_history a JOIN transactions_order b ON b.orderID = a.orderID WHERE b.orderID = (SELECT MAX(orderID) FROM transactions_order)";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            // Store values on variables
                            double dt_distributed_amount = reader.GetDouble(reader.GetOrdinal("distributed_amount"));
                            distributed_amount += dt_distributed_amount.ToString("N2");

                            DateTime dt_distribution_date = reader.GetDateTime(reader.GetOrdinal("distribution_date"));
                            distribution_date = dt_distribution_date.ToString("yyyy-MM-dd hh:mm tt");
                        }

                        // Construct transaction details string
                        transactionDetails = $"DO YOU WANNA UNDO THE LATEST TRANSACTION?\n\n Transaction Type: {transaction_type}\n Executed Timestamp: {executed_timestamp}\n Distribution Date: {distribution_date}\n Amount: PHP {distributed_amount}\n";

                        break;
                    case "expenses":
                        // Retrieve Expense information from the database
                        string fundName = "", expense_date = "", expense_amount = "", expense_reason = "";

                        dbcon.OpenCon();
                        query = $"SELECT a.fundname, b.expense_date, b.expense_amount, b.reason FROM funds a JOIN expenses_history b ON b.fundID = a.fundID JOIN transactions_order c ON c.orderID = b.orderID WHERE c.orderID = (SELECT MAX(orderID) FROM transactions_order)";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            // Store values on variables
                            fundName = reader.GetString(reader.GetOrdinal("fundName"));
                            expense_reason = reader.GetString(reader.GetOrdinal("reason"));

                            double dt_expense_amount = reader.GetDouble(reader.GetOrdinal("expense_amount"));
                            expense_amount += dt_expense_amount.ToString("N2");

                            DateTime dt_expense_date = reader.GetDateTime(reader.GetOrdinal("expense_date"));
                            expense_date = dt_expense_date.ToString("yyyy-MM-dd hh:mm tt");
                        }

                        // Construct transaction details string
                        transactionDetails = $"DO YOU WANNA UNDO THE LATEST TRANSACTION?\n\n Transaction Type: {transaction_type}\n Executed Timestamp: {executed_timestamp}\n Expense Date: {expense_date}\n Fundname: {fundName}\n Amount: PHP {expense_amount}\n Reason: {expense_reason}\n";
                        
                        break;
                    case "transfer":
                        // Retrieve Transfer information from the database
                        string to_fundName = "", from_fundName = "", transfer_date = "", transfer_amount = "", transfer_reason = "";

                        dbcon.OpenCon();
                        query = $"SELECT DISTINCT    (SELECT fundname FROM funds WHERE fundID = b.from_fundID) AS from_fund_name,    (SELECT fundname FROM funds WHERE fundID = c.to_fundID) AS to_fund_name,    b.transfer_date,    b.transfer_amount,    b.reason FROM    transfer_history b JOIN    transfer_history c ON c.to_fundID = b.to_fundID JOIN   transactions_order d ON c.orderID = b.orderID WHERE    c.orderID = (SELECT MAX(orderID) FROM transactions_order);";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            // Store values on variables
                            from_fundName = reader.GetString(reader.GetOrdinal("from_fund_name"));
                            to_fundName = reader.GetString(reader.GetOrdinal("to_fund_name"));
                            transfer_reason = reader.GetString(reader.GetOrdinal("reason"));

                            double dt_transfer_amount = reader.GetDouble(reader.GetOrdinal("transfer_amount"));
                            transfer_amount += dt_transfer_amount.ToString("N2");

                            DateTime dt_transfer_date = reader.GetDateTime(reader.GetOrdinal("transfer_date"));
                            transfer_date = dt_transfer_date.ToString("yyyy-MM-dd hh:mm tt");
                        }

                        // Construct transaction details string
                        transactionDetails = $"DO YOU WANNA UNDO THE LATEST TRANSACTION?\n\n Transaction Type: {transaction_type}\n Executed Timestamp: {executed_timestamp}\n Transfer Date: {transfer_date}\n From: {from_fundName}\n To: {to_fundName}\n Amount: PHP {transfer_amount}\n Reason: {transfer_reason}\n";
                       
                        break;
                    default:
                        // Set default transaction details for undefined transaction types
                        transactionDetails = $"An error occurred: Undefined or Empty transaction"; 
                         break;
                }
            }
            catch (Exception ex)
            {
                // Handles error message
                transactionDetails = $"An error occurred: {ex.Message}";
            }
            finally
            {
                dbcon.CloseCon();
            }

            // Return the generated transaction details
            return transactionDetails;
        }
        public void undoTransaction()
        {
            try
            {
                // Get the latest transaction order id
                dbcon.OpenCon();
                string query = "SELECT MAX(orderID) latest_order_id FROM transactions_order;";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows && !reader.IsDBNull(reader.GetOrdinal("latest_order_id")))
                {
                    
                    // Store latest transaction order id in a variable for query purposes
                    int latest_order_id = reader.GetInt32(reader.GetOrdinal("latest_order_id"));
                    dbcon.CloseCon();

                    // Get the transaction type of latest transaction
                    dbcon.OpenCon();
                    query = $"SELECT transaction_type FROM transactions_order WHERE orderID = {latest_order_id}";
                    cmd = new MySqlCommand(query, dbcon.Getcon());
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        // Store the transaction typo on a variable
                        string latest_transaction_type = reader.GetString(reader.GetOrdinal("transaction_type"));
                        dbcon.CloseCon();

                        // Make a condition for transaction type
                        switch (latest_transaction_type)
                        {
                            case "cashin":
                                // Get the cashin amount from cashin_history
                                dbcon.OpenCon();
                                query = $"SELECT cashin_amount FROM cashin_history WHERE orderID = {latest_order_id}";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                reader = cmd.ExecuteReader();
                                reader.Read();

                                // Store the amount on a variable
                                double cashin_amount = reader.GetDouble(reader.GetOrdinal("cashin_amount"));
                                dbcon.CloseCon();

                                // Update the balance of the unallocated fund
                                dbcon.OpenCon();
                                query = $"UPDATE funds SET balance = balance - {cashin_amount} WHERE abbreviation = 'UN'";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();
                                dbcon.CloseCon();

                                // Delete the records from transactions_order, you don't have to delete the record from cashin_history since it is on delete cascade
                                dbcon.OpenCon();
                                query = $"DELETE FROM transactions_order WHERE orderID = {latest_order_id};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();

                                // Inform the user that the latest transaction has been undone
                                ShowSuccessfulMessage("The most recent transaction (Cash in/Add balance) has been successfully undone");
                                break;

                            case "distribution":
                                // Get the distributed amount from distribution_history
                                dbcon.OpenCon();
                                query = $"SELECT distributed_amount FROM distribution_history WHERE orderID = {latest_order_id};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                reader = cmd.ExecuteReader();
                                reader.Read();

                                // Store the amount on a variable
                                double distributed_amount = reader.GetDouble(reader.GetOrdinal("distributed_amount"));
                                dbcon.CloseCon();

                                // Update the balance of the unallocated fund
                                dbcon.OpenCon();
                                query = $"UPDATE funds SET balance = balance + {distributed_amount} WHERE abbreviation = 'UN';";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();
                                dbcon.CloseCon();

                                // Update the balance of allocated funds
                                dbcon.OpenCon();
                                query = $"UPDATE funds SET balance = balance - (allocated_percentage / 100 * {distributed_amount}) WHERE fundname != 'Unallocated Fund';";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();
                                dbcon.CloseCon();

                                // Delete the transaction record from transactions_order, distribution_history is on delete cascade
                                dbcon.OpenCon();
                                query = $"DELETE FROM transactions_order WHERE orderID = {latest_order_id};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();

                                // Inform the user that the latest transaction has been undone
                                ShowSuccessfulMessage("The most recent transaction (Distribution) has been successfully undone.");
                                break;

                            case "expenses":
                                // Get the expense details from expenses_history
                                dbcon.OpenCon();
                                query = $"SELECT expense_amount, fundID FROM expenses_history WHERE orderID = {latest_order_id};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                reader = cmd.ExecuteReader();
                                reader.Read();

                                // Store values on variables
                                int expense_fundID = reader.GetInt32(reader.GetOrdinal("fundID"));
                                double expense_amount = reader.GetDouble(reader.GetOrdinal("expense_amount"));
                                dbcon.CloseCon();

                                // Update the balance of the affected fund
                                dbcon.OpenCon();
                                query = $"UPDATE funds SET balance = balance + {expense_amount} WHERE fundID = {expense_fundID};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();
                                dbcon.CloseCon();

                                // Delete the transaction record
                                dbcon.OpenCon();
                                query = $"DELETE FROM transactions_order WHERE orderID = {latest_order_id};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();

                                // Inform the user that the latest transaction has been undone
                                ShowSuccessfulMessage("The most recent transaction (Expenditure) has been successfully undone.");
                                break;

                            case "transfer":
                                // Get the expense details from expenses_history
                                dbcon.OpenCon();
                                query = $"SELECT transfer_amount, from_fundID, to_fundID FROM transfer_history WHERE orderID = {latest_order_id};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                reader = cmd.ExecuteReader();
                                reader.Read();

                                // Store values on variables
                                double transfer_amount = reader.GetDouble(reader.GetOrdinal("transfer_amount"));
                                int from_fundID = reader.GetInt32(reader.GetOrdinal("from_fundID"));
                                int to_fundID = reader.GetInt32(reader.GetOrdinal("to_fundID"));
                                dbcon.CloseCon();

                                // Update the balance of from_fund
                                dbcon.OpenCon();
                                query = $"UPDATE funds SET balance = balance + {transfer_amount} WHERE fundID = {from_fundID};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();
                                dbcon.CloseCon();

                                // Update the balance of to_fund
                                dbcon.OpenCon();
                                query = $"UPDATE funds SET balance = balance - {transfer_amount} WHERE fundID = {to_fundID};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();
                                dbcon.CloseCon();

                                // Delete transaction record
                                dbcon.OpenCon();
                                query = $"DELETE FROM transactions_order WHERE orderID = {latest_order_id};";
                                cmd = new MySqlCommand(query, dbcon.Getcon());
                                cmd.ExecuteNonQuery();

                                // Inform the user that the latest transaction has been undone
                                ShowSuccessfulMessage("The most recent transaction (Transfer) has been successfully undone.");
                                break;

                            default:

                                // Message box function for error display
                                ShowErrorMessage("Unknown Error: Can't find the transaction_type");
                                break;
                        }
                    }
                    else
                    {
                        // Message box function for error display
                        ShowErrorMessage("No rows for latest order id");
                    }
                }
                else
                {
                    // Message box function for error display
                    ShowErrorMessage("Empty transactions");
                }
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage(ex.Message);

            }
            finally { dbcon.CloseCon(); }
        }

        // TRANSACTIONS
        public void cashin(double amount, string source, string timestamp)
        {
            int orderID;
            try
            {
                // Retrieve the latest transaction ID
                dbcon.OpenCon();
                string query = "SELECT MAX(orderID) as latestid FROM transactions_order;";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows && !reader.IsDBNull(reader.GetOrdinal("latestid")))
                {
                    // Increment the latest transaction ID to prepare for insertion
                    orderID = reader.GetInt32(reader.GetOrdinal("latestid")) + 1;
                }
                else
                {
                    // Start the transaction ID from 1 if no previous transactions exist
                    orderID = 1;
                }
                dbcon.CloseCon();

                // Insert on overall transaction history
                dbcon.OpenCon();
                query = $"INSERT INTO transactions_order (orderID, transaction_type) VALUES ({orderID}, 'cashin')";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();

                // Inserting records on cashin_history
                dbcon.OpenCon();
                query = $"INSERT cashin_history (cashinID, orderID, cashin_date, cashin_amount, source) SELECT IFNULL(MAX(cashinID), 0) + 1, {orderID}, '{timestamp}', {amount}, '{source}' FROM cashin_history;";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();

                // Update the balance of Unallocated fund
                dbcon.OpenCon();
                query = $"UPDATE funds SET balance = balance + {amount} WHERE fundname = 'Unallocated Fund';";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();

                // Inform the user that the transaction has been completed
                ShowSuccessfulMessage("Transaction completed: Balance added successfully");

            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage($"An error occurred: {ex.Message}");
            }
            finally { dbcon.CloseCon(); }
        }

        public void expenses(int fundID, double amount, string reason, string timestamp)
        {
            int orderID;
            double prev_balance = 0, after_balance = 0;
            try
            {
                // Retrieve the latest transaction ID
                dbcon.OpenCon();
                string query = "SELECT MAX(orderID) as latestid FROM transactions_order;";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows && !reader.IsDBNull(reader.GetOrdinal("latestid")))
                {
                    // Increment the latest transaction ID to prepare for insertion
                    orderID = reader.GetInt32(reader.GetOrdinal("latestid")) + 1;
                }
                else 
                {
                    // Start the transaction ID from 1 if no previous transactions exist
                    orderID = 1;
                }

                dbcon.CloseCon();

                // Insert on overall transaction history
                dbcon.OpenCon();
                query = $"INSERT INTO transactions_order (orderID, transaction_type) VALUES ({orderID}, 'expenses')";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();

                // Get the prev and after balance
                dbcon.OpenCon();
                query = $"SELECT balance AS prev_balance, balance - {amount} AS after_balance FROM funds WHERE fundID = {fundID}";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    // Store values on variables
                    prev_balance = reader.GetDouble(reader.GetOrdinal("prev_balance"));
                    after_balance = reader.GetDouble(reader.GetOrdinal("after_balance"));
                }
                dbcon.CloseCon();

                // Inserting records on expenses_history
                dbcon.OpenCon();
                query = $"INSERT expenses_history (expenseID, orderID, expense_amount, prev_balance, after_balance, expense_date, reason, fundID) SELECT IFNULL(MAX(expenseID), 0) + 1, {orderID}, {amount}, {prev_balance}, {after_balance}, '{timestamp}', '{reason}', {fundID} FROM expenses_history;";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();

                // Update affected balance
                dbcon.OpenCon();
                query = $"UPDATE funds SET balance = balance - {amount} WHERE fundID = {fundID};";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();

                // Inform the user that the transaction has been completed
                ShowSuccessfulMessage("Transaction completed: Your expense has been recorded successfully");

            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage($"An error occurred: {ex.Message}");
            }
            finally { dbcon.CloseCon(); }
        }

        public void distribute(double amount, string timestamp)
        {
            int orderID;
            double prev_balance = 0, after_balance = 0;
            try
            {
                // Retrieve the latest transaction ID
                dbcon.OpenCon();
                string query = "SELECT MAX(orderID) as latestid FROM transactions_order;";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows && !reader.IsDBNull(reader.GetOrdinal("latestid")))
                {
                    // Increment the latest transaction ID to prepare for insertion
                    orderID = reader.GetInt32(reader.GetOrdinal("latestid")) + 1;
                }
                else 
                {
                    // Start the transaction ID from 1 if no previous transactions exist
                    orderID = 1; 
                }
                dbcon.CloseCon();

                // Insert on overall transaction history
                dbcon.OpenCon();
                query = $"INSERT INTO transactions_order (orderID, transaction_type) VALUES ({orderID}, 'distribution')";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();

                // Get the prev and after balance of unallocated balance
                dbcon.OpenCon();
                query = $"SELECT balance AS prev_balance, balance - {amount} AS after_balance FROM funds WHERE fundname = 'Unallocated Fund'";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    // Store values on variables
                    prev_balance = reader.GetDouble(reader.GetOrdinal("prev_balance"));
                    after_balance = reader.GetDouble(reader.GetOrdinal("after_balance"));
                }
                dbcon.CloseCon();

                // Insert distribution_history record
                dbcon.OpenCon();
                query = $"INSERT INTO distribution_history (distributionID, orderID, distribution_date, distributed_amount, prev_balance, after_balance) SELECT IFNULL(MAX(distributionID), 0) + 1, {orderID}, '{timestamp}', {amount}, {prev_balance}, {after_balance} FROM distribution_history;";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();

                // Update the unallocated balance
                dbcon.OpenCon();
                query = $"UPDATE funds SET balance = balance - {amount} WHERE fundname = 'Unallocated Fund';";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();

                // Get the latest ID for distribution_history
                dbcon.OpenCon();
                query = "SELECT MAX(distributionID) as latest_distribution_id FROM distribution_history;";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                reader = cmd.ExecuteReader();
                reader.Read();
                int curr_distribution_id = reader.GetInt32(reader.GetOrdinal("latest_distribution_id"));
                dbcon.CloseCon();

                // Use loop for amount_distribution_history record
                int rowcount = 0;
                dbcon.OpenCon();
                query = "SELECT fundID FROM funds WHERE fundname != 'Unallocated Fund'";
                cmd = new MySqlCommand(query , dbcon.Getcon());
                reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    // Count the number of rows returned
                    while (reader.Read())
                    {
                        rowcount++; 
                    }
                    dbcon.CloseCon();

                    // Initialize the distributed amount per fund
                    double distributed_amount_per_fund = 0;

                    for (int fundID = 1; fundID <= rowcount; fundID++)
                    {
                        // Get the prev and after balance of fund
                        dbcon.OpenCon();
                        query = $"SELECT (allocated_percentage / 100 * {amount}) AS distributed_amount_per_fund, balance AS prev_balance, balance + (allocated_percentage / 100 * {amount}) AS after_balance FROM funds WHERE fundID = {fundID};";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        reader = cmd.ExecuteReader();
                        reader.Read();

                        if (reader.HasRows)
                        {   
                            // Store values on variables
                            distributed_amount_per_fund = reader.GetDouble(reader.GetOrdinal("distributed_amount_per_fund"));
                            prev_balance = reader.GetDouble(reader.GetOrdinal("prev_balance"));
                            after_balance = reader.GetDouble(reader.GetOrdinal("after_balance"));
                        }
                        dbcon.CloseCon();

                        // Insert record of the current fund 
                        dbcon.OpenCon();
                        query = $"INSERT INTO amount_distribution_history(balanceID, distributed_amount, prev_balance, after_balance, fundID, distributionID) SELECT IFNULL((SELECT MAX(balanceID)), 0) + 1, {distributed_amount_per_fund}, {prev_balance}, {after_balance}, {fundID}, {curr_distribution_id} FROM amount_distribution_history";
                        cmd = new MySqlCommand(query, dbcon.Getcon());
                        cmd.ExecuteNonQuery();
                        dbcon.CloseCon();
                    }

                    // Update the allocated funds
                    dbcon.OpenCon();
                    query = $"UPDATE funds SET balance = balance + (allocated_percentage / 100 * {amount}) WHERE allocated_percentage > 0;";
                    cmd = new MySqlCommand(query, dbcon.Getcon());
                    cmd.ExecuteNonQuery();

                    // Inform the user that the transaction has been completed
                    ShowSuccessfulMessage("Transaction completed: Funds have been distributed successfully.");

                }
            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage($"An error occurred: {ex.Message}");
            }
            finally { dbcon.CloseCon(); }
        }

        public void transfer(double amount, int from, int to, string reason, string timestamp)
        {
            int orderID;
            double from_prev = 0, from_after = 0, to_prev = 0, to_after = 0;
            try
            {
                // Retrieve the latest transaction ID
                dbcon.OpenCon();
                string query = "SELECT MAX(orderID) as latestid FROM transactions_order;";
                MySqlCommand cmd = new MySqlCommand(query, dbcon.Getcon());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows && !reader.IsDBNull(reader.GetOrdinal("latestid")))
                {
                    // Increment the latest transaction ID to prepare for insertion
                    orderID = reader.GetInt32(reader.GetOrdinal("latestid")) + 1;
                }
                else
                {
                    // Start the transaction ID from 1 if no previous transactions exist
                    orderID = 1;
                }
                dbcon.CloseCon();

                // Insert on overall transaction history
                dbcon.OpenCon();
                query = $"INSERT INTO transactions_order (orderID, transaction_type) VALUES ({orderID}, 'transfer')";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();

                // Get the prev and after balance of from fund
                dbcon.OpenCon();
                query = $"SELECT balance AS from_prev, balance - {amount} as from_after FROM funds WHERE fundID = {from}";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    // Insert values on variables
                    from_prev = reader.GetDouble(reader.GetOrdinal("from_prev"));
                    from_after = reader.GetDouble(reader.GetOrdinal("from_after"));
                }
                dbcon.CloseCon();

                // Get the prev and after balance of to fund
                dbcon.OpenCon();
                query = $"SELECT balance AS to_prev, balance + {amount} as to_after FROM funds WHERE fundID = {to}";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    // Insert values on variables
                    to_prev = reader.GetDouble(reader.GetOrdinal("to_prev"));
                    to_after = reader.GetDouble(reader.GetOrdinal("to_after"));
                }
                dbcon.CloseCon();

                // Inserting records on transfer_history
                dbcon.OpenCon();
                query = $"INSERT INTO transfer_history (transferID, orderID, from_fundID, to_fundID, transfer_amount, from_prev_balance, from_after_balance, to_prev_balance, to_after_balance, transfer_date, reason) SELECT IFNULL(MAX(transferID), 0) + 1, {orderID}, {from}, {to}, {amount}, {from_prev}, {from_after}, {to_prev}, {to_after}, '{timestamp}', '{reason}' FROM transfer_history;";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();

                // Update the balance of affected fund
                dbcon.OpenCon();
                query = $"UPDATE funds SET balance = balance - {amount} WHERE fundID = {from};";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();
                dbcon.CloseCon();
                dbcon.OpenCon();
                query = $"UPDATE funds SET balance = balance + {amount} WHERE fundID = {to};";
                cmd = new MySqlCommand(query, dbcon.Getcon());
                cmd.ExecuteNonQuery();

                // Inform the user that the transaction has been completed
                ShowSuccessfulMessage("Transaction completed: Funds have been transferred successfully.");

            }
            catch (Exception ex)
            {
                // Message box function for error display
                ShowErrorMessage($"An error occurred: {ex.Message}");
            }
            finally { dbcon.CloseCon(); }
        }

        // TRANSACTION RECORDS
        public void Displaydata(DataGridView dgv, string query)
        {
            // To populate a DataGridView

            dbcon.OpenCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter(query, dbcon.Getcon());

            // Fill the DataTable with the results of the query
            adapt.Fill(dt);

            // Bind the DataTable as the data source for the DataGridView
            dgv.DataSource = dt;

            dbcon.CloseCon();
        }

        public void ClearDataGridView(DataGridView dgv)
        {
            // Clear the data source of the DataGridView
            dgv.DataSource = null;
        }

        // MESSAGE BOXES
        public void ShowErrorMessage(string message)
        {
            // messagebox with pre-defined icons and header text
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccessfulMessage(string message)
        {
            // messagebox with pre-defined icons and header text
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}

