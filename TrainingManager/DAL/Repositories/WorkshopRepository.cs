using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Context;
using ORM.Entities;

namespace DAL.Repositories
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private AppDbContext context;

        public void AddWorkshop(WorkshopDto workshopDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkshop(int id)
        {
            throw new NotImplementedException();
        }

        public bool GetStudentAttendance(int workshopId, int studentId)
        {
            throw new NotImplementedException();
        }

        public WorkshopDto GetWorkshop(int id)
        {
            throw new NotImplementedException();
        }

        public WorkshopDto GetWorkshopByModuleId(int moduleId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentAttendance(int workshopId, int studentId, bool isAttended)
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkshop(int id, WorkshopDto workshopDto)
        {
            throw new NotImplementedException();
        }
    }
}
