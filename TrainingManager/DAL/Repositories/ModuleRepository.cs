using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Context;
using ORM.Entities;
using DAL.Mappers;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private AppDbContext context;

        public async Task<int> AddModuleAsync(ModuleDto moduleDto)
        {
            if (moduleDto == null)
            {
                throw new ArgumentNullException(nameof(moduleDto));
            }

            int id = context.Modules.Add(moduleDto.ToModule()).Id;

            await context.SaveChangesAsync();

            return id;
        }

        public async Task DeleteModuleAsync(int id)
        {
            Module module = await context.Modules.FindAsync(id);

            if (module == null)
            {
                throw new ArgumentException();
            }

            context.Modules.Remove(module);
            context.SaveChanges();
        }

        public async Task<ModuleDto> GetModuleAsync(int id)
        {
            try
            {
                return (await context.Modules.FindAsync(id)).ToModuleDto();
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public async Task UpdateModuleAsync(int id, ModuleDto moduleDto)
        {
            if (moduleDto == null)
            {
                throw new ArgumentNullException();
            }

            Module module = await context.Modules.FindAsync(id);

            if (module == null)
            {
                throw new ArgumentException();
            }

            module.Name = moduleDto.Name;
            module.Description = moduleDto.Description;
            module.Deadline = moduleDto.Deadline;
            module.CreatedAt = moduleDto.CreatedAt;

            context.SaveChanges();
        }
    }
}
