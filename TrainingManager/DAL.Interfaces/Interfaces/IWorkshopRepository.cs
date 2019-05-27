using System.Collections.Generic;
using DAL.Interfaces.DTO;
using System.Threading.Tasks;

namespace DAL.Interfaces.Interfaces
{
    public interface IWorkshopRepository
    {
        /// <summary>
        /// Returns collection of all workshops
        /// </summary>
        /// <returns>Collection of all workshops</returns>
        Task<IEnumerable<WorkshopDto>> GetWorkshops();
        /// <summary>
        /// Returns all workshops of specified group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>Collection of workshops of specified group</returns>
        Task<IEnumerable<WorkshopDto>> GetWorkshopsAsync(int groupId);
        /// <summary>
        /// Returns existing workshop by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Existing workshop</returns>
        Task<WorkshopDto> GetWorkshopAsync(int id);
        /// <summary>
        /// Returns existing workshop by module id
        /// </summary>
        /// <param name="moduleId">Module id</param>
        /// <returns>Existing workshop</returns>
        Task<WorkshopDto> GetWorkshopByModuleIdAsync(int moduleId);
        /// <summary>
        /// Adds new workshop
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <param name="workshopDto">Workshop DTO</param>
        Task<int> AddWorkshopAsync(int groupId, WorkshopDto workshopDto);
        /// <summary>
        /// Updates information about workshop
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="workshopDto">New workshop information</param>
        Task UpdateWorkshopAsync(int id, WorkshopDto workshopDto);
        /// <summary>
        /// Deletes workshop
        /// </summary>
        /// <param name="id">Id</param>
        Task DeleteWorkshopAsync(int id);
        /// <summary>
        /// Returns student attendance at workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <param name="studentId">Student id</param>
        /// <returns>Student attendance at workshop</returns>
        Task<AttendanceDto> GetStudentAttendanceAsync(int workshopId, int studentId);
        /// <summary>
        /// Updates information about attendance of workshop by student
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <param name="studentId">Student id</param>
        /// <param name="isAttended">Attendance</param>
        Task UpdateStudentAttendanceAsync(int workshopId, int studentId, bool isAttended);
    }
}
