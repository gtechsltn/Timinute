﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Timinute.Server.Data;

#nullable disable

namespace Timinute.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("bit");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Timinute.Server.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset?>("LastLoginDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "86ca07cf-3b9e-4495-8fe3-56cd9bf1cfc8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f1bbce0f-d94d-4e3e-ae1d-07a42b9b8c78",
                            Email = "test1@email.com",
                            EmailConfirmed = true,
                            FirstName = "Jan",
                            LastName = "Testovic",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEDgV3QGcSGxXfgIEFYvljstwmQb05lu59FQY/6H4R7SLAZkYc2uJCmNyio51dtfuGg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2d9dad18-a34e-4d2f-8336-babb25fb201b",
                            TwoFactorEnabled = false,
                            UserName = "test1@email.com"
                        },
                        new
                        {
                            Id = "b24dc9b2-81f4-4e30-99d8-105acb901a26",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "25686410-f2e8-43ad-afd2-f510abbeb8ee",
                            Email = "test2@email.com",
                            EmailConfirmed = true,
                            FirstName = "Ivana",
                            LastName = "Maricenkova",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEDgV3QGcSGxXfgIEFYvljstwmQb05lu59FQY/6H4R7SLAZkYc2uJCmNyio51dtfuGg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9ae05c28-9cf6-40c0-b087-3b7e8785473c",
                            TwoFactorEnabled = false,
                            UserName = "test2@email.com"
                        },
                        new
                        {
                            Id = "eb3a885f-44e4-45b0-a1bd-bcf84a104f81",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4910f5cb-605d-4b1e-bc96-803c23088dfc",
                            Email = "test3@email.com",
                            EmailConfirmed = true,
                            FirstName = "Marek",
                            LastName = "Klukac",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEDgV3QGcSGxXfgIEFYvljstwmQb05lu59FQY/6H4R7SLAZkYc2uJCmNyio51dtfuGg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e3bd3f0b-3045-4767-a56b-6e8419fd38d4",
                            TwoFactorEnabled = false,
                            UserName = "test3@email.com"
                        });
                });

            modelBuilder.Entity("Timinute.Server.Models.Project", b =>
                {
                    b.Property<string>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Timinute.Server.Models.TrackedTask", b =>
                {
                    b.Property<string>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TaskId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("TrackedTasks");

                    b.HasData(
                        new
                        {
                            TaskId = "7fde90dd-b420-4c0a-a401-8340fda67776",
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            EndDate = new DateTime(2022, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Project A",
                            StartDate = new DateTime(2022, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "86ca07cf-3b9e-4495-8fe3-56cd9bf1cfc8"
                        },
                        new
                        {
                            TaskId = "53021ea4-3be2-481a-a7e0-5e3eebc09585",
                            Duration = new TimeSpan(0, 3, 0, 0, 0),
                            EndDate = new DateTime(2022, 2, 2, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Project B",
                            StartDate = new DateTime(2022, 2, 2, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "86ca07cf-3b9e-4495-8fe3-56cd9bf1cfc8"
                        },
                        new
                        {
                            TaskId = "67471fb3-0807-45ad-9f88-1d8b501c8037",
                            Duration = new TimeSpan(0, 4, 0, 0, 0),
                            EndDate = new DateTime(2022, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Project C",
                            StartDate = new DateTime(2022, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "86ca07cf-3b9e-4495-8fe3-56cd9bf1cfc8"
                        },
                        new
                        {
                            TaskId = "d7c5687b-0484-4034-b6c5-1df560133b3e",
                            Duration = new TimeSpan(0, 5, 0, 0, 0),
                            EndDate = new DateTime(2022, 2, 2, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Project D",
                            StartDate = new DateTime(2022, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "b24dc9b2-81f4-4e30-99d8-105acb901a26"
                        },
                        new
                        {
                            TaskId = "74bb1b68-fc67-454f-9b11-0e960681cafd",
                            Duration = new TimeSpan(0, 6, 0, 0, 0),
                            EndDate = new DateTime(2022, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Project E",
                            StartDate = new DateTime(2022, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "b24dc9b2-81f4-4e30-99d8-105acb901a26"
                        },
                        new
                        {
                            TaskId = "33e4a47e-e2cb-48c4-8070-f114939202ec",
                            Duration = new TimeSpan(0, 7, 0, 0, 0),
                            EndDate = new DateTime(2022, 2, 2, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Project F",
                            StartDate = new DateTime(2022, 2, 2, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "eb3a885f-44e4-45b0-a1bd-bcf84a104f81"
                        },
                        new
                        {
                            TaskId = "028fe42c-b77f-487f-9b0b-d99db2a1304a",
                            Duration = new TimeSpan(0, 7, 0, 0, 0),
                            EndDate = new DateTime(2022, 2, 2, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Project G",
                            StartDate = new DateTime(2022, 2, 2, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "eb3a885f-44e4-45b0-a1bd-bcf84a104f81"
                        });
                });

            modelBuilder.Entity("Timinute.Server.Models.ApplicationRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationRole");

                    b.HasData(
                        new
                        {
                            Id = "2fc3b348-3432-41b7-a3eb-d22150f3859e",
                            ConcurrencyStamp = "d4215cfe-ffaa-466f-a36f-06bf6c7bc54d",
                            Name = "Basic",
                            NormalizedName = "BASIC",
                            Description = "Basic role with lowest rights."
                        },
                        new
                        {
                            Id = "84d5a5ce-d485-4ebc-9bd2-f10f8cef809b",
                            ConcurrencyStamp = "4760ab97-d6f4-443c-85da-eabdada6e725",
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            Description = "Admin role with highest rights."
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Timinute.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Timinute.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Timinute.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Timinute.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Timinute.Server.Models.TrackedTask", b =>
                {
                    b.HasOne("Timinute.Server.Models.Project", "Project")
                        .WithMany("TrackedTasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Timinute.Server.Models.ApplicationUser", "User")
                        .WithMany("TrackedTasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Timinute.Server.Models.ApplicationUser", b =>
                {
                    b.Navigation("TrackedTasks");
                });

            modelBuilder.Entity("Timinute.Server.Models.Project", b =>
                {
                    b.Navigation("TrackedTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
