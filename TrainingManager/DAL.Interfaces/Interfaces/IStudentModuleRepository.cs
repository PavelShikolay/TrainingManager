using System.Collections.Generic;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Interfaces
{
    public interface IStudentModuleRepository
    {
        /// <summary>
        /// Adds student module
        /// </summary>
        /// <param name="studentModuleDto">Student module entity</param>
        void AddStudentModule(StudentModuleDto studentModuleDto);
        /// <summary>
        /// Returns student existing student module entity 
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Existing student module entity</returns>
        StudentModuleDto GetStudentModuleDto(int id);
        /// <summary>
        /// Returns a collection of student modules of specified student
        /// </summary>
        /// <param name="studentId">Student id</param>
        /// <returns>Collection of student modules of specified student</returns>
        IEnumerable<StudentModuleDto> GetStudentModuleDtosByStudentId(int studentId);
        /// <summary>
        /// Returns a collection of student modules of specifed module
        /// </summary>
        /// <param name="moduleId">Module id</param>
        /// <returns>Collection of student modules of specifed module</returns>
        IEnumerable<StudentModuleDto> GetStudentModuleDtosByModuleId(int moduleId);
        /// <summary>
        /// Update existing student module
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="studentModuleDto">New student module information</param>
        void UpdateStudentModule(int id, StudentModuleDto studentModuleDto);
        /// <summary>
        /// Deletes student module
        /// </summary>
        /// <param name="id">Id</param>
        void DeleteStudentModule(int id);
    }
}
