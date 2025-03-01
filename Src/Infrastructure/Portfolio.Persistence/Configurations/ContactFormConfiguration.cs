using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Entities;

namespace Portfolio.Persistence.Configurations;

public class ContactFormConfiguration : IEntityTypeConfiguration<ContactForm>
{
    public void Configure(EntityTypeBuilder<ContactForm> builder)
    {
        builder.Property(a => a.Name).IsRequired().HasMaxLength(20);
        builder.Property(a => a.Email).IsRequired().HasMaxLength(40);
        builder.Property(a => a.Message).IsRequired().HasMaxLength(100);
    }
}
