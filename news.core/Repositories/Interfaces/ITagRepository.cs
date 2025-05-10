using news.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.core.Repositories.Interfaces
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        Task<Tag> GetByIdAsync(long id);
    }
}
