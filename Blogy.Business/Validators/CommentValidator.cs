using Blogy.Entity.Entites;
using FluentValidation;

namespace Blogy.Business.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.WriterId).NotEmpty().WithMessage("Kullanıcı Boş Olamaz");
            RuleFor(c => c.BlogId).NotEmpty().WithMessage("Blog Boş Olamaz");

            RuleFor(c => c.Content)
                .NotEmpty().WithMessage("Yorum Boş Olamaz!")
                .MaximumLength(1000).WithMessage("Yorum 250 Karakterden Fazla Olamaz!");
        }
    }
}
