namespace Blogy.Business.DTOs.CategoryDtos;

public class CreateCategoryDto
{
    public string? Name { get; set; } // nullable olmaz ise uyarı mesajı validation'dan değil property validation'undan gelir ve ingilizce olur
}
