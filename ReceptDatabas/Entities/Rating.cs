namespace ReceptDatabas.Entities
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; } // Exempelvis 1 till 5
    }

}
