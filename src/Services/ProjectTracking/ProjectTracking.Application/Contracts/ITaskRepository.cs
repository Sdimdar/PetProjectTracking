
using ProjectTracking.Domain.Entities;

namespace ProjectTracking.Application.Contracts;

public interface ITaskRepository:IBaseRepository<TaskDbModel>
{
    Task<List<TaskDbModel>> GetTasksByProjectId(int projectId);
}