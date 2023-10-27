using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VoiceActing { get;set; }

        [Required]
        public byte[] VideoData { get; set; }

        public int IdMovie { get; set; }
        public Movie Movie { get; set; }
    }
}
