using QuickTaskAPI.Business.Features.Task.Request.v1;
using QuickTaskAPI.Business.Features.Task.Response.v1;

namespace QuickTaskAPI.Business.Features.Task
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseViewModel>> GetAllAsync(int page = 1, int pageSize = 10,CancellationToken cancellationToken = default);
        Task<TaskResponseViewModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TaskResponseViewModel> AddAsync(TaskRequestViewModel task, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Guid id, TaskRequestViewModel task, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
