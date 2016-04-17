using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using forum.Services.Models;
using forum.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace forum.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private CommentService _commentService;
        private ApplicationUserService _userService;

        public CommentsController(CommentService commentService, ApplicationUserService userService)
        {
            _commentService = commentService;
        }

        // POST api/comments/5
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]Reply reply)
        {
            CommentDTO comment = new CommentDTO
            {
                Content = reply.Content,
                Created = reply.Created,
                ParentCommentId = id,
                CreatorId = _userService.GetUserIdFromName(reply.CreatorId),
                ParentPostId = reply.parentPostId
            };

            if (!_commentService.CheckIfCommentExistsById(id))
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _commentService.AddComment(comment);

            return Ok();
        }

        // PUT api/comments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string updatedContent)
        {
            if (string.IsNullOrWhiteSpace(updatedContent))
            {
                return HttpBadRequest();
            }

            _commentService.UpdateCommentContent(id, updatedContent);
            return Ok();
        }
    }
}
