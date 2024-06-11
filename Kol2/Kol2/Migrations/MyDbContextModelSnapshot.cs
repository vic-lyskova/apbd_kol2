﻿// <auto-generated />
using System;
using Kol2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kol2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kol2.Models.Backpack", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("backpacks");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            ItemId = 1,
                            Amount = 10
                        },
                        new
                        {
                            CharacterId = 2,
                            ItemId = 2,
                            Amount = 20
                        },
                        new
                        {
                            CharacterId = 3,
                            ItemId = 3,
                            Amount = 30
                        });
                });

            modelBuilder.Entity("Kol2.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentWeight = 10,
                            FirstName = "FirstName1",
                            LastName = "LastName1",
                            MaxWeight = 100
                        },
                        new
                        {
                            Id = 2,
                            CurrentWeight = 20,
                            FirstName = "FirstName2",
                            LastName = "LastName2",
                            MaxWeight = 200
                        },
                        new
                        {
                            Id = 3,
                            CurrentWeight = 30,
                            FirstName = "FirstName3",
                            LastName = "LastName3",
                            MaxWeight = 300
                        });
                });

            modelBuilder.Entity("Kol2.Models.CharacterTitle", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CharacterId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("character_titles");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AcquiredAt = new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterId = 2,
                            TitleId = 2,
                            AcquiredAt = new DateTime(1909, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterId = 3,
                            TitleId = 3,
                            AcquiredAt = new DateTime(1000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Kol2.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Name1",
                            Weight = 10
                        },
                        new
                        {
                            Id = 2,
                            Name = "Name2",
                            Weight = 20
                        },
                        new
                        {
                            Id = 3,
                            Name = "Name3",
                            Weight = 30
                        });
                });

            modelBuilder.Entity("Kol2.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("titles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Name1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Name2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Name3"
                        });
                });

            modelBuilder.Entity("Kol2.Models.Backpack", b =>
                {
                    b.HasOne("Kol2.Models.Character", "Character")
                        .WithMany("Backpacks")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kol2.Models.Item", "Item")
                        .WithMany("Backpacks")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Kol2.Models.CharacterTitle", b =>
                {
                    b.HasOne("Kol2.Models.Character", "Character")
                        .WithMany("CharactersTitles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kol2.Models.Title", "Title")
                        .WithMany("CharactersTitles")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Kol2.Models.Character", b =>
                {
                    b.Navigation("Backpacks");

                    b.Navigation("CharactersTitles");
                });

            modelBuilder.Entity("Kol2.Models.Item", b =>
                {
                    b.Navigation("Backpacks");
                });

            modelBuilder.Entity("Kol2.Models.Title", b =>
                {
                    b.Navigation("CharactersTitles");
                });
#pragma warning restore 612, 618
        }
    }
}