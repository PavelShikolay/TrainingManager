﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Workshop> Workshops { get; set; }
        public virtual User User { get; set; }
    }
}
