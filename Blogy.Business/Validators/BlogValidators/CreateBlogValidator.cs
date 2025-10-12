using Blogy.Business.DTOs.BlogDtos;
using FluentValidation;

namespace Blogy.Business.Validators.BlogValidators;

public class CreateBlogValidator : AbstractValidator<CreateBlogDto>
{
    public CreateBlogValidator()
    {
        RuleFor(b => b.Title).NotEmpty().WithMessage("Blog Başlığı Boş Bırakılamaz!");
        RuleFor(b => b.Description).NotEmpty().WithMessage("Blog Açıklaması Boş Bırakılamaz!");
        RuleFor(b => b.CoverImage).NotEmpty().WithMessage("Blog Kapak Resmi Boş Bırakılamaz!");
        RuleFor(b => b.BlogImage1).NotEmpty().WithMessage("Blog Resmi 1 Boş Bırakılamaz!");
        RuleFor(b => b.BlogImage2).NotEmpty().WithMessage("Blog Resmi 2 Boş Bırakılamaz!");
        RuleFor(b => b.CategoryId).NotEmpty().WithMessage("Blog Kategorisi Boş Bırakılamaz!");
    }
}
