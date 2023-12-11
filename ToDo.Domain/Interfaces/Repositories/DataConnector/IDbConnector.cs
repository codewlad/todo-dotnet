using System.Data;

namespace ToDo.Domain.Interfaces.Repositories.DataConnector
{
    public interface IDbConnector : IDisposable
    {
        IDbConnection DbConnection { get; }
        IDbTransaction DbTransaction { get; }

        IDbTransaction BeginTransaction(IsolationLevel isolation);
    }
}
