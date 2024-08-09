using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Moq;
using DataAccessLayer.Data;

namespace UnitTests.DALTests
{
    public class MovieRepositoryTests
    {
        private MovieRepository _repository;
        private List<Movie> _movies;
        DbSet<Movie> _dbSet;


        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<MovieDBContext>()
            .UseSqlServer("Data Source=DESKTOP-CPI51I3\\MSSQLSERVER01;Initial Catalog=MovieDB;Integrated Security=True;TrustServerCertificate=True")
            .Options;

            var context = new MovieDBContext(options);
            _repository = new MovieRepository(context);
            _movies = new List<Movie>
        {
            new Movie { Name = "Furiosa: A Mad Max Saga",Description="As the world falls, young Furiosa is snatched from the Green Place of Many Mothers into the hands of a great biker horde led by the warlord Dementus. Sweeping through the wasteland, they encounter the citadel presided over by Immortan Joe. The two tyrants wage war for dominance, and Furiosa must survive many trials as she puts together the means to find her way home.",IsDeleted=false },
        };
        }

        [Test]
        public void GetAll_ReturnsAllMovies()
        {
            var result = _repository.GetAll();

            Assert.AreEqual(6, result.Count());
        }

        [Test]
        public void GetById_ValidId_ReturnsCorrectMovie()
        {
            var result = _repository.GetById(5);

            Assert.NotNull(result);
        }

        [Test]
        public void Create_ValidMovie_AddsMovieToDbSet()
        {
            foreach (var movie in _movies)
            {
                Assert.DoesNotThrow(() => _repository.Create(movie));
            }
        }

        [Test]
        public void Update_ValidMovie_UpdatesMovieInDbSet()
        {
            var id = 11;
            var existingMovie = _movies[0];
            existingMovie.Name = "Furiosa: A Mad Max Saga";

            _repository.Update(existingMovie,id);
        }

        [Test]
        public void Delete_ValidMovie_RemovesMovieFromDbSet()
        {
            var existingMovie = _movies[0];

            _repository.Delete(existingMovie);


        }
    }
}
