using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services.Models
{
    public class BoardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PostDTO> Posts { get; set; }
    }
}
