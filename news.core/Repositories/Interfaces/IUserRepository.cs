using news.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
    }
}
