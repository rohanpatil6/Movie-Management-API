using AutoMapper;
using Movie_Management_API.EntityModels;

namespace Movie_Management_API.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity -> DTO
            CreateMap<Movie, MovieDto>().ReverseMap();

            // DTO -> Entity (for create/update)
            CreateMap<CreateUpdateMovieDto, Movie>();
        }
    }
}
