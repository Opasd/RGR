using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TreeDataGridDemo.ModelDogs
{
    public partial class dogs_raceContext : DbContext
    {
        public dogs_raceContext()
        {
        }

        public dogs_raceContext(DbContextOptions<dogs_raceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Stat> Stats { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=./dogs_race.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>(entity =>
            {
                entity.ToTable("dog");

                entity.Property(e => e.Dogid).HasColumnName("dogid");

                entity.Property(e => e.Gender)
                    .HasColumnType("VARCHAR (30)")
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR (30)")
                    .HasColumnName("name");

                entity.Property(e => e.Stats).HasColumnName("stats");

                entity.HasOne(d => d.StatsNavigation)
                    .WithMany(p => p.Dogs)
                    .HasForeignKey(d => d.Stats);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.Matchesid);

                entity.ToTable("matches");

                entity.Property(e => e.Matchesid).HasColumnName("matchesid");

                entity.Property(e => e.Grand)
                    .HasColumnType("VARCHAR (30)")
                    .HasColumnName("grand");

                entity.Property(e => e.Results).HasColumnName("results");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.ResultsNavigation)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.Results);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.Resultsid);

                entity.ToTable("results");

                entity.Property(e => e.Resultsid)
                    .ValueGeneratedNever()
                    .HasColumnName("resultsid");

                entity.Property(e => e.Reward).HasColumnName("reward");

                entity.Property(e => e.Winner).HasColumnName("winner");

                entity.HasOne(d => d.WinnerNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.Winner);
            });

            modelBuilder.Entity<Stat>(entity =>
            {
                entity.HasKey(e => e.Statsid);

                entity.ToTable("stats");

                entity.Property(e => e.Statsid).HasColumnName("statsid");

                entity.Property(e => e.Races).HasColumnName("races");

                entity.Property(e => e.Windist).HasColumnName("windist");

                entity.Property(e => e.Wins).HasColumnName("wins");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("track");

                entity.Property(e => e.Trackid).HasColumnName("trackid");

                entity.Property(e => e.City)
                    .HasColumnType("VARCHAR (30)")
                    .HasColumnName("city");

                entity.Property(e => e.Dist).HasColumnName("dist");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
