using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
