﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using movie_tracker.Models;

namespace movie_tracker.Migrations
{
    [DbContext(typeof(MovieDataContext))]
    [Migration("20201102163544_release_year")]
    partial class release_year
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("movie_tracker.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateSeen")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateSeen = new DateTime(2019, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genre = "Action",
                            Rating = 9,
                            Title = "Avengers: Endgame"
                        },
                        new
                        {
                            Id = 2,
                            DateSeen = new DateTime(2018, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 8,
                            Title = "Incredibles 2"
                        },
                        new
                        {
                            Id = 3,
                            Genre = "Drama",
                            Title = "Dunkirk"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
