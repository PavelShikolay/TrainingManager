using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;
using BLL.Mappes;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var usersDtos = await userRepository.GetUsersAsync();

            var users = new List<User>();

            foreach (var userDto in usersDtos)
            {
                users.Add(userDto.ToUser());
            }

            return users;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string role)
        {
            if (role == null)
            {
                throw new ArgumentException($"Argument {nameof(role)} can't be null!");
            }

            var usersDtos = await userRepository.GetUsersAsync(role);

            var users = new List<User>();

            foreach (var userDto in usersDtos)
            {
                users.Add(userDto.ToUser());
            }

            return users;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(userId)} can't be less or equal zero!");
            }

            var userDto = await userRepository.GetUserAsync(userId);

            return userDto.ToUser();
        }

        public async Task<int> AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException($"Argument {nameof(user)} can't be null!");
            }

            int id = await userRepository.AddUserAsync(user.ToUserDto());

            return id;
        }

        public async Task UpdateUserAsync(int userId, User user)
        {
            if (userId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(userId)} can't be less or equal zero!");
            }
            if (user == null)
            {
                throw new ArgumentNullException($"Argument {nameof(user)} can't be null!");
            }

            await userRepository.UpdateUserAsync(userId, user.ToUserDto());
        }

        public async Task DeleteUserAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(userId)} can't be less or equal zero!");
            }

            await userRepository.DeleteUserAsync(userId);
        }
    }
}
