﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MovieApplication.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20240808065831_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Movie", b =>
                {
                    b.Property<int>("movieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("movieID"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reviewID")
                        .HasColumnType("int");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("movieID");

                    b.HasIndex("reviewID");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("Person", b =>
                {
                    b.Property<int>("personID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("personID"));

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("personID");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("Review", b =>
                {
                    b.Property<int>("reviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reviewID"));

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("reviewID");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleID"));

                    b.Property<int>("movieID")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("personID")
                        .HasColumnType("int");

                    b.HasKey("roleID");

                    b.HasIndex("movieID");

                    b.HasIndex("personID");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Movie", b =>
                {
                    b.HasOne("Review", "review")
                        .WithMany()
                        .HasForeignKey("reviewID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("review");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.HasOne("Movie", "movie")
                        .WithMany()
                        .HasForeignKey("movieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Person", "person")
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
