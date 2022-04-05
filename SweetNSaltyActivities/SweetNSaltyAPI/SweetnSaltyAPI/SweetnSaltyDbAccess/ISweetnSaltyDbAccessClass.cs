﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetnSaltyDbAccess
{
    public interface ISweetnSaltyDbAccessClass
    {
        Task<SqlDataReader> PostFlavor(string flavor);
        Task<SqlDataReader> PostPerson(string Fname, string Lname);
        Task<SqlDataReader> GetPerson(string Fname, string Lname);
        Task<SqlDataReader> GetPersonAndFlavors(int id);
        Task<SqlDataReader> GetAllFlavors();         //credit Dan
    }
}
