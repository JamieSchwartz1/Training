using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace P0
{
    public class Customer
    {
        DatabaseAccess dbAccess = new DatabaseAccess();
        public int CustID { get; set; }
        public string CustName { get; set; }
        public string CustPass { get; set; }

        public void LogInCustomer()
        {
            //prompt user for name and password, compare name and password to data in SQL table
            //pull password from database and .tostring(), if comparison is true, log in. Else, do not log in
            try
            {
                //check if user exists
                dbAccess.ViewCustomers();
                Console.WriteLine("Please enter your name: ");
                string custName = Console.ReadLine();
                dbAccess.LogInCustomer(custName);

                //check if password is the same
                Console.WriteLine("Please enter your password: ");
                string password = Console.ReadLine();
                dbAccess.PasswordLogIn(password);

                Console.WriteLine($"Please note that your customer ID is [{dbAccess.ViewCustID(custName)}]");

                CustID = dbAccess.ViewCustID(custName);
            }
            catch (Exception es) { Console.WriteLine(es); }
        }
        public void AddCustomer()
        {
            Console.WriteLine("Please enter your name: ");
            string custName = Console.ReadLine();
            dbAccess.CreateCustomer(custName);
            Console.WriteLine($"Please note that your customer ID is [{dbAccess.ViewCustID(custName)}]");
        }
    }
}
