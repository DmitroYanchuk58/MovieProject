using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class CommentRepo : IRepo<Comment>
    {
        CommentValidation valid = new CommentValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(Comment comment)
        {
            Comment newComment = new Comment() { IdMovie = comment.IdMovie, IdUser = comment.IdUser, Text = comment.Text, IsDeleted = false };
            if (newComment != null)
            {
                var validResult = valid.Validate(newComment);
                if (validResult.IsValid)
                {
                    var movie = dbContext.Movies.Find(newComment.IdMovie);
                    var user = dbContext.Users.Find(newComment.IdUser);
                    if (movie != null && user != null)
                    {
                        newComment.User = user;
                        newComment.Movie = movie;
                        dbContext.Comments.Add(newComment);
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
        public bool Delete(int id)
        {
            var findComment = dbContext.Comments.Find(id);
            if (findComment != null)
            {
                var validResult = valid.Validate(findComment);
                if (validResult.IsValid)
                {
                    findComment.IsDeleted = true;
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

        public Comment Read(int id)
        {
            var findComment = dbContext.Comments.Find(id);
            if (findComment != null && !findComment.IsDeleted)
            {
                var validResult = valid.Validate(findComment);
                if (validResult.IsValid)
                {
                    findComment.Movie = dbContext.Movies.Find(findComment.IdMovie);
                    findComment.User = dbContext.Users.Find(findComment.IdUser);
                    return findComment;
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

        public bool Update(Comment myObject, int id)
        {
            if (myObject != null)
            {
                var validResult = valid.Validate(myObject);
                if (validResult.IsValid)
                {
                    var comment = dbContext.Comments.Find(id);
                    comment = myObject;
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
    }
}
