using Microsoft.AspNetCore.Http;
using MovieDatabase.Context;
using MovieDatabase.CRUDRepo;
using MovieDatabase.Models;

class main
{
    public static void Main()
    {
        MovieRepo repo= new MovieRepo();
    }
    #region Movie
    private void DeleteMovie()
    {
        MovieRepo repo = new MovieRepo();
        if (repo.Delete(3))
            Console.WriteLine("OK");
        else Console.WriteLine("NOT OK");
    }
    private void CreateMovie()
    {
        MovieRepo repo = new MovieRepo();
        Movie movie = new Movie();
        movie.Name = Console.ReadLine();
        movie.Description = Console.ReadLine();
        repo.Create(movie);
    }
    #endregion
    private void CreateVideo()
    {
        VideoRepo repo = new VideoRepo();
        MovieDBContext db = new MovieDBContext();
        Video video = new Video();
        video.VoiceActing = Console.ReadLine();
        IFormFile video2 = null;
        repo.Create(video2, video.VoiceActing);
    }
}