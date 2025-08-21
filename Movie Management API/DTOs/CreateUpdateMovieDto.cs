using System.ComponentModel.DataAnnotations;

namespace Movie_Management_API.DTOs
{
    public class CreateUpdateMovieDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;


        [StringLength(150)]
        public string? Director { get; set; }


        [Range(1888, 3000)]
        public int? ReleaseYear { get; set; } // Movies exist from 1888


        [StringLength(100)]
        public string? Genre { get; set; }


        [Range(1.0, 10.0)]
        public decimal? Rating { get; set; }
    }
}
