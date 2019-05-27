using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    public class Workshop
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int GroupId { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }

        public virtual Group Group { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
