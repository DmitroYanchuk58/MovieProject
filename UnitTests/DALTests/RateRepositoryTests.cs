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
    public class RateRepositoryTests
    {
        private RateRepository _repository;
        private List<Rate> _rates;
        DbSet<Rate> _dbSet;


        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<MovieDBContext>()
            .UseSqlServer("Data Source=DESKTOP-CPI51I3\\MSSQLSERVER01;Initial Catalog=MovieDB;Integrated Security=True;TrustServerCertificate=True")
            .Options;

            var context = new MovieDBContext(options);
            _repository = new RateRepository(context);
            _rates = new List<Rate>
        {
                new Rate{Evaluation=99,IdMovie=11,IdUser=3}
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
            foreach (var movie in _rates)
            {
                Assert.DoesNotThrow(() => _repository.Create(movie));
            }
        }

        [Test]
        public void Update_Valid_UpdatesInDbSet()
        {
            var id = 11;
            var existing = _rates[0];
            existing.Evaluation = 66;

            _repository.Update(existing, id);
        }

        [Test]
        public void Delete_Valid_RemovesFromDbSet()
        {
            var existingMovie = _rates[0];

            _repository.Delete(existingMovie);


        }
    }
}
