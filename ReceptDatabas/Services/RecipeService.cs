using ReceptDatabas.Entities;
using ReceptDatabas.Interface;
using ReceptDatabas.Repository;

namespace ReceptDatabas.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeRepository _recipeRepository;

        public RecipeService(RecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        // Denna metod använder GetAllRecipesAsync för att hämta alla recept och filtrerar dem baserat på titeln.
        public async Task<IEnumerable<Recipe>> GetRecipesByTitleAsync(string title)
        {
            var allRecipes = await _recipeRepository.GetAllRecipesAsync();
            return allRecipes.Where(r => r.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        // Lägger till ett nytt recept i databasen genom att anropa CreateRecipeAsync-metoden i RecipeRepository.
        public async Task AddRecipeAsync(Recipe recipe)
        {
            await _recipeRepository.CreateRecipeAsync(recipe);
        }

        // Uppdaterar ett befintligt recept i databasen. Tar ett Recipe-objekt som parameter och uppdaterar det befintliga receptet med dessa data.
        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            await _recipeRepository.UpdateRecipeAsync(recipe);
        }

        // Raderar ett recept från databasen baserat på dess id. 
        public async Task DeleteRecipeAsync(int recipeId)
        {
            await _recipeRepository.DeleteRecipeAsync(recipeId);
        }
    }


}
