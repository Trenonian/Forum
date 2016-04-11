using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services.Models
{
    public class VoteDTO
    {
        public int Id { get; set; }
        public string VoterId { get; set; }
        public int TargetId { get; set; }
        public bool isUpVote { get; set; }
    }
}
