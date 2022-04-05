﻿using SweetnSaltyModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public interface IMapper
    {
        Flavor EntityToFlavor(SqlDataReader dr);
        Person EntityToPerson(SqlDataReader dr);
        List<Flavor> EntityToFlavorList(SqlDataReader dr);         //credit Dan Works
    }
}