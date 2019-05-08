using System;

namespace BLL.Interfaces.Entities
{
    public class Workshop
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int GroupId { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
    }
}
