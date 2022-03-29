using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class ResultRepository : Repository<Result, int>, IResultRepository
    {
        public ResultRepository(SrmsContext sc) : base(sc)
        {
        }
    }
}
