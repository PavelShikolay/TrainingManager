namespace ORM.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public int StudentId { get; set; }
        public bool IsAttended { get; set; }

        public virtual User User { get; set; }
        public virtual Workshop Workshop { get; set; }
    }
}
