using forum.Infrastructure;
using forum.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services
{
    public class PostService
    {
        private PostRepository _postRepo;

        private CommentTreeService _commentTreeService;

        public PostService(PostRepository postRepo, CommentTreeService commentTreeService)
        {
            _postRepo = postRepo;
            _commentTreeService = commentTreeService;
        }

        public ICollection<PostDTO> GetAllPosts()
        {
            return _postRepo.List().Select(p => new PostDTO
            {
                Title = p.Title,
                Content = p.Content,
                Created = p.Created,
                Deleted = p.Deleted,
                Creator = new ApplicationUserDTO
                {
                    UserName = p.Creator.UserName
                },
                Board = new BoardDTO
                {
                    Name = p.ParentBoard.Name
                }
            }).ToList();
        }

        public PostDTO GetPostById(int id)
        {
            return _postRepo.GetPostById(id).Select(p => new PostDTO
            {
                Title = p.Title,
                Content = p.Content,
                Created = p.Created,
                Deleted = p.Deleted,
                Creator = new ApplicationUserDTO
                {
                    UserName = p.Creator.UserName
                },
                Board = new BoardDTO
                {
                    Name = p.ParentBoard.Name
                },
                Comments = _commentTreeService.GetCompleteCommentTree(p.Id, false)
            }).FirstOrDefault();
        }
    }
}
