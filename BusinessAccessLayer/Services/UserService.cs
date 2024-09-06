using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class UserService
    {
        private readonly MovieDBContext _context;

        public UserService(MovieDBContext context)
        {
            _context = context;
        }

        public bool CreateUser(string name,string password,ref int id)
        {
            User user = new User() {Nickname=name,Password=password};
            if (!IsNameFree(name))
            {
                UserRepository repository = new UserRepository(_context);
                repository.Create(user); 
                id=GetUserId(name);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUserExists(string name, string password,ref int id)
        {
            UserRepository repository = new UserRepository(_context);
            var users=repository.GetAll();
            if(users.Any(user=>user.Nickname==name && user.Password == password))
            {
                id=GetUserId(name);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsNameFree(string name)
        {
            UserRepository repository = new UserRepository(_context);
            var users = repository.GetAll();
            return users.Any(user => user.Nickname == name);
        }

        private int GetUserId(string name)
        {
            UserRepository repository = new UserRepository(_context);
            return repository.GetAll().Where(user => user.Nickname == name).FirstOrDefault().Id;
        }

        public bool DeleteAccount(int id)
        {
            UserRepository repository = new UserRepository(_context);
            var user=repository.GetById(id);
            if (user != null)
            {
                try
                {
                    repository.Delete(user);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAccount(User updateUser,int id)
        {
            UserRepository repository = new UserRepository(_context);
            try
            {
                repository.Update(updateUser, id);
            }
            catch
            {
                return false; 
            }
            return true;
        }

    }
}
