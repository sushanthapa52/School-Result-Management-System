using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class ResultRepository :IResultRepository
    {
        private readonly SrmsContext _sc;

        public ResultRepository(SrmsContext sc)
        {
            _sc = sc;
        }

        public async Task<Result> AddResultAsync(Result model)
        {
            await _sc.Results.AddAsync(model);
            await _sc.SaveChangesAsync();
            return model;
        }
    }
}
