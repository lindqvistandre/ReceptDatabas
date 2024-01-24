using ReceptDatabas.Entities;

namespace ReceptDatabas.Interface
{

            public interface IRecipeService
            {
                Task<IEnumerable<Recipe>> GetRecipesByTitleAsync(string title);
                Task AddRecipeAsync(Recipe recipe);
                Task UpdateRecipeAsync(Recipe recipe);
                Task DeleteRecipeAsync(int recipeId);
            }

 }

    

