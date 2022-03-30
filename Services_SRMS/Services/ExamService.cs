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
    public class ExamService : Service<Exam, int>, IExamService
    {
        public ExamService(IExamRepository repository) : base(repository)
        {
        }
    }
}
