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
        IEnumerable<Workshop> GetWorkshops(int groupId);
        /// <summary>
        /// Returns specified workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <returns>Specified workshop</returns>
        Workshop GetWorkshop(int workshopId);
        /// <summary>
        /// Adds workshop for specified group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <param name="workshop">Workshop info</param>
        /// <returns>Id of created workshop</returns>
        int AddWorkshop(int groupId, Workshop workshop);
        /// <summary>
        /// Updates existed workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <param name="workshop">Workshop info</param>
        void UpdateWorkshop(int workshopId, Workshop workshop);
        /// <summary>
        /// Deletes existed workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        void DeleteWorkshop(int workshopId);
        /// <summary>
        /// Returns attendance of stundent on workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <param name="studentId">Student id</param>
        /// <returns>Attendance of student on workshop</returns>
        bool GetAttendance(int workshopId, int studentId);
        /// <summary>
        /// Returns attendance of student on all workshops
        /// </summary>
        /// <param name="studentId">Student id</param>
        /// <returns>Collection of attendances of student on all workshops</returns>
        IEnumerable<Attendance> GetAttendancesOfStudent(int studentId);
        /// <summary>
        /// Returns attendance of all students on workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <returns>Collection of attendances of all students on workshop</returns>
        IEnumerable<Attendance> GetAttendancesAtWorkshop(int workshopId);
    }
}
