using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ClientAuthentication
{
    public class SqlServerClientSourceAuthencitationHandler: IClientSourceAuthencitationHandler, IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection connection;
        private bool disposedValue;

        public SqlServerClientSourceAuthencitationHandler(string connectionString)
        {
            _connectionString = connectionString;
            connection = new SqlConnection(_connectionString);
        }

        public bool Validate(string clientSource)
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            string query = "SELECT TOP 1 1 FROM ClientSource WHERE ClientId = @ClientSource AND GETDATE() >= ValidFrom AND GETDATE() <= ValidTo AND IsEnable = 1";
            using (var command = new SqlCommand(query, connection))
            { 
                command.Parameters.AddWithValue("@ClientSource", clientSource);
                using var reader = command.ExecuteReader();
                if(reader.Read())
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if(connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }

            
                disposedValue = true;
            }
        }

     

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
