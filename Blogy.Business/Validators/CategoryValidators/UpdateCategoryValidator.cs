using Blogy.Business.DTOs.CategoryDtos;
using FluentValidation;

namespace Blogy.Business.Validators.CategoryValidators;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz!")
            .MinimumLength(3).WithMessage("Kategori Adı Minimum 3 Karakter Olmalı")
            .MaximumLength(50).WithMessage("Kategori Adı Maximum 50 Karakter Olabilir");
    }
}
