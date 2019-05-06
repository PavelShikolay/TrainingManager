using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Interfaces
{
    public interface IModuleRepository
    {
        /// <summary>
        /// Creates new module
        /// </summary>
        /// <param name="moduleDto">Module DTO</param>
        void AddModule(ModuleDto moduleDto);
        /// <summary>
        /// Returns module specified by id
        /// </summary>
        /// <param name="id">Module id</param>
        void GetModule(int id);
        /// <summary>
        /// Updates information about existing module
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="moduleDto">Module DTO</param>
        void UpdateModule(int id, ModuleDto moduleDto);
        /// <summary>
        /// Deletes module specified by id
        /// </summary>
        /// <param name="id">Id</param>
        void DeleteModule(int id);
    }
}
