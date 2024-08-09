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
    public class GenreRepositoryTests
    {
        private GenreRepository _repository;
        private List<Genre> _genres;
        DbSet<Genre> _dbSet;


        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<MovieDBContext>()
            .UseSqlServer("Data Source=DESKTOP-CPI51I3\\MSSQLSERVER01;Initial Catalog=MovieDB;Integrated Security=True;TrustServerCertificate=True")
            .Options;

            var context = new MovieDBContext(options);
            _repository = new GenreRepository(context);
            _genres = new List<Genre>
        {
            new Genre { Name="Science Fiction"},
            new Genre{Name="Action"},
            new Genre{Name="Comedy"},
            new Genre{Name="Adventure"},
            new Genre{Name="History"},
            new Genre{Name="War"},
            new Genre{Name="Thriller"},
            new Genre{Name="Crime"},
            new Genre{Name="Animation"},
            new Genre{Name="Family"}

        };
        }

        [Test]
        public void GetAll_ReturnsAll()
        {
            var result = _repository.GetAll();

            Assert.AreEqual(10, result.Count());
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
            foreach (var movie in _genres)
            {
                Assert.DoesNotThrow(() => _repository.Create(movie));
            }
        }

        [Test]
        public void Update_Valid_UpdatesInDbSet()
        {
            var id = 11;
            var existingMovie = _genres[0];
            existingMovie.Name = "Crime";

            _repository.Update(existingMovie, id);
        }

        [Test]
        public void Delete_Valid_RemovesFromDbSet()
        {
            var existingMovie = _genres[0];

            _repository.Delete(existingMovie);


        }
    }
}
