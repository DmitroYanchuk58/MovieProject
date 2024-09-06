using BusinessAccessLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : Controller
    {
        private RateService _service;
        private readonly MovieDBContext _context;

        public RateController(MovieDBContext context, RateService rateService)
        {
            _context = context;
            _service = rateService;
        }
        [HttpPost("CreateRate")]
        public ActionResult CreateRate(int idMovie, int evaluation)
        {
            var idUser = "";
            if (HttpContext.Request.Cookies.TryGetValue("Id", out idUser))
            {
                if (_service.Create(Convert.ToInt32(idUser), idMovie, evaluation))
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(400);
                }

            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpPost("UpdateRate")]
        public ActionResult UpdateRate(int idRate, int evaluation)
        {
            var idUser = "";
            if (HttpContext.Request.Cookies.TryGetValue("Id", out idUser))
            {
                if (_service.Update(Convert.ToInt32(idUser), idRate, new Rate { Evaluation = evaluation }))
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(400);
                }

            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpPost("DeleteRate")]
        public ActionResult DeleteRate(int idRate)
        {
            var idUser = "";
            if (HttpContext.Request.Cookies.TryGetValue("Id", out idUser))
            {
                if (_service.Delete(Convert.ToInt32(idUser), idRate))
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(400);
                }
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}
