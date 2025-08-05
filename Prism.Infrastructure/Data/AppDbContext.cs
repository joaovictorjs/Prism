using System;
using Microsoft.EntityFrameworkCore;
using Prism.Domain.User;
using Prism.Infrastructure.Data.Configurations;

namespace Prism.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
