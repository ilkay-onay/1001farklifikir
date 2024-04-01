namespace farkli1001fikir.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "default";
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int Upvotes { get; set; } = 0;
        public int Downvotes { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? Tags { get; set; }
        public string? ImagePath { get; set; }
        public bool? IsPublic { get; set; }
    }
}
