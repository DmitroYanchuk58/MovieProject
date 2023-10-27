using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    //public class RateRepo:IRepo<Rate>
    //{
    //    ModelValidation validation = new ModelValidation();
    //    Context.MovieDBContext dbContext = new Context.MovieDBContext();

    //    public bool Create(Rate rate)
    //    {
    //        Rate newRate = new Rate() { Id = dbContext.Rates.Any() ? dbContext.Rates.Max(x => x.Id) + 1 : 0, IdMovie=rate.IdMovie,IdUser=rate.IdUser,Movie=rate.Movie,User=rate.User};
    //        if (validation.ValidationRate(newRate))
    //        {
    //            dbContext.Rates.Add(newRate);
    //            dbContext.SaveChanges();
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //    public bool Delete(int id)
    //    {
    //        var findRate = dbContext.Rates.Find(id);
    //        if (validation.ValidationRate(findRate))
    //        {
    //            dbContext.Remove(findRate);
    //            dbContext.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    public Rate Read(int id)
    //    {
    //        var findRate = dbContext.Rates.Find(id);
    //        if (validation.ValidationRate(findRate))
    //        {
    //            return findRate;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }

    //    public bool Update(Rate myObject, int id)
    //    {
    //        if (validation.ValidationRate(myObject))
    //        {
    //            var rate = dbContext.Rates.Find(id);
    //            rate = myObject;
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
