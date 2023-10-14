using AbpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbpApp.Persistence.EntityTypeConfiguration
{
    internal class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Weight).IsRequired();
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.Key).IsRequired();
        }
    }
}
