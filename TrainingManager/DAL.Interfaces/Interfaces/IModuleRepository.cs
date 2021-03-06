﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Interfaces
{
    public interface IModuleRepository
    {
        /// <summary>
        /// Returns collection of all modules of specified group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>Collection of all modules of specified group</returns>
        Task<IEnumerable<ModuleDto>> GetModulesAsync(int groupId);
        /// <summary>
        /// Returns module specified by id
        /// </summary>
        /// <param name="id">Module id</param>
        Task<ModuleDto> GetModuleAsync(int id);
        /// <summary>
        /// Creates new module
        /// </summary>
        /// <param name="moduleDto">Module DTO</param>
        Task<int> AddModuleAsync(ModuleDto moduleDto);
        /// <summary>
        /// Updates information about existing module
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="moduleDto">Module DTO</param>
        Task UpdateModuleAsync(int id, ModuleDto moduleDto);
        /// <summary>
        /// Deletes module specified by id
        /// </summary>
        /// <param name="id">Id</param>
        Task DeleteModuleAsync(int id);
    }
}
