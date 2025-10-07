using AutoMapper;
using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Entity.Entites;

namespace Blogy.Business.Mappings;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap(); // CreateCategoryDto'dan Category'e ve tersine dönüşüm için ReverseMap() ekledik. 

        // Eğer property isimleri farklı olsaydı, ForMember kullanarak manuel eşleme yapabilirdik.
    }
}
