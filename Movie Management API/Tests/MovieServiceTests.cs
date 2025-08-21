using AutoMapper;
using Moq;
using Xunit;
using Movie_Management_API.DTOs;
using Movie_Management_API.EntityModels;
using Movie_Management_API.Services;
using Movie_Management_API.DAO;

namespace Movie_Management_API.Tests
{
    public class MovieServiceTests
    {
        private readonly IMapper _mapper;
        public MovieServiceTests()
        {
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = cfg.CreateMapper();
        }


        [Fact]
        public async Task Create_ShouldAssignId()
        {
            var repo = new Mock<IMovieRepository>();
            repo.Setup(r => r.AddAsync(It.IsAny<Movie>())).ReturnsAsync((Movie m) => m);


            var service = new MovieService(repo.Object, _mapper);
            var dto = new CreateUpdateMovieDto { Title = "Test Movie", Rating = 8.5m };


            var result = await service.CreateAsync(dto);


            Assert.Equal("Test Movie", result.Title);
            Assert.NotEqual(Guid.Empty, result.Id);
        }
    }
}
