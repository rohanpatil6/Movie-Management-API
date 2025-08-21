namespace Movie_Management_API.DTOs
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Director { get; set; }
        public int? ReleaseYear { get; set; }
        public string? Genre { get; set; }
        public decimal? Rating { get; set; } // 1.0 to 10.0
    }
}
