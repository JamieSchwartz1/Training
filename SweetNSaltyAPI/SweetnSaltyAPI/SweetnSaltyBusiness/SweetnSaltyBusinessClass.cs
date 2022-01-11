using SweetnSaltyDbAccess;
using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public class SweetnSaltyBusinessClass : ISweetnSaltyBusinessClass
    {
        private readonly ISweetnSaltyDbAccessClass _dbAccess;
        private readonly IMapper _mapper;

        public SweetnSaltyBusinessClass(ISweetnSaltyDbAccessClass Dbaccess, IMapper mapper)//you need a reference to the DbAccess Layer 
        {
            this._mapper = mapper;
            this._dbAccess = Dbaccess;
        }
        public async Task<Flavor> PostFlavor(string flavor)
        {
            SqlDataReader dr = await this._dbAccess.PostFlavor(flavor);
            if (dr.Read())
            {
                Flavor flav = this._mapper.EntityToFlavor(dr);
                return flav;
            }
            else return null;
        }
        public async Task<Person> PostPerson(string fname, string lname)
        {
            SqlDataReader dr = await this._dbAccess.PostPerson(fname, lname);
            if (dr.Read())
            {
                Person person = this._mapper.EntityToPerson(dr);
                return person;
            }
            else return null;
        }
        public async Task<Person> GetPerson(string fname, string lname)
        {
            SqlDataReader dr = await this._dbAccess.GetPerson(fname, lname);
            if (dr.Read())
            {
                Person p = this._mapper.EntityToPerson(dr);
                return p;
            }
            else return null;
        }
        public async Task<Person> GetPersonAndFlavors(int id)
        {
            SqlDataReader dr = await this._dbAccess.GetPersonAndFlavors(id);
            if (dr.Read())
            {
                Person p = this._mapper.EntityToPerson(dr);
                return p;
            }
            else return null;
        }
        public async Task<List<Flavor>> GetAllFlavors()         //credit Dan Works
        {
            SqlDataReader dr = await this._dbAccess.GetAllFlavors();
            List<Flavor> listFlavors = this._mapper.EntityToFlavorList(dr);
            return listFlavors;
        }
    }
}