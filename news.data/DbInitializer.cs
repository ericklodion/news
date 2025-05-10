using news.domain.Contexts;
using news.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Password = "1234",
                    Name = "Administrador",
                    Email = "admin@ici.com.br"
                });

                context.SaveChanges();
            }
        }
    }
}
