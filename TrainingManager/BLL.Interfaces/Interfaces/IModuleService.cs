using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IModuleService
    {
        /// <summary>
        /// Returns all modules
        /// </summary>
        /// <param name="groupId">Group id of which this module belongs</param>
        /// <returns>All modules in selected group</returns>
        Task<IEnumerable<Module>> GetModulesAsync(int groupId);
        /// <summary>
        /// Returns selected module
        /// </summary>
        /// <param name="moduleId">Module id</param>
        /// <returns>Selected module</returns>
        Task<Module> GetModuleAsync(int moduleId);
        /// <summary>
        /// Adds module into group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <param name="module">Module info</param>
        /// <returns>Id of created module</returns>
        Task<int> AddModuleAsync(int groupId, Module module);
        /// <summary>
        /// Updates existed module
        /// </summary>
        /// <param name="moduleId">Module id</param>
        /// <param name="module">Module new info</param>
        Task UpdateModuleAsync(int moduleId, Module module);
        /// <summary>
        /// Deletes existed module
        /// </summary>
        /// <param name="moduleId">Module id</param>
        Task DeleteModuleAsync(int moduleId);
    }
}
