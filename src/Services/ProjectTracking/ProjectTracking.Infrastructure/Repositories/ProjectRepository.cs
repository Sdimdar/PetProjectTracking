using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Application.Exceptions;
using ProjectTracking.Domain.Entities;
using ProjectTracking.Infrastructure.Persistence;

namespace ProjectTracking.Infrastructure.Repositories;

public class ProjectRepository:IProjectRepository
{
    private readonly ProjectTrackingDbContext _db;


    public ProjectRepository(ProjectTrackingDbContext db)
    {
        _db = db;
    }

    public async Task<bool> AddAsync(ProjectDbModel entity)
    {
        _db.Projects.Add(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(ProjectDbModel entity)
    {
        _db.Projects.Update(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(ProjectDbModel entity)
    {
        IQueryable<TaskDbModel> query = _db.TaskDbModels.Where(x => x.ProjectId == entity.Id);
        _db.TaskDbModels.RemoveRange(query);
        _db.Projects.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<ProjectDbModel?> GetByIdAsync(int id)
    {
        var entity = await _db.Projects.FirstOrDefaultAsync(e => e.Id == id);
        if (entity is null) throw new DatabaseException($"Entity with id = {id} not found");
        return entity;
    }

    public async Task<List<ProjectDbModel>> GetFilteredBatchOfData(int pageSize, int page, string? filterString = null)
    {
        return await FilterByString(_db.Projects, filterString)
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    private IQueryable<ProjectDbModel> FilterByString(IQueryable<ProjectDbModel> tasks, string? filetString)
    {
        return string.IsNullOrEmpty(filetString)
            ? tasks
            : tasks.Where(v => v.ProjectName.ToLower().Contains(filetString.ToLower())
                                  || v.Status.ToLower().Contains(filetString.ToLower())
            );
    }
}