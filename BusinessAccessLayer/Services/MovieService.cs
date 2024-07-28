using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services
{
    public class MovieService : IService<Movie>
    {
        public Movie Create(Movie _object)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Movie _object)
        {
            throw new NotImplementedException();
        }
    }
}
