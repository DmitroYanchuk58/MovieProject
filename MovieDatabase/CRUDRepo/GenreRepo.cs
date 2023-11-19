using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class GenreRepo : IRepo<Genre>
    {
        GenreValidation valid = new GenreValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(Genre genre)
        {
            Genre newGenre = new Genre() { Name = genre.Name, IsDeleted = false };
            if (newGenre != null)
            {
                var validResult = valid.Validate(newGenre);
                if (validResult.IsValid)
                {
                    dbContext.Genres.Add(newGenre);
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
        public bool Delete(int id)
        {
            var findGenre = dbContext.Genres.Find(id);
            if (findGenre != null)
            {
                var validResult = valid.Validate(findGenre);
                if (validResult.IsValid)
                {
                    findGenre.IsDeleted = true;
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

        public Genre Read(int id)
        {
            var findGenre = dbContext.Genres.Find(id);
            if (findGenre != null && !findGenre.IsDeleted)
            {
                var validResult = valid.Validate(findGenre);
                if (validResult.IsValid)
                {
                    findGenre.MovieGenres = dbContext.MovieGenres.Where(mg => mg.IdGenre == id).ToList();
                    return findGenre;
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

        public bool Update(Genre myObject, int id)
        {
            if (myObject != null)
            {
                var validResult = valid.Validate(myObject);
                if (validResult.IsValid)
                {
                    var genre = dbContext.Genres.Find(id);
                    if (genre != null)
                    {
                        genre = myObject;
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
