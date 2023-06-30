using Iisaefi.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurations supplémentaires pour vos entités
        modelBuilder.Entity<UserModel>().HasKey(u => u.Id);
        modelBuilder.Entity<MedicalRecord>().HasKey(m => m.Id);

        base.OnModelCreating(modelBuilder);
    }
}
