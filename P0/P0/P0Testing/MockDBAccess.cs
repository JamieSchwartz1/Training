using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0;

namespace P0Testing
{
    internal class MockDBAccess
    {
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            Customer cust1 = new Customer()
            {
                CustName = "test1",
                CustPass = "test1"
            };
            Customer cust2 = new Customer()
            {
                CustName = "test2",
                CustPass = "test1"
            };
            Customer cust3 = new Customer()
            {
                CustName = "test3",
                CustPass = "test3"
            };
            customers.Add(cust1);
            customers.Add(cust2);
            customers.Add(cust3);
            return customers;
        }
        public bool badCust()
        {
            List<Customer> customers = new List<Customer>();
            Customer cust1 = new Customer()
            {
                CustName = "",
                CustPass = ""
            };
            if(cust1 != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<GetProduct> GetShoppingCartItems()
        {
            List<GetProduct> carts = new List<GetProduct>();
            GetProduct item1 = new GetProduct()
            {
                ProductID = 1,
                ProductPrice = 129.99m,
            };
            GetProduct item2 = new GetProduct() 
            {
                ProductID = 5,
                ProductPrice = 49.99m,
            };
            GetProduct item3 = new GetProduct()
            {
                ProductID = 9,
                ProductPrice = 29.99m,
            };
            carts.Add(item1);
            carts.Add(item2);
            carts.Add(item3);
            return carts;
        }
    }
}
