using Dapper;
using ReceptDatabas.Entities;
using System.Data;

namespace ReceptDatabas.Repository
{
    public class RecipeRepository
    {
        private readonly IDbConnection _dbConnection;

        public RecipeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            var query = "SELECT * FROM Recipes";
            return await _dbConnection.QueryAsync<Recipe>(query);
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            var query = "SELECT * FROM Recipes WHERE RecipeId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Recipe>(query, new { Id = id });
        }

        public async Task<int> CreateRecipeAsync(Recipe recipe)
        {
            var query = "INSERT INTO Recipes (UserId, Title, Description, Ingredients, CategoryId) VALUES (@UserId, @Title, @Description, @Ingredients, @CategoryId)";
            return await _dbConnection.ExecuteAsync(query, recipe);
        }

        public async Task<int> UpdateRecipeAsync(Recipe recipe)
        {
            var query = "UPDATE Recipes SET Title = @Title, Description = @Description, Ingredients = @Ingredients, CategoryId = @CategoryId WHERE RecipeId = @RecipeId";
            return await _dbConnection.ExecuteAsync(query, recipe);
        }

        public async Task<int> DeleteRecipeAsync(int id)
        {
            var query = "DELETE FROM Recipes WHERE RecipeId = @Id";
            return await _dbConnection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<Recipe>> SearchRecipesAsync(string title)
        {
            var query = "SELECT * FROM Recipes WHERE Title LIKE @Title";
            return await _dbConnection.QueryAsync<Recipe>(query, new { Title = $"%{title}%" });
        }
    }
}
