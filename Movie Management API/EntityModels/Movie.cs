using System;
using System.Collections.Generic;

namespace Movie_Management_API.EntityModels;

public partial class Movie
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Director { get; set; }

    public int? ReleaseYear { get; set; }

    public string? Genre { get; set; }

    public decimal? Rating { get; set; }
}
