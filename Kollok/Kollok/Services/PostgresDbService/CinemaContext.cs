using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kollok
{
    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
        {
        }

        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Cinema;Username=postgres;Password=andrew7322");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("films");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .HasColumnName("genre");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Rate).HasColumnName("rate");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("sessions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.SessionDate).HasColumnName("session_date");

                entity.Property(e => e.SessionTime).HasColumnName("session_time");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sessions_movie_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
