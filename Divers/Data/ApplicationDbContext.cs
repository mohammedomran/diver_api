using Divers.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Divers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Room> rooms { get; set; }
        public DbSet<Roomrate> roomrates { get; set; }
        public DbSet<Meal> meals { get; set; }
        public DbSet<Mealrate> mealrates { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 4, Type = "Standard", Quantity = 15 },
                new Room { Id = 1, Type = "Sea view", Quantity = 15 },
                new Room { Id = 2, Type = "Garden view", Quantity = 15 },
                new Room { Id = 3, Type = "Royal suite", Quantity = 15 },
                new Room { Id = 5, Type = "Bool View", Quantity = 15 },
                new Room { Id = 6, Type = "Connecting", Quantity = 15 },
                new Room { Id = 7, Type = "Villa", Quantity = 15 },
                new Room { Id = 8, Type = "Studio", Quantity = 15 },
                new Room { Id = 9, Type = "President suite", Quantity = 15 },
                new Room { Id = 10, Type = "Hollywood Twin", Quantity = 15 }
            );

            modelBuilder.Entity<Meal>().HasData(
                new Meal { Id = 1, Type = "Half Board " },
                new Meal { Id = 2, Type = "Full Board " },
                new Meal { Id = 3, Type = "All Inclusive" }
            );

            modelBuilder.Entity<Roomrate>().HasData(
                new Roomrate
                {
                    Id = 1,
                    Rate = 80,
                    Start = Convert.ToDateTime("1/1/2021 12:00:00 AM"),
                    End = Convert.ToDateTime("1/15/2021 12:00:00 AM"),
                    RoomId = 4
                },
                new Roomrate
                {
                    Id = 2,
                    Rate = 100,
                    Start = Convert.ToDateTime("1/16/2021 12:00:00 AM"),
                    End = Convert.ToDateTime("4/30/2021 12:00:00 AM"),
                    RoomId = 4
                },
                new Roomrate
                {
                    Id = 3,
                    Rate = 80,
                    Start = Convert.ToDateTime("7/1/2021 12:00:00 AM"),
                    End = Convert.ToDateTime("8/1/2021 12:00:00 AM"),
                    RoomId = 4
                }
            );

            modelBuilder.Entity<Mealrate>().HasData(
                new Mealrate
                {
                    Id = 1,
                    Rate = 5,
                    Start = Convert.ToDateTime("1/1/2021 12:00:00 AM"),
                    End = Convert.ToDateTime("5/30/2021 12:00:00 AM"),
                    MealId = 1
                },
                new Mealrate
                {
                    Id = 2,
                    Rate = 10,
                    Start = Convert.ToDateTime("6/1/2021 12:00:00 AM"),
                    End = Convert.ToDateTime("12/31/2021 12:00:00 AM"),
                    MealId = 1
                },
                new Mealrate
                {
                    Id = 3,
                    Rate = 25,
                    Start = Convert.ToDateTime("1/1/2021 12:00:00 AM"),
                    End = Convert.ToDateTime("5/30/2021 12:00:00 AM"),
                    MealId = 2
                },
                new Mealrate
                {
                    Id = 4,
                    Rate = 25,
                    Start = Convert.ToDateTime("6/1/2021 12:00:00 AM"),
                    End = Convert.ToDateTime("12/31/2021 12:00:00 AM"),
                    MealId = 2
                },
                new Mealrate
                {
                    Id = 5,
                    Rate = 25,
                    Start = Convert.ToDateTime("1/1/2021 12:00:00 AM"),
                    End = Convert.ToDateTime("5/30/2021 12:00:00 AM"),
                    MealId = 3
                },
                new Mealrate
                {
                    Id = 6,
                    Rate = 30,
                    Start = Convert.ToDateTime("6/1/2021 12:00:00 AM"),
                    End = Convert.ToDateTime("12/31/2021 12:00:00 AM"),
                    MealId = 3
                }
            );
        }

    }
}
