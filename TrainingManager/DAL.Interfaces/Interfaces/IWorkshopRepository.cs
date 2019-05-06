using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Interfaces
{
    public interface IWorkshopRepository
    {
        /// <summary>
        /// Adds new workshop
        /// </summary>
        /// <param name="workshopDto">Workshop DTO</param>
        void AddWorkshop(WorkshopDto workshopDto);
        /// <summary>
        /// Returns existing workshop by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Existing workshop</returns>
        WorkshopDto GetWorkshop(int id);
        /// <summary>
        /// Returns existing workshop by module id
        /// </summary>
        /// <param name="moduleId">Module id</param>
        /// <returns>Existing workshop</returns>
        WorkshopDto GetWorkshopByModuleId(int moduleId);
        /// <summary>
        /// Updates information about workshop
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="workshopDto">New workshop information</param>
        void UpdateWorkshop(int id, WorkshopDto workshopDto);
        /// <summary>
        /// Deletes workshop
        /// </summary>
        /// <param name="id">Id</param>
        void DeleteWorkshop(int id);
        /// <summary>
        /// Returns student attendance at workshop
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <param name="studentId">Student id</param>
        /// <returns>Student attendance at workshop</returns>
        bool GetStudentAttendance(int workshopId, int studentId);
        /// <summary>
        /// Updates information about attendance of workshop by student
        /// </summary>
        /// <param name="workshopId">Workshop id</param>
        /// <param name="studentId">Student id</param>
        /// <param name="isAttended">Attendance</param>
        void UpdateStudentAttendance(int workshopId, int studentId, bool isAttended);
    }
}
