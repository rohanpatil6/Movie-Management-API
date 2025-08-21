using Microsoft.AspNetCore.Mvc;
using Moq;
using Movie_Management_API.Controllers;
using Movie_Management_API.DTOs;
using Movie_Management_API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Movie_Management_API.Tests.Controllers
{
    public class MoviesControllerTests
    {
        private readonly Mock<IMovieService> _mockService;
        private readonly MoviesController _controller;

        public MoviesControllerTests()
        {
            _mockService = new Mock<IMovieService>();
            _controller = new MoviesController(_mockService.Object);
        }

        [Fact]
        public async Task GetMovies_ReturnsOk_WithMovies()
        {
            _mockService.Setup(s => s.GetAllAsync())
                .ReturnsAsync(new List<MovieDto> {
                    new MovieDto { Id = Guid.NewGuid(), Title = "Inception" }
                });

            var result = await _controller.GetMovies();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var movies = Assert.IsAssignableFrom<IEnumerable<MovieDto>>(okResult.Value);
            Assert.Single(movies);
        }

        [Fact]
        public async Task GetMovie_ReturnsNotFound_WhenDoesNotExist()
        {
            _mockService.Setup(s => s.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((MovieDto)null);

            var result = await _controller.GetMovie(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetMovie_ReturnsOk_WhenExists()
        {
            var movie = new MovieDto { Id = Guid.NewGuid(), Title = "Matrix" };
            _mockService.Setup(s => s.GetByIdAsync(movie.Id))
                .ReturnsAsync(movie);

            var result = await _controller.GetMovie(movie.Id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnMovie = Assert.IsType<MovieDto>(okResult.Value);
            Assert.Equal(movie.Title, returnMovie.Title);
        }

        [Fact]
        public async Task CreateMovie_ReturnsCreatedAtAction()
        {
            var dto = new CreateUpdateMovieDto { Title = "Interstellar", Director = "Nolan", ReleaseYear = 2014, Genre = "Sci-Fi", Rating = 9 };
            var createdMovie = new MovieDto { Id = Guid.NewGuid(), Title = "Interstellar" };

            _mockService.Setup(s => s.CreateAsync(dto)).ReturnsAsync(createdMovie);

            var result = await _controller.CreateMovie(dto);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnMovie = Assert.IsType<MovieDto>(createdAtActionResult.Value);
            Assert.Equal("Interstellar", returnMovie.Title);
        }

        [Fact]
        public async Task UpdateMovie_ReturnsOk_WhenSuccessful()
        {
            var dto = new CreateUpdateMovieDto { Title = "Dark Knight", Director = "Nolan", ReleaseYear = 2008, Genre = "Action", Rating = 9 };
            var updatedMovie = new MovieDto { Id = Guid.NewGuid(), Title = "Dark Knight" };

            _mockService.Setup(s => s.UpdateAsync(It.IsAny<Guid>(), dto))
                .ReturnsAsync(updatedMovie);

            var result = await _controller.UpdateMovie(Guid.NewGuid(), dto);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnMovie = Assert.IsType<MovieDto>(okResult.Value);
            Assert.Equal("Dark Knight", returnMovie.Title);
        }

        [Fact]
        public async Task UpdateMovie_ReturnsNotFound_WhenNotExist()
        {
            var dto = new CreateUpdateMovieDto { Title = "Avatar", Director = "Cameron", ReleaseYear = 2009, Genre = "Fantasy", Rating = 8 };
            _mockService.Setup(s => s.UpdateAsync(It.IsAny<Guid>(), dto))
                .ReturnsAsync((MovieDto)null);

            var result = await _controller.UpdateMovie(Guid.NewGuid(), dto);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task DeleteMovie_ReturnsNoContent_WhenSuccessful()
        {
            _mockService.Setup(s => s.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            var result = await _controller.DeleteMovie(Guid.NewGuid());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteMovie_ReturnsNotFound_WhenNotExist()
        {
            _mockService.Setup(s => s.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(false);

            var result = await _controller.DeleteMovie(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
