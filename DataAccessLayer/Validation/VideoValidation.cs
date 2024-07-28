using FluentValidation;
using DataAccessLayer.Models;

namespace DataAccessLayer.Validation
{
    public class VideoValidation : Validation<Video>
    {
        public VideoValidation()
        {
            RuleFor(o => o.Id).NotEmpty().Must(i => i >= 0);
            RuleFor(o => o.VoiceActing).MinimumLength(4).NotEmpty().MaximumLength(1000);
            RuleFor(o => o.VideoData).NotEmpty();
        }
    }
}
