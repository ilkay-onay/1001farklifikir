using System;
using System.ComponentModel.DataAnnotations;

namespace farkli1001fikir.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        public required string UserId { get; set; }

        [Required]
        public required string CommentText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

    }
}
