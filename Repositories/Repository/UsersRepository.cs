using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Repositories.IRepository;
using Repositories.IRepository.BaseRepository;
using Repositories.Repository.BaseRepository;

namespace Repositories.Repository
{
    public class UsersRepository : BaseRepository<Users>,IUsersRepository
    { 
        public Users FindByName(string name)
        {
            var user = dbSet.FirstOrDefault(x => x.Name.Equals(name));
            if (user != null)
            {
                return user;
            }
            throw new Exception("Brak takiego użytkownika");
        }
    }
}