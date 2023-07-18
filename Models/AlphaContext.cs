using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Event>? Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasIndex(u => u.Id).IsUnique();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.RegisterDate).IsUnicode(false);
                entity.Property(e => e.Access).HasMaxLength(45).IsUnicode(false);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("units");
                entity.HasIndex(u => u.Id).IsUnique();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasMaxLength(45).IsUnicode(false);
                entity.Property(e => e.State).IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");
                entity.HasIndex(u => u.Id).IsUnique();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Type).HasMaxLength(45).IsUnicode(false);
                entity.Property(e => e.Class).IsUnicode(false);
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.ToTable("entries");
                entity.HasIndex(u => u.Id).IsUnique();
                entity.HasOne<Unit>().WithMany();
                entity.HasOne<Event>().WithMany();
                entity.HasOne<User>().WithMany();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UnitId).IsUnicode(false);
                entity.Property(e => e.EventId).IsUnicode(false);
                entity.Property(e => e.UserId).IsUnicode(false);
                entity.Property(e => e.Measure).IsUnicode(false);
                entity.Property(e => e.Tag).HasMaxLength(45).IsUnicode(false);
                entity.Property(e => e.Notes).HasMaxLength(500).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
