using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DALTests
{
    public class MovieGenreRepositoryTests
    {
        private MovieGenreRepository _repository;
        private List<MovieGenre> _movieGenre;
        DbSet<MovieGenre> _dbSet;


        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<MovieDBContext>()
            .UseSqlServer("Data Source=DESKTOP-CPI51I3\\MSSQLSERVER01;Initial Catalog=MovieDB;Integrated Security=True;TrustServerCertificate=True")
            .Options;

            var context = new MovieDBContext(options);
            _repository = new MovieGenreRepository(context);
            _movieGenre = new List<MovieGenre>
        {
                new MovieGenre{IdMovie=5,IdGenre=4},
                new MovieGenre{IdMovie=5,IdGenre=5},
                new MovieGenre{IdMovie=5,IdGenre=6}

        };
        }

        [Test]
        public void GetAll_ReturnsAll()
        {
            var result = _repository.GetAll();

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void GetById_ValidId_ReturnsCorrect()
        {
            var result = _repository.GetById(5);

            Assert.NotNull(result);
        }

        [Test]
        public void Create_Valid_AddsToDbSet()
        {
            foreach (var movie in _movieGenre)
            {
                Assert.DoesNotThrow(() => _repository.Create(movie));
            }
        }

        [Test]
        public void Update_Valid_UpdatesInDbSet()
        {
            var id = 11;
            var existing = _movieGenre[0];
            existing.IdMovie = 7;

            _repository.Update(existing, id);
        }

        [Test]
        public void Delete_Valid_RemovesFromDbSet()
        {
            var existingMovie = _movieGenre[0];

            _repository.Delete(existingMovie);


        }
    }
}
