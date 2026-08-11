using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitApi9K.Models;
using UnitApi9K.Models.DBModels;

namespace UnitApi9K.DAL
{
    public class UnitManagementDbContext : DbContext
    {
        public UnitManagementDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Dog> Dogs {get; set;}
        public DbSet<TrainingSession> TrainingSessions {get; set;}
        public DbSet<Handler> Handlers {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dog>()
                        .HasOne(d=> d.Handler)
                        .WithOne(h=> h.Dog)
                        .HasForeignKey<Dog>(d=> d.HandlerId)
                        .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<TrainingSession>()
                        .HasOne(t=> t.Dog)
                        .WithMany(d=> d.TrainingSessions)
                        .HasForeignKey(t=> t.DogId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}