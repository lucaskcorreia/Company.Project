using Company.Project.Domain.Entities;
using Company.Project.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Company.Project.Infra.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        { }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}