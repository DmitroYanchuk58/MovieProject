using BusinessAccessLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private CommentService _service;
        private readonly MovieDBContext _context;

        public CommentController(MovieDBContext context, CommentService commentService)
        {
            _context = context;
            _service = commentService;
        }
        [HttpPost("CreateComment")]
        public void CreateComment(int idUser, int idMovie, string text)
        {
            _service.Create(idMovie, idUser, text);
        }
        [HttpPost("UpdateComment")]
        public ActionResult UpdateComment(int idComment, string newText)
        {
            var idUser = "";
            if (HttpContext.Request.Cookies.TryGetValue("Id", out idUser))
            {
                if (_service.Update(Convert.ToInt32(idUser), idComment, new Comment { Text = newText }))
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
        [HttpPost("DeleteComment")]
        public ActionResult DeleteComment(int idComment)
        {
            var idUser = "";
            if (HttpContext.Request.Cookies.TryGetValue("Id", out idUser))
            {
                if (_service.Delete(Convert.ToInt32(idUser), idComment))
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
