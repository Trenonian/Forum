using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace forum.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Signature { get; set; }
        public int PostScore { get; set; }
        public int CommentScore { get; set; }
        [InverseProperty("Creator")]
        public ICollection<UserRelations> TaggingOthers { get; set; }
        [InverseProperty("Target")]
        public ICollection<UserRelations> TaggedBy { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
