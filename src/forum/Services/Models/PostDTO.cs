using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services.Models
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ApplicationUserDTO Creator { get; set; }
        public BoardDTO Board { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public string Content { get; set; }
        
        public ICollection<CommentDTO> Comments { get; set; }
    }
}
