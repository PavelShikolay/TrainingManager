using System;

namespace DAL.Interfaces.DTO
{
    public class ModuleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
    }
}
