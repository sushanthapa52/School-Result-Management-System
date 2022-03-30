using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSServices.Services
{
    public class ClassService : Service<Class, int>, IClassService
    {   
        public ClassService(IClassRepository repository) : base(repository)
        {
            
        }
    }
}
