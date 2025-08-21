using Movie_Management_API.DTOs;

namespace Movie_Management_API.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<MovieDto?> GetByIdAsync(Guid id);
        Task<MovieDto> CreateAsync(CreateUpdateMovieDto dto);
        Task<MovieDto?> UpdateAsync(Guid id, CreateUpdateMovieDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
