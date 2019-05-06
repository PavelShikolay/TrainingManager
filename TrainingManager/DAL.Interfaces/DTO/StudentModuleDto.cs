using System;

namespace DAL.Interfaces.DTO
{
    public class StudentModuleDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ModuleId { get; set; }
        public int Grade { get; set; }
        public string Feedback { get; set; }
        public string GithubLink { get; set; }
        public DateTime DoneAt { get; set; }
    }
}
