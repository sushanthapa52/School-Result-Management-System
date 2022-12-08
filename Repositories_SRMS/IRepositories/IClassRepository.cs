﻿using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.IRepositories
{
   public interface IClassRepository
    {
  
        IEnumerable<Class> GetAllClasses();

        Task<Class> AddClassAsync(Class cls);

        Class GetClassById(int id);

        Class UpdateClass(Class classupdates);

        Task RemoveClassAsync(int id);

        bool ClassExists(string classname);
        Task AddSubjectsToClassAsync(List<int> ids, int classid);
        List<int> GetSubjectsByClassId(int classid);
    }
}
