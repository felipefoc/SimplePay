using Microsoft.EntityFrameworkCore;
using SimplePay.Models;

namespace SimplePay.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Shopkeeper> Shopkeepers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações do mapeamento (Fluent API)
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id); // Define a chave primária
            entity.Property(u => u.FullName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Cpf).IsRequired().HasMaxLength(12);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Password).IsRequired();
            entity.Property(u => u.Balance).HasDefaultValue(0m);
            entity.HasIndex(u => u.Cpf).IsUnique(); // Cpf único
            entity.HasIndex(u => u.Email).IsUnique();
        });
        
        modelBuilder.Entity<Shopkeeper>(entity =>
        {
            entity.HasKey(u => u.Id); // Define a chave primária
            entity.Property(u => u.FullName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Cnpj).IsRequired().HasMaxLength(17);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Balance).HasDefaultValue(0m);
            entity.Property(u => u.Password).IsRequired();
            entity.HasIndex(u => u.Cnpj).IsUnique(); // Cpf único
        });

        modelBuilder.Entity<PaymentHistory>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Date);
            entity.Property(u => u.Amount).IsRequired();
            entity.Property(u => u.Type).IsRequired();
            entity.HasOne(u => u.Payer)
                .WithMany()
                .HasForeignKey(u => u.PayerId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(u => u.Shopkeeper)
                .WithMany()
                .HasForeignKey(u => u.ShopkeeperId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}