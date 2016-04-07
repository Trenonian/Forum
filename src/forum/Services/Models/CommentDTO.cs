using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services.Models
{
    public class CommentDTO : VoteableDTO
    {
        public int Id { get; set; }
        public VoteableDTO Parent { get; set; }
    }
}
