using Movie_Management_API.EntityModels;

namespace Movie_Management_API.DAO
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(Guid id);
        Task<Movie> AddAsync(Movie entity);
        Task<Movie?> UpdateAsync(Movie entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
