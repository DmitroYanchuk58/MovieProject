using BusinessAccessLayer.BusinessObjects;
using BusinessAccessLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private MovieService _service;
        private readonly MovieDBContext _context;

        public MovieController(MovieDBContext context, MovieService movieService)
        {
            _context = context;
            _service = movieService;
        }

        [HttpGet("Movies")]
        public ActionResult<List<MovieDTO>> GetMovieList()
        {
            return _service.GetAll().ToList();
        }
        [HttpGet("RateMovies")]
        public ActionResult<List<MovieDTO>> GetSortMoviesOrderByRate()
        {
            return _service.GetAll().OrderBy(x => x.Rate).ToList();
        }
        [HttpGet("MoviesByActor")]
        public ActionResult<List<MovieDTO>> GetMoviesByActor(int idActor)
        {
            return _service.GetMoviesByActor(idActor).ToList();
        }
        [HttpGet("MoviesByGenre")]
        public ActionResult<List<MovieDTO>> GetMoviesByGenre(int idGenre)
        {
            return _service.GetMoviesByGenre(idGenre).ToList();
        }
       
    }
}
