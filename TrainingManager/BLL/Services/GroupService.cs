using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;
using BLL.Mappes;

namespace BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            var groupDtos = await groupRepository.GetGroupsAsync();

            var groups = new List<Group>();

            foreach (var groupDto in groupDtos)
            {
                groups.Add(groupDto.ToGroup());
            }

            return groups;
        }

        public async Task<Group> GetGroupAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }

            var group = (await groupRepository.GetGroupAsync(groupId)).ToGroup();

            return group;
        }

        public async Task<int> AddGroupAsync(Group group)
        {
            if (group == null)
            {
                throw new ArgumentNullException($"Entity {nameof(group)} can't be null!");
            }

            int id = await groupRepository.AddGroupAsync(group.ToGroupDto());

            return id;
        }

        public async Task UpdateGroupAsync(int groupId, Group group)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }
            if (group == null)
            {
                throw new ArgumentNullException($"Entity {nameof(group)} can't be null!");
            }

            await groupRepository.UpdateGroupAsync(groupId, group.ToGroupDto());
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }

            await groupRepository.DeleteGroupAsync(groupId);
        }
    }
}
