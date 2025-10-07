using Blogy.Entity.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.GenericRepositories;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity // Bunun anlamı, TEntity tipi bir class olmak zorunda demektir ve bu class BaseEntity'den türemiş olmalıdır.
{
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
    Task<TEntity> GetByIdAsync(int id);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
}
