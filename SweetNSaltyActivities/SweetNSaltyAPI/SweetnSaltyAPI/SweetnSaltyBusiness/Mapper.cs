using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public class Mapper : IMapper
    {
        public Flavor EntityToFlavor(SqlDataReader dr)
        {
            return new Flavor()
            {
                FlavorID = dr.GetInt32(0),
                FlavorName = dr[1].ToString()
            };
        }

        public Person EntityToPerson(SqlDataReader dr)
        {
            return new Person()
            {
                PersonID = dr.GetInt32(0),
                Fname = dr[1].ToString(),
                Lname = dr[2].ToString()
            };
        }
        public List<Flavor> EntityToFlavorList(SqlDataReader dr)        //credit Dan Works
        {
            List<Flavor> flavorList = new List<Flavor>();
            while (dr.Read())
            {
                Flavor f = new Flavor()
                {
                    FlavorID = dr.GetInt32(0),
                    FlavorName = dr[1].ToString()
                };
                flavorList.Add(f);
            }
            return flavorList;
        }
    }
}
