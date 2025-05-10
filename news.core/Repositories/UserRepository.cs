using Microsoft.EntityFrameworkCore;
using news.core.Repositories.Interfaces;
using news.domain.Contexts;
using news.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public override IQueryable<User> BaseQuery()
        {
            return _context.Users;
        }

        public Task<User> GetByEmail(string email)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
