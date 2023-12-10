using System.Data;
using System.Data.SqlClient;
using ToDo.Domain.Interfaces.Repositories.DataConnector;

namespace ToDo.Infra.DataConnector
{
    public class SqlConnector : IDbConnector
    {
        public SqlConnector(string connectionString)
        {
            DbConnection = SqlClientFactory.Instance.CreateConnection();
            DbConnection.ConnectionString = connectionString;
        }
        public IDbConnection DbConnection {get;}

        public IDbTransaction DbTransaction {get; private set;}

        public void Dispose()
        {
            DbConnection?.Dispose();
            DbTransaction?.Dispose();
        }
    }
}
