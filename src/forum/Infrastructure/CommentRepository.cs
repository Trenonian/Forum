using CoderCamps.Infrastructure;
using forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Infrastructure
{
    public class CommentRepository : GenericRepository<Comment>
    {
        public CommentRepository(ApplicationDbContext db) : base(db) { }

        public IQueryable<Comment> GetCompleteCommentTreeFromId(int id, bool isComment)
        {
            IQueryable<Comment> level;
            if (isComment)
            {
                level = _db.Comments.Where(c => c.ParentCommentId == id);
            }
            else
            {
                level = _db.Comments.Where(c => c.ParentPostId == id);
            }
            IQueryable<Comment> complete =  level.Select(nest => new Comment
            {
                Content = nest.Content,
                Created = nest.Created,
                CreatorId = nest.CreatorId,
                Creator = nest.Creator,
                Deleted = nest.Deleted,
                Id = nest.Id,
                ParentComment = nest.ParentComment,
                ParentCommentId = nest.ParentCommentId,
                ParentPost = nest.ParentPost,
                ParentPostId = nest.ParentPostId,
                Score = nest.Score,
                Votes = nest.Votes,
                Comments = GetCompleteCommentTreeFromId(nest.Id, true).ToList()
            });
            return complete;
        }
    }
}
