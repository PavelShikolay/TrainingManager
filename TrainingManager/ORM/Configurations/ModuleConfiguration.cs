using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    internal sealed class ModuleConfiguration : EntityTypeConfiguration<Module>
    {
        public ModuleConfiguration()
        {
            ToTable("modules");
            HasKey(m => m.Id);
            Property(m => m.Id).HasColumnName("id");
            Property(m => m.GroupId).HasColumnName("group_id").IsRequired();
            Property(m => m.Name).HasColumnName("name").HasMaxLength(512).IsRequired();
            Property(m => m.Description).HasColumnName("description").IsRequired();
            Property(m => m.CreatedAt).HasColumnName("created_at").IsRequired();
            Property(m => m.Deadline).HasColumnName("deadline").IsRequired();
        }
    }
}
