using BusinessAccessLayer.BusinessObjects;
using BusinessAccessLayer.Services.Contracts;
using BusinessAccessLayer.Services;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.DTO;

namespace UnitTests.BASTests.Service
{
    public class SGenreTests
    {
        private GenreService service;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<MovieDBContext>()
            .UseSqlServer("Data Source=DESKTOP-CPI51I3\\MSSQLSERVER01;Initial Catalog=MovieDB;Integrated Security=True;TrustServerCertificate=True")
            .Options;

            var context = new MovieDBContext(options);
            service = new GenreService(context);
        }

        [Test]
        public void GetByIdNull()
        {
            for (int i = 0; i < 4; i++)
            {
                Assert.IsNull(service.Get(i));
            }
        }

        [Test]
        public void GetByIdNotNull()
        {
            for (int i = 5; i < 13; i++)
            {
                Assert.IsNotNull(service.Get(i));
            }
        }

        [Test]
        public void AddMovieToList()
        {
            Assert.DoesNotThrow(() => service.AddMovieToGenreList(10, 12));
        }

        [Test]
        public void AddMovieToList2()
        {
            Assert.Throws<ArgumentException>(() => service.AddMovieToGenreList(99, 99));
        }
        [Test]
        public void AddMovieToList3()
        {
            for(int i = 100; i <= 100; i++)
            {
                Assert.Throws<ArgumentException>(() => service.AddMovieToGenreList(i, i));
            }
        }

        [Test]
        public void CreateGenre()
        {

        }
    }
}
