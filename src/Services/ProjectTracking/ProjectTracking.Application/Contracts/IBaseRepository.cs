namespace ProjectTracking.Application.Contracts;

public interface IBaseRepository<TEntity>
{
    Task<bool> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(int id);
    Task<List<TEntity>> GetFilteredBatchOfData(int pageSize, int page, string? filterString = null);
}