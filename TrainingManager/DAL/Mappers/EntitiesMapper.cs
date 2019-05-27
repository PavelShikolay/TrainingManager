using DAL.Interfaces.DTO;
using System.Linq;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class EntitiesMapper
    {
        /// <summary>
        /// Maps user DTO entity to user entity
        /// </summary>
        /// <param name="userDto">User DTO entity</param>
        /// <returns>User entity</returns>
        public static User ToUser(this UserDto userDto)
        {
            int roleId = (new ORM.Context.AppDbContext()).Roles.First(r => r.Name == userDto.Role).Id;

            return new User()
            {
                Id = userDto.Id,
                GroupId = userDto.GroupId,
                RoleId = roleId,
                Name = userDto.Name,
                Surname = userDto.Surname,
                Patronymic = userDto.Patronymic,
                GithubLink = userDto.GithubLink,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber
            };
        }

        /// <summary>
        /// Maps user entity to user DTO entity
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>User DTO entity</returns>
        public static UserDto ToUserDto(this User user)
        {
            string role = (new ORM.Context.AppDbContext()).Roles.First(r => r.Id == user.Id).Name;

            return new UserDto()
            {
                Id = user.Id,
                GroupId = user.GroupId,
                Role = role,
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                GithubLink = user.GithubLink,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        /// <summary>
        /// Maps group DTO entity to group entity
        /// </summary>
        /// <param name="userDto">Group DTO entity</param>
        /// <returns>Group entity</returns>
        public static Group ToGroup(this GroupDto groupDto)
        {
            return new Group
            {
                Id = groupDto.Id,
                MentorId = groupDto.MentorId,
                Name = groupDto.Name
            };
        }

        /// <summary>
        /// Maps group entity to group DTO entity
        /// </summary>
        /// <param name="user">Group entity</param>
        /// <returns>Group DTO entity</returns>
        public static GroupDto ToGroupDto(this Group group)
        {
            return new GroupDto
            {
                Id = group.Id,
                MentorId = group.MentorId,
                Name = group.Name
            };
        }

        /// <summary>
        /// Maps module DTO entity to module entity
        /// </summary>
        /// <param name="moduleDto">Module DTO entity</param>
        /// <returns>Module entity</returns>
        public static Module ToModule(this ModuleDto moduleDto)
        {
            return new Module()
            {
                Id = moduleDto.Id,
                GroupId = moduleDto.GroupId,
                Name = moduleDto.Name,
                Description = moduleDto.Description,
                CreatedAt = moduleDto.CreatedAt,
                Deadline = moduleDto.Deadline
            };
        }

        /// <summary>
        /// Maps module entity to module DTO entity
        /// </summary>
        /// <param name="module">Module entity</param>
        /// <returns>Module DTO entity</returns>
        public static ModuleDto ToModuleDto(this Module module)
        {
            return new ModuleDto()
            {
                Id = module.Id,
                GroupId = module.GroupId,
                Name = module.Name,
                Description = module.Description,
                CreatedAt = module.CreatedAt,
                Deadline = module.Deadline
            };
        }

        /// <summary>
        /// Maps student module DTO entity to student module entity
        /// </summary>
        /// <param name="studentModuleDto">Student DTO entity</param>
        /// <returns>Student entity</returns>
        public static StudentModule ToStudentModule(this StudentModuleDto studentModuleDto)
        {
            return new StudentModule()
            {
                Id = studentModuleDto.Id,
                StudentId = studentModuleDto.StudentId,
                ModuleId = studentModuleDto.ModuleId,
                Grade = studentModuleDto.Grade,
                Feedback = studentModuleDto.Feedback,
                GithubLink = studentModuleDto.GithubLink,
                DoneAt = studentModuleDto.DoneAt
            };
        }

        /// <summary>
        /// Maps student module entity to student module DTO entity
        /// </summary>
        /// <param name="studentModule">Student module entity</param>
        /// <returns>Student module DTO entity</returns>
        public static StudentModuleDto ToStudentModuleDto(this StudentModule studentModule)
        {
            return new StudentModuleDto()
            {
                Id = studentModule.Id,
                StudentId = studentModule.StudentId,
                ModuleId = studentModule.ModuleId,
                Grade = studentModule.Grade,
                Feedback = studentModule.Feedback,
                GithubLink = studentModule.GithubLink,
                DoneAt = studentModule.DoneAt
            };
        }

        /// <summary>
        /// Maps workshop DTO entity to workshop entity
        /// </summary>
        /// <param name="workshopDto">Workshop DTO entity</param>
        /// <returns>Workshop entity</returns>
        public static Workshop ToWorkshop(this WorkshopDto workshopDto)
        {
            return new Workshop()
            {
                Id = workshopDto.Id,
                ModuleId = workshopDto.ModuleId,
                GroupId = workshopDto.GroupId,
                DateTime = workshopDto.DateTime,
                Location = workshopDto.Location
            };
        }

        /// <summary>
        /// Maps workshop entity to workshop DTO entity
        /// </summary>
        /// <param name="workshop">Workshop entity</param>
        /// <returns>Workshop DTO entity</returns>
        public static WorkshopDto ToWorkshopDto(this Workshop workshop)
        {
            return new WorkshopDto()
            {
                Id = workshop.Id,
                ModuleId = workshop.ModuleId,
                GroupId = workshop.GroupId,
                DateTime = workshop.DateTime,
                Location = workshop.Location
            };
        }

        /// <summary>
        /// Maps attendance DTO entity to attendance entity
        /// </summary>
        /// <param name="attendanceDto">Attendance DTO entity</param>
        /// <returns>Attendance entity</returns>
        public static Attendance ToAttendance(this AttendanceDto attendanceDto)
        {
            return new Attendance()
            {
                Id = attendanceDto.Id,
                StudentId = attendanceDto.StudentId,
                WorkshopId = attendanceDto.WorkshopId,
                IsAttended = attendanceDto.IsAttended
            };
        }

        /// <summary>
        /// Maps attendance entity to attendance DTO entity
        /// </summary>
        /// <param name="attendanceDto">Attendance DTO entity</param>
        /// <returns>Attendance entity</returns>
        public static AttendanceDto ToAttendanceDto(this Attendance attendanceDto)
        {
            return new AttendanceDto()
            {
                Id = attendanceDto.Id,
                StudentId = attendanceDto.StudentId,
                WorkshopId = attendanceDto.WorkshopId,
                IsAttended = attendanceDto.IsAttended
            };
        }
    }
}
