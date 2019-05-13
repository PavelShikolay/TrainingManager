using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    internal sealed class GroupConfiguration : EntityTypeConfiguration<Attendance>
    {
        public GroupConfiguration()
        {
            ToTable("groups");
            HasKey(g => g.Id);
            Property(g => g.Id).HasColumnName("id");
        }
    }
}
