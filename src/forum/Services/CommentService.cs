﻿using forum.Infrastructure;
using forum.Models;
using forum.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services
{
    public class CommentService
    {
        private CommentRepository _commentRepo;

        public CommentService(CommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public ICollection<CommentDTO> GetCompleteCommentTreeFromPostId(int id)
        {
            ICollection<CommentDTO> comments = _commentRepo.GetCommentById(id).Select(c => new CommentDTO
            {
                Id = c.Id,
                Content = c.Content,
                Deleted = c.Deleted,
                ParentCommentId = c.ParentCommentId,
                Creator = new ApplicationUserDTO
                {
                    UserName = c.Creator.UserName,
                    Signature = c.Creator.Signature
                },
                Created = c.Created,
                Score = c.Score
            }).ToList();
            
            foreach (var comment in comments)
            {
                comment.Comments = comments.Where(c => c.ParentCommentId == comment.Id).OrderByDescending(c => c.Score).ToList();
            }

            return comments.Where(c => !c.ParentCommentId.HasValue).OrderByDescending(c => c.Score).ToList();
        }

        public void UpdateCommentContent(int id, string updatedContent)
        {
            _commentRepo.UpdateComment(id, updatedContent);
            _commentRepo.SaveChanges();
        }
        
        public bool CheckIfCommentExistsById(int id)
        {
            return _commentRepo.CheckIfCommentExistsById(id);
        }

        public void AddComment(CommentDTO newCommentDTO)
        {
            Comment newComment = new Comment
            {
                Content = newCommentDTO.Content,
                ParentCommentId = newCommentDTO.ParentCommentId,
                ParentPostId = newCommentDTO.ParentPostId,
                CreatorId = newCommentDTO.CreatorId
            };

            _commentRepo.Add(newComment);
        }
    }
}
