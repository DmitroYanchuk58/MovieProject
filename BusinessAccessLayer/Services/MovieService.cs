using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.BusinessObjects;
using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            MovieDTO movieDTO;
            List<MovieDTO> result= new List<MovieDTO>();
            MovieRepository repository = new MovieRepository(_context);
            var movies = repository.GetAll();
            foreach (var movie in movies)
            {
                movieDTO = new MovieDTO(_context,movie.Id);
                result.Add(movieDTO);
            }
            return result;
        }

        public void Update(MovieDTO _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDTO> GetMoviesByActor(int idActor)
        {
            MovieDTO movieDTO;
            List<MovieDTO> result = new List<MovieDTO>();
            MovieRepository repository = new MovieRepository(_context);
            var movies = repository.GetAll();
            foreach (var movie in movies)
            {
                movieDTO = new MovieDTO(_context, movie.Id);
                if (movieDTO.Employees != null && movieDTO.Employees.Any(employee => employee.Id == idActor))
                {
                    result.Add(movieDTO);
                }
            }
            return result;
        }

        public IEnumerable<MovieDTO> GetMoviesByGenre(int idGenre)
        {
            MovieDTO movieDTO;
            List<MovieDTO> result = new List<MovieDTO>();
            MovieRepository repository = new MovieRepository(_context);
            var movies = repository.GetAll();
            foreach (var movie in movies)
            {
                movieDTO = new MovieDTO(_context, movie.Id);
                if (movieDTO.Genres != null && movieDTO.Genres.Any(genre => genre.Id == idGenre))
                {
                    result.Add(movieDTO);
                }
            }
            return result;
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
