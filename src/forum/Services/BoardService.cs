using forum.Infrastructure;
using forum.Models;
using forum.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services
{
    public class BoardService
    {
        private BoardRepository _boardRepo;

        public BoardService(BoardRepository boardRepo)
        {
            _boardRepo = boardRepo;
        }

        public ICollection<BoardDTO> GetAllBoards()
        {
            return _boardRepo.List().Select(b => new BoardDTO
            {
                Name = b.Name,
                Posts = b.Posts.Select(p => new PostDTO
                {
                    Title = p.Title,
                    Creator = new ApplicationUserDTO
                    {
                        UserName = p.Creator.UserName
                    },
                    Id = p.Id
                }).OrderByDescending(p => p.Created).Take(5).ToList()
            }).ToList();
        }

        public BoardDTO GetBoardByName(string name)
        {
            return _boardRepo.GetBoardByName(name).Select(b => new BoardDTO
            {
                Name = b.Name,
                Posts = b.Posts.Select(p => new PostDTO
                {
                    Title = p.Title,
                    Creator = new ApplicationUserDTO
                    {
                        UserName = p.Creator.UserName
                    },
                    Id = p.Id
                }).ToList()
            }).FirstOrDefault();
        }

        public bool CheckIfBoardExistsByName(string name)
        {
            return _boardRepo.List().Any(b => b.Name == name);
        }

        public void PostNewBoard(BoardDTO newBoardDTO)
        {
            Board newBoard = new Board
            {
                Name = newBoardDTO.Name
            };

            _boardRepo.Add(newBoard);
        }
    }
}
