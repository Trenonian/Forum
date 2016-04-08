using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Models
{
    public abstract class Voteable
    {
        [Key]
        public int Id { get; set; }

        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }

        public int ParentBoardId { get; set; }
        [ForeignKey("ParentBoardId")]
        public Board ParentBoard { get; set; }

        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }

        public ICollection<Edit> Edits { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
