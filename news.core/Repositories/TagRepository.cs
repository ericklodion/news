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
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public override IQueryable<Tag> BaseQuery()
        {
            return _context.Tags;
        }

        public async Task<Tag> GetByIdAsync(long id)
        {
            return await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
