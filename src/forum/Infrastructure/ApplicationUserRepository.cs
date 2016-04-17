using CoderCamps.Infrastructure;
using forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Infrastructure
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>
    {
        public ApplicationUserRepository(ApplicationDbContext db) : base(db) { }

        public IQueryable<string> GetUserIdFromName(string userName)
        {
            return _db.Users.Where(u => u.UserName == userName).Select(u => u.Id);
        }
    }
}
