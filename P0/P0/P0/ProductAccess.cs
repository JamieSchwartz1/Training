using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace P0
{
    class ProductAccess
    {
        public void getInventory()
        {
            GetProduct product = new GetProduct();
            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            string querystring = "SELECT * FROM dbo.FullProductList;";
            prodSQL.Open();
            SqlCommand cmd = new SqlCommand(querystring, prodSQL);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                product.ProductID = dr.GetInt32(0);   //stepping over
                product.ProductName = dr[1].ToString();
                //product.ProductPrice = dr.GetDecimal(2);
                product.ProductDesc = dr[2].ToString();
                product.ProductSect = dr[3].ToString();
                //product.ProductCount = dr.GetInt32(5);
            }
            prodSQL.Close();
        }

        public void getKiddieWorld()
        {
            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            string querystring = "SELECT ProductID, ProductName, ProductDescription FROM dbo.FullProductList WHERE ProductSection = 'Kiddie World';";
            prodSQL.Open();
            SqlCommand cmd = new SqlCommand(querystring, prodSQL);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("[" + dr[0].ToString() + "] " + dr[1].ToString() + "\t$" + dr[2].ToString() + "\t" + dr[3].ToString());
            }
            prodSQL.Close();
        }
        public void getScaryCity()
        {
            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            string querystring = "SELECT ProductID, ProductName, ProductDescription FROM dbo.FullProductList WHERE ProductSection = 'Scary City';";
            prodSQL.Open();
            SqlCommand cmd = new SqlCommand(querystring, prodSQL);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("[" + dr[0].ToString() + "] " + dr[1].ToString() + "\t$" + dr[2].ToString() + "\t" + dr[3].ToString());
            }
            prodSQL.Close();
        }
        public void getRichPenthouse()
        {
            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            string querystring = "SELECT ProductID, ProductName, ProductDescription FROM dbo.FullProductList WHERE ProductSection = 'Rich Penthouse';";
            prodSQL.Open();
            SqlCommand cmd = new SqlCommand(querystring, prodSQL);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("[" + dr[0].ToString() + "] " + dr[1].ToString() + "\t$" + dr[2].ToString() + "\t" + dr[3].ToString());
            }
            prodSQL.Close();
        }
        public void getRuralCabin()
        {
            string newStr = "Data source=JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog=P0;integrated security=true";
            SqlConnection prodSQL = new SqlConnection(newStr);
            string querystring = "SELECT ProductID, ProductName, ProductDescription FROM dbo.FullProductList WHERE ProductSection = 'Rural Cabin';";
            prodSQL.Open();
            SqlCommand cmd = new SqlCommand(querystring, prodSQL);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("[" + dr[0].ToString() + "] " + dr[1].ToString() + "\t$" + dr[2].ToString() + "\t" + dr[3].ToString());
            }
            prodSQL.Close();
        }
    }
}
