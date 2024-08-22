using BusinessAccessLayer.BusinessObjects;
using BusinessAccessLayer.DTO;
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

namespace BusinessAccessLayer.Services
{
    public class GenreService: IService<GenreDTO>
    {
        private readonly MovieDBContext _context;

        public GenreService(MovieDBContext context)
        {
            _context = context;
        }
        public void Create(GenreDTO _object)
        {
            if(_object == null) throw new ArgumentNullException(nameof(_object));

            GenreRepository repository=new GenreRepository(_context);

            repository.Create(_object.Genre);
        }

        public void AddMovieToGenreList(int idMovie,int idGenre)
        {
            GenreDTO genreDTO=new GenreDTO(_context,idGenre);
            try
            {
                if (_context.Movies.Find(idMovie) != null && _context.Genres.Find(idGenre) != null)
                {
                    MovieGenre movieGenre = new MovieGenre() { IdGenre = idGenre, IdMovie = idMovie };
                    MovieGenreRepository movieGenreRepository = new MovieGenreRepository(_context);
                    movieGenreRepository.Create(movieGenre);
                }
                else
                {
                    throw new ArgumentException("Data objects with the specified IDs do not exist");
                }
            }
            catch
            {
                throw;
            }
        }

        public GenreDTO Get(int id)
        {
            GenreDTO genre = new GenreDTO(_context, id);
            if (genre.Genre != null)
            {
                return genre;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            GenreRepository repository = new GenreRepository(_context);
            var genres = repository.GetAll();
            List<GenreDTO> result = new List<GenreDTO>();
            foreach (var genre in genres)
            {
                result.Add(new GenreDTO(_context,genre.Id));
            }
            return result;
        }

        public void Update(GenreDTO _object)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
