using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace alpha_api.Models
{
    public partial class AlphaContext : DbContext
    {
        public AlphaContext()
        {
        }

        public AlphaContext(DbContextOptions<AlphaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Unit>? Units { get; set; }
        public virtual DbSet<Entry>? Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasIndex(e => e.Id).IsUnique();
                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.RegisterDate).IsUnicode(false);
                entity.Property(e => e.Access).HasMaxLength(45).IsUnicode(false);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("units");
                entity.HasIndex(e => e.Id).IsUnique();
                entity.Property(e => e.MachineId).HasMaxLength(36).IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(45).IsUnicode(false);
                entity.Property(e => e.State).IsUnicode(false);
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.ToTable("entries");
                entity.HasIndex(e => e.Id).IsUnique();
                entity.HasOne(e => e.Unit).WithMany(u => u.Entries).HasForeignKey(e => e.UnitId);
                entity.HasOne(e => e.User).WithMany(u => u.Entries).HasForeignKey(e => e.UserId);
                entity.Property(e => e.UnitId).IsUnicode(false);
                entity.Property(e => e.UserId).IsUnicode(false);
                entity.Property(e => e.Event).IsUnicode(false);
                entity.Property(e => e.Measure).IsUnicode(false);
                entity.Property(e => e.Tag).HasMaxLength(45).IsUnicode(false);
                entity.Property(e => e.Notes).HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.Date).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
