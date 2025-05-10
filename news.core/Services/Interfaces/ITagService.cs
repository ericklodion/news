using news.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.core.Services.Interfaces
{
    public interface ITagService
    {
        Task CreateAsync(Tag tag);
        Task DeleteAsync(Tag tag);
        Task<IEnumerable<Tag>> GetAsync();
        Task<Tag> GetByIdAsync(long id);
        Task UpdateAsync(Tag tag);
    }
}
