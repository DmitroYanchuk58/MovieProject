using MovieDatabase.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Validation
{
    public class VideoValidation : AbstractValidator<Video>
    {
        public VideoValidation() {
            RuleFor(o => o.Id).NotEmpty().Must(i => i >= 0);
            RuleFor(o => o.VoiceActing).MinimumLength(4).NotEmpty().MaximumLength(1000);
            RuleFor(o => o.VideoData).NotEmpty();
        }
    }
}
