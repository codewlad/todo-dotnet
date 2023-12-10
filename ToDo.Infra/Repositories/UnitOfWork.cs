using System.Data;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Repositories.DataConnector;

namespace ToDo.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(DbConnector.DbConnection));

        public IDbConnector DbConnector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void BeginTransaction()
        {
            if(DbConnector.DbConnection.State == ConnectionState.Open)
            {
                DbConnector.DbTransaction = DbConnector.DbConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
            }
        }

        public void CommitTransaction()
        {
            if (DbConnector.DbConnection.State == ConnectionState.Open)
            {
                DbConnector.DbTransaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            DbConnector.DbTransaction.Rollback();
        }
    }
}
