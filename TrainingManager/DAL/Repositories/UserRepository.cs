using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Context;
using ORM.Entities;
using System.Threading.Tasks;
using System.Linq;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext context;

        public async Task AddUserAsync(UserDto userDto)
        {
            if(userDto == null)
            {
                throw new ArgumentException();
            }

            context.Users.Add(userDto.ToUser());
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            UserDto user = (await context.Users.FindAsync(id)).ToUserDto();

            if(user == null)
            {
                throw new ArgumentException();
            }

            context.Users.Remove(user.ToUser());
            await context.SaveChangesAsync();
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            UserDto user = (await context.Users.FindAsync(id)).ToUserDto();

            if (user == null)
            {
                throw new ArgumentException();
            }

            return user;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync(int roleId)
        {
            var users = from u in context.Users
                        where u.RoleId == roleId
                        select u.ToUserDto();

            return (await ORM.QueriableExtensions.ToListAsync(users));
        }

        public async Task UpdateUserAsync(int id, UserDto updatedUser)
        {
            var user = (await context.Users.FindAsync(id)).ToUserDto();

            if(user == null)
            {
                throw new ArgumentException();
            }

            user.Name = updatedUser.Name;
            user.Surname = updatedUser.Surname;
            user.Patronymic = updatedUser.Patronymic;
            user.RoleId = updatedUser.RoleId;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.GithubLink = updatedUser.GithubLink;
            user.Email = updatedUser.Email;

            await context.SaveChangesAsync();
        }
    }
}