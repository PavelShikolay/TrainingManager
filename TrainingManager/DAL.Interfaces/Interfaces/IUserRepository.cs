using System.Collections.Generic;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Adds new user
        /// </summary>
        /// <param name="userDto">New user entity</param>
        void AddUser(UserDto userDto);
        /// <summary>
        /// Returns user entity using user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User entity</returns>
        UserDto GetUser(int id);
        /// <summary>
        /// Returns a collection of users with specified role
        /// </summary>
        /// <param name="roleId">Role id</param>
        /// <returns>collection of users with specified role</returns>
        IEnumerable<UserDto> GetUsers(int roleId);
        /// <summary>
        /// Updates information about user
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="updatedUser">New information</param>
        void UpdateUser(int id, UserDto updatedUser);
        /// <summary>
        /// Deletes specified user
        /// </summary>
        /// <param name="id">User id</param>
        void DeleteUser(int id);
    }
}
