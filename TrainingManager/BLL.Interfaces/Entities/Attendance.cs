using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public int StudentId { get; set; }
        public bool IsAttended { get; set; }
    }
}
