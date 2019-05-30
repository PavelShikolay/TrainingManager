using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Entities;
using DAL.Mappers;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly DbContext context;

        public async Task<IEnumerable<ModuleDto>> GetModulesAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be equal or less zero!");
            }

            var modules = await context.Set<Module>().Where(m => m.GroupId == groupId).ToListAsync();

            var modulesDtos = new List<ModuleDto>();

            foreach (var module in modules)
            {
                modulesDtos.Add(module.ToModuleDto());
            }

            return modulesDtos;
        }

        public async Task<ModuleDto> GetModuleAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be equal or less zero!");
            }

            var moduleDto = (await context.Set<Module>().FirstAsync(m => m.Id == id)).ToModuleDto();

            return moduleDto;
        }

        public async Task<int> AddModuleAsync(ModuleDto moduleDto)
        {
            if (moduleDto == null)
            {
                throw new ArgumentNullException($"Argument {nameof(moduleDto)} can't be null!");
            }

            context.Set<Module>().Add(moduleDto.ToModule());

            await context.SaveChangesAsync();

            var id = (await context.Set<Module>().FirstAsync(m => m.Name == moduleDto.Name &&
                                                             m.GroupId == moduleDto.GroupId &&
                                                             m.Description == m.Description &&
                                                             m.Deadline == moduleDto.Deadline &&
                                                             m.CreatedAt == moduleDto.CreatedAt)).Id;

            return id;
        }

        public async Task UpdateModuleAsync(int id, ModuleDto moduleDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be equal or less zero!");
            }
            if (moduleDto == null)
            {
                throw new ArgumentNullException($"Argument {nameof(moduleDto)} can't be null!");
            }

            var module = await context.Set<Module>().FirstAsync(m => m.Id == id);

            if (module == null)
            {
                throw new ArgumentException($"Module with id: {id} doesn't exists!");
            }

            module.Name = moduleDto.Name;
            module.GroupId = moduleDto.GroupId;
            moduleDto.Description = moduleDto.Description;
            moduleDto.Deadline = moduleDto.Deadline;
            moduleDto.CreatedAt = moduleDto.CreatedAt;

            await context.SaveChangesAsync();
        }

        public async Task DeleteModuleAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be equal or less zero!");
            }

            foreach (var module in context.Set<Module>())
            {
                if (module.Id == id)
                {
                    context.Set<Module>().Remove(module);
                    break;
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
