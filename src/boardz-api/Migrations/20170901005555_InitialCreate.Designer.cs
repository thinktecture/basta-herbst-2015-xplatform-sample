﻿// <auto-generated />
using BoardZ.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BoardZ.API.Migrations
{
    [DbContext(typeof(BoardZContext))]
    [Migration("20170901005555_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("boardz")
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoardZ.API.Models.AgeRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColorIndicator");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AgeRatings");
                });

            modelBuilder.Entity("BoardZ.API.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("UserName");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BoardZ.API.Models.Coordinate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("BoardZ.API.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AgeRatingId");

                    b.Property<string>("Description");

                    b.Property<string>("Edition");

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("AgeRatingId");

                    b.HasIndex("Name");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BoardZ.API.Models.GameCategory", b =>
                {
                    b.Property<Guid>("GameId");

                    b.Property<Guid>("CategoryId");

                    b.HasKey("GameId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("GamesCategories");
                });

            modelBuilder.Entity("BoardZ.API.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CoordinateId");

                    b.Property<Guid>("GameId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PlayingSince");

                    b.HasKey("Id");

                    b.HasIndex("CoordinateId");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BoardZ.API.Models.Game", b =>
                {
                    b.HasOne("BoardZ.API.Models.AgeRating", "AgeRating")
                        .WithMany("Games")
                        .HasForeignKey("AgeRatingId");
                });

            modelBuilder.Entity("BoardZ.API.Models.GameCategory", b =>
                {
                    b.HasOne("BoardZ.API.Models.Category", "Category")
                        .WithMany("GameCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoardZ.API.Models.Game", "Game")
                        .WithMany("GameCategories")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoardZ.API.Models.Player", b =>
                {
                    b.HasOne("BoardZ.API.Models.Coordinate", "Coordinate")
                        .WithMany()
                        .HasForeignKey("CoordinateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoardZ.API.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
