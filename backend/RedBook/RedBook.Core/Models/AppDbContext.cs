using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RedBook.API.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Park> Parks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=212.111.85.37;Port=5432;Username=user;Password=VY7710Z1+J00aAE5u;Database=red_book");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("book_pkey");

            entity.ToTable("book");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Animalname)
                .HasMaxLength(100)
                .HasColumnName("animalname");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Habitat)
                .HasMaxLength(200)
                .HasColumnName("habitat");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");
            entity.Property(e => e.Parkid).HasColumnName("parkid");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.Taxon)
                .HasMaxLength(100)
                .HasColumnName("taxon");

            entity.HasOne(d => d.Park).WithMany(p => p.Books)
                .HasForeignKey(d => d.Parkid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_park");
        });

        modelBuilder.Entity<Park>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("parks_pkey");

            entity.ToTable("parks");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Parkname)
                .HasMaxLength(100)
                .HasColumnName("parkname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
