using Movie_Management_API.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Movie_Management_API.DAO
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _ctx;
        public MovieRepository(MovieDbContext ctx) => _ctx = ctx;


        public async Task<IEnumerable<Movie>> GetAllAsync() =>
        await _ctx.Movies.AsNoTracking().OrderBy(m => m.Title).ToListAsync();


        public async Task<Movie?> GetByIdAsync(Guid id) =>
        await _ctx.Movies.FindAsync(id);


        public async Task<Movie> AddAsync(Movie entity)
        {
            _ctx.Movies.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }


        public async Task<Movie?> UpdateAsync(Movie entity)
        {
            var exists = await _ctx.Movies.AnyAsync(x => x.Id == entity.Id);
            if (!exists) return null;
            _ctx.Movies.Update(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _ctx.Movies.FindAsync(id);
            if (entity == null) return false;
            _ctx.Movies.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }


        public Task<bool> ExistsAsync(Guid id) =>
        _ctx.Movies.AnyAsync(x => x.Id == id);


        public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();
    }
}
