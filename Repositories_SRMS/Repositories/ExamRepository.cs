using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class ExamRepository : Repository<Exam, int>, IExamRepository
    {
        public ExamRepository(SrmsContext sc) : base(sc)
        {
        }
    }
}
