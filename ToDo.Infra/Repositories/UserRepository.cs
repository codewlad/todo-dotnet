using Dapper;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Repositories.DataConnector;
using ToDo.Domain.Models;

namespace ToDo.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnector _dbConnector;
        public UserRepository(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        const string basesql = @"
            SELECT [userId]
                ,[name]
                ,[email]
                ,[login]
                ,[password]
                ,[createdAt]
            FROM [dbo].[users]
            WHERE 1 = 1
        ";

        public IEnumerable<UserModel> All()
        {
            string sql = basesql;

            return _dbConnector.DbConnection.Query<UserModel>(sql, _dbConnector.DbTransaction);
        }

        public int? CreateUser(UserModel user)
        {
            string sql = @"
                INSERT INTO [dbo].[users]
                   ([name]
                   ,[email]
                   ,[login]
                   ,[password]
                   ,[createdAt])
                VALUES
                   (@Name
                   ,@Email
                   ,@Login
                   ,@Password
                   ,@CreatedAt);
                SELECT CAST(SCOPE_IDENTITY() as int);
            ";

            return _dbConnector.DbConnection.ExecuteScalar<int>(sql, new
            {
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                CreatedAt = DateTime.Now,
            }, _dbConnector.DbTransaction);
        }

        public int UpdateUser(UserModel user)
        {
            string sql = @"
                UPDATE [dbo].[users]
                SET [name] = @Name
                   ,[email] = @Email
                   ,[login] = @Login
                   ,[password] = @Password
                WHERE
                   UserId = @UserId
            ";

            return _dbConnector.DbConnection.Execute(sql, new
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
            }, _dbConnector.DbTransaction);
        }

        public UserModel? GetUserById(int userId)
        {
            string sql = $"{basesql} AND userId = @UserId";

            return _dbConnector.DbConnection.QueryFirstOrDefault<UserModel>(sql, new { UserId = userId }, _dbConnector.DbTransaction);
        }

        public int DeleteUser(int userId)
        {
            string sql = @$"
                DELETE FROM [dbo].[users]
                WHERE UserId = @UserId
            ";

            return _dbConnector.DbConnection.Execute(sql, new { UserId = userId }, _dbConnector.DbTransaction);
        }

        public async Task<int?> VerifyIfEmailExists(string email)
        {
            string sql = $"select userId from users where email = @Email";

            var result = await _dbConnector.DbConnection.ExecuteScalarAsync<int>(sql, new { Email = email }, _dbConnector.DbTransaction);

            return result;
        }
    }
}
