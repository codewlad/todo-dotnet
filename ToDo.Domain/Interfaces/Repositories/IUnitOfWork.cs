using ToDo.Domain.Interfaces.Repositories.DataConnector;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IDbConnector DbConnector { get; set; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
