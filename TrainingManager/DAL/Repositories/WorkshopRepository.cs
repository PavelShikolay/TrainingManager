using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Context;
using ORM.Entities;
using System.Threading.Tasks;
using DAL.Mappers;
using System.Linq;

namespace DAL.Repositories
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private AppDbContext context;

        public async Task AddWorkshopAsync(WorkshopDto workshopDto)
        {
            if(workshopDto == null)
            {
                throw new ArgumentException();
            }

            context.Workshops.Add(workshopDto.ToWorkshop());
            await context.SaveChangesAsync();
        }

        public async Task DeleteWorkshopAsync(int id)
        {
            var workshop = await context.Workshops.FindAsync(id);

            if(workshop == null)
            {
                throw new ArgumentException();
            }

            context.Workshops.Remove(workshop);
            await context.SaveChangesAsync();
        }

        public async Task<bool> GetStudentAttendanceAsync(int workshopId, int studentId)
        {
            var studentAttendence = context.Attendances.First(a => a.WorkshopId == workshopId && a.StudentId == studentId);

            if(studentAttendence == null)
            {
                throw new ArgumentException();
            }

            return studentAttendence.IsAttended;
        }

        public async Task<WorkshopDto> GetWorkshopAsync(int id)
        {
            var workshop = (await context.Workshops.FindAsync(id)).ToWorkshopDto();

            if (workshop == null)
            {
                throw new ArgumentException();
            }

            return workshop;
        }

        public async Task<WorkshopDto> GetWorkshopByModuleIdAsync(int moduleId)
        {
            var workshop = (await context.Workshops.FindAsync(moduleId)).ToWorkshopDto();

            if (workshop == null)
            {
                throw new ArgumentException();
            }

            return workshop;
        }

        public async Task UpdateStudentAttendanceAsync(int workshopId, int studentId, bool isAttended)
        {
            var studentAttendence = context.Attendances.First(a => a.WorkshopId == workshopId && a.StudentId == studentId);

            if (studentAttendence == null)
            {
                throw new ArgumentException();
            }

            studentAttendence.IsAttended = isAttended;

            await context.SaveChangesAsync();
        }

        public async Task UpdateWorkshopAsync(int id, WorkshopDto workshopDto)
        {
            var workshop = (await context.Workshops.FindAsync(id)).ToWorkshopDto();

            if(workshop == null)
            {
                throw new ArgumentException();
            }

            workshop.DateTime = workshopDto.DateTime;
            workshop.Location = workshopDto.Location;
            workshop.ModuleId = workshopDto.ModuleId;

            await context.SaveChangesAsync();
        }
    }
}