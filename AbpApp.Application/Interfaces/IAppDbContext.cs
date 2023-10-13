using AbpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AbpApp.Application.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Option> Options { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
