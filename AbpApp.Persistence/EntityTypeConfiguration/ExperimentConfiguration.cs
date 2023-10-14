using Microsoft.EntityFrameworkCore;
using AbpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbpApp.Persistence.EntityTypeConfiguration
{
    internal class ExperimentConfiguration : IEntityTypeConfiguration<Experiment>
    {
        public void Configure(EntityTypeBuilder<Experiment> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p=>p.DeviceToken).IsRequired();
        }
    }
}
