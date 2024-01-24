using Microsoft.EntityFrameworkCore;
using QuickTaskAPI.Business.Data;

namespace QuickTaskAPI.Business.Features.Task.Data
{
    public class TaskRepository(AppDbContext dbContext) : ITaskRepository
    {
        private readonly AppDbContext DbContext = dbContext;

        public async Task<IEnumerable<Entities.Task>> GetAllAsync(int page = 1, int pageSize = 10,CancellationToken cancellation = default)
        {
            return await DbContext.Tasks
              .Skip((page - 1) * pageSize)
              .Take(pageSize)
              .ToListAsync(cancellation);
              
        }

        public async Task<Entities.Task> GetByIdAsync(Guid id, CancellationToken cancellation = default) => await DbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id, cancellation);

        public async Task<Entities.Task> AddAsync(Entities.Task task, CancellationToken cancellation = default)
        {
            await DbContext.Tasks.AddAsync(task, cancellation);
            return task;
        }

        public async Task<bool> UpdateAsync(Guid id, Entities.Task task, CancellationToken cancellation = default)
        {
            var existingTask = await DbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id, cancellation);
            if (existingTask == null)
            {
                return false;
            }

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.StartDate = task.StartDate;
            existingTask.EndDate = task.EndDate;
            existingTask.IsCompleted = task.IsCompleted;
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellation = default)
        {
            var task = await DbContext.Tasks.FirstOrDefaultAsync(task => task.Id == id,  cancellation);
            if (task == null)
            {
                return false;
            }

            DbContext.Tasks.Remove(task);
            return true;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
             return await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
