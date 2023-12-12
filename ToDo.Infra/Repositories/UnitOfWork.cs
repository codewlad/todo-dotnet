using System.Data;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Repositories.DataConnector;

namespace ToDo.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;

        public UnitOfWork(IDbConnector dbConnector)
        {
            this.DbConnector = dbConnector;
        }

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(DbConnector));

        public IDbConnector DbConnector { get; set; }

        public void BeginTransaction()
        {
            DbConnector.BeginTransaction(IsolationLevel.ReadUncommitted);
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
            if (DbConnector.DbConnection.State == ConnectionState.Open)
            {
                DbConnector.DbTransaction.Rollback();
            }
        }
    }
}
