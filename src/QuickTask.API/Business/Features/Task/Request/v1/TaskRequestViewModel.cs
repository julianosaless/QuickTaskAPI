using System.ComponentModel.DataAnnotations;

namespace QuickTaskAPI.Business.Features.Task.Request.v1
{
    public record TaskRequestViewModel
    {
        /// <summary>
        /// Task Id
        /// </summary>
        /// <example>
        ///  3fa85f64-5717-4562-b3fc-2c963f66afa6
        /// </example>
        public Guid Id { get; set; }

        /// <summary>
        /// Task Title
        /// </summary>
        /// <example>
        ///  Create new API
        /// </example>
        [Required]
        [MaxLength(100)]
        public required string Title { get; set; } = "TO DO";


        /// <summary>
        /// Task Description
        /// </summary>
        /// <example>
        ///  task controller...
        /// </example>
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Task Is Completed
        /// </summary>
        /// <example>
        ///  N
        /// </example>
        public char IsCompleted { get; set; } = 'N';
    }
}
