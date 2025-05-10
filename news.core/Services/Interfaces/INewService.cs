using news.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.core.Services.Interfaces
{
    public interface INewService
    {
        Task CreateAsync(New model);
        Task DeleteAsync(New tag);
        Task<IEnumerable<New>> GetAsync();
        Task<New> GetByIdAsync(long id);
        Task UpdateAsync(New model);
    }
}
