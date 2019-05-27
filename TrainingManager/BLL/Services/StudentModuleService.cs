using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappes;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
{
    public class StudentModuleService : IStudentModulesService
    {
        private readonly IStudentModuleRepository studentModuleRepository;

        public async Task<IEnumerable<StudentModule>> GetStudentModulesAsync(int moduleId)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            var studentModulesDtos = await studentModuleRepository.GetStudentModuleDtosByModuleIdAsync(moduleId);

            var studentModules = new List<StudentModule>();

            foreach (var studentModuleDto in studentModulesDtos)
            {
                studentModules.Add(studentModuleDto.ToStudentModule());
            }

            return studentModules;
        }

        public async Task<StudentModule> GetStudentModuleAsync(int studentId, int moduleId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(studentId)} can't be less or equal zero!");
            }
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            var studentModulesDtos = await studentModuleRepository.GetStudentModuleDtosByStudentIdAsync(studentId);

            var studentModule = studentModulesDtos.First(sm => sm.ModuleId == moduleId).ToStudentModule();

            return studentModule;
        }

        public async Task AddStudentModulesAsync(int moduleId)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            await studentModuleRepository.AddStudentModulesAsync(moduleId);
        }

        public async Task UpdateStudentModuleAsync(int studentModuleId, StudentModule studentModule)
        {
            if (studentModuleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(studentModuleId)} can't be less or equal zero!");
            }
            if (studentModule == null)
            {
                throw new ArgumentNullException($"Argument {nameof(studentModule)} can't be null!");
            }

            await studentModuleRepository.UpdateStudentModuleAsync(studentModuleId, studentModule.ToStudentModuleDto());
        }

        public async Task DeleteStudentModulesAsync(int moduleId)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            await studentModuleRepository.DeleteStudentModulesAsync(moduleId);
        }
    }
}
