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
    }
}
