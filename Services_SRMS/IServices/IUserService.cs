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
        User SignInValidation(string? email, string? password);


    }
}
