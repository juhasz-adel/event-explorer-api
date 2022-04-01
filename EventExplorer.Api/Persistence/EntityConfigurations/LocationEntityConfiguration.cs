using EventExplorer.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventExplorer.Api.Persistence.EntityConfigurations
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .ToTable("locations");

            builder
                .Property(x => x.Id)
                .HasColumnName("id");

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.City)
                .HasColumnName("city")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.Address)
                .HasColumnName("address")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.ZipCode)
                .HasColumnName("zip_code")
                .HasMaxLength(4)
                .IsRequired();

            builder
                .Property(x => x.MaximumHeadCount)
                .HasColumnName("maximum_head_count")
                .IsRequired();
        }
    }
}
