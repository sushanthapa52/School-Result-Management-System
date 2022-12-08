using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private SrmsContext _sc;
        public SubjectRepository(SrmsContext sc)
        {
            _sc = sc;
        }
        public int GetSubjectId()
        {
            return _sc.Subjects.Max(x => x.Id);
        }
        public async Task<Subject> AddSubjectAsync(Subject sub)
        {

            await _sc.Subjects.AddAsync(sub);
            await _sc.SaveChangesAsync();
            return sub;
        }

        public async Task RemoveSubject(int id)
        {
            Subject? subject = _sc.Subjects.Find(id);

            if (subject != null)
            {
                _sc.Subjects.Remove(subject);
               await _sc.SaveChangesAsync();
            }
 }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _sc.Subjects;
        }


        public  Subject GetSubjectById(int id)
        {
            var subject =  _sc.Subjects.Find(id);
            return subject;
        }

        public Subject UpdateSubject(Subject subjectupdates)
        {
            var subject = _sc.Subjects.Attach(subjectupdates);
            subject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sc.SaveChanges();
            return subjectupdates;
        }
        public bool SubjectExists(string subjectname)
        {
            Subject? subj = _sc.Subjects.FirstOrDefault(x => x.SubjectName == subjectname);
            if(subj != null)
                return true;    
            return false;

           
        }
    }

}
