using Dapper;
using ReceptDatabas.Entities;
using System.Data;

namespace ReceptDatabas.Repository
{
    public class CategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public CategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var query = "SELECT * FROM Categories";
            return await _dbConnection.QueryAsync<Category>(query);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var query = "SELECT * FROM Categories WHERE CategoryId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Category>(query, new { Id = id });
        }

        public async Task<int> CreateCategoryAsync(Category category)
        {
            var query = "INSERT INTO Categories (Name) VALUES (@Name)";
            return await _dbConnection.ExecuteAsync(query, category);
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            var query = "UPDATE Categories SET Name = @Name WHERE CategoryId = @CategoryId";
            return await _dbConnection.ExecuteAsync(query, category);
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            var query = "DELETE FROM Categories WHERE CategoryId = @Id";
            return await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
