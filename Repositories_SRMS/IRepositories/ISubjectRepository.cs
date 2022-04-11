using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.IRepositories
{
    public interface ISubjectRepository
    {
        Task<Subject> AddSubjectAsync(Subject sub);
        int GetSubjectId();
        Task RemoveSubject(int id);
        IEnumerable<Subject> GetAllSubjects();
        Subject GetSubjectById(int id);
        Subject UpdateSubject(Subject subjectupdates);
    }

    
}
