using AbpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbpApp.Application.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Option> Options { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
