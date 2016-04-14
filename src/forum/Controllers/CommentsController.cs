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

        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        // POST api/comments
        [HttpPost]
        public IActionResult Post([FromBody]CommentDTO newComment)
        {
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
