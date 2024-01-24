namespace QuickTaskAPI.Business.Features.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public  string? Description { get; set; }
        public DateTime StartDate;
        public DateTime EndDate;
        public bool IsCompleted { get; set; }
    }
}
