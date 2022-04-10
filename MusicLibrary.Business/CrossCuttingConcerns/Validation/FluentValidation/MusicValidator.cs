using FluentValidation;
using MusicLibrary.Entities.Concrete;

namespace MusicLibrary.Business.CrossCuttingConcerns.Validation.FluentValidation
{
    public class MusicValidator : AbstractValidator<Music>
    {
        public MusicValidator()
        {
            RuleFor(m => m.Id).NotEmpty().WithMessage("");

            RuleFor(m => m.Name).MinimumLength(2);
            RuleFor(m => m.GenreId).GreaterThan(0);

        }
    }
}
