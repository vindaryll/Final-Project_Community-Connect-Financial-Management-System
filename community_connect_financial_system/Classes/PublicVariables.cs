
namespace community_connect_finance_system.Classes
{
    public static class PublicVariables
    {
        // insert your dbname and "misc_files" folder path
        // Go to Solution Explorer
        // Find the "misc_files" folder
        // copy full path
        // paste it on "miscFilesPath" variable

        /* Solution for .resx files may be blocked with an error
        1. Use 'Open in Terminal' item of the solution in 'Solution Explorer'
        2. Enter the next commands in opened 'Developer PowerShell terminal':

            Get-ChildItem *.resx -Recurse | Unblock-File

        3. The command will complete without a confirmation.
        4. The projects in the solution now can be built.
        */

        public static string dbname = "community_connect_db";
        public static string miscFilesPath = "C:\\Users\\daryll\\Downloads\\May 2_backbone done\\May 2_backbone done\\community_connect_financial_system\\community_connect_financial_system\\Misc_files\\";

        // for logins
        public static string username = "";
        public static string email = "";
        public static string password = "";

        // for log conditions and 
        public static bool log = false;
        public static bool otpsent = false;
        public static string randomCode = "";

        // used for homepage
        public static double totalAllocated;

        // used for funds transactions
        public static int fundIndex = 0;
        public static string[] fundName;
        public static double[] fundbalance;
        public static int[] fundID;

        // used as reference for distribution history: view more
        public static int distributionID;

        // used as reference for orders of transaction: view more
        public static int orderID;
        public static string transactionType;
        public static string executed_timestamp;
            // cashin
        public static string cashin_date;
        public static string cashin_amount;
        public static string cashin_source;
            // distribution
        public static string distribution_date;
        public static string distributed_amount;
            // expenses
        public static string expense_fundName;
        public static string expense_date;
        public static string expense_amount;
        public static string expense_reason;
            // transfer
        public static string to_fundName;
        public static string from_fundName;
        public static string transfer_date;
        public static string transfer_amount;
        public static string transfer_reason;


    }
}
