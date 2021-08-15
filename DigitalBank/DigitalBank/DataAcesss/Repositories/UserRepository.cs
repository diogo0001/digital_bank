using DigitalBank.DataAcesss.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.DataAcesss.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<User> GetUsers()
        {
            return _appDbContext.User.ToList();
        }

        public List<User> GetUsersWithAccounts()
        {
            return _appDbContext.User
                .Include(e => e.Accounts)
                .ToList();
        }
    }
}
