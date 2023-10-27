using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    //public class CommentRepo:IRepo<Comment>
    //{
    //    ModelValidation validation = new ModelValidation();
    //    Context.MovieDBContext dbContext = new Context.MovieDBContext();

    //    public bool Create(Comment comment)
    //    {
    //        Comment newComment = new Comment() { Id = dbContext.Users.Any() ? dbContext.Users.Max(x => x.Id) + 1 : 0,IdMovie=comment.IdMovie,IdUser=comment.IdUser,Movie=comment.Movie,User=comment.User };
    //        if (validation.ValidationComment(newComment))
    //        {
    //            dbContext.Comments.Add(newComment);
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
    //        var findComment = dbContext.Comments.Find(id);
    //        if (validation.ValidationComment(findComment))
    //        {
    //            dbContext.Remove(findComment);
    //            dbContext.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    public Comment Read(int id)
    //    {
    //        var findComment = dbContext.Comments.Find(id);
    //        if (validation.ValidationComment(findComment))
    //        {
    //            return findComment;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }

    //    public bool Update(Comment myObject, int id)
    //    {
    //        if (validation.ValidationComment(myObject))
    //        {
    //            var comment = dbContext.Comments.Find(id);
    //            comment = myObject;
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
