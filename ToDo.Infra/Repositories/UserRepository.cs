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

        public async Task<int> CreateUserAsync(UserModel user)
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

            int userId = await _dbConnector.DbConnection.ExecuteScalarAsync<int>(sql, new
            {
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                CreatedAt = DateTime.Now,
            }, _dbConnector.DbTransaction);

            return userId;
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
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

            var updatedUser = await _dbConnector.DbConnection.QueryFirstOrDefaultAsync(sql, new
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
            }, _dbConnector.DbTransaction);

            return updatedUser;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            string sql = @$"
                DELETE FROM [dbo].[users]
                WHERE UserId = @UserId
            ";

            var rowsAffected = await _dbConnector.DbConnection.ExecuteAsync(sql, new { UserId = userId }, _dbConnector.DbTransaction);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            string sql = basesql;

            var users = await _dbConnector.DbConnection.QueryAsync<UserModel>(sql, _dbConnector.DbTransaction);

            return users.ToList();
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            string sql = $"{basesql} AND userId = @Id";

            var user = await _dbConnector.DbConnection.QueryFirstOrDefaultAsync<UserModel>(sql, new { Id = userId }, _dbConnector.DbTransaction);

            return user;
        }
    }
}
