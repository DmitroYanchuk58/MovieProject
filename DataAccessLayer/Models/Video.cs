namespace DataAccessLayer.Models
{
    public class Video : Entity 
    {
        public string VoiceActing { get; set; }

        public byte[] VideoData { get; set; }

        public int IdMovie { get; set; }
        public Movie Movie { get; set; }
    }
}
