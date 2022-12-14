using Microsoft.EntityFrameworkCore;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Domain.Entities;
using ProjectTracking.Infrastructure.Persistence;

namespace ProjectTracking.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ProjectTrackingDbContext _db;


    public TaskRepository(ProjectTrackingDbContext db)
    {
        _db = db;
    }

    public async Task<bool> AddAsync(TaskDbModel entity)
    {
        _db.TaskDbModels.Add(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task UpdateAsync(TaskDbModel entity)
    {
        _db.TaskDbModels.Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskDbModel entity)
    {
        _db.TaskDbModels.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<TaskDbModel?> GetByIdAsync(int id)
    {
        var entity = await _db.TaskDbModels.FirstOrDefaultAsync(e => e.Id == id);
        return entity;
    }

    public async Task<List<TaskDbModel>> GetFilteredBatchOfData(int pageSize, int page, string? filterString = null)
    {
        return await FilterByString(_db.TaskDbModels, filterString)
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    private IQueryable<TaskDbModel> FilterByString(IQueryable<TaskDbModel> projects, string? filetString)
    {
        return string.IsNullOrEmpty(filetString)
            ? projects
            : projects.Where(v => v.TaskName.ToLower().Contains(filetString.ToLower())
                                  || v.Status.ToLower().Contains(filetString.ToLower())
            );
    }
}