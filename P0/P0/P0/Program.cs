using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace P0
{
    class Program
    {
        /**customer should be able to view a list of store locations and select one, able to view available products to purchase, able to purchase at least 1 
         *      product, able to view past purchases, able to view current cart, able to checkout, able to cancel purchase
         * Products must have name, price, and description
         * Orders must compute total cost, be able to contain at least 1 product, limit contents to no more than 50 items, limit total cost to no more than $500
         * Store must be able to view past sales, view sales by store location
         *      (stretch goal) manage product inventory
         * Solution should contain 4 projects: Client(FE), Domain(Business Layer), Storage(Repository Layer), Testing
         */
        /** ask for username and Password
         * Business = "which location would you like to purchase from?"
         * List products
         * Put chosen products in Cart()
         * option to list items in cart
         * if needed, remove item from cart
         * purchase items and add to purchase history
         * decrease number of Products at Business
         * option to cancel purchase and redact purchase in history, and increase number of Products at Business
         */
        static void Main(string[] args)
        {
            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS; initial Catalog=P0; integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            prodSQL.Open();
            ProductAccess inventory = new ProductAccess();
            CartDB cartDB = new CartDB();
            Customer customer = new Customer();
            
            Console.WriteLine("Welcome to Fun-iture! We sell fun furniture");
            //switch statement for login, register or quit -- credit to Kevin 
            Console.WriteLine("In order to start, choose one of the following. \n[1]To login\n[2]To register\n[0]To quit");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            
            //switch between: log in (already created user) && register (create user)
            switch (menuChoice)
            {
                case 0:
                    //exit
                    break;
                case 1:
                    string querystring = $"SELECT * FROM dbo.Customer";
                    SqlCommand cmd = new SqlCommand(querystring, prodSQL);
                    SqlDataReader dr = cmd.ExecuteReader();
                    Console.WriteLine("List of Customer Names:");
                    while (dr.Read())
                    {
                        Console.WriteLine("\t" + dr[1].ToString());
                    }
                    customer.LogInCustomer();
                    break;
                case 2:
                    customer.AddCustomer();
                    break;
                default:
                    Console.WriteLine("Please enter one of the following. \n[1]To login\n[2]To register\n[0]To quit");
                    break;
            }

            //**choose location**
            Console.WriteLine("\tOur stores include...\nKiddie World\nScary City\nRural Cabin\nRich Penthouse\n");
            Console.WriteLine("Please enter the name of the store you would like to shop at.");
            inventory.getInventory();
            bool chooseStore = false;
            string choseLocation = Console.ReadLine();
            do
            {   //**switch between locations**
                if (choseLocation.ToLower() == "kiddie world")              //if kiddie world is chosen
                {
                    chooseStore = true;                                     //end do...while loop
                    Console.WriteLine("\nYou have chosen Kiddie World.");
                    Console.WriteLine("\nWe offer the following items: ");
                    inventory.getKiddieWorld();                             //print product list from database
                    Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    string itemChoice = Console.ReadLine();
                    cartDB.AddToCart(itemChoice);                           //add items to cart
                    Console.WriteLine("Continue shopping at Kiddie World? Enter Yes or No.");
                    string keepShopping = Console.ReadLine();
                    while(keepShopping.ToUpper() == "YES")
                    {
                        inventory.getKiddieWorld();                             //print product list from database
                        Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                        itemChoice = Console.ReadLine();
                        cartDB.AddToCart(itemChoice);                           //add items to cart
                        Console.WriteLine("Continue shopping at Kiddie World? Enter Yes or No.");
                        keepShopping = Console.ReadLine();
                    };
                }
                else if (choseLocation.ToLower() == "scary city")           //else if scary city is chosen
                {
                    chooseStore = true;                                     //end do...while loop
                    Console.WriteLine("\nYou have chosen Scary City.");
                    Console.WriteLine("\nWe offer the following items: ");
                    inventory.getScaryCity();                               //prints product list
                    Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    string itemChoice = Console.ReadLine();
                    cartDB.AddToCart(itemChoice);                           //add items to cart
                    Console.WriteLine("Continue shopping at Scary City? Enter Yes or No.");
                    string keepShopping = Console.ReadLine();
                    while (keepShopping.ToUpper() == "YES")
                    {
                        inventory.getScaryCity();                             //print product list from database
                        Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                        itemChoice = Console.ReadLine();
                        cartDB.AddToCart(itemChoice);                           //add items to cart
                        Console.WriteLine("Continue shopping at Scary City? Enter Yes or No.");
                        keepShopping = Console.ReadLine();
                    };
                }
                else if (choseLocation.ToLower() == "rural cabin")          //else if rural cabin is chosen
                {
                    chooseStore = true;                                     //end do...while loop
                    Console.WriteLine("\nYou have chosen Rural Cabin.");
                    Console.WriteLine("\nWe offer the following items: ");
                    inventory.getRuralCabin();                              //prints product list
                    Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    string itemChoice = Console.ReadLine();
                    cartDB.AddToCart(itemChoice);                           //add items to cart
                    Console.WriteLine("Continue shopping at Rural Cabin? Enter Yes or No.");
                    string keepShopping = Console.ReadLine();
                    while (keepShopping.ToUpper() == "YES")
                    {
                        inventory.getRuralCabin();                             //print product list from database
                        Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                        itemChoice = Console.ReadLine();
                        cartDB.AddToCart(itemChoice);                           //add items to cart
                        Console.WriteLine("Continue shopping at Rural Cabin? Enter Yes or No.");
                        keepShopping = Console.ReadLine();
                    };
                }
                else if (choseLocation.ToLower() == "rich penthouse")       //else if rich penthouse is chosen
                {
                    chooseStore = true;                                     //end do...while loop
                    Console.WriteLine("\nYou have chosen Rich Penthouse.");
                    Console.WriteLine("\nWe offer the following items: ");
                    inventory.getRichPenthouse();                           //prints product list
                    Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    string itemChoice = Console.ReadLine();
                    cartDB.AddToCart(itemChoice);                           //add items to cart
                    Console.WriteLine("Continue shopping at Rich Penthouse? Enter Yes or No.");
                    string keepShopping = Console.ReadLine();
                    while (keepShopping.ToUpper() == "YES")
                    {
                        inventory.getRichPenthouse();                             //print product list from database
                        Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                        itemChoice = Console.ReadLine();
                        cartDB.AddToCart(itemChoice);                           //add items to cart
                        Console.WriteLine("Continue shopping at Rich Penthouse? Enter Yes or No.");
                        keepShopping = Console.ReadLine();
                    };
                }
                else                                                        //else repeat store locations
                {
                    Console.WriteLine("\nPlease choose one of the following locations: ");
                    Console.WriteLine("Kiddie World\nScary City\nRural Cabin\nRich Penthouse");
                    choseLocation = Console.ReadLine();                     //read for next loop
                }
            } while (chooseStore == false);
        }
    }
}
