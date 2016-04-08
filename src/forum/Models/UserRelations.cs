using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Models
{
    public class UserRelations
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }

        public string TargetId { get; set; }
        [ForeignKey("TargetId")]
        public ApplicationUser Target { get; set; }

        public string Tag { get; set; }
    }
}
