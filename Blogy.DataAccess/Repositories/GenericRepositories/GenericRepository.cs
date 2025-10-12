﻿using Blogy.DataAccess.Context;
using Blogy.Entity.Entites;
using Blogy.Entity.Entites.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blogy.DataAccess.Repositories.GenericRepositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _table;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _table.FindAsync(id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _table.AsNoTracking().ToListAsync(); // AsNoTracking() ile performans artışı sağlanır, çünkü sadece okuma işlemi yapılıyor.
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _table.AsNoTracking().Where(filter).ToListAsync(); 

    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        _context.Entry(entity).Property(x => x.CreatedDate).IsModified = false; // CreatedDate alanının güncellenmesini engelle
        await _context.SaveChangesAsync();
    }
}
