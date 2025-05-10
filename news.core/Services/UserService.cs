using news.core.Repositories.Interfaces;
using news.core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Login(string email, string password)
        {
            var user = await _repository.GetByEmail(email);

            //Aqui poderiamos criar uma classe para criptografar essa senha, salvar criptografada e validar
            if (!user.Password.Equals(password, StringComparison.InvariantCultureIgnoreCase))
                return false;

            return true;
        }
    }
}
