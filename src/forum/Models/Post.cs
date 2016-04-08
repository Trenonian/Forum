using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Models
{
    public class Post :Voteable
    {
        public string Title { get; set; }
    }
}
