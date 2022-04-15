using EventExplorer.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventExplorer.Api.Persistence.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("users");
            
            builder
                .Property(x => x.Id)
                .HasColumnName("id");
            
            builder
                .Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();
            
            builder
                .Property(x => x.Password)
                .HasColumnName("password")
                .HasMaxLength(10)
                .IsRequired();
            
            builder
                .Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(255)
                .IsRequired();
            
            builder
                .Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(255)
                .IsRequired();
            
            builder
                .Property(x => x.BirthDate)
                .HasColumnName("birth_date")
                .IsRequired();
        }
    }
}
