using EventExplorer.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventExplorer.Api.Persistence.EntityConfigurations
{
    public class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .ToTable("events");

            builder
                .Property(x => x.Id)
                .HasColumnName("id");

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.Address)
                .HasColumnName("address")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.StartDate)
                .HasColumnName("start_date")
                .IsRequired();

            builder
                .Property(x => x.EndDate)
                .HasColumnName("end_date")
                .IsRequired();

            builder
                .Property(x => x.MaximumHeadCount)
                .HasColumnName("maximum_head_count")
                .IsRequired();

            builder
                .Property(x => x.EntranceFee)
                .HasColumnName("entrance_fee")
                .IsRequired();

            builder
                .Property(x => x.IsIndoor)
                .HasColumnName("is_indoor")
                .IsRequired();
        }
    }
}
