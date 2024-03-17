using System.Linq.Expressions;
using Core.Context;
using Core.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : EfDbContextBase.DbContextBase, new()
{
    private readonly TContext _dbContext = new();

    private DbSet<TEntity> Table => _dbContext.Set<TEntity>();

    public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<TEntity> query = Table;

        if (predicate != null) query = query.Where(predicate);

        if (include != null) query = include(query);

        if (orderBy != null) query = orderBy(query);

        return await query.ToListAsync();
    }

    public async Task<IList<TEntity>> GetAllPaginatedAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool enableTracking = false, int currentPage = 1, int pageSize = int.MaxValue)
    {
        IQueryable<TEntity> query = Table;

        if (predicate != null) query = query.Where(predicate);

        if (include != null) query = include(query);

        if (orderBy != null) query = orderBy(query);

        return await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null, bool enableTracking = false)
    {
        IQueryable<TEntity> query = Table;

        if (!enableTracking)
            query = query.AsNoTracking();

        if (include != null)
            query = include(query);

        return await query.FirstOrDefaultAsync(predicate);
    }

    public Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool enableTracking = false)
    {
        IQueryable<TEntity> query = Table;

        if (!enableTracking)
            query = query.AsNoTracking();

        return Task.FromResult(query.Where(predicate));
    }

    public async Task<long> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> query = Table;

        if (predicate != null) query = query.Where(predicate);

        return await query.LongCountAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IList<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        var enumerable = entities as TEntity[] ?? entities.ToArray();
        await Table.AddRangeAsync(enumerable);
        await _dbContext.SaveChangesAsync();
        return enumerable.ToList();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Table.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task HardDeleteAsync(TEntity entity)
    {
        Table.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task HardDeleteAsync(string id)
    {
        var entity = await Table.FindAsync(id);
        if (entity != null) Table.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task HardDeleteMatchingAsync(IEnumerable<string> ids)
    {
        foreach (var id in ids)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null)
                Table.Remove(entity);
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task HardDeleteMatchingAsync(params TEntity[] entities)
    {
        Table.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task HardDeleteMatchingAsync(IEnumerable<TEntity> entities)
    {
        Table.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(TEntity entity)
    {
        (entity as EntityBase)!.IsDeleted = true;
        Table.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(string id)
    {
        var entity = await Table.FindAsync(id);
        if (entity != null)
        {
            (entity as EntityBase)!.IsDeleted = true;
            Table.Update(entity);
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task SoftDeleteMatchingAsync(IEnumerable<string> ids)
    {
        foreach (var id in ids)
        {
            var entity = await Table.FindAsync(id);
            if (entity == null)
                continue;

            (entity as EntityBase)!.IsDeleted = true;
            Table.Update(entity);
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task SoftDeleteMatchingAsync(params TEntity[] entities)
    {
        foreach (var entity in entities)
            (entity as EntityBase)!.IsDeleted = true;

        Table.UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SoftDeleteMatchingAsync(IEnumerable<TEntity> entities)
    {
        var enumerable = entities as TEntity[] ?? entities.ToArray();
        foreach (var entity in enumerable)
            (entity as EntityBase)!.IsDeleted = true;

        Table.UpdateRange(enumerable);
        await _dbContext.SaveChangesAsync();
    }
}