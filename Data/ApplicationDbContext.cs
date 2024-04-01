using farkli1001fikir.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace farkli1001fikir.Data
{   public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Cards = Set<CardModel>();
            Comments = Set<CommentModel>();
            Votes = Set<VoteModel>();
        }

        public DbSet<CardModel> Cards { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<VoteModel> Votes { get; set; }
    }

}
