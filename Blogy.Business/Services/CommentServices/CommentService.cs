using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.DataAccess.Repositories.CommentRepositories;
using Blogy.Entity.Entites;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Blogy.Business.Services.CommentServices
{
    public class CommentService (ICommentRepository _commentRepository, IMapper _mapper, IValidator<Comment> _validator) : ICommentService
    {

        public async Task CreateAsync(CreateCommentDto createDto)
        {
            var comment = _mapper.Map<Comment>(createDto);
            var result = await _validator.ValidateAsync(comment);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            await _commentRepository.CreateAsync(comment);
        }

        public async Task DeleteAsync(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }

        public async Task<IList<ResultCommentDto>> GetAllAsync()
        {
            var items = await _commentRepository.GetAllAsync();
            return _mapper.Map<IList<ResultCommentDto>>(items);
        }

        public async Task<UpdateCommentDto> GetByIdAsync(int id)
        {
            var item = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateCommentDto>(item);
        }

        public async Task<ResultCommentDto> GetSingleByIdAsync(int id)
        {
            var item = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<ResultCommentDto>(item);
        }

        public async Task UpdateAsync(UpdateCommentDto updateDto)
        {
            var comment = _mapper.Map<Comment>(updateDto);
            var result = await _validator.ValidateAsync(comment);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            await _commentRepository.UpdateAsync(comment);
        }
    }
}
