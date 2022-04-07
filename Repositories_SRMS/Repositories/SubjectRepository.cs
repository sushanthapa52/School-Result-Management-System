using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class SubjectRepository : Repository<Subject, int> , ISubjectRepository
    {
        public SubjectRepository(SrmsContext sc) : base(sc)
        {
        }
        public int GetSubjectId()
        {
            return  _sc.Subjects.Max(x => x.Id);
        }
        public async Task AddSubjectAsync(Subject sub)
        {
            await _sc.Subjects.AddAsync(sub);
            _sc.SaveChanges();
        }
    }
    
}
