using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services.Models
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public PostDTO ParentPost { get; set; }

        public CommentDTO ParentComment { get; set; }

        public ApplicationUserDTO Creator { get; set; }
        public BoardDTO ParentBoard { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        
        public ICollection<CommentDTO> Comments { get; set; }
        public ICollection<VoteDTO> Votes { get; set; }
    }
}
