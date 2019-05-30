using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Mappers;
using DAL.Interfaces.Interfaces;
using DAL.Interfaces.DTO;
using ORM.Entities;

namespace DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DbContext context;

        public async Task<ICollection<GroupDto>> GetGroupsAsync()
        {
            var groups = await context.Set<Group>().Select(g => g).ToListAsync();

            var groupsDtos = new List<GroupDto>();

            foreach (var group in groups)
            {
                groupsDtos.Add(group.ToGroupDto());
            }

            return groupsDtos;
        }

        public async Task<GroupDto> GetGroupAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }

            var group = await context.Set<Group>().FirstAsync(g => g.Id == groupId);

            return group.ToGroupDto();
        }

        public async Task<int> AddGroupAsync(GroupDto groupDto)
        {
            if (groupDto == null)
            {
                throw new ArgumentNullException($"Argument {nameof(groupDto)} can't be null!");
            }

            int id = context.Set<Group>().Add(groupDto.ToGroup()).Id;

            await context.SaveChangesAsync();

            return id;
        }

        public async Task UpdateGroupAsync(int groupId, GroupDto groupDto)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }
            if (groupDto == null)
            {
                throw new ArgumentNullException($"Argument {nameof(groupDto)} can't be null!");
            }

            var group = await context.Set<Group>().FirstAsync(g => g.Id == groupId);

            if (group == null)
            {
                throw new ArgumentException($"Group with id: {groupId} doesn't exists!");
            }

            group.MentorId = groupDto.MentorId;
            group.Name = groupDto.Name;

            await context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }

            var group = await context.Set<Group>().FirstAsync(g => g.Id == groupId);

            context.Set<Group>().Remove(group);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetStudentsAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }

            var students = await context.Set<User>().Where(u => u.GroupId == groupId).ToListAsync();

            var studentsDtos = new List<UserDto>();

            foreach (var student in students)
            {
                studentsDtos.Add(student.ToUserDto());
            }

            await context.SaveChangesAsync();

            return studentsDtos;
        }
    }
}
