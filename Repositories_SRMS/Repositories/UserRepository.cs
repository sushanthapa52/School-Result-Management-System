using Microsoft.EntityFrameworkCore;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(SrmsContext sc) : base(sc)
        {
           
        }

        public User CheckUser(string email, string password)
        {
            return _sc.Users.FirstOrDefault(x => x.UserEmail == email && x.UserPassword == password);
        }

        public async Task<User> FindUserByIdAsync(int id)
        {
            var user = await _sc.Users.FindAsync(id);

            return user;
        }

    
    }
}
