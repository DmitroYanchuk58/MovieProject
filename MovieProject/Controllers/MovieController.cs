using Microsoft.AspNetCore.Mvc;
using MovieDatabase.CRUDRepo;
using MovieDatabase.Models;
using MovieDatabase.ViewModel;

namespace MovieProject.Controllers
{
    public class MovieController
    {
        #region Rate
        [HttpPost]
        public async Task<IResult> CreateRate(int evaluation,int idMovie,int idUser)
        {
            RateRepo repo = new RateRepo();
            Rate rate = new Rate() { Evaluation = evaluation, IdMovie = idMovie, IdUser = idUser };
            bool result = repo.Create(rate);

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
        public async Task<IResult> DeleteRate(int id)
        {
            RateRepo repo = new RateRepo();
            if (repo.Delete(id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpPost]
        public async Task<IResult> UpdateRate(int evaluation, int idMovie, int idUser,int id)
        {
            RateRepo repo = new RateRepo();
            Rate rate = new Rate() { Evaluation = evaluation, IdMovie = idMovie, IdUser = idUser };
            if (repo.Update(rate, id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpGet]
        public Rate GetRate(int id)
        {
            RateRepo repo = new RateRepo();
            Rate rate= repo.Read(id);
            if (rate != null)
            {
                return rate;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region Employee
        [HttpDelete]
        public async Task<IResult> DeleteEmployee(int id)
        {
            EmployeeRepo repo = new EmployeeRepo();
            if (repo.Delete(id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpGet]
        public Employee GetEmployee(int id)
        {
            EmployeeRepo repo = new EmployeeRepo();
            Employee employee=repo.Read(id);
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IResult> UpdateEmployee(string name,string surname,int id)
        {
            EmployeeRepo repo = new EmployeeRepo();
            Employee employee = new Employee() { Name=name,Surname=surname };
            if (repo.Update(employee, id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpPost]
        public async Task<IResult> CreateEmployee(string name,string surname)
        {
            EmployeeRepo repo = new EmployeeRepo();
            Employee employee = new Employee() { Name = name, Surname = surname };
            if (repo.Create(employee))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        #endregion
        #region Genre
        [HttpDelete]
        public async Task<IResult> DeleteGenre(int id)
        {
            GenreRepo repo = new GenreRepo();
            if (repo.Delete(id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpGet]
        public Genre GetGenre(int id)
        {
            GenreRepo repo = new GenreRepo();
            Genre genre=repo.Read(id);
            if (genre != null)
            {
                return genre;
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IResult> UpdateGenre(string name, int id)
        {
            GenreRepo repo = new GenreRepo();
            Genre newGenre = new Genre() { Name =name};
            if (repo.Update(newGenre, id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpPost]
        public async Task<IResult> CreateGenre(string name)
        {
            GenreRepo repo = new GenreRepo();
            Genre genre = new Genre() { Name = name};
            if (repo.Create(genre))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        #endregion
        #region Comment 
        [HttpDelete]
        public async Task<IResult> DeleteComment(int id)
        {
            CommentRepo repo = new CommentRepo();
            if (repo.Delete(id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpGet]
        public Comment GetComment(int id)
        {
            CommentRepo repo = new CommentRepo();
            Comment comment= repo.Read(id);
            if(comment != null)
            {
                return comment;
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IResult> UpdateComment(string text, int id)
        {
            CommentRepo repo = new CommentRepo();
            Comment newComment = new Comment() {Text=text};
            if (repo.Update(newComment, id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpPost]
        public async Task<IResult> CreateComment(string text,int idUser,int idMovie)
        {
            CommentRepo repo = new CommentRepo();
            Comment comment = new Comment() { Text = text,IdUser=idUser,IdMovie=idMovie };
            if (repo.Create(comment))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        #endregion
        #region MovieGenre
        [HttpDelete]
        public async Task<IResult> DeleteMovieGenre(int id)
        {
            MovieGenreRepo repo = new MovieGenreRepo();
            if (repo.Delete(id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpGet]
        public MovieGenre GetMovieGenre(int id)
        {
            MovieGenreRepo repo = new MovieGenreRepo();
            MovieGenre mg = repo.Read(id);
            if (mg != null)
            {
                return mg;
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IResult> UpdateMovieGenre(int idGenre,int idMovie, int id)
        {
            MovieGenreRepo repo = new MovieGenreRepo();
            MovieGenre mg = new MovieGenre() { IdGenre=idGenre,IdMovie=idMovie};
            if (repo.Update(mg, id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpPost]
        public async Task<IResult> CreateMovieGenre(int idGenre, int idMovie)
        {
            MovieGenreRepo repo = new MovieGenreRepo();
            MovieGenre mg= new MovieGenre() {IdMovie = idMovie,IdGenre=idGenre };
            if (repo.Create(mg))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        #endregion
        #region MovieEmployee
        [HttpDelete]
        public async Task<IResult> DeleteMovieEmployee(int id)
        {
            MovieEmployeeRepo repo = new MovieEmployeeRepo();
            if (repo.Delete(id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpGet]
        public MovieEmployee GetMovieEmployee(int id)
        {
            MovieEmployeeRepo repo = new MovieEmployeeRepo();
            MovieEmployee mg = repo.Read(id);
            if (mg != null)
            {
                return mg;
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IResult> UpdateMovieEmployee(int idEmployee, int idMovie, int id)
        {
            MovieEmployeeRepo repo = new MovieEmployeeRepo();
            MovieEmployee me = new MovieEmployee() { IdEmployee=idEmployee,IdMovie=idMovie};
            if (repo.Update(me, id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpPost]
        public async Task<IResult> CreateMovieEmployee(int idEmployee, int idMovie)
        {
            MovieEmployeeRepo repo = new MovieEmployeeRepo();
            MovieEmployee mg = new MovieEmployee() { IdMovie = idMovie, IdEmployee = idEmployee };
            if (repo.Create(mg))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        #endregion
        #region Movie
        [HttpDelete]
        public async Task<IResult> DeleteMovie(int id)
        {
            MovieRepo repo = new MovieRepo();
            if (repo.Delete(id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpGet]
        public Movie GetMovie(int id)
        {
            MovieRepo repo = new MovieRepo();
            Movie movie = repo.Read(id);
            if (movie != null)
            {
                return movie;
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IResult> UpdateMovie(string name, string description, int id)
        {
            MovieRepo repo = new MovieRepo();
            Movie movie = new Movie() { Name=name,Description=description };
            if (repo.Update(movie, id))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpPost]
        public async Task<IResult> CreateMovie(string name,string description)
        {
            MovieRepo repo = new MovieRepo();
            Movie movie = new Movie() { Name=name,Description=description};
            if (repo.Create(movie))
            {
                return Results.Ok();
            }
            else
            {
                return Results.Problem();
            }
        }
        [HttpGet]
        public List<MovieWithRateVM> GetMostRateMovie()
        {
            MovieRepo repo = new MovieRepo();
            return repo.GetMostRateMovie();
        }
        [HttpGet]
        public List<MovieWithGenreVM> GetMovieByGenre(int id)
        {
            MovieRepo repo = new MovieRepo();
            return repo.GetMovieByGenre(id);
        }
        [HttpGet]
        public List<MovieWithEmployeeVM> GetMovieByActor(int idActor)
        {
            MovieRepo repo=new MovieRepo();
            return repo.GetMovieByActor(idActor);
        }
        #endregion

    }
}
