using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }

        public virtual ICollection<StudentModule> StudentModules { get; set; }
        public virtual Workshop Workshop { get; set; }
    }
}
