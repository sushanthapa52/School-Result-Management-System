using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly SrmsContext _sc;
        public ClassRepository(SrmsContext sc)
        {
            _sc = sc;
        }

        public async Task<Class> AddClassAsync(Class newclass)
        {
            await _sc.Classes.AddAsync(newclass);
            await _sc.SaveChangesAsync();
            return newclass;
        }
    }
}
