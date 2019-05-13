using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IGroupsService
    {
        /// <summary>
        /// Returns all groups
        /// </summary>
        /// <returns>All groups</returns>
        IEnumerable<Group> GetGroupsAsync();
        /// <summary>
        /// Returns specified group entity
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>Group entity</returns>
        Group GetGroupAsync(int groupId);
        /// <summary>
        /// Adds group
        /// </summary>
        /// <returns>Created group id</returns>
        int AddGroupAsync();
        /// <summary>
        /// Updates existed group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <param name="group">New group info</param>
        void UpdateGroupAsync(int groupId, Group group);
        /// <summary>
        /// Deletes existed group
        /// </summary>
        /// <param name="groupId">Group id</param>
        void DeleteGroupAsync(int groupId);
        /// <summary>
        /// Returns all students in group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IEnumerable<User> GetStudentsAsync(int groupId);
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
