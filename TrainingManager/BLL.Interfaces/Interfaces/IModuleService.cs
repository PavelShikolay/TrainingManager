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
        IEnumerable<Module> GetModulesAsync(int groupId);
        /// <summary>
        /// Returns selected module
        /// </summary>
        /// <param name="moduleId">Module id</param>
        /// <returns>Selected module</returns>
        Module GetModuleAsync(int moduleId);
        /// <summary>
        /// Adds module into group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        int AddModuleAsync(int groupId, Module module);
        void UpdateModuleAsync(int moduleId, Module module);
        void DeleteModuleAsync(int moduleId);
    }
}
