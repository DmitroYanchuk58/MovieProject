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
    public class CommentRepositoryTests
    {
        private CommentRepository _repository;
        private List<Comment> _comments;
        DbSet<Comment> _dbSet;


        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<MovieDBContext>()
            .UseSqlServer("Data Source=DESKTOP-CPI51I3\\MSSQLSERVER01;Initial Catalog=MovieDB;Integrated Security=True;TrustServerCertificate=True")
            .Options;

            var context = new MovieDBContext(options);
            _repository = new CommentRepository(context);
            _comments = new List<Comment>
        {
                new Comment{IdMovie=11,IdUser=3,Text="test text"},
                new Comment{IdMovie=9,IdUser=3,Text="test text"},
                new Comment{IdMovie=6,IdUser=3,Text="test text"}
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
            foreach (var movie in _comments)
            {
                Assert.DoesNotThrow(() => _repository.Create(movie));
            }
        }

        [Test]
        public void Update_Valid_UpdatesInDbSet()
        {
            var id = 11;
            var existing = _comments[0];
            existing.Text = "updated text";

            _repository.Update(existing, id);
        }

        [Test]
        public void Delete_Valid_RemovesFromDbSet()
        {
            var existingMovie = _comments[0];

            _repository.Delete(existingMovie);


        }
    }
}
