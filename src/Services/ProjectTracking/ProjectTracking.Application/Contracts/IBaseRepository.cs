namespace ProjectTracking.Application.Contracts;

public interface IBaseRepository<TEntity>
{
    Task<bool> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(int id);
    Task<List<TEntity>> GetFilteredBatchOfData(int pageSize, int page, string? filterString = null);
}