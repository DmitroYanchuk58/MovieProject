using FluentValidation;
using MovieDatabase.Models;

namespace MovieDatabase.Validation
{
    public class VideoValidation : AbstractValidator<Video>
    {
        public VideoValidation()
        {
            RuleFor(o => o.Id).NotEmpty().Must(i => i >= 0);
            RuleFor(o => o.VoiceActing).MinimumLength(4).NotEmpty().MaximumLength(1000);
            RuleFor(o => o.VideoData).NotEmpty();
        }
    }
}
