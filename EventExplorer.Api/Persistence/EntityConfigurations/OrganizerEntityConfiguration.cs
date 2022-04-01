using EventExplorer.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventExplorer.Api.Persistence.EntityConfigurations
{
    public class OrganizerEntityConfiguration :IEntityTypeConfiguration<Organizer>
    {
        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder
                .ToTable("organizers");
            
            builder
                .Property(x => x.Id)
                .HasColumnName("id");

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
