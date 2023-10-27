using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    //public class GenreRepo:IRepo<Genre>
    //{
    //    ModelValidation validation = new ModelValidation();
    //    Context.MovieDBContext dbContext = new Context.MovieDBContext();

    //    public bool Create(Genre genre)
    //    {
    //        Genre newGenre = new Genre() { Id = dbContext.Genres.Any() ? dbContext.Genres.Max(x => x.Id) + 1 : 0, MovieGenres=genre.MovieGenres,Name=genre.Name};
    //        if (validation.ValidationGenre(newGenre))
    //        {
    //            dbContext.Genres.Add(newGenre);
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
    //        var findGenre = dbContext.Genres.Find(id);
    //        if (validation.ValidationGenre(findGenre))
    //        {
    //            dbContext.Remove(findGenre);
    //            dbContext.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    public Genre Read(int id)
    //    {
    //        var findGenre = dbContext.Genres.Find(id);
    //        if (validation.ValidationGenre(findGenre))
    //        {
    //            return findGenre;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }

    //    public bool Update(Genre myObject, int id)
    //    {
    //        if (validation.ValidationGenre(myObject))
    //        {
    //            var genre = dbContext.Genres.Find(id);
    //            genre = myObject;
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
