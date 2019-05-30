using System;
using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using ORM.Entities;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Mappers;
using System.Linq;

namespace DAL.Repositories
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private readonly DbContext context;

        public async Task<IEnumerable<WorkshopDto>> GetWorkshops()
        {
            var workshops = await context.Set<Workshop>().Select(w => w).ToListAsync();

            var workshopsDtos = new List<WorkshopDto>();

            foreach (var workshop in workshops)
            {
                workshopsDtos.Add(workshop.ToWorkshopDto());
            }

            return workshopsDtos;
        }

        public async Task<IEnumerable<WorkshopDto>> GetWorkshopsAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }

            var workshops = await context.Set<Workshop>().Where(w => w.GroupId == groupId).ToListAsync();

            var workshopsDtos = new List<WorkshopDto>();

            foreach (var workshop in workshops)
            {
                workshopsDtos.Add(workshop.ToWorkshopDto());
            }

            return workshopsDtos;
        }

        public async Task<WorkshopDto> GetWorkshopAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be less or equal zero!");
            }

            var workshop = await context.Set<Workshop>().FirstAsync(w => w.Id == id);

            return workshop.ToWorkshopDto();
        }

        public async Task<WorkshopDto> GetWorkshopByModuleIdAsync(int moduleId)
        {
            if (moduleId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(moduleId)} can't be less or equal zero!");
            }

            var workshop = await context.Set<Workshop>().FirstAsync(w => w.ModuleId == moduleId);

            return workshop.ToWorkshopDto();
        }

        public async Task<int> AddWorkshopAsync(WorkshopDto workshopDto)
        {
            if (workshopDto == null)
            {
                throw new ArgumentNullException($"Argument {nameof(workshopDto)} can't be null!");
            }

            int id = context.Set<Workshop>().Add(workshopDto.ToWorkshop()).Id;

            var students = await context.Set<User>().Where(u => u.GroupId == workshopDto.GroupId).ToListAsync();

            foreach (var student in students)
            {
                context.Set<Attendance>().Add(new Attendance()
                {
                    WorkshopId = workshopDto.Id,
                    StudentId = student.Id,
                    IsAttended = false
                });
            }

            await context.SaveChangesAsync();

            return id;
        }

        public async Task UpdateWorkshopAsync(int id, WorkshopDto workshopDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be less or equal zero!");
            }
            if (workshopDto == null)
            {
                throw new ArgumentNullException($"Argument {nameof(workshopDto)} can't be null!");
            }

            var workshop = await context.Set<Workshop>().FirstAsync(w => w.Id == id);

            if (workshop == null)
            {
                throw new ArgumentException($"Group with id: {id} doesn't exists!");
            }

            workshop.ModuleId = workshopDto.ModuleId;
            workshop.GroupId = workshopDto.GroupId;
            workshop.DateTime = workshopDto.DateTime;
            workshop.Location = workshopDto.Location;

            await context.SaveChangesAsync();
        }

        public async Task DeleteWorkshopAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument {nameof(id)} can't be less or equal zero!");
            }

            var workshop = await context.Set<Workshop>().FirstAsync(w => w.Id == id);

            context.Set<Workshop>().Remove(workshop);

            await context.SaveChangesAsync();
        }

        public async Task<AttendanceDto> GetStudentAttendanceAsync(int workshopId, int studentId)
        {
            if (workshopId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(workshopId)} can't be less or equal zero!");
            }
            if (studentId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(studentId)} can't be less or equal zero!");
            }

            var attendance = await context.Set<Attendance>().FirstAsync(a => a.WorkshopId == workshopId && a.StudentId == studentId);

            return attendance.ToAttendanceDto();
        }

        public async Task UpdateStudentAttendanceAsync(AttendanceDto attendanceDto)
        {
            if (attendanceDto == null)
            {
                throw new ArgumentNullException($"Argument {nameof(attendanceDto)} can't be null!");
            }

            var attendance = await context.Set<Attendance>().FirstAsync(a => a.WorkshopId == attendanceDto.WorkshopId &&
                                                                             a.StudentId == attendanceDto.StudentId);

            if (attendance == null)
            {
                throw new ArgumentException($"Attendance with student id: {attendanceDto.StudentId} " +
                    $"and workshop id: {attendanceDto.WorkshopId} doesn't exists!");
            }

            attendance.IsAttended = attendanceDto.IsAttended;

            await context.SaveChangesAsync();
        }
    }
}