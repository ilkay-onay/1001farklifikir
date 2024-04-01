using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farkli1001fikir.Data;
using farkli1001fikir.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using X.PagedList;

namespace farkli1001fikir.Services
{
    public class CardService(ApplicationDbContext context)
    {
        public IPagedList<CardModel> GetCardsForAdmin(int page, int pageSize)
        {
            var cards = context.Cards.OrderBy(c => c.Title);
            var pagedList = cards.ToPagedList(page, pageSize);

            return pagedList;
        }

        public bool SaveOrUpdateCard(CardModel card, string userId)
        {
            if (card.Id == 0)
            {
                card.UserId = userId;
                card.IsPublic = true;
                context.Cards.Add(card);
            }
            else
            {
                var existingCard = context.Cards.SingleOrDefault(c => c.Id == card.Id && c.UserId == userId);

                if (existingCard == null)
                    return false;

                existingCard.Title = card.Title;
                existingCard.Description = card.Description;
                existingCard.Tags = card.Tags;
                existingCard.ImagePath = card.ImagePath;
                existingCard.IsPublic = card.IsPublic;
                existingCard.UpdatedAt = DateTime.UtcNow;
            }

            context.SaveChanges();
            return true;
        }


        public bool DeleteCard(int cardId, string? userId = null)
        {
            var cardToDelete = userId != null
                ? context.Cards.SingleOrDefault(c => c.Id == cardId && c.UserId == userId)
                : context.Cards.Find(cardId);

            if (cardToDelete == null)
            {
                return false;
            }

            context.Cards.Remove(cardToDelete);
            context.SaveChanges();

            return true;
        }
        public List<CardModel> GetCardsForUser(string userId)
        {
            return context.Cards.Where(c => c.UserId == userId).ToList();
        }

        public List<CardModel> GetPublicCards(string userId, bool includePublic = true)
        {
            var query = context.Cards.Where(c => c.UserId == userId);
            if (includePublic)
            {
                query = query.Union(context.Cards.Where(c => c.IsPublic == true || c.IsPublic == null));
            }

            return [.. query];
        }

        public CardModel? GetUserCardById(int cardId, string userId)
        {
            return context.Cards.SingleOrDefault(c => c.Id == cardId && c.UserId == userId);
        }

        public async Task<CardDetailViewModel?> GetCardDetails(int cardId)
        {
            var card = await context.Cards
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == cardId);

            if (card == null)
            {
                return null;
            }

            var comments = await context.Comments
                .Where(c => c.CardId == cardId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            return new CardDetailViewModel
            {
                Card = card,
                Comments = comments
            };
        }

        public async Task<bool> ManageComment(int cardId, int? commentId, string newText, string userId, bool isDelete = false)
        {
            if (isDelete)
            {
                var comment = await context.Comments.FindAsync(commentId);
                if (comment == null || comment.UserId != userId)
                {
                    return false;
                }

                context.Comments.Remove(comment);
            }
            else
            {
                if (commentId.HasValue)
                {
                    var comment = await context.Comments.FindAsync(commentId);
                    if (comment == null || comment.UserId != userId)
                    {
                        return false;
                    }

                    comment.CommentText = newText;
                    comment.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    var comment = new CommentModel
                    {
                        CardId = cardId,
                        UserId = userId,
                        CommentText = newText
                    };

                    context.Comments.Add(comment);
                }
            }

            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Vote(int cardId, string userId, bool isUpvote)
        {
            var existingVote = context.Votes.FirstOrDefault(v => v.UserId == userId && v.CardId == cardId);

            if (existingVote == null)
            {
                var vote = new VoteModel
                {
                    UserId = userId,
                    CardId = cardId,
                    IsUpvote = isUpvote
                };

                context.Votes.Add(vote);

                var card = context.Cards.FirstOrDefault(c => c.Id == cardId);
                if (card != null)
                {
                    if (isUpvote)
                        card.Upvotes++;
                    else
                        card.Downvotes++;

                    await context.SaveChangesAsync();
                }

                return true;
            }

            return false;
        }
    }
}
