using Blogy.Business.DTOs.CategoryDtos;
using FluentValidation;

namespace Blogy.Business.Validators.CategoryValidators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name) // Hangi Property'ye kural uygulayacağımızı belirtir.
            .NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz!")
            .MinimumLength(3).WithMessage("Kategori Adı Minimum 3 Karakter Olmalı")
            .MaximumLength(50).WithMessage("Kategori Adı Maximum 50 Karakter Olabilir");
    }
}
