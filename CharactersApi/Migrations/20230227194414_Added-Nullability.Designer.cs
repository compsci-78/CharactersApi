﻿// <auto-generated />
using System;
using CharactersApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CharactersApi.Migrations
{
    [DbContext(typeof(CharactersDbContext))]
    [Migration("20230227194414_Added-Nullability")]
    partial class AddedNullability
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 1,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieId = 1
                        });
                });

            modelBuilder.Entity("CharactersApi.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Any",
                            Gender = "Male",
                            Name = "Character_A",
                            Picture = "http://puctureUrl.com"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Any",
                            Gender = "Female",
                            Name = "Character_B",
                            Picture = "http://puctureUrl.com"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Any",
                            Gender = "Female",
                            Name = "Character_C",
                            Picture = "http://puctureUrl.com"
                        });
                });

            modelBuilder.Entity("CharactersApi.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Any",
                            Name = "Franchies_A"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Any",
                            Name = "Franchies_B"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Any",
                            Name = "Franchies_C"
                        });
                });

            modelBuilder.Entity("CharactersApi.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Picture")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Year")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Someone",
                            FranchiseId = 1,
                            Genre = "Action",
                            Picture = "http://puctureUrl.com",
                            Title = "Movie_A",
                            Trailer = "http://videoProvider.com",
                            Year = "1999"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Someone",
                            FranchiseId = 1,
                            Genre = "Comedy",
                            Picture = "http://puctureUrl.com",
                            Title = "Movie_B",
                            Trailer = "http://videoProvider.com",
                            Year = "1999"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Someone",
                            FranchiseId = 2,
                            Genre = "Romantic",
                            Picture = "http://puctureUrl.com",
                            Title = "Movie_C",
                            Trailer = "http://videoProvider.com",
                            Year = "1999"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("CharactersApi.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CharactersApi.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharactersApi.Models.Movie", b =>
                {
                    b.HasOne("CharactersApi.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("CharactersApi.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
