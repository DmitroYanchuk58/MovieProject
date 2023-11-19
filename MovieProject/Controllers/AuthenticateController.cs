using Microsoft.AspNetCore.Mvc;
using MovieDatabase.CRUDRepo;
using MovieDatabase.Models;

namespace MovieProject.Controllers
{
    public class AuthenticateController
    {
        [HttpPost]
        public async Task<IResult> CreateUser(string Nickname, string Password)
        {
            UserRepo repo = new UserRepo();
            User user = new User() { Nickname = Nickname, Password = Password };
            bool result = repo.Create(user);

            if (result)
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpDelete]
        public async Task<IResult> DeleteUser(int id)
        {
            UserRepo repo = new UserRepo();
            if (repo.Delete(id))
                return Results.Ok();
            else return Results.Problem();
        }
        [HttpPost]
        public async Task<IResult> UpdateUser(int id, string Nickname, string Password)
        {
            UserRepo repo = new UserRepo();
            if (repo.Update(new User { Nickname = Nickname, Password = Password }, id))
                return Results.Ok();
            else return Results.Problem();
        }

        [HttpGet]
        public User GetUser(int id)
        {
            UserRepo repo = new UserRepo();
            User user = repo.Read(id);
            if (user != null)
                return user;
            else return null;
        }

        [HttpGet]
        public bool Login(string nickname, string password)
        {
            UserRepo repo = new UserRepo();
            return repo.IsUser(nickname, password);
        }
    }
}
