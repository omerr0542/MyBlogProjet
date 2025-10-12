using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Entity.Entites;

namespace Blogy.Business.Mappings;

public class BlogMappings : Profile
{
    public BlogMappings()
    {
        CreateMap<Blog, ResultBlogDto>().ReverseMap();
        CreateMap<Blog, UpdateBlogDto>().ReverseMap();
        CreateMap<Blog, CreateBlogDto>().ReverseMap();
    }
}
