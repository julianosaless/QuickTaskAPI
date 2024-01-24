using QuickTaskAPI.Business.Features.Task.Data;
using QuickTaskAPI.Business.Features.Task.Request.v1;
using QuickTaskAPI.Business.Features.Task.Response.v1;

namespace QuickTaskAPI.Business.Features.Task
{
    public class TaskService(ITaskRepository taskRepository) : ITaskService
    {
        public async Task<IEnumerable<TaskResponseViewModel>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var tasks = await taskRepository.GetAllAsync(page,pageSize,cancellationToken);
            return tasks.Select(task => new TaskResponseViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                IsCompleted = task.IsCompleted ? 'Y' : 'N'
            });
        }


        public async Task<TaskResponseViewModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {   
            var response = await taskRepository.GetByIdAsync(id, cancellationToken);
            return new TaskResponseViewModel
            {
                Id = response.Id,
                Title = response.Title,
                IsCompleted = response.IsCompleted ? 'Y' : 'N'
            };
        }

        public async Task<TaskResponseViewModel> AddAsync(TaskRequestViewModel task, CancellationToken cancellationToken = default)
        {
            var newTask = await taskRepository.AddAsync(new Entities.Task
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                IsCompleted = task.IsCompleted  == 'y'
            }, cancellationToken); ;

            await taskRepository.SaveChangesAsync(cancellationToken);
            return new TaskResponseViewModel
            {
                Id = newTask.Id,
                Title = newTask.Title,
                Description = newTask.Description,
                StartDate = newTask.StartDate,
                EndDate = newTask.EndDate,
                IsCompleted = newTask.IsCompleted ? 'Y' : 'N'
            };
        }

        public async Task<bool> UpdateAsync(Guid id, TaskRequestViewModel task, CancellationToken cancellationToken = default)
        {
           return await taskRepository.UpdateAsync
           (
                id,
                new Entities.Task
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    IsCompleted = task.IsCompleted == 'y'
                },cancellationToken
            );
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await taskRepository.DeleteAsync(id,cancellationToken);
        }
       
    }
}
