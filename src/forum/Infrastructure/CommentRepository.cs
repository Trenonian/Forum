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

        public IQueryable<Comment> GetCommentById(int id)
        {
            return _db.Comments.Where(c => c.ParentPostId == id);
        }

        public bool CheckIfCommentExistsById(int id)
        {
            return _db.Comments.Any(c => c.Id == id);
        }

        public IQueryable<Comment> GetAllImmediateChildCommentsFromPostById(int id)
        {
            return _db.Comments.Where(c => c.ParentPostId == id && c.ParentComment == null);
        }

        public void UpdateComment(int id, string updatedContent)
        {
            _db.Comments.FirstOrDefault(c => c.Id == id).Content = updatedContent;
        }

        //public IQueryable<Comment> GetCompleteCommentTreeFromPostId(int id)
        //{
        //    IQueryable<Comment> level = GetAllImmediateChildCommentsFromPostById(id);
        //    IQueryable<Comment> complete = level.Select(nest => new Comment
        //    {
        //        Content = nest.Content,
        //        Created = nest.Created,
        //        CreatorId = nest.CreatorId,
        //        Creator = nest.Creator,
        //        Deleted = nest.Deleted,
        //        Id = nest.Id,
        //        ParentComment = nest.ParentComment,
        //        ParentCommentId = nest.ParentCommentId,
        //        ParentPost = nest.ParentPost,
        //        ParentPostId = nest.ParentPostId,
        //        Score = nest.Score,
        //        Votes = nest.Votes,
        //        Comments = GetCommentsFromCommentId(nest).ToList()
        //    });

        //    return complete;
        //}

        //public IQueryable<Comment> GetCommentsFromCommentId(Comment comment)
        //{
        //    if (!comment.Comments.Any())
        //    {
        //        return null;
        //    }

        //    return comment.Comments.Select(nest => new Comment
        //    {
        //        Content = nest.Content,
        //        Created = nest.Created,
        //        CreatorId = nest.CreatorId,
        //        Creator = nest.Creator,
        //        Deleted = nest.Deleted,
        //        Id = nest.Id,
        //        ParentComment = nest.ParentComment,
        //        ParentCommentId = nest.ParentCommentId,
        //        ParentPost = nest.ParentPost,
        //        ParentPostId = nest.ParentPostId,
        //        Score = nest.Score,
        //        Votes = nest.Votes,
        //        Comments = GetCommentsFromCommentId(nest).ToList()
        //    }).AsQueryable();
        //}

    }
}
