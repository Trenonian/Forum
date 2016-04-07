using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }

        public int TargetId { get; set; }
        [ForeignKey("TargetId")]
        public ApplicationUser Target { get; set; }

        public string Content { get; set; }
    }
}
