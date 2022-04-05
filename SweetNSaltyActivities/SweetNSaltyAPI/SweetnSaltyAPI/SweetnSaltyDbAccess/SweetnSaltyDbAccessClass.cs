using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyDbAccess
{
    public class SweetnSaltyDbAccessClass : ISweetnSaltyDbAccessClass
    {
        private readonly string str = "Data source = JAMIESCHWARTZPC\\SQLEXPRESS;initial Catalog = SweetNSaltyAPI; integrated security = true";
        private readonly SqlConnection _con;
        public SweetnSaltyDbAccessClass()
        {
            this._con = new SqlConnection(this.str);
            _con.Open();
        }
        public async Task<SqlDataReader> PostFlavor(string flavorName)
        {
            string sqlQuery = $"INSERT INTO Flavor VALUES (@flavorName)";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                cmd.Parameters.AddWithValue("@flavorName", flavorName);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    string getFlavor = "SELECT TOP 1 * FROM Flavor ORDER BY FlavorID DESC";
                    using (SqlCommand cmd1 = new SqlCommand(getFlavor, this._con)) {
                        SqlDataReader dr = await cmd1.ExecuteReaderAsync();
                        return dr;
                    }
                }
                catch(DbException ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
        public async Task<SqlDataReader> PostPerson(string Fname, string Lname)
        {
            string sqlQuery = $"INSERT INTO Person (Fname, Lname) VALUES (@Fname, @Lname)";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                cmd.Parameters.AddWithValue("@Fname", Fname);
                cmd.Parameters.AddWithValue("@Lname", Lname);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    string getPerson = "SELECT TOP 1 * FROM Person ORDER BY PersonID DESC";
                    using (SqlCommand cmd1 = new SqlCommand(getPerson, this._con))
                    {
                        SqlDataReader dr = await cmd1.ExecuteReaderAsync();
                        return dr;
                    }
                }
                catch (DbException ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
        public async Task<SqlDataReader> GetPerson(string Fname, string Lname)
        {
            string sqlQuery = $"SELECT TOP 1 * FROM Person ORDER BY PersonID DESC";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
        }
        public async Task<SqlDataReader> GetPersonAndFlavors(int id)
        {
            string sqlQuery = $"SELECT TOP 1 * FROM PersonFlavorJunction ORDER BY PersonID DESC";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
        }
        public async Task<SqlDataReader> GetAllFlavors()         //credit Dan
        {
            string sqlQuery = "SELECT * FROM Flavor";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                //await cmd.ExecuteNonQueryAsync();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
        }
    }
}
