using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string VoterId { get; set; }
        [ForeignKey("VoterId")]
        public ApplicationUser Voter { get; set; }

        public int TargetId { get; set; }
        [ForeignKey("TargetId")]
        public Voteable Target { get; set; }

        public bool isUpVote { get; set; }
    }
}
