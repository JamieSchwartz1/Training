using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P0
{
    public class Mapper
    {
        public List<Customer> EntityToCustomerList(SqlDataReader dr)
        {
            List<Customer> customers = new List<Customer>();
            while (dr.Read())
            {
                Customer c = new Customer()
                {
                    CustID = Convert.ToInt32(dr[0].ToString()),
                    CustName = dr[1].ToString(),
                    CustPass = dr[2].ToString(),
                };
                customers.Add(c);
            }
            return customers;
        }
    }
}
