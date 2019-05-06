using System;

namespace DAL.Interfaces.DTO
{
    public class WorkshopDto
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
    }
}
