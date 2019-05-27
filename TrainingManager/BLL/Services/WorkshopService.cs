using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;
using BLL.Mappes;

namespace BLL.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly IWorkshopRepository workshopRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IUserRepository userRepository;

        public async Task<IEnumerable<Workshop>> GetWorkshopsAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }

            var workshopsDtos = await workshopRepository.GetWorkshopsAsync(groupId);

            var workshops = new List<Workshop>();

            foreach (var workshopDto in workshopsDtos)
            {
                workshops.Add(workshopDto.ToWorkshop());
            }

            return workshops;
        }

        public async Task<Workshop> GetWorkshopAsync(int workshopId)
        {
            if (workshopId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(workshopId)} can't be less or equal zero!");
            }

            var workshopDto = await workshopRepository.GetWorkshopAsync(workshopId);

            return workshopDto.ToWorkshop();
        }

        public async Task<int> AddWorkshopAsync(int groupId, Workshop workshop)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(groupId)} can't be less or equal zero!");
            }
            if (workshop == null)
            {
                throw new ArgumentNullException($"Argument {nameof(workshop)} can't be null!");
            }

            int id = await workshopRepository.AddWorkshopAsync(groupId, workshop.ToWorkshopDto());

            return id;
        }

        public async Task UpdateWorkshopAsync(int workshopId, Workshop workshop)
        {
            if (workshopId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(workshopId)} can't be less or equal zero!");
            }
            if (workshop == null)
            {
                throw new ArgumentNullException($"Argument {nameof(workshop)} can't be null!");
            }

            await workshopRepository.UpdateWorkshopAsync(workshopId, workshop.ToWorkshopDto());
        }

        public async Task DeleteWorkshopAsync(int workshopId)
        {
            if (workshopId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(workshopId)} can't be less or equal zero!");
            }

            await workshopRepository.DeleteWorkshopAsync(workshopId);
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesAtWorkshopAsync(int workshopId)
        {
            if (workshopId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(workshopId)} can't be less or equal zero!");
            }

            int groupId = (await workshopRepository.GetWorkshopAsync(workshopId)).GroupId;

            var students = await groupRepository.GetStudentsAsync(groupId);

            var attendances = new List<Attendance>();

            foreach (var student in students)
            {
                var attendance = (await workshopRepository.GetStudentAttendanceAsync(workshopId, student.Id)).ToAttendance();

                attendances.Add(attendance);
            }

            return attendances;
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesOfStudentAsync(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(studentId)} can't be less or equal zero!");
            }

            int groupId = (await userRepository.GetUserAsync(studentId)).GroupId;

            var workshops = await workshopRepository.GetWorkshopsAsync(groupId);

            var attendances = new List<Attendance>();

            foreach (var workshop in workshops)
            {
                var attendance = (await workshopRepository.GetStudentAttendanceAsync(workshop.Id, studentId)).ToAttendance();

                attendances.Add(attendance);
            }

            return attendances;
        }

        public async Task<bool> GetAttendanceAsync(int workshopId, int studentId)
        {
            if (workshopId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(workshopId)} can't be less or equal zero!");
            }
            if (studentId <= 0)
            {
                throw new ArgumentException($"Argument {nameof(studentId)} can't be less or equal zero!");
            }

            var attendance = await workshopRepository.GetStudentAttendanceAsync(workshopId, studentId);

            return attendance.IsAttended;
        }
    }
}
