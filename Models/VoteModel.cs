namespace farkli1001fikir.Models
{
    public class VoteModel
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public int CardId { get; set; }
        public bool IsUpvote { get; set; }
    }
}