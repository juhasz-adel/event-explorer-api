using EventExplorer.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventExplorer.Api.Persistence.EntityConfigurations
{
    public class AttendanceEntityConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder
                .ToTable("attendances");

            builder
                .HasKey(x => new { x.EventId, x.UserId });

            builder
                .Property(x => x.EventId)
                .HasColumnName("event_id");

            builder
                .Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();
        }
    }
}
