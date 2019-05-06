using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Context;
using ORM.Entities;

namespace DAL.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private AppDbContext context;

        public void AddModule(ModuleDto moduleDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteModule(int id)
        {
            throw new NotImplementedException();
        }

        public void GetModule(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateModule(int id, ModuleDto moduleDto)
        {
            throw new NotImplementedException();
        }
    }
}
