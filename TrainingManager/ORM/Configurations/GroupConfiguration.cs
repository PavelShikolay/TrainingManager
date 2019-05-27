using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    internal sealed class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable("groups");
            HasKey(g => g.Id);
            Property(g => g.Id).HasColumnName("id");
            Property(g => g.MentorId).HasColumnName("mentor_id");
            Property(g => g.Name).HasColumnName("name").IsRequired();
        }
    }
}
