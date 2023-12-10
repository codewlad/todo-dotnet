using System.Data;

namespace ToDo.Domain.Interfaces.Repositories.DataConnector
{
    public interface IDbConnector
    {
        IDbConnection DbConnection { get; }
        IDbTransaction DbTransaction { get; set; }
    }
}
