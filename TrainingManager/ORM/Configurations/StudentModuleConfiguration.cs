using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    internal sealed class StudentModuleConfiguration : EntityTypeConfiguration<StudentModule>
    {
        public StudentModuleConfiguration()
        {
            ToTable("student_modules");
            HasKey(sm => sm.Id);
            Property(sm => sm.Id).HasColumnName("id");
            Property(sm => sm.StudentId).HasColumnName("student_id").IsRequired();
            Property(sm => sm.ModuleId).HasColumnName("module_id").IsRequired();
            Property(sm => sm.Grade).HasColumnName("grade").IsOptional();
            Property(sm => sm.Feedback).HasColumnName("feedback").IsOptional();
            Property(sm => sm.GithubLink).HasColumnName("github_link").IsOptional();
            Property(sm => sm.DoneAt).HasColumnName("done_at").IsOptional();
        }
    }
}
