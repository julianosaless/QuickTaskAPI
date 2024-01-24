namespace QuickTaskAPI.Business.Features.Task.Data
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.Task>> GetAllAsync(int page = 1, int pageSize = 10,CancellationToken cancellationToken = default);
        Task<Entities.Task> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Entities.Task> AddAsync(Entities.Task task, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Guid id, Entities.Task task, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
