using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Interfaces
{
    public interface IGroupRepository
    {
        /// <summary>
        /// Returns collection of all groups
        /// </summary>
        /// <returns></returns>
        Task<ICollection<GroupDto>> GetGroupsAsync();
        /// <summary>
        /// Returns specified group entity
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>Specified group entity</returns>
        Task<GroupDto> GetGroupAsync(int groupId);
        /// <summary>
        /// Adds new group entity
        /// </summary>
        /// <param name="groupDto">Group info</param>
        /// <returns>New group id</returns>
        Task<int> AddGroupAsync(GroupDto groupDto);
        /// <summary>
        /// Updates existed group entity
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <param name="groupDto">Group new info</param>
        Task UpdateGroupAsync(int groupId, GroupDto groupDto);
        /// <summary>
        /// Deletes existed group entity
        /// </summary>
        /// <param name="groupId">Group id</param>
        Task DeleteGroupAsync(int groupId);
        /// <summary>
        /// Returns collection of all students in selected group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>Collection of all students in selected group</returns>
        Task<IEnumerable<UserDto>> GetStudentsAsync(int groupId);
    }
}
