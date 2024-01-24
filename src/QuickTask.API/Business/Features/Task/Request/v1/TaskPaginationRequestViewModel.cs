namespace QuickTaskAPI.Business.Features.Task.Request.v1
{
    public record TaskPaginationRequestViewModel
    {
        public int Page { get; init; }
        public int PageSize { get; init; }

    }
}
