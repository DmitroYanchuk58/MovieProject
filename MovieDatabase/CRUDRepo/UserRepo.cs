using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class UserRepo : IRepo<User>
    {
        UserValidation valid = new UserValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(User user)
        {
            User newUser = new User() { Nickname = user.Nickname, Password = user.Password, IsDeleted = false };
            if (newUser != null)
            {
                var validResult = valid.Validate(newUser);
                if (validResult.IsValid)
                {
                    dbContext.Users.Add(newUser);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            var findUser = dbContext.Users.Find(id);
            if (findUser != null)
            {
                var validResult = valid.Validate(findUser);
                if (validResult.IsValid)
                {
                    findUser.IsDeleted = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public User Read(int id)
        {
            var findUser = dbContext.Users.Find(id);
            if (findUser != null && !findUser.IsDeleted)
            {
                var validResult = valid.Validate(findUser);
                if (validResult.IsValid)
                {
                    findUser.Rates = dbContext.Rates.Where(r => r.IdUser == findUser.Id).ToList();
                    findUser.Comments = dbContext.Comments.Where(c => c.IdUser == findUser.Id).ToList();
                    return findUser;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public bool Update(User myObject, int id)
        {
            if (myObject != null)
            {
                var validResult = valid.Validate(myObject);
                if (validResult.IsValid)
                {
                    var User = dbContext.Users.Find(id);
                    if (User != null)
                    {
                        User.Nickname = myObject.Nickname;
                        User.Password = myObject.Password;
                        dbContext.Update(User);
                        dbContext.SaveChanges();
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool IsUser(string nickname, string password)
        {
            var user = dbContext.Users.Where(u => u.Nickname == nickname && u.Password == password).FirstOrDefault();
            if (user != null && !user.IsDeleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
