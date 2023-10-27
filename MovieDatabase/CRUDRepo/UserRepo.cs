using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    //public class UserRepo : IRepo<User>
    //{
    //    ModelValidation validation=new ModelValidation();
    //    Context.MovieDBContext dbContext=new Context.MovieDBContext();

    //    public bool Create(User user)
    //    {
    //        User newUser = new User() {Nickname=user.Nickname,Password=user.Password };
    //        if (validation.ValidationUser(newUser))
    //        {
    //            dbContext.Users.Add(newUser);
    //            dbContext.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    public bool Delete(int id)
    //    {
    //        var findUser = dbContext.Users.Find(id);
    //        if (validation.ValidationUser(findUser))
    //        {
    //            dbContext.Remove(findUser);
    //            dbContext.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    public User Read(int id)
    //    {
    //        var findUser = dbContext.Users.Find(id);
    //        if (validation.ValidationUser(findUser))
    //        {
    //            return findUser;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }

    //    public bool Update(User myObject, int id)
    //    {
    //        if (validation.ValidationUser(myObject))
    //        {
    //            var User = dbContext.Users.Find(id);
    //            User = myObject;
    //            dbContext.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}
}
