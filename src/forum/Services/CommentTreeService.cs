using forum.Infrastructure;
using forum.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services
{
    public class CommentTreeService
    {
        private CommentRepository _commentRepo;

        public CommentTreeService(CommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public ICollection<CommentDTO> GetCompleteCommentTree(int id, bool isComment)
        {
            ICollection<CommentDTO> comments = _commentRepo.GetCompleteCommentTreeFromId(id, isComment).Select(c => new CommentDTO
            {
                Content = c.Content,
                Deleted = c.Deleted,
                Creator = new ApplicationUserDTO
                {
                    UserName = c.Creator.UserName,
                    Signature = c.Creator.Signature
                },
                Created = c.Created,
                Score = c.Score,
                Comments = GetCompleteCommentTree(c.Id, true)
            }).ToList();
            return comments;
        }

    }
}
