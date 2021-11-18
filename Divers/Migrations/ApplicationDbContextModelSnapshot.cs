﻿// <auto-generated />
using System;
using Divers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Divers.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Divers.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("meals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Half Board "
                        },
                        new
                        {
                            Id = 2,
                            Type = "Full Board "
                        },
                        new
                        {
                            Id = 3,
                            Type = "All Inclusive"
                        });
                });

            modelBuilder.Entity("Divers.Models.Mealrate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.ToTable("mealrates");
                });

            modelBuilder.Entity("Divers.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AdultsNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KidsNumber")
                        .HasColumnType("int");

                    b.Property<int?>("MealId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("RoomId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("Divers.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("DefaultRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("rooms");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "Standard"
                        },
                        new
                        {
                            Id = 1,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "Sea view"
                        },
                        new
                        {
                            Id = 2,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "Garden view"
                        },
                        new
                        {
                            Id = 3,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "Royal suite"
                        },
                        new
                        {
                            Id = 5,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "Bool View"
                        },
                        new
                        {
                            Id = 6,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "Connecting"
                        },
                        new
                        {
                            Id = 7,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "Villa"
                        },
                        new
                        {
                            Id = 8,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "Studio"
                        },
                        new
                        {
                            Id = 9,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "President suite"
                        },
                        new
                        {
                            Id = 10,
                            DefaultRate = 75m,
                            Quantity = 15,
                            Type = "Hollywood Twin"
                        });
                });

            modelBuilder.Entity("Divers.Models.Roomrate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("roomrates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            End = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rate = 80,
                            RoomId = 4,
                            Start = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            End = new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rate = 100,
                            RoomId = 4,
                            Start = new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            End = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rate = 80,
                            RoomId = 4,
                            Start = new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Divers.Models.Mealrate", b =>
                {
                    b.HasOne("Divers.Models.Meal", null)
                        .WithMany("Mealrates")
                        .HasForeignKey("MealId");
                });

            modelBuilder.Entity("Divers.Models.Reservation", b =>
                {
                    b.HasOne("Divers.Models.Meal", "Meal")
                        .WithMany("Reservations")
                        .HasForeignKey("MealId");

                    b.HasOne("Divers.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Divers.Models.Roomrate", b =>
                {
                    b.HasOne("Divers.Models.Room", null)
                        .WithMany("Roomrates")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Divers.Models.Meal", b =>
                {
                    b.Navigation("Mealrates");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Divers.Models.Room", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Roomrates");
                });
#pragma warning restore 612, 618
        }
    }
}
