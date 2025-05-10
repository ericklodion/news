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
    public class NewRepository : BaseRepository<New>, INewRepository
    {
        public NewRepository(AppDbContext context) : base(context)
        {
        }

        public override IQueryable<New> BaseQuery()
        {
            return _context.News
                .Include(x => x.User)
                .Include(x => x.NewTags)
                    .ThenInclude(x => x.Tag);
        }

        public async Task<New> GetByIdAsync(long id)
        {
            return await BaseQuery().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
