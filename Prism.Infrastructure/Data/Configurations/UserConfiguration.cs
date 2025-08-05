using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prism.Domain.User;
using Prism.Infrastructure.Data.Converters;

namespace Prism.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").HasColumnOrder(1).ValueGeneratedNever();
        builder.Property(x => x.Name).HasColumnName("name").HasColumnOrder(2);
        builder.Property(x => x.Email).HasColumnName("email").HasColumnOrder(3);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Password).HasColumnName("password").HasColumnOrder(4);
        builder.Property(x => x.IsBlocked).HasColumnName("is_blocked").HasColumnOrder(5);
        builder
            .Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnOrder(6)
            .HasConversion<DateTimeUtcConverter>();
        builder
            .Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnOrder(7)
            .HasConversion<DateTimeUtcConverter>();
    }
}
