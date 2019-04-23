using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    internal sealed class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("users");
            HasKey(u => u.Id);
            Property(u => u.Id).HasColumnName("id");
            Property(u => u.RoleId).HasColumnName("role_id").IsRequired();
            Property(u => u.Name).HasColumnName("name").HasMaxLength(64).IsRequired();
            Property(u => u.Surname).HasColumnName("surname").HasMaxLength(64).IsRequired();
            Property(u => u.Patronymic).HasColumnName("patronymic").HasMaxLength(64).IsRequired();
            Property(u => u.GithubLink).HasColumnName("github_link").HasMaxLength(256).IsOptional();
            Property(u => u.Email).HasColumnName("email").HasMaxLength(64).IsRequired();
            Property(u => u.PhoneNumber).HasColumnName("phone_number").HasMaxLength(32).IsOptional();
        }
    }
}
