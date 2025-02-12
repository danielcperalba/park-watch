using Microsoft.EntityFrameworkCore;
using ParkWatch.API.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ParkWatch.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<UserTrailHistory> UserTrailHistories { get; set; }
        public DbSet<SightingComment> SightingComments { get; set; }
        public DbSet<SightingLike> SightingLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Relacionamentos e restrições de chaves estrangeiras
            modelBuilder.Entity<Sighting>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sightings)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Sighting>()
                .HasOne(s => s.Species)
                .WithMany(sp => sp.Sightings)
                .HasForeignKey(s => s.SpeciesId);

            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.Achievements)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserTrailHistory>()
                .HasOne(uth => uth.User)
                .WithMany(u => u.TrailHistory)
                .HasForeignKey(uth => uth.UserId);

            modelBuilder.Entity<SightingComment>()
                .HasOne(sc => sc.User)
                .WithMany()
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SightingComment>()
                .HasOne(sc => sc.Sighting)
                .WithMany(s => s.Comments)
                .HasForeignKey(sc => sc.SightingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SightingLike>()
                .HasOne(sl => sl.User)
                .WithMany()
                .HasForeignKey(sl => sl.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SightingLike>()
                .HasOne(sl => sl.Sighting)
                .WithMany(s => s.Likes)
                .HasForeignKey(sl => sl.SightingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
