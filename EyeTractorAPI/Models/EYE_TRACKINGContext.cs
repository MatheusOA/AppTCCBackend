using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EyeTractorAPI.Models
{
    public partial class EYE_TRACKINGContext : DbContext
    {
        public EYE_TRACKINGContext()
        {
        }

        public EYE_TRACKINGContext(DbContextOptions<EYE_TRACKINGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CameraData> CameraData { get; set; }
        public virtual DbSet<SellingPoints> SellingPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("StringConexao");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CameraData>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CameraId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SellingPoints>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Latitude).HasColumnType("decimal(20, 15)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(20, 15)");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Vicinity)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
