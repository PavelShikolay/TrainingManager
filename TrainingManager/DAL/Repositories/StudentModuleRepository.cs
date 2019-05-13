using System;
using System.Linq;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Context;
using DAL.Mappers;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StudentModuleRepository : IStudentModuleRepository
    {
        private AppDbContext context;

        public async Task AddStudentModuleAsync(StudentModuleDto studentModuleDto)
        {
            if(studentModuleDto == null)
            {
                throw new ArgumentNullException();
            }

            context.StudentModules.Add(studentModuleDto.ToStudentModule());

            await context.SaveChangesAsync();
        }

        public async Task DeleteStudentModuleAsync(int id)
        {
            StudentModuleDto studentModule = (await context.StudentModules.FindAsync(id)).ToStudentModuleDto();

            if(studentModule == null)
            {
                throw new ArgumentException("No studentModule with such id found");
            }

            context.StudentModules.Remove(studentModule.ToStudentModule());
            await context.SaveChangesAsync();
        }

        public async Task<StudentModuleDto> GetStudentModuleDtoAsync(int id)
        {
            try
            {
                return (await context.StudentModules.FindAsync(id)).ToStudentModuleDto();
            }
            catch (Exception)
            {
                throw new ArgumentException("No studentModule with such id found");
            }
        }

        public async Task<IEnumerable<StudentModuleDto>> GetStudentModuleDtosByModuleIdAsync(int moduleId)
        {
            var studentModule = from s in context.StudentModules
                                where s.ModuleId == moduleId
                                select s.ToStudentModuleDto();

            return (await ORM.QueriableExtensions.ToArrayAsync(studentModule));
        }

        public async Task<IEnumerable<StudentModuleDto>> GetStudentModuleDtosByStudentIdAsync(int studentId)
        {
            var studentModule = from s in context.StudentModules
                                where s.StudentId == studentId
                                select s.ToStudentModuleDto();

            return (await ORM.QueriableExtensions.ToArrayAsync(studentModule));
        }

        public async Task UpdateStudentModuleAsync(int id, StudentModuleDto studentModuleDto)
        {
            var studentModule = (await context.StudentModules.FindAsync(id)).ToStudentModuleDto();

            if (studentModule == null)
            {
                throw new ArgumentException();
            }

            studentModule.GithubLink = studentModuleDto.GithubLink;
            studentModule.Grade = studentModuleDto.Grade;
            studentModule.ModuleId = studentModuleDto.ModuleId;
            studentModule.StudentId = studentModuleDto.StudentId;
            studentModule.DoneAt = studentModuleDto.DoneAt;
            studentModule.Feedback = studentModule.Feedback;

            await context.SaveChangesAsync();
        }
    }
}
