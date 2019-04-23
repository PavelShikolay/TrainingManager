using System.Data.Entity.ModelConfiguration;
using ORM.Entities;


namespace ORM.Configurations
{
    internal sealed class WorkshopConfiguration : EntityTypeConfiguration<Workshop>
    {
        public WorkshopConfiguration()
        {
            ToTable("workshops");
            HasKey(w => w.Id);
            Property(w => w.Id).HasColumnName("id");
            Property(w => w.ModuleId).HasColumnName("module_id").IsRequired();
            Property(w => w.DateTime).HasColumnName("datetime").IsRequired();
            Property(w => w.Location).HasColumnName("location").IsRequired();
        }
    }
}
