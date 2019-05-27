using System.Collections.Generic;

namespace BLL.Interfaces.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        public string Name { get; set; }
    }
}
