using BusinessAccessLayer.BusinessObjects;
using BusinessAccessLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private UserService _service;
        private readonly MovieDBContext _context;

        public UserController(MovieDBContext context, UserService userService)
        {
            _context = context;
            _service = userService;
        }

        [HttpPost("Registration")]
        public ActionResult CreateUser(string name,string password)
        {
            int id=0;
            if(_service.CreateUser(name, password,ref id))
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                };
                HttpContext.Response.Cookies.Append("Id", id.ToString(), cookieOptions);
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpGet("Login")]
        public ActionResult Login(string name, string password)
        {
            int id = 0;
            if(_service.IsUserExists(name, password, ref id))
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7),
                    HttpOnly = true,
                    Secure = true, 
                    SameSite = SameSiteMode.Strict
                };
                HttpContext.Response.Cookies.Append("Id", id.ToString(), cookieOptions);
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("DeleteAccount")]
        public ActionResult DeleteAccount()
        {
            var id = "";
            if (HttpContext.Request.Cookies.TryGetValue("Id", out id))
            {
                if (_service.DeleteAccount(Convert.ToInt32(id)))
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

        [HttpPost("UpdateAccount")]
        public ActionResult UpdateAccount(string newNickname)
        {
            var id = "";
            if (HttpContext.Request.Cookies.TryGetValue("Id", out id))
            {
                if (_service.UpdateAccount(new User { Nickname = newNickname }, Convert.ToInt32(id)))
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
