using Microsoft.AspNetCore.Http;
using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class VideoRepo : IRepo<Video>
    {
        VideoValidation valid = new VideoValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(IFormFile videoFile, string voice)
        {
            Video newVideo = new Video() { VoiceActing = voice, IsDeleted = false };
            var validResult = valid.Validate(newVideo);
            if (validResult.IsValid)
            {
                using (var memoryStream = new MemoryStream())
                {
                    videoFile.CopyTo(memoryStream);
                    var videoData = memoryStream.ToArray();
                    dbContext.Videos.Add(newVideo);
                    dbContext.SaveChanges();

                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public Video Read(int id)
        {
            Video video = dbContext.Videos.Find(id);
            var validResult=valid.Validate(video);
            if (validResult.IsValid)
            {
                return video;
            }
            else
            {
                return null;
            }
        }

        public bool Update(Video myObject, int id)
        {
            var validResult=valid.Validate(myObject);
            if (validResult.IsValid)
            {
                Video video = dbContext.Videos.Find(id);
                video = myObject;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            Video video = dbContext.Videos.Find(id);
            var validResult= valid.Validate(video);
            if (validResult.IsValid)
            {
                video.IsDeleted= true;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
