using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
