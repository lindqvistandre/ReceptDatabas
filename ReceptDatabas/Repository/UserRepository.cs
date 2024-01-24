using Dapper;
using ReceptDatabas.Entities;
using System.Data;

namespace ReceptDatabas.Repository
{
    public class UserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var query = "SELECT * FROM Users";
            return await _dbConnection.QueryAsync<User>(query);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var query = "SELECT * FROM Users WHERE UserId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
        }

        public async Task<int> CreateUserAsync(User user)
        {
            var query = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
            return await _dbConnection.ExecuteAsync(query, user);
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            var query = "UPDATE Users SET Username = @Username, Password = @Password, Email = @Email WHERE UserId = @UserId";
            return await _dbConnection.ExecuteAsync(query, user);
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            var query = "DELETE FROM Users WHERE UserId = @Id";
            return await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }

}
