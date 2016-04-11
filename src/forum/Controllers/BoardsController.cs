using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using forum.Services;
using forum.Services.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace forum.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : Controller
    {
        private BoardService _boardService;

        public BoardsController(BoardService boardService)
        {
            _boardService = boardService;
        }

        // GET: api/boards
        [HttpGet]
        public IActionResult GetAllBoards()
        {
            ICollection<BoardDTO> boards = _boardService.GetAllBoards();
            return Ok(boards);
        }

        // GET api/boards/name
        [HttpGet("{name}")]
        public IActionResult GetBoardByName(string name)
        {
            BoardDTO board = _boardService.GetBoardByName(name);
            if (board == null)
            {
                return HttpNotFound();
            }
            return Ok(board);
        }

        // POST api/boards
        [HttpPost]
        public IActionResult PostNewBoard([FromBody]BoardDTO newestBoard)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            if (_boardService.CheckIfBoardExistsByName(newestBoard.Name))
            {
                return HttpBadRequest();
            }
            _boardService.PostNewBoard(newestBoard);
            return Ok();
        }

    }
}
