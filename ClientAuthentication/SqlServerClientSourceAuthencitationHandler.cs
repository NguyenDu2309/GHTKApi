using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ClientAuthentication
{
    public class SqlServerClientSourceAuthencitationHandler: IClientSourceAuthencitationHandler
    {
        private readonly string _connectionString;
        private SqlConnection connection;

        public SqlServerClientSourceAuthencitationHandler(string connectionString)
        {
            _connectionString = connectionString;
            connection = new SqlConnection(_connectionString);
        }

        public bool Validate(string ClientSource)
        {

        }
    }
}
