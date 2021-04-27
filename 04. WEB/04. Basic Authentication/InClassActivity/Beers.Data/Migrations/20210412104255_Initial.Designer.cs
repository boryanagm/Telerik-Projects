﻿// <auto-generated />
using Beers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Beers.Data.Migrations
{
    [DbContext(typeof(BeerDbContext))]
    [Migration("20210412104255_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Beers.Data.Models.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ABV")
                        .HasColumnType("float");

                    b.Property<int>("BreweryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BeerId");

                    b.HasIndex("BreweryId");

                    b.ToTable("Beers");

                    b.HasData(
                        new
                        {
                            BeerId = 1,
                            ABV = 0.0,
                            BreweryId = 1,
                            Name = "Pirinsko"
                        },
                        new
                        {
                            BeerId = 2,
                            ABV = 0.0,
                            BreweryId = 1,
                            Name = "Shumensko"
                        });
                });

            modelBuilder.Entity("Beers.Data.Models.Brewery", b =>
                {
                    b.Property<int>("BreweryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BreweryId");

                    b.ToTable("Breweries");

                    b.HasData(
                        new
                        {
                            BreweryId = 1,
                            Name = "Carlsberg"
                        });
                });

            modelBuilder.Entity("Beers.Data.Models.Rating", b =>
                {
                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("BeerId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            BeerId = 1,
                            UserId = 1,
                            Value = 5
                        },
                        new
                        {
                            BeerId = 2,
                            UserId = 1,
                            Value = 3
                        },
                        new
                        {
                            BeerId = 1,
                            UserId = 2,
                            Value = 1
                        },
                        new
                        {
                            BeerId = 2,
                            UserId = 2,
                            Value = 1
                        });
                });

            modelBuilder.Entity("Beers.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Gosho"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Pesho"
                        });
                });

            modelBuilder.Entity("Beers.Data.Models.Beer", b =>
                {
                    b.HasOne("Beers.Data.Models.Brewery", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brewery");
                });

            modelBuilder.Entity("Beers.Data.Models.Rating", b =>
                {
                    b.HasOne("Beers.Data.Models.Beer", "Beer")
                        .WithMany("Ratings")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Beers.Data.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Beers.Data.Models.Beer", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Beers.Data.Models.Brewery", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("Beers.Data.Models.User", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}