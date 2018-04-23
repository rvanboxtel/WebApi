using System;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace WebApi.Dao
{
    public class DbContext : IDisposable
    {
        private SqlConnection _connection;

        public DbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLServer);
        }

        internal IDbConnection GetConnection()
        {
            return _connection;
        }


        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }
}