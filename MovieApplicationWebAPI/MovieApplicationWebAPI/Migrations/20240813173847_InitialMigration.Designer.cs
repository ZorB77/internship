﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApplicationWebAPI.Models;

#nullable disable

namespace MovieApplicationWebAPI.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20240813173847_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieApplicationWebAPI.Models.Distribution", b =>
                {
                    b.Property<int>("distributionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("distributionID"));

                    b.Property<string>("details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("distributionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<int>("studioID")
                        .HasColumnType("int");

                    b.HasKey("distributionID");

                    b.HasIndex("movieId");

                    b.HasIndex("studioID");

                    b.ToTable("distributions");
                });

            modelBuilder.Entity("MovieApplicationWebAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("MovieApplicationWebAPI.Models.Person", b =>
                {
                    b.Property<int>("personID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("personID"));

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("personID");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("MovieApplicationWebAPI.Models.Review", b =>
                {
                    b.Property<int>("reviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reviewID"));

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.HasKey("reviewID");

                    b.HasIndex("movieId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("MovieApplicationWebAPI.Models.Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleID"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("personID")
                        .HasColumnType("int");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.HasKey("roleID");

                    b.HasIndex("movieId");

                    b.HasIndex("personID");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("MovieApplicationWebAPI.Models.Studio", b =>
                {
                    b.Property<int>("studioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studioID"));

                    b.Property<int>("establishmentYear")
                        .HasColumnType("int");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("studioID");

                    b.ToTable("studios");
                });

            modelBuilder.Entity("MovieApplicationWebAPI.Models.Distribution", b =>
                {
                    b.HasOne("MovieApplicationWebAPI.Models.Movie", "movie")
                        .WithMany()
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApplicationWebAPI.Models.Studio", "studio")
                        .WithMany()
                        .HasForeignKey("studioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movie");

                    b.Navigation("studio");
                });

            modelBuilder.Entity("MovieApplicationWebAPI.Models.Review", b =>
                {
                    b.HasOne("MovieApplicationWebAPI.Models.Movie", "movie")
                        .WithMany()
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movie");
                });

            modelBuilder.Entity("MovieApplicationWebAPI.Models.Role", b =>
                {
                    b.HasOne("MovieApplicationWebAPI.Models.Movie", "movie")
                        .WithMany()
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApplicationWebAPI.Models.Person", "person")
                        .WithMany()
                        .HasForeignKey("personID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movie");

                    b.Navigation("person");
                });
#pragma warning restore 612, 618
        }
    }
}
