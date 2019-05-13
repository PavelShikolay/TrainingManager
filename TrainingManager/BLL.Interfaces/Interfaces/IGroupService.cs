using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IGroupService
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
        /// /// <param name="group">Group info</param>
        /// <returns>Created group id</returns>
        int AddGroupAsync(Group group);
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
    }
}
