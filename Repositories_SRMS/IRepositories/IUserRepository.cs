﻿using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.IRepositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        User CheckUser(string email, string password);
    }
}
