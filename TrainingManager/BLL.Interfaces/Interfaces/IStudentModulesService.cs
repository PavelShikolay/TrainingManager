using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IStudentModulesService
    {
        /// <summary>
        /// Returns all student modules for specified module
        /// </summary>
        /// <param name="moduleId">Module id</param>
        /// <returns>Collection of student modules for specified module</returns>
        Task<IEnumerable<StudentModule>> GetStudentModulesAsync(int moduleId);
        /// <summary>
        /// Returns student module of specified student 
        /// </summary>
        /// <param name="studentId">Student id</param>
        /// <param name="moduleId">Module id</param>
        /// <returns>Student module entity of specified student</returns>
        Task<StudentModule> GetStudentModuleAsync(int studentId, int moduleId);
        /// <summary>
        /// Adds student modules for all students in group which has specified module
        /// </summary>
        /// <param name="moduleId">Module id</param>
        Task AddStudentModulesAsync(int moduleId);
        /// <summary>
        /// Updates specified student module
        /// </summary>
        /// <param name="studentModuleId">Student module id</param>
        /// <param name="studentModule">Student module new info</param>
        Task UpdateStudentModuleAsync(int studentModuleId, StudentModule studentModule);
        /// <summary>
        /// Deletes all student modules for specified module
        /// </summary>
        /// <param name="moduleId">Module id</param>
        Task DeleteStudentModulesAsync(int moduleId);
    }
}
