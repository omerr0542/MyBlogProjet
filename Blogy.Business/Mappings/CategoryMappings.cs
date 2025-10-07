using AutoMapper;
using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Entity.Entites;

namespace Blogy.Business.Mappings;

public class CategoryMappings : Profile
{
    public CategoryMappings()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap(); // CreateCategoryDto'dan Category'e ve tersine dönüşüm için ReverseMap() ekledik. 

        // Eğer property isimleri farklı olsaydı, ForMember kullanarak manuel eşleme yapabilirdik.
    }
}
