using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace P0
{
    public interface IMapper
    {
        List<GetProduct> EntityToProductList(SqlDataReader dr);
    }
}
