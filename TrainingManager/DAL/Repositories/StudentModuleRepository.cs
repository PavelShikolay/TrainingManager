using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Context;
using ORM.Entities;

namespace DAL.Repositories
{
    public class StudentModuleRepository : IStudentModuleRepository
    {
        private AppDbContext context;

        public void AddStudentModule(StudentModuleDto studentModuleDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudentModule(int id)
        {
            throw new NotImplementedException();
        }

        public StudentModuleDto GetStudentModuleDto(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentModuleDto> GetStudentModuleDtosByModuleId(int moduleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentModuleDto> GetStudentModuleDtosByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentModule(int id, StudentModuleDto studentModuleDto)
        {
            throw new NotImplementedException();
        }
    }
}
