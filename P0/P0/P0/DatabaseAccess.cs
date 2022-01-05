using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace P0
{
    //anything that uses a query will go in this Namespace!!!
    public class DatabaseAccess : IDataBaseAccess
    {
        string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
        public readonly SqlConnection connect;
        public int CartID { get; set; }
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
                product.ProductPrice = decimal.Parse(dr[3].ToString());
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
                    Console.WriteLine($" [{dr[0].ToString()}] {dr[1].ToString()}\t${dr[3].ToString()}\t{dr[2].ToString()}");
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
        public int getActiveCustID(string custName)
        {
            int custID = 0;
            SqlCommand cmd = new SqlCommand($"SELECT CustomerID FROM dbo.Customer WHERE CustName = '{custName}';", connect);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    custID = Convert.ToInt32(dr[0].ToString());
                }
            }
            Console.WriteLine("Your Customer ID is " + custID);
            dr.Close();
            return custID;
        }
        public int NewCart(int storeID, int custID)
        {
            CartID = 0;
            string querystring = $"INSERT INTO ShoppingCart (StoreID, CustomerID) " +
                $"VALUES ('{storeID}', '{custID}')";
            List<int> newCart = new List<int>();
            SqlCommand cmd = new SqlCommand(querystring, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Close();
            string querys1 = "SELECT CartID FROM ShoppingCart";
            SqlCommand cmd1 = new SqlCommand(querys1, connect);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                CartID = Convert.ToInt32(dr1[0].ToString());
            }
            dr1.Close();
            Console.WriteLine($"A new cart has been assigned. Your cart ID is {CartID}");
            newCart.Add(CartID);
            return CartID;
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
                    string querystring = $"INSERT INTO ItemsInCart(CartID, ProductID, ProductTotal) " +
                        $"SELECT s.CartID, f.ProductID, f.ProductPrice FROM ShoppingCart s " +
                        $"INNER JOIN Inventory i on s.StoreID = i.StoreID " +
                        $"INNER JOIN FullProductList f on i.ProductID = f.ProductID " +
                        $"WHERE f.ProductID = '{itemNum}' AND s.CartID = '{CartID}'";
                    SqlCommand cmd = new SqlCommand(querystring, connect);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read() == true)
                    {
                        dr.Close();
                        Console.WriteLine("Item does not exist. Please enter the product name or product ID.");
                        itemNum = Console.Read();
                        querystring = $"INSERT INTO ItemsInCart(CartID, ProductID, ProductTotal) " +
                        $"SELECT s.CartID, f.ProductID, f.ProductPrice FROM ShoppingCart s " +
                        $"INNER JOIN Inventory i on s.StoreID = i.StoreID " +
                        $"INNER JOIN FullProductList f on i.ProductID = f.ProductID " +
                        $"WHERE f.ProductID = '{itemNum}' AND s.CartID = '{CartID}'";
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
            double priceSum = 0;
            string querystring = $"SELECT * FROM ItemsInCart";
            using (SqlCommand cmd = new SqlCommand(querystring, connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    priceSum += Convert.ToDouble(dr[3]);
                    Console.WriteLine($" CartID: {dr[1].ToString()}\t" +
                        $"ProductID: {dr[2].ToString()}\t" +
                        $"Total Price: {priceSum}");
                }
            }
        }
    }
}