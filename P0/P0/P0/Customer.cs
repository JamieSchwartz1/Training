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
        //public string CustName { get; set; }
        public void AddCustomer()
        {
            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            prodSQL.Open();
            Console.WriteLine("Please enter your name: ");
            string custName = Console.ReadLine();
            while (custName == "")
            {
                Console.WriteLine("You must your name: ");
                custName = Console.ReadLine();
            }
            Console.WriteLine("Please enter your email: ");
            string custEmail = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine();
            while (password == "")
            {
                Console.WriteLine("You must enter a password: ");
                password = Console.ReadLine();
            }
            string querystring = $"INSERT INTO Customer(CustName, CustEmail, CustPass) VALUES ('{custName}', '{custEmail}', '{password}');";
            try
            {
                SqlCommand cmd = new SqlCommand(querystring, prodSQL);
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception e) { Console.WriteLine(e); }
            Console.WriteLine($"Thank you {custName}. You have successfully created an account with Fun-iture.");
            prodSQL.Close();
        }
        public void LogInCustomer()
        {
            //open sql
            //prompt user for name and password
            //compare name and password to data in SQL table
            //pull password from database and .tostring()
            //compare
            //if comparison is true, log in. Else, do not log in

            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            prodSQL.Open();
            try
            {
                //check if user exists
                Console.WriteLine("Please enter your name: ");
                string custName = Console.ReadLine();
                string querystring = $"SELECT CustName FROM Customer WHERE CustName = '{custName}'";
                SqlCommand cmd = new SqlCommand(querystring, prodSQL);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == false)
                {
                    dr.Close();
                    Console.WriteLine("User does not exist. Please enter an existing name.");
                    custName = Console.ReadLine();
                    querystring = $"SELECT CustName FROM Customer WHERE CustName = '{custName}'";
                    cmd = new SqlCommand(querystring, prodSQL);
                    dr = cmd.ExecuteReader();
                }
                dr.Close();

                Console.WriteLine("Please enter your password: ");
                string password = Console.ReadLine();
                string querystring1 = $"SELECT CustPass FROM Customer WHERE CustPass = '{password}'";
                SqlCommand cmd1 = new SqlCommand(querystring1, prodSQL);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read() == false)
                {
                    dr1.Close();
                    Console.WriteLine("Log in unsuccessful. Please reenter your password.");
                    password = Console.ReadLine();
                    querystring1 = $"SELECT CustPass FROM Customer WHERE CustPass = '{password}'";
                    cmd1 = new SqlCommand(querystring1, prodSQL);
                    dr1 = cmd1.ExecuteReader();
                }
                Console.WriteLine("You have successfully logged in.");
                dr.Close();
            }
            catch (Exception es) { Console.WriteLine(es); }
            prodSQL.Close();
        }
        //public Customer() { }
        //public Customer(string custName)
        //{
        //    this.CustName = custName;
        //}
    }
}
