using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappes;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository moduleRepository;

        public async Task<IEnumerable<Module>> GetModulesAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }

            var moduleDtos = await moduleRepository.GetModuleDtosAsync(groupId);

            var modules = new List<Module>();

            foreach (var moduleDto in moduleDtos)
            {
                modules.Add(moduleDto.ToModule());
            }

            return modules;
        }

        public async Task<Module> GetModuleAsync(int moduleId)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            var module = (await moduleRepository.GetModuleAsync(moduleId)).ToModule();

            return module;
        }

        public async Task<int> AddModuleAsync(int groupId, Module module)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }
            if (module == null)
            {
                throw new ArgumentException($"Argument {nameof(module)} can't be null!");
            }

            int id = await moduleRepository.AddModuleAsync(groupId, module.ToModuleDto());

            return id;
        }

        public async Task UpdateModuleAsync(int moduleId, Module module)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }
            if (module == null)
            {
                throw new ArgumentException($"Argument {nameof(module)} can't be null!");
            }

            await moduleRepository.UpdateModuleAsync(moduleId, module.ToModuleDto());
        }

        public async Task DeleteModuleAsync(int moduleId)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            await moduleRepository.DeleteModuleAsync(moduleId);
        }
    }
}
