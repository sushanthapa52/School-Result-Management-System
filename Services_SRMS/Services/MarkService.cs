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
    internal class MarkService : Service<Mark, int>, IMarkService
    {
        public MarkService(IMarkRepository repository) : base(repository)
        {
        }
    }
}
