using AutoMapper;
using Movie_Management_API.DAO;
using Movie_Management_API.DTOs;
using Movie_Management_API.EntityModels;

namespace Movie_Management_API.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;
        private readonly IMapper _mapper;


        public MovieService(IMovieRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            var movies = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }


        public async Task<MovieDto?> GetByIdAsync(Guid id)
        {
            var movie = await _repo.GetByIdAsync(id);
            return movie == null ? null : _mapper.Map<MovieDto>(movie);
        }


        public async Task<MovieDto> CreateAsync(CreateUpdateMovieDto dto)
        {
            var entity = _mapper.Map<Movie>(dto);
            entity.Id = Guid.NewGuid();
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<MovieDto>(created);
        }


        public async Task<MovieDto?> UpdateAsync(Guid id, CreateUpdateMovieDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;


            _mapper.Map(dto, existing);
            var updated = await _repo.UpdateAsync(existing);
            return updated == null ? null : _mapper.Map<MovieDto>(updated);
        }


        public Task<bool> DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }
}
