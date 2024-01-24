using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Xunit;
using Moq;

using QuickTaskAPI.Controllers;
using QuickTaskAPI.Business.Features.Task;
using QuickTaskAPI.Business.Features.Task.Response.v1;


namespace QuickTask.API.Tests.Features.Task
{
    public  class TasksControllerTests
    {
        [Fact]
        public async void GetTasks_ReturnsCorrectPageOfTasks()
        {
            // Arrange
            var mockTaskService = new Mock<ITaskService>();
            var mockLogger = new Mock<ILogger<TasksController>>();

            var controller = new TasksController(mockTaskService.Object, mockLogger.Object);

            var tasks = new List<TaskResponseViewModel>
            {
                new() { Id = Guid.NewGuid(), Title = "Task 1", IsCompleted = 'Y' },
                new() { Id = Guid.NewGuid(), Title = "Task 2", IsCompleted = 'F' }
            };

            mockTaskService
                .Setup(c => c.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), default))
                .ReturnsAsync(tasks);
  
            // Act
              var result = await controller.GetAllAsync(page: 2, pageSize: 2);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var taskViewModels = Assert.IsAssignableFrom<IEnumerable<TaskResponseViewModel>>(okResult.Value);
            Assert.Equal(2, taskViewModels.Count());

           
            mockTaskService
                .Verify(service => service.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), default), Times.Once);
        }
    }
}
