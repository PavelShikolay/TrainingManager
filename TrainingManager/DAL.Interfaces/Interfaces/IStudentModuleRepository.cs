using System.Collections.Generic;
using DAL.Interfaces.DTO;
using System.Threading.Tasks;

namespace DAL.Interfaces.Interfaces
{
    public interface IStudentModuleRepository
    {
        /// <summary>
        /// Adds student module
        /// </summary>
        /// <param name="studentModuleDto">Student module entity</param>
        Task AddStudentModuleAsync(StudentModuleDto studentModuleDto);
        /// <summary>
        /// Returns student existing student module entity 
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Existing student module entity</returns>
        Task<StudentModuleDto> GetStudentModuleDtoAsync(int id);
        /// <summary>
        /// Returns a collection of student modules of specified student
        /// </summary>
        /// <param name="studentId">Student id</param>
        /// <returns>Collection of student modules of specified student</returns>
        Task<IEnumerable<StudentModuleDto>> GetStudentModuleDtosByStudentIdAsync(int studentId);
        /// <summary>
        /// Returns a collection of student modules of specifed module
        /// </summary>
        /// <param name="moduleId">Module id</param>
        /// <returns>Collection of student modules of specifed module</returns>
        Task<IEnumerable<StudentModuleDto>> GetStudentModuleDtosByModuleIdAsync(int moduleId);
        /// <summary>
        /// Update existing student module
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="studentModuleDto">New student module information</param>
        Task UpdateStudentModuleAsync(int id, StudentModuleDto studentModuleDto);
        /// <summary>
        /// Deletes student module
        /// </summary>
        /// <param name="id">Id</param>
        Task DeleteStudentModuleAsync(int id);
    }
}
