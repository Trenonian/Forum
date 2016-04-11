using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services.Models
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string TargetId { get; set; }
        public string Content { get; set; }
    }
}
