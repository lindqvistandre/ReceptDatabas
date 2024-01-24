namespace ReceptDatabas.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; } // Referens till User som skapade receptet
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int CategoryId { get; set; }
    }
}
