using FluentValidation;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    public class CreateCommendValidator :AbstractValidator<CreatePostCommand>
    {
        public CreateCommendValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull();
        }
    }
}
