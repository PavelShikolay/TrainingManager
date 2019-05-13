using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IStudentService
    {
        /// <summary>
        /// Returns all students in group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IEnumerable<User> GetStudentsAsync(int groupId);
        /// <summary>
        /// Returns specified student
        /// </summary>
        /// <param name="studentId">Student id</param>
        /// <returns>Specified student</returns>
        User GetStudentAsync(int studentId);
        /// <summary>
        /// Adds student into group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <param name="user">Student info</param>
        /// <returns>Student id</returns>
        int AddStudentAsync(int groupId, User user);
        /// <summary>
        /// Updates info about student
        /// </summary>
        /// <param name="studentId">Student id</param>
        /// <param name="user">Student new info</param>
        void UpdateStudentAsync(int studentId, User user);
        /// <summary>
        /// Deletes existed student
        /// </summary>
        /// <param name="studentId">Student id</param>
        void DeleteStudentAsync(int studentId);
    }
}
