using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services.Models
{
    public class PostDTO : VoteableDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Heat { get; set; }
    }
}
