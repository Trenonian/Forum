using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }

        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        
        public ICollection<Vote> Votes { get; set; }

        public int ParentPostId { get; set; }
        [ForeignKey("ParentPostId")]
        public Post ParentPost { get; set; }

        public int ParentCommentId { get; set; }
        [ForeignKey("ParentCommentId")]
        public Comment ParentComment { get; set; }

        [InverseProperty("ParentComment")]
        public ICollection<Comment> Comments { get; set; }
    }
}
