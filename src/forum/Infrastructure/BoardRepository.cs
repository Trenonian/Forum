using CoderCamps.Infrastructure;
using forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Infrastructure
{
    public class BoardRepository : GenericRepository<Board>
    {
        public BoardRepository(ApplicationDbContext db) : base(db) { }

        public IQueryable<Board> GetBoardByName(string name)
        {
            return _db.Boards.Where(b => b.Name == name);
        }
    }
}
