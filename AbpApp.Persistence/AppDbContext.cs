using AbpApp.Application.Interfaces;
using AbpApp.Domain.Entities;
using AbpApp.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AbpApp.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Option> Options { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ExperimentConfiguration());
            builder.ApplyConfiguration(new OptionConfiguration());

            base.OnModelCreating(builder);
        }
    }
}