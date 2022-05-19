using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.IRepositories
{
    public interface IResultRepository
    {
         Task<Result> AddResultAsync(Result model);

        IEnumerable<Result> GetAllResults();
        Result ResultExists(int eid, int sid, int cid);
    }
}
