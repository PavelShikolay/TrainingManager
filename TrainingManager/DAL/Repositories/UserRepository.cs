using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Entities;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await context.Set<User>().Select(u => u).ToListAsync();

            var usersDtos = new List<UserDto>();

            foreach (var user in users)
            {
                usersDtos.Add(user.ToUserDto());
            }

            return usersDtos;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync(string role)
        {
            if (role == null)
            {
                throw new ArgumentNullException($"Argument {nameof(role)} can't be null!");
            }

            int roleId = (await context.Set<Role>().FirstAsync(r => r.Name == role)).Id;

            var users = await context.Set<User>().Where(u => u.RoleId == roleId).ToListAsync();

            var usersDtos = new List<UserDto>();

            foreach (var user in users)
            {
                usersDtos.Add(user.ToUserDto());
            }

            return usersDtos;
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be less or equal zero!");
            }

            var user = await context.Set<User>().FirstAsync(u => u.Id == id);

            return user.ToUserDto();
        }

        public async Task<int> AddUserAsync(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException($"Argument {nameof(userDto)} can't be null!");
            }

            int id = context.Set<User>().Add(userDto.ToUser()).Id;

            await context.SaveChangesAsync();

            return id;
        }

        public async Task UpdateUserAsync(int id, UserDto updatedUser)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be less or equal zero!");
            }
            if (updatedUser == null)
            {
                throw new ArgumentNullException($"Argument {nameof(updatedUser)} can't be null!");
            }

            int roleId = (await context.Set<Role>().FirstAsync(r => r.Name == updatedUser.Role)).Id;

            var user = await context.Set<User>().FirstAsync(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentException($"User with id: {id} doesn't exists!");
            }

            user.GroupId = updatedUser.GroupId;
            user.RoleId = roleId;
            user.Name = updatedUser.Name;
            user.Surname = updatedUser.Surname;
            user.Patronymic = updatedUser.Patronymic;
            user.GithubLink = updatedUser.GithubLink;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;

            await context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be less or equal zero!");
            }

            var user = await context.Set<User>().FirstAsync(u => u.Id == id);

            context.Set<User>().Remove(user);

            await context.SaveChangesAsync();
        }
    }
}