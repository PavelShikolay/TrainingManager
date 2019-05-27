using System.Data.Entity;
using ORM.Configurations;
using ORM.Entities;

namespace ORM.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("TrainingManagerConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<StudentModule> StudentModules { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Migrations.Configuration>());

            modelBuilder.Configurations.Add(new AttendanceConfiguration());
            modelBuilder.Configurations.Add(new ModuleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new StudentModuleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new WorkshopConfiguration());

            modelBuilder.Entity<User>()
                        .HasRequired<Role>(u => u.Role)
                        .WithMany(r => r.Users)
                        .HasForeignKey<int>(u => u.RoleId);

            modelBuilder.Entity<User>()
                        .HasRequired<Group>(u => u.Group)
                        .WithMany(g => g.Users)
                        .HasForeignKey<int>(u => u.GroupId);

            modelBuilder.Entity<Group>()
                        .HasRequired<User>(g => g.User)
                        .WithMany(u => u.Groups)
                        .HasForeignKey(g => g.MentorId);

            modelBuilder.Entity<StudentModule>()
                        .HasRequired<User>(sm => sm.User)
                        .WithMany(u => u.StudentModules)
                        .HasForeignKey<int>(um => um.StudentId);

            modelBuilder.Entity<StudentModule>()
                        .HasRequired<Module>(sm => sm.Module)
                        .WithMany(m => m.StudentModules)
                        .HasForeignKey<int>(sm => sm.ModuleId);

            modelBuilder.Entity<Workshop>()
                        .HasRequired<Module>(w => w.Module)
                        .WithOptional(m => m.Workshop);

            modelBuilder.Entity<Attendance>()
                        .HasRequired<Workshop>(a => a.Workshop)
                        .WithMany(w => w.Attendances)
                        .HasForeignKey<int>(a => a.WorkshopId);

            modelBuilder.Entity<Attendance>()
                        .HasRequired<User>(a => a.User)
                        .WithMany(u => u.Attendances)
                        .HasForeignKey<int>(a => a.StudentId);

            modelBuilder.Entity<Module>()
                        .HasRequired<Group>(m => m.Group)
                        .WithMany(g => g.Modules)
                        .HasForeignKey<int>(m => m.GroupId);

            modelBuilder.Entity<Workshop>()
                        .HasRequired<Group>(w => w.Group)
                        .WithMany(g => g.Workshops)
                        .HasForeignKey(w => w.GroupId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
