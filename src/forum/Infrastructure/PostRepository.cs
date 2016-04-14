using CoderCamps.Infrastructure;
using forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Infrastructure
{

    public class PostRepository : GenericRepository<Post>
    {
        public PostRepository(ApplicationDbContext db) : base(db) { }

        public IQueryable<Post> GetPostById(string boardName, int postId)
        {
            return _db.Posts.Where(p => p.ParentBoard.Name == boardName && p.Id == postId);
        }
    }
}
