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
    public class PostsController : Controller
    {
        private PostService _postService;

        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        // GET: api/posts
        [HttpGet]
        public IActionResult Get()
        {
            ICollection<PostDTO> posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        // GET api/posts/boardName/postId
        [HttpGet("{boardName}/{postId}")]
        public IActionResult Get(string boardName, int postId)
        {
            PostDTO post = _postService.GetPostById(boardName,postId);

            if (post == null)
            {
                return HttpNotFound();
            }

            return Ok(post);
        }

        // POST api/posts
        [HttpPost]
        public IActionResult Post([FromBody]PostDTO newPost)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            _postService.CreateNewPost(newPost);
            return Ok();
        }

        // PUT api/posts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PostDTO value)
        {
            return Ok();
        }

        // DELETE api/posts/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
