using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    internal sealed class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("roles");
            HasKey(r => r.Id);
            Property(r => r.Id).HasColumnName("id");
            Property(r => r.Name).HasColumnName("name").HasMaxLength(32).IsRequired();
        }
    }
}
