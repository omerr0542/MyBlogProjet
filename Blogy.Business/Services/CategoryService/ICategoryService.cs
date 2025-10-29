using Blogy.Business.DTOs.CategoryDtos;

namespace Blogy.Business.Services.CategoryService;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllAsync();
    Task<List<ResultCategoryDto>> GetCategoriesWithBlogsAsync();
    Task<UpdateCategoryDto> GetByIdAsync(int id); // Burada UpdateCategoryDto dönüyoruz çünkü güncelleme için kullanacağız GetByIdAsync Methodunu.
    Task CreateAsync(CreateCategoryDto createCategoryDto);
    Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteAsync(int id);
}
