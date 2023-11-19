using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class RateRepo : IRepo<Rate>
    {
        RateValidation valid = new RateValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(Rate rate)
        {
            Rate newRate = new Rate() { Evaluation = rate.Evaluation, IdMovie = rate.IdMovie, IdUser = rate.IdUser, IsDeleted = false };
            if (newRate != null)
            {
                var validResult = valid.Validate(newRate);
                if (validResult.IsValid)
                {
                    var movie = dbContext.Movies.Find(newRate.IdMovie);
                    var user = dbContext.Users.Find(newRate.IdUser);
                    if (movie != null && user != null)
                    {
                        Rate checkRate = dbContext.Rates.Where(r => r.IdMovie == newRate.IdMovie && r.IdUser == user.Id).FirstOrDefault();
                        if (checkRate != null)
                        {
                            Update(newRate, checkRate.Id);
                            return true;
                        }
                        else
                        {
                            dbContext.Rates.Add(newRate);
                            dbContext.SaveChanges();
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            var findRate = dbContext.Rates.Find(id);
            if (findRate != null)
            {
                var validResult = valid.Validate(findRate);
                if (validResult.IsValid)
                {
                    findRate.IsDeleted = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Rate Read(int id)
        {
            var findRate = dbContext.Rates.Find(id);
            if (findRate != null && !findRate.IsDeleted)
            {
                var validResult = valid.Validate(findRate);
                if (validResult.IsValid)
                {
                    findRate.User = dbContext.Users.Where(u => u.Id == findRate.IdUser).FirstOrDefault();
                    findRate.Movie = dbContext.Movies.Where(m => m.Id == findRate.IdMovie).FirstOrDefault();
                    return findRate;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool Update(Rate myObject, int id)
        {
            if (myObject != null)
            {
                var validResult = valid.Validate(myObject);
                if (validResult.IsValid)
                {
                    var rate = dbContext.Rates.Find(id);
                    if (rate != null)
                    {
                        rate.Evaluation = myObject.Evaluation;
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
