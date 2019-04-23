using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    internal sealed class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            ToTable("attendances");
            HasKey(a => a.Id);
            Property(a => a.Id).HasColumnName("id");
            Property(a => a.WorkshopId).HasColumnName("workshop_id").IsRequired();
            Property(a => a.StudentId).HasColumnName("student_id").IsRequired();
            Property(a => a.IsAttended).HasColumnName("is_attended").IsRequired();
        }
    }
}
