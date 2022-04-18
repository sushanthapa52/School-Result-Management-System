﻿using SRMSDataAccess.Models;
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
          _sc= sc;
        }

      

        public IEnumerable<Class> GetAllClasses()
        {
            return _sc.Classes;
        }

        public async Task<Class> AddClassAsync(Class cls)
        {
            await _sc.Classes.AddAsync(cls);
            await _sc.SaveChangesAsync();
            return cls;

            
        }

        public Class GetClassById(int id)
        {
            var cl= _sc.Classes.Find(id);
            return cl;
        }


        public Class UpdateClass(Class classupdates)
        {
            var newclass = _sc.Classes.Attach(classupdates);
            newclass.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sc.SaveChanges();
            return classupdates;
        }

        public async Task RemoveClassAsync(int id)
        {
            Class? cls=_sc.Classes.Find(id);
            if (cls != null)
            {
                _sc.Classes.Remove(cls);
                await _sc.SaveChangesAsync();
            }

            
        }
    }
    }

