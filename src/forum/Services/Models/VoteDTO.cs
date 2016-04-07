using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services.Models
{
    public class VoteDTO
    {
        public int Id { get; set; }
        public ApplicationUserDTO Voter { get; set; }
        public ApplicationUserDTO Target { get; set; }
        public bool isUpVote { get; set; }
    }
}
