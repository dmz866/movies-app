namespace Movies.Application.Entities
{
    public class MovieRating
    {
        public int MovieRatingId { get; set; }

        public decimal Value { get; set; }

        public int MovieId { get; set; }
    }
}
