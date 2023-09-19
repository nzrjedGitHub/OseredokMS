﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oseredok.Infrastructure.Persistence;

#nullable disable

namespace Oseredok.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Oseredok.Domain.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.HasIndex("UserId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f"),
                            GymId = 1,
                            Salary = 6000m,
                            UserId = new Guid("d4119255-950b-4d87-f432-9ce087f34698")
                        });
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientPaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoachId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClientPaymentId");

                    b.HasIndex("CoachId");

                    b.HasIndex("GymId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                            ClientPaymentId = new Guid("d4e65555-950b-4d87-b111-9ce087f3c79f"),
                            CoachId = new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                            GymId = 1,
                            UserId = new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f")
                        });
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.ClientPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("LastPaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("LastPaymentSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PaymentPerSession")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ClientPayments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4e65555-950b-4d87-b111-9ce087f3c79f"),
                            Balance = 100m,
                            LastPaymentDate = new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastPaymentSum = 100m,
                            PaymentPerSession = 50m
                        });
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Coach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<decimal>("PercentagePerSession")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Coaches");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                            GymId = 1,
                            PercentagePerSession = 15m,
                            UserId = new Guid("d4119255-950b-4d87-b568-9ce087f34698")
                        },
                        new
                        {
                            Id = new Guid("d4e61167-950b-4d87-b568-9ce087f3c744"),
                            GymId = 1,
                            PercentagePerSession = 0m,
                            UserId = new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f")
                        });
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ClientCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Gyms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "someAddress",
                            ClientCapacity = 5
                        });
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "coach"
                        },
                        new
                        {
                            Id = 3,
                            Name = "client"
                        },
                        new
                        {
                            Id = 4,
                            Name = "noRole"
                        });
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SessionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SessionStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CoachId");

                    b.HasIndex("GymId");

                    b.HasIndex("SessionStatusId");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4f65555-950b-4d27-b568-9ce087f3c79f"),
                            ClientId = new Guid("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                            CoachId = new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                            GymId = 1,
                            SessionDate = new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionStatusId = 5
                        },
                        new
                        {
                            Id = new Guid("d4f62345-950b-4d27-b568-9ce087f3c79f"),
                            ClientId = new Guid("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                            CoachId = new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                            GymId = 1,
                            SessionDate = new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionStatusId = 6
                        },
                        new
                        {
                            Id = new Guid("d4f65555-950b-4d27-b231-9ce087f3c79f"),
                            ClientId = new Guid("d4f65555-950b-4d27-b568-9ce087f3c22f"),
                            CoachId = new Guid("d4e61167-950b-4d87-b568-9ce087f3c79f"),
                            GymId = 1,
                            SessionDate = new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionStatusId = 7
                        });
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.SessionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("SessionStatuses");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Name = "awaiting"
                        },
                        new
                        {
                            Id = 5,
                            Name = "accepted"
                        },
                        new
                        {
                            Id = 6,
                            Name = "inProcess"
                        },
                        new
                        {
                            Id = 7,
                            Name = "completed"
                        });
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4e65555-950b-4d87-b568-9ce087f3c79f"),
                            Email = "nazar.sachuk@gmail.com",
                            FirstName = "Nazar",
                            LastName = "Sachuk",
                            MiddleName = "Igorovych",
                            Password = "loremIpsum123",
                            PhoneNumber = "0509781078",
                            RegDate = new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9270),
                            RoleId = 3
                        },
                        new
                        {
                            Id = new Guid("d4e69655-950b-4d87-b555-9ce087f3c79f"),
                            Email = "default.coach@gmail.com",
                            FirstName = "Default",
                            LastName = "Coach",
                            MiddleName = "lorem",
                            Password = "loremIpsum123",
                            PhoneNumber = "0509781078",
                            RegDate = new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9306),
                            RoleId = 2
                        },
                        new
                        {
                            Id = new Guid("d4e65555-950b-4d87-b568-9ce087f34698"),
                            Email = "nazar.sachuk@gmail2.com",
                            FirstName = "Nazar2",
                            LastName = "Sachuk2",
                            MiddleName = "Igorovych2",
                            Password = "loremIpsum123",
                            PhoneNumber = "0509781078",
                            RegDate = new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9310),
                            RoleId = 3
                        },
                        new
                        {
                            Id = new Guid("d4e96455-950b-4d87-b568-9ce087f34698"),
                            Email = "nazar.sachuk@gmail3.com",
                            FirstName = "Nazar3",
                            LastName = "Sachuk3",
                            MiddleName = "Igorovych3",
                            Password = "loremIpsum123",
                            PhoneNumber = "0509781078",
                            RegDate = new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9312),
                            RoleId = 3
                        },
                        new
                        {
                            Id = new Guid("d4119255-950b-4d87-b568-9ce087f34698"),
                            Email = "max.smirnov@gmail.com",
                            FirstName = "Max",
                            LastName = "Smirnov",
                            MiddleName = "lorem",
                            Password = "loremIpsum123",
                            PhoneNumber = "0509781078",
                            RegDate = new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9316),
                            RoleId = 2
                        },
                        new
                        {
                            Id = new Guid("d4119255-950b-4d87-f432-9ce087f34698"),
                            Email = "masha.lorem@gmail.com",
                            FirstName = "Masha",
                            LastName = "lorem",
                            MiddleName = "lorem",
                            Password = "loremIpsum123",
                            PhoneNumber = "0509781078",
                            RegDate = new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9319),
                            RoleId = 1
                        },
                        new
                        {
                            Id = new Guid("d4119255-950b-4d87-f432-9ce087f39925"),
                            Email = "pasha.mamchur@gmail.com",
                            FirstName = "Pasha",
                            LastName = "Mamchur",
                            MiddleName = "Olexandrovych",
                            Password = "loremIpsum123",
                            PhoneNumber = "0509781078",
                            RegDate = new DateTime(2023, 5, 19, 18, 56, 17, 932, DateTimeKind.Local).AddTicks(9325),
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Admin", b =>
                {
                    b.HasOne("Oseredok.Domain.Entities.Gym", "Gym")
                        .WithMany()
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oseredok.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Client", b =>
                {
                    b.HasOne("Oseredok.Domain.Entities.ClientPayment", "ClientPayment")
                        .WithMany()
                        .HasForeignKey("ClientPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oseredok.Domain.Entities.Coach", "Coach")
                        .WithMany("Clients")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oseredok.Domain.Entities.Gym", "Gym")
                        .WithMany("Clients")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Oseredok.Domain.Entities.User", "User")
                        .WithOne("Client")
                        .HasForeignKey("Oseredok.Domain.Entities.Client", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClientPayment");

                    b.Navigation("Coach");

                    b.Navigation("Gym");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Coach", b =>
                {
                    b.HasOne("Oseredok.Domain.Entities.Gym", "Gym")
                        .WithMany("Coaches")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oseredok.Domain.Entities.User", "User")
                        .WithOne("Coach")
                        .HasForeignKey("Oseredok.Domain.Entities.Coach", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Gym");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Session", b =>
                {
                    b.HasOne("Oseredok.Domain.Entities.Client", "Client")
                        .WithMany("Sessions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Oseredok.Domain.Entities.Coach", "Coach")
                        .WithMany("Sessions")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Oseredok.Domain.Entities.Gym", "Gym")
                        .WithMany("Sessions")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Oseredok.Domain.Entities.SessionStatus", "SessionStatus")
                        .WithMany()
                        .HasForeignKey("SessionStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Coach");

                    b.Navigation("Gym");

                    b.Navigation("SessionStatus");
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.User", b =>
                {
                    b.HasOne("Oseredok.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Client", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Coach", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.Gym", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Coaches");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Oseredok.Domain.Entities.User", b =>
                {
                    b.Navigation("Client")
                        .IsRequired();

                    b.Navigation("Coach")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
