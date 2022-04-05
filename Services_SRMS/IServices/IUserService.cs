using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSServices.IServices
{
    public  interface IUserService : IService<User, int>
    {
      Task<User> FindByEmailAsync(string email)  
      Task<IEnumerable<User>> ValidatePassword(User user);
    }
}
