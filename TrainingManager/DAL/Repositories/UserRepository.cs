using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Context;
using ORM.Entities;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext context;

        public void AddUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers(int roleId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int id, UserDto updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
