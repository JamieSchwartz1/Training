using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace P0
{
    //anything that uses a query will go in this Namespace!!!
    public class DatabaseAccess
    {
        string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
        public readonly SqlConnection connect;
        public DatabaseAccess()
        {
            this.connect = new SqlConnection(newStr);
            connect.Open();
        }
        public int ExitAll()
        {
            return 0;
        }
        public void CreateCustomer(string custName)
        {
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
                SqlCommand cmd = new SqlCommand(querystring, connect);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }
            Console.WriteLine($"Thank you {custName}. You have successfully created an account with Fun-iture.");
        }
        public void ViewCustomers()
        {
            SqlCommand cmd0 = new SqlCommand("SELECT * FROM dbo.Customer", connect);
            SqlDataReader dr0 = cmd0.ExecuteReader();
            Console.WriteLine("List of Customer Names:");
            while (dr0.Read())
            {
                Console.WriteLine("\t" + dr0[1].ToString());
            }
            dr0.Close();
        }
        public int ViewCustID(string custName)
        {
            int custID = 0;
            SqlCommand cmd = new SqlCommand($"SELECT CustomerID FROM dbo.Customer WHERE CustName = '{custName}';", connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                custID = dr.GetInt32(0);
            }
            dr.Close();
            return custID;
        }
        public void LogInCustomer(string custName)
        {
            string querystring = $"SELECT CustName FROM Customer WHERE CustName = '{custName}'";
            SqlCommand cmd = new SqlCommand(querystring, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read() == false)
            {
                dr.Close();
                Console.WriteLine("User does not exist. Please enter an existing name.");
                custName = Console.ReadLine();
                querystring = $"SELECT CustName FROM Customer WHERE CustName = '{custName}'";
                cmd = new SqlCommand(querystring, connect);
                dr = cmd.ExecuteReader();
            }
            dr.Close();
        }
        public void PasswordLogIn(string password)
        {
            string querystring = $"SELECT CustPass FROM Customer WHERE CustPass = '{password}'";
            SqlCommand cmd = new SqlCommand(querystring, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read() == false)
            {
                dr.Close();
                Console.WriteLine("Log in unsuccessful. Please reenter your password.");
                password = Console.ReadLine();
                querystring = $"SELECT CustPass FROM Customer WHERE CustPass = '{password}'";
                cmd = new SqlCommand(querystring, connect);
                dr = cmd.ExecuteReader();
            }
            dr.Close();
            Console.WriteLine("You have successfully logged in.");
        }
        public void getInventory()
        {
            string querystring = "SELECT * FROM dbo.FullProductList;";
            GetProduct product = new GetProduct();
            SqlCommand cmd = new SqlCommand(querystring, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                product.ProductID = dr.GetInt32(0);
                product.ProductName = dr[1].ToString();
                product.ProductDesc = dr[2].ToString();
                product.ProductSect = dr[3].ToString();
            }
            dr.Close();
        }
        public List<GetProduct> DisplayProducts(int storeID)
        {
            string querystring = "SELECT Inventory.ProductID, ProductName, ProductPrice, ProductDescription FROM FullProductList " +
                "LEFT OUTER JOIN Inventory " +
                "ON Inventory.ProductID = FullProductList.ProductID " +
                "LEFT OUTER JOIN StoresList " +
                "ON StoresList.StoreID = Inventory.StoreID " +
                "WHERE Inventory.StoreID = " + storeID + " ;";
            List<GetProduct> products = new List<GetProduct>();
            using (SqlCommand cmd = new SqlCommand(querystring, connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($" [{dr[0].ToString()}] {dr[1].ToString()}\t${dr[2].ToString()}\t{dr[3].ToString()}");
                }
                dr.Close();
            }
            return products;
        }
        public void DisplayStores()
        {
            string querystring = "SELECT * FROM StoresList";
            List<Stores> stores = new List<Stores>();
            using (SqlCommand cmd = new SqlCommand(querystring, connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($" [{dr[0].ToString()}] {dr[1].ToString()}");
                }
                dr.Close();
            }
        }
        public void NewCart(int storeID, int custID)
        {
            string querystring = $"INSERT INTO ShoppingCart (StoreID, CustomerID) " +
                $"VALUES (" +
                $"(SELECT StoreID FROM StoresList WHERE StoreID = {storeID}), " +
                $"(SELECT CustomerID FROM Customer WHERE CustomerID = {custID}) " +
                $");";
            SqlCommand cmd = new SqlCommand(querystring, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"Your CartID is {dr[0].ToString()}.");
            }
            dr.Close();
        }
        public void AddItemToCart(string itemToAdd)
        {
            int itemNum;
            bool isNum = int.TryParse(itemToAdd, out itemNum);
            try
            {
                //if itemToAdd is not an int
                if (isNum == false)
                {
                    Console.WriteLine("Please enter the number associated with the product.");
                }
                else
                {
                    string querystring = $"INSERT INTO ItemsInCart(ProductID, ProductTotal) " +
                        $"SELECT ProductID, ProductPrice FROM FullProductList WHERE ProductID = '{itemNum}'";
                    SqlCommand cmd = new SqlCommand(querystring, connect);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read() == false)
                    {
                        dr.Close();
                        Console.WriteLine("Item does not exist. Please enter the product name or product ID.");
                        itemToAdd = Console.ReadLine();
                        querystring = $"INSERT INTO ItemsInCart(ProductID, ProductTotal) " +
                            $"SELECT ProductID, ProductPrice FROM FullProductList WHERE ProductID = '{itemNum}'";
                        cmd = new SqlCommand(querystring, connect);
                        dr = cmd.ExecuteReader();
                    }
                    Console.WriteLine($"Successfully added item {itemToAdd} to cart.");
                    dr.Close();
                }
            }
            catch (Exception e) { Console.WriteLine("Error: " + e); }
        }
        public void ViewCart()
        {
            string querystring = $"SELECT * FROM ItemsInCart";
            using (SqlCommand cmd = new SqlCommand(querystring, connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($" [{dr[3].ToString()}] {dr[4].ToString()}");
                }
                dr.Close();
            }
        }
    }
}
