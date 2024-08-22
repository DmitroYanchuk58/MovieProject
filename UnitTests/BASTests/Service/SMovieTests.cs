using BusinessAccessLayer.BusinessObjects;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BASTests
{
    public class SMovieTests
    {
        private IService<MovieDTO> service;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<MovieDBContext>()
            .UseSqlServer("Data Source=DESKTOP-CPI51I3\\MSSQLSERVER01;Initial Catalog=MovieDB;Integrated Security=True;TrustServerCertificate=True")
            .Options;

            var context = new MovieDBContext(options);
            service =new MovieService(context);
        }

        [Test]
        public void GetByIdNull()
        {
            for (int i = 0; i < 5; i++)
            {
                Assert.IsNull(service.Get(i));
            }
        }

        [Test]
        public void GetByIdNotNull()
        {
            for(int i = 5; i < 12; i++)
            {
                Assert.IsNotNull(service.Get(i));
            }
        }
    }
}
