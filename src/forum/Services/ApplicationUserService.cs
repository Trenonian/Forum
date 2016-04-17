using forum.Infrastructure;
using forum.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.Services
{
    public class ApplicationUserService
    {
        private ApplicationUserRepository _userRepo;

        public ApplicationUserService(ApplicationUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public string GetUserIdFromName(string userName)
        {
            string userId = _userRepo.GetUserIdFromName(userName).FirstOrDefault();
            return userId;
        }
    }
}
