using forum.Infrastructure;
using forum.Models;
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

        private CommentService _commentTreeService;

        public PostService(PostRepository postRepo, CommentService commentTreeService)
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
                },
                Id = p.Id
            }).ToList();
        }

        public PostDTO GetPostById(string boardName, int postId)
        {
            return _postRepo.GetPostById(boardName, postId).Select(p => new PostDTO
            {
                Id = p.Id,
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
                Comments = _commentTreeService.GetCompleteCommentTreeFromPostId(p.Id)
            }).FirstOrDefault();
        }

        public void CreateNewPost(PostDTO newPostDTO)
        {
            Post newPost = new Post
            {
                Content = newPostDTO.Content,
                Created = newPostDTO.Created,
                CreatorId = newPostDTO.Creator.Id,
                ParentBoardId = newPostDTO.Board.Id,
                Title = newPostDTO.Title
            };
            _postRepo.Add(newPost);
        }
    }
}
