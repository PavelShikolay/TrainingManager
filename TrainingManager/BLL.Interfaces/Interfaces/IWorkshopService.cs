using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IWorkshopService
    {
        /// <summary>
        /// Returns a collection of workshops for specified group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>Collection of workshops for specified group</returns>
        Task<IEnumerable<Workshop>> GetWorkshopsAsync(int groupId);
        /// <summary>
        /// Returns specified workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <returns>Specified workshop</returns>
        Task<Workshop> GetWorkshopAsync(int workshopId);
        /// <summary>
        /// Adds workshop for specified group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <param name="workshop">Workshop info</param>
        /// <returns>Id of created workshop</returns>
        Task<int> AddWorkshopAsync(Workshop workshop);
        /// <summary>
        /// Updates existed workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <param name="workshop">Workshop info</param>
        Task UpdateWorkshopAsync(int workshopId, Workshop workshop);
        /// <summary>
        /// Deletes existed workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        Task DeleteWorkshopAsync(int workshopId);
        /// <summary>
        /// Returns attendance of stundent on workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <param name="studentId">Student id</param>
        /// <returns>Attendance of student on workshop</returns>
        Task<bool> GetAttendanceAsync(int workshopId, int studentId);
        /// <summary>
        /// Returns attendance of student on all workshops
        /// </summary>
        /// <param name="studentId">Student id</param>
        /// <returns>Collection of attendances of student on all workshops</returns>
        Task<IEnumerable<Attendance>> GetAttendancesOfStudentAsync(int studentId);
        /// <summary>
        /// Returns attendance of all students on workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <returns>Collection of attendances of all students on workshop</returns>
        Task<IEnumerable<Attendance>> GetAttendancesAtWorkshopAsync(int workshopId);
    }
}
