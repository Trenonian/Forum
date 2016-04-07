using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Models
{
    public class Edit
    {
        public int Id { get; set; }

        public int ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Voteable Parent { get; set; }

        public DateTime Time { get; set; }
        public string Content { get; set; }
    }
}
