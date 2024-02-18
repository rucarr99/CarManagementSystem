using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagementSystem.Infra.DbContext
{
    public interface IDbConnectivity
    {
        public SqlCommand DbCommand(string strProcedure);
    }
}
