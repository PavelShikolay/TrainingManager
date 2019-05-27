using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;
using BLL.Mappes;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUserRepository userRepository;

        public async Task<IEnumerable<User>> GetStudentsAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }

            string usersRole = "Student";

            var studentsDtos = await userRepository.GetUsersAsync(usersRole);

            var students = new List<User>();

            foreach (var studentDto in studentsDtos)
            {
                students.Add(studentDto.ToUser());
            }

            return students;
        }

        public async Task<User> GetStudentAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(studentId)} can't be less or equal zero!");
            }

            var student = await userRepository.GetUserAsync(studentId);

            return student.ToUser();
        }

        public async Task<int> AddStudentAsync(int groupId, User user)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }
            if (user == null)
            {
                throw new ArgumentNullException($"Argument {nameof(user)} can't be null!");
            }

            string role = "Student";

            user.Role = role;
            user.GroupId = groupId;

            int id = await userRepository.AddUserAsync(user.ToUserDto());

            return id;
        }

        public async Task UpdateStudentAsync(int studentId, User user)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(studentId)} can't be less or equal zero!");
            }
            if (user == null)
            {
                throw new ArgumentNullException($"Argument {nameof(user)} can't be null!");
            }

            await userRepository.UpdateUserAsync(studentId, user.ToUserDto());
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(studentId)} can't be less or equal zero!");
            }

            await userRepository.DeleteUserAsync(studentId);
        }
    }
}
