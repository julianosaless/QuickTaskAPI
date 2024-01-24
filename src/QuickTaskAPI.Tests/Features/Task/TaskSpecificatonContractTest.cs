using Xunit;
using FluentAssertions;

using QuickTask.API.Tests.Infrastructure;
using QuickTaskAPI.Business.Features.Task.Response.v1;
using QuickTaskAPI.Business.Features.Task.Request.v1;


namespace QuickTask.API.Tests.Features.Task
{
    public class TaskSpecificatonContractTest
    {
        [Theory]
        [APISpecificationContract("Features/Task/Data/Post/request.json", typeof(TaskRequestViewModel))]
        public void Should_create_api_task_post_request_specification(APISpecificationContractResponse specificationContract)
        {
            specificationContract
                .OriginalContent
                .Content
                .Should()
                .Be(specificationContract.ApplicationContent.Content);
        }

        [Theory]
        [APISpecificationContract("Features/Task/Data/Post/request.json", typeof(TaskResponseViewModel))]
        public void Should_create_api_task_post_response_specification(APISpecificationContractResponse specificationContract)
        {
            specificationContract
                .OriginalContent
                .Content
                .Should()
                .Be(specificationContract.ApplicationContent.Content);
        }

    }

}
