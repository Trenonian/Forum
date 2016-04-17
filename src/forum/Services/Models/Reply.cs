using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services.Models
{
    public class Reply
    {
        public string CreatorId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int parentPostId { get; set; }
    }
}
