using System;
using System.Linq;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Entities;
using DAL.Mappers;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class StudentModuleRepository : IStudentModuleRepository
    {
        private readonly DbContext context;

        public async Task<IEnumerable<StudentModuleDto>> GetStudentModuleDtosByModuleIdAsync(int moduleId)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            var studentModules = await context.Set<StudentModule>().Where(sm => sm.ModuleId == moduleId).ToListAsync();

            var studentModulesDtos = new List<StudentModuleDto>();

            foreach (var studentModule in studentModules)
            {
                studentModulesDtos.Add(studentModule.ToStudentModuleDto());
            }

            return studentModulesDtos;
        }

        public async Task<IEnumerable<StudentModuleDto>> GetStudentModuleDtosByStudentIdAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(studentId)} can't be less or equal zero!");
            }

            var studentModules = await context.Set<StudentModule>().Where(sm => sm.StudentId == studentId).ToListAsync();

            var studentModulesDtos = new List<StudentModuleDto>();

            foreach (var studentModule in studentModules)
            {
                studentModulesDtos.Add(studentModule.ToStudentModuleDto());
            }

            return studentModulesDtos;
        }

        public async Task<StudentModuleDto> GetStudentModuleDtoAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be less or equal zero!");
            }

            var studentModule = await context.Set<StudentModule>().FirstAsync(sm => sm.Id == id);

            return studentModule.ToStudentModuleDto();
        }

        public async Task AddStudentModulesAsync(int moduleId)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            int groupId = (await context.Set<Module>().FirstAsync(m => m.Id == moduleId)).GroupId;

            var students = await context.Set<User>().Where(s => s.GroupId == groupId).ToListAsync();

            foreach (var student in students)
            {
                context.Set<StudentModule>().Add(new StudentModule()
                {
                    ModuleId = moduleId,
                    StudentId = student.Id
                });
            }

            await context.SaveChangesAsync();
        }

        public async Task UpdateStudentModuleAsync(int id, StudentModuleDto studentModuleDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be less or equal zero!");
            }
            if (studentModuleDto == null)
            {
                throw new ArgumentException($"Argument {nameof(studentModuleDto)} can't be null!");
            }

            var studentModule = await context.Set<StudentModule>().FirstAsync(sm => sm.Id == id);

            if (studentModule == null)
            {
                throw new ArgumentException($"Student module with id: {id} doesn't exists!");
            }

            studentModule.Feedback = studentModuleDto.Feedback;
            studentModule.GithubLink = studentModuleDto.Feedback;
            studentModule.Grade = studentModuleDto.Grade;
            studentModule.DoneAt = studentModuleDto.DoneAt;

            await context.SaveChangesAsync();
        }

        public async Task DeleteStudentModulesAsync(int moduleId)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            int groupId = (await context.Set<Module>().FirstAsync(m => m.Id == moduleId)).GroupId;

            var students = await context.Set<User>().Where(s => s.GroupId == groupId).ToListAsync();

            var studentModules = await context.Set<StudentModule>().Where(sm => sm.ModuleId == moduleId).ToListAsync();

            foreach (var student in students)
            {
                foreach (var studentModule in studentModules)
                {
                    if (studentModule.StudentId == student.Id)
                    {
                        context.Set<StudentModule>().Remove(studentModule);
                    }
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
