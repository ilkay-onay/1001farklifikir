using System.Collections.Generic;
using farkli1001fikir.Models;

namespace farkli1001fikir.Models
{
    
    public class CardDetailViewModel
    {
        public required CardModel Card { get; set; }
        public List<CommentModel>? Comments { get; set; }
    }
}
