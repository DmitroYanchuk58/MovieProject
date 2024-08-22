using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.BusinessObjects;
using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessAccessLayer.Services
{
    public class MovieService : IService<MovieDTO>
    {
        private readonly MovieDBContext _context;

        public MovieService(MovieDBContext context)
        {
            _context = context; 
        }
        public void Create(MovieDTO _object)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(MovieDTO _object)
        {
            throw new NotImplementedException();
        }

        public MovieDTO Get(int id) {
            MovieDTO movie =new MovieDTO(_context, id);
            if (movie.Movie != null)
            {
                return movie;
            }
            else
            {
                return null;
            }
        }

    }
}
