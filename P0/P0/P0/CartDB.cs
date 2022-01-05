using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace P0
{
    public class CartDB
    {
        //list problem: unable to convert from string to SQL
        DatabaseAccess dbAccess = new DatabaseAccess();
        Customer customer = new Customer();
        Stores store = new Stores();

        public void CreateCart(int storeID, int custID)
        {
            dbAccess.NewCart(storeID, customer.CustID);
        }
        public void AddItemToCart(string itemToAdd)
        {
            dbAccess.AddItemToCart(itemToAdd);
        }
        public void ViewCart()
        {
            dbAccess.ViewCart();
        }

        //{
        //    string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
        //    SqlConnection prodSQL = new SqlConnection(newStr);
        //    prodSQL.Open();
        //    int itemNum;
        //    bool isNum = int.TryParse(itemToAdd, out itemNum);
        //    try
        //    {
        //        //if itemToAdd is not an int
        //        if (isNum == false)
        //        {
        //            Console.WriteLine("Please enter the number associated with the product.");
        //        }
        //        else
        //        {
        //            string querystring = $"INSERT INTO ItemsInCart VALUES ProductID, ProductPrice FROM FullProductList";
        //            SqlCommand cmd = new SqlCommand(querystring, prodSQL);
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read() == false)
        //            {
        //                dr.Close();
        //                Console.WriteLine("Item does not exist. Please enter the product name or product ID.");
        //                itemToAdd = Console.ReadLine();
        //                querystring = $"SELECT ProductID, ProductPrice FROM FullProductList " +
        //                    $"WHERE ProductID = '{itemNum}'";
        //                cmd = new SqlCommand(querystring, prodSQL);
        //                dr = cmd.ExecuteReader();
        //            }
        //            Console.WriteLine($"Successfully added item {itemToAdd} to cart.");
        //            dr.Close();
        //        }
        //    }
        //    catch (Exception e) { Console.WriteLine("Error: " + e); }
        //}

        /**Dictionary<int, decimal> productDict = new Dictionary<int, decimal>();  //productID and price
        GetProduct productGet = new GetProduct();
        public void AddToCart(string itemToAdd){
            int itemNum;
            if(itemToAdd is string && itemToAdd == productGet.ProductName){
                productDict.Add(productGet.ProductID, productGet.ProductPrice);
                Console.WriteLine("Successfully added " + itemToAdd + " to the cart.");
            }
            else if (int.TryParse(itemToAdd, out itemNum)){
                productDict.Add(productGet.ProductID, productGet.ProductPrice);     //"already added"
                Console.WriteLine("Successfully added " + itemNum + " to the cart.");
            }
            else{
                Console.WriteLine("Could not add item.");
            }
        }
        public void ViewCart(){
            Console.WriteLine("Items in cart: ");
            for(int i = 0; i < productDict.Count(); i++){
                Console.WriteLine(productDict);
            }
        }
        **/

        /**public void AddToCart(string itemToAdd){
            the cart itself must exist for each customerID, not for all customers
            readline item to buy, then add it to cart
            to open sql database
            /**string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            prodSQL.Open();
            string querystring = $"INSERT INTO dbo.Cart(ProductID) VALUES ('{itemToAdd}');";
            try {
                query to insert various products into cart
                SqlCommand cmd = new SqlCommand(querystring, prodSQL);
                int row = cmd.ExecuteNonQuery();
                row = cmd.ExecuteNonQuery();
                prodSQL.Close();
                Console.WriteLine("Item successfully added to cart");
            }
            catch(Exception e) {
                Console.WriteLine("Item could not be added to the cart." + e);
            }
            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            prodSQL.Open();
            try {
                string querystring = $"SELECT ProductID, ProductPrice FROM FullProductList " +
                        $"WHERE ProductName = '{itemToAdd}' OR ProductID = '{itemToAdd}'";
                SqlCommand cmd = new SqlCommand(querystring, prodSQL);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read() == false) {
                    dr.Close();
                    Console.WriteLine("Item does not exist. Please enter the product name or product ID.");
                    itemToAdd = Console.ReadLine();
                    querystring = $"SELECT ProductID, ProductPrice FROM FullProductList " +
                        $"WHERE ProductName = '{itemToAdd.ToLower()}'";
                    cmd = new SqlCommand(querystring, prodSQL);
                    dr = cmd.ExecuteReader();
                }
                Console.WriteLine($"Successfully added item {itemToAdd} to cart");
                foreach (int item in itemToAdd) {
                    Console.WriteLine("Items in cart: " + itemToAdd);
                }
                dr.Close();
                if itemToAdd is not an int
                if (isNum == false) {
                    string querystring = $"SELECT ProductID, ProductPrice INTO Cart FROM FullProductList " +
                        $"WHERE ProductName = '{itemToAdd.ToLower()}'";
                    SqlCommand cmd = new SqlCommand(querystring, prodSQL);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read() == false) {
                        dr.Close();
                        Console.WriteLine("Item does not exist. Please enter the product name or product ID.");
                        itemToAdd = Console.ReadLine();
                        querystring = $"SELECT ProductID, ProductPrice INTO Cart FROM FullProductList " +
                            $"WHERE ProductName = '{itemToAdd.ToLower()}'";
                        cmd = new SqlCommand(querystring, prodSQL);
                        dr = cmd.ExecuteReader();
                    }
                    Console.WriteLine($"Successfully added item {itemToAdd} to cart");
                    dr.Close();
                }
                else {
                    string querystring = $"SELECT ProductID, ProductPrice INTO Cart FROM FullProductList " +
                        $"WHERE ProductID = '{itemNum}'";
                    SqlCommand cmd = new SqlCommand(querystring, prodSQL);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read() == false) {
                        dr.Close();
                        Console.WriteLine("Item does not exist. Please enter the product name or product ID.");
                        itemToAdd = Console.ReadLine();
                        querystring = $"SELECT ProductID, ProductPrice INTO Cart FROM FullProductList " +
                            $"WHERE ProductID = '{itemNum}'";
                        cmd = new SqlCommand(querystring, prodSQL);
                        dr = cmd.ExecuteReader();
                    }
                    Console.WriteLine($"Successfully added item {itemToAdd} to cart.");
                    dr.Close();
                }
            }
            catch (Exception e) { Console.WriteLine("Error: " + e); }
        }
        public void ViewCart() {
            try {
                string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
                SqlConnection prodSQL = new SqlConnection(newStr);
                prodSQL.Open();
                string querystring = $"SELECT * FROM Cart_{custName};";
                SqlCommand cmd = new SqlCommand(querystring, prodSQL);
                int row = cmd.ExecuteNonQuery();
                Console.WriteLine(row);
                prodSQL.Close();
            }
            catch (Exception e) { Console.WriteLine("Could not view cart" + e); }
        }
        public static void RemoveFromCart(string itemToRemove) {
            Console.WriteLine("Which item would you like to remove?");
            itemToRemove = Console.ReadLine();
            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            prodSQL.Open();
            string querystring = $"DELETE FROM dbo.Cart WHERE ProductID = '{itemToRemove}';";
            try {
                SqlCommand cmd = new SqlCommand(querystring, prodSQL);
                int row = cmd.ExecuteNonQuery();
                Console.WriteLine("You have successfully removed the item.");
                prodSQL.Close();
            }
            catch (Exception e) { Console.WriteLine("Item could not be removed from cart." + e); }
        }
        **/
    }
}