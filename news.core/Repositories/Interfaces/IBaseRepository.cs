using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.core.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task CreateAsync(T model);
        Task DeleteAsync(T model);
        Task UpdateAsync(T model);
    }
}
