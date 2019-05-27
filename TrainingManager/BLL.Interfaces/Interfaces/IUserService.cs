using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>All users</returns>
        Task<IEnumerable<User>> GetUsersAsync();
        /// <summary>
        /// Returns all users with specified role
        /// </summary>
        /// <returns>All users</returns>
        Task<IEnumerable<User>> GetUsersAsync(string role);
        /// <summary>
        /// Adds new user
        /// </summary>
        /// <param name="user">User info</param>
        /// <returns>User id</returns>
        Task<int> AddUserAsync(User user);
        /// <summary>
        /// Returns user specified by id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>User entity</returns>
        Task<User> GetUserAsync(int userId);
        /// <summary>
        /// Updates specified user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="user">New user info</param>
        Task UpdateUserAsync(int userId, User user);
        /// <summary>
        /// Deletes existed user
        /// </summary>
        /// <param name="userId">User id</param>
        Task DeleteUserAsync(int userId);
    }
}
