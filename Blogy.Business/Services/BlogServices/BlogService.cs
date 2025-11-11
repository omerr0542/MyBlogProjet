using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Mappings;
using Blogy.DataAccess.Repositories.BlogRepository;
using Blogy.DataAccess.Repositories.CategoryRepository;
using Blogy.Entity.Entites;

namespace Blogy.Business.Services.BlogServices;

public class BlogService(IBlogRepository _blogRepository, IMapper _mapper) : IBlogService
{
    public async Task CreateAsync(CreateBlogDto createDto)
    {
        var entity = _mapper.Map<Blog>(createDto);
        await _blogRepository.CreateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _blogRepository.DeleteAsync(id);
    }

    public async Task<IList<ResultBlogDto>> GetAllAsync()
    {
        var values = await _blogRepository.GetAllAsync();
        return _mapper.Map<IList<ResultBlogDto>>(values);
    }

    public async Task<List<ResultBlogDto>> GetBlogsByCategoryIdAsync(int CategoryId)
    {
        var values = await _blogRepository.GetAllAsync(x => x.CategoryId == CategoryId);
        return _mapper.Map<List<ResultBlogDto>>(values);
    }

    public async Task<List<ResultBlogDto>> GetBlogsWithCategoryAsync()
    {
        var values = await _blogRepository.GetBlogsWithCategoryAsync();
        return _mapper.Map<List<ResultBlogDto>>(values);
    }

    public async Task<UpdateBlogDto> GetByIdAsync(int id)
    {
        var values = await _blogRepository.GetByIdAsync(id);
        return _mapper.Map<UpdateBlogDto>(values);
    }

    public async Task<List<ResultBlogDto>> GetLastNBlogsAsync(int n)
    {
        var values = await _blogRepository.GetLastNBlogsAsync(n);
        return _mapper.Map<List<ResultBlogDto>>(values);
    }

    public async Task<ResultBlogDto> GetSingleByIdAsync(int id)
    {
        var values = await _blogRepository.GetByIdAsync(id);
        return _mapper.Map<ResultBlogDto>(values);
    }

    public async Task UpdateAsync(UpdateBlogDto updateDto)
    {
        var entity = _mapper.Map<Blog>(updateDto);
        await _blogRepository.UpdateAsync(entity);
    }
}
