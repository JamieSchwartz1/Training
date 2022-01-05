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

        /**ORDER OF PROCESS
         * 1. customer table
         * 2. storesList
         * 3. FullProductList
         * 4. ShoppingCart
         * 5. ItemsInCart
         * 6. Orders
         * 7. Inventory
         */
        public static int CartItemID { get; set; }
        public static int LineID { get; set; }
        public static int CartID { get; set; }
        public static int ProductID { get; set; }
        public static float ItemTotal { get; set; }
        static void Main(string[] args)
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            CartDB cartDB = new CartDB();
            Customer customer = new Customer();
            int CustID = 0;

            Console.WriteLine("Welcome to Fun-iture! We sell fun furniture");
            //switch statement for login, register or quit -- credit to Kevin 
            Console.WriteLine("In order to start, choose one of the following.\n[1]To login\n[2]To register\n[0]To quit");
            bool mainMenu = true;
            //choose between: log in (already created user) && register (create user)
            do
            {
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                if (menuChoice == 1)
                {
                    dbAccess.ViewCustomers();                   //view previously created customer names
                    Console.WriteLine("\nPlease enter your name: ");
                    string custName = Console.ReadLine();
                    if (custName == "0")
                    {
                        mainMenu = true;
                    }
                    else
                    {
                        dbAccess.LogInCustomer(custName);           //test against previous names to see if it matches
                        Console.WriteLine("\nPlease enter your password: ");
                        string password = Console.ReadLine();
                        dbAccess.PasswordLogIn(password);           //test against password to specific name
                        CustID = dbAccess.getActiveCustID(custName);    //set CustID equal to the active ID
                        mainMenu = false;
                    }
                }
                else if (menuChoice == 2)
                {
                    Console.WriteLine("\nPlease enter your name: ");
                    string custName = Console.ReadLine();
                    if (custName == "0")
                    {
                        mainMenu = true;
                    }
                    else
                    {
                        dbAccess.CreateCustomer(custName);          //create name and password
                        CustID = dbAccess.getActiveCustID(custName);    //set CustID equal to the active ID
                        mainMenu = false;
                    }
                }
                else if (menuChoice == 0)
                {
                    //exit
                    mainMenu = false;
                }
                else
                {
                    Console.WriteLine("\nPlease enter one of the following." +
                        "\n[1] To login\n[2] To register\n[0] To quit");
                }
            } while (mainMenu == true);
            /**do
            //{
            //    if (menuChoice == 1)
            //    {
            //        customer.LogInCustomer();
            //        dbAccess.getActiveCustID(customer);
            //        mainMenu = false;
            //    }
            //    else if (menuChoice == 2)
            //    {
            //        customer.AddCustomer();
            //        mainMenu = false;
            //    }
            //    else if (menuChoice == 0)
            //    {
            //        //exit application
            //        mainMenu = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Please enter one of the following.\n[1]To login\n[2]To register\n[0]To quit");
            //    }
            //} while (mainMenu == true);
            **/
            //**choose location**

            Console.WriteLine("Our stores include...");
            dbAccess.DisplayStores();
            Console.WriteLine("Please enter the number of the store you would like to shop at.");
            dbAccess.getInventory();
            bool chooseStore = false;
            string storestring = Console.ReadLine();
            int storeID = Int32.Parse(storestring);
            try
            {
                dbAccess.NewCart(storeID, CustID);
                Console.WriteLine("A new cart has been assigned.");
            }
            catch (Exception e) { Console.WriteLine(e); }
            do
            {   //**switch between locations**
                if (storeID == 1)                                   //if kiddie world is chosen
                {
                    chooseStore = true;                                     //end do...while loop
                    Console.WriteLine("\nYou have chosen Kiddie World.");
                    Console.WriteLine("\nWe offer the following items:");
                    dbAccess.DisplayProducts(1);                             //print product list
                    Console.WriteLine("Please enter the number associated with the product you would like to purchase");
                    string itemToAdd = Console.ReadLine();
                    dbAccess.AddItemToCart(itemToAdd);                      //add item to cart
                    Console.WriteLine("The items in your cart include: ");
                    dbAccess.ViewCart();
                    //"would you like to keep shopping?"

                    /**Console.WriteLine("Which item would you like to add to your cart? Enter the product ID.");
                    //string itemChoice = Console.ReadLine();
                    //cartDB.AddToCart(itemChoice);                           //add items to cart
                    ////Console.WriteLine("Continue shopping at Kiddie World? Enter Yes or No.");
                    //string keepShopping = Console.ReadLine();
                    //while (keepShopping.ToUpper() == "YES"){
                    //    productAccess.getKiddieWorld(1);                             //print product list from database
                    //    Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    //    itemChoice = Console.ReadLine();
                    //    cartDB.AddToCart(itemChoice);                           //add items to cart
                    //    Console.WriteLine("Continue shopping at Kiddie World? Enter Yes or No.");
                    //    keepShopping = Console.ReadLine();
                    //};
                    **/
                }
                else if (storeID == 2)           //else if scary city is chosen
                {
                    chooseStore = true;                                     //end do...while loop
                    Console.WriteLine("\nYou have chosen Scary City.");
                    Console.WriteLine("\nWe offer the following items: ");
                    dbAccess.DisplayProducts(2);                               //prints product list
                    Console.WriteLine("Please enter the number associated with the product you would like to purchase");
                    string itemToAdd = Console.ReadLine();
                    dbAccess.AddItemToCart(itemToAdd);                      //add item to cart
                    Console.WriteLine("The items in your cart include: ");
                    dbAccess.ViewCart();

                    /**Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    //string itemChoice = Console.ReadLine();
                    //cartDB.AddToCart(itemChoice);                           //add items to cart
                    //Console.WriteLine("Continue shopping at Scary City? Enter Yes or No.");
                    //string keepShopping = Console.ReadLine();
                    //while (keepShopping.ToUpper() == "YES"){
                    //    productAccess.getScaryCity(2);                             //print product list from database
                    //    Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    //    itemChoice = Console.ReadLine();
                    //    cartDB.AddToCart(itemChoice);                           //add items to cart
                    //    Console.WriteLine("Continue shopping at Scary City? Enter Yes or No.");
                    //    keepShopping = Console.ReadLine();
                    //};
                    **/
                }
                else if (storeID == 3)          //else if rural cabin is chosen
                {
                    chooseStore = true;                                     //end do...while loop
                    Console.WriteLine("\nYou have chosen Rural Cabin.");
                    Console.WriteLine("\nWe offer the following items: ");
                    dbAccess.DisplayProducts(3);                              //prints product list
                    Console.WriteLine("Please enter the number associated with the product you would like to purchase");
                    string itemToAdd = Console.ReadLine();
                    dbAccess.AddItemToCart(itemToAdd);                      //add item to cart
                    Console.WriteLine("The items in your cart include: ");
                    dbAccess.ViewCart();

                    /**
                    //Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    //string itemChoice = Console.ReadLine();
                    //cartDB.AddToCart(itemChoice);                           //add items to cart
                    //Console.WriteLine("Continue shopping at Rural Cabin? Enter Yes or No.");
                    //string keepShopping = Console.ReadLine();
                    //while (keepShopping.ToUpper() == "YES"){
                    //    productAccess.getRuralCabin(3);                             //print product list from database
                    //    Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    //    itemChoice = Console.ReadLine();
                    //    cartDB.AddToCart(itemChoice);                           //add items to cart
                    //    Console.WriteLine("Continue shopping at Rural Cabin? Enter Yes or No.");
                    //    keepShopping = Console.ReadLine();
                    //};
                    **/
                }
                else if (storeID == 4)       //else if rich penthouse is chosen
                {
                    chooseStore = true;                                         //end do...while loop
                    Console.WriteLine("\nYou have chosen Rich Penthouse.");
                    Console.WriteLine("\nWe offer the following items: ");
                    dbAccess.DisplayProducts(4);                           //prints product list
                    Console.WriteLine("Please enter the number associated with the product you would like to purchase");
                    string itemToAdd = Console.ReadLine();
                    dbAccess.AddItemToCart(itemToAdd);                      //add item to cart
                    Console.WriteLine("The items in your cart include: ");
                    dbAccess.ViewCart();

                    /**Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    //string itemChoice = Console.ReadLine();
                    //cartDB.AddToCart(itemChoice);                             //add items to cart
                    //Console.WriteLine("Continue shopping at Rich Penthouse? Enter Yes or No.");
                    //string keepShopping = Console.ReadLine();
                    //while (keepShopping.ToUpper() == "YES"){
                    //    productAccess.getRichPenthouse(4);                             //print product list from database
                    //    Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
                    //    itemChoice = Console.ReadLine();
                    //    cartDB.AddToCart(itemChoice);                           //add items to cart
                    //    Console.WriteLine("Continue shopping at Rich Penthouse? Enter Yes or No.");
                    //    keepShopping = Console.ReadLine();
                    //};**/
                }
                else                                                        //else repeat store locations
                {
                    Console.WriteLine("\nPlease choose one of the following locations: ");
                    dbAccess.DisplayStores();
                    storeID = Console.Read();                     //read for next loop
                }
            } while (chooseStore == false);

            //bool addMore = false;

            //do
            //{
            //    Console.WriteLine("Which item would you like to add to your cart? Enter the name of the item.");
            //    string itemChoice = Console.ReadLine();                

            //} while (addMore == false);
        }
    }
}