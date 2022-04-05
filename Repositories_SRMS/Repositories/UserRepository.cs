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
      

        public async Task<User> FindUserByIdAsync(int id)
        {
            var user = await _sc.Users.FindAsync(id);

            return user;
        }

    
    }
}
