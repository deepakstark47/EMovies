﻿// <auto-generated />
using System;
using EMovies.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EMovies.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EMovies.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActorId"), 1L, 1);

                    b.Property<string>("ActorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("EMovies.Models.Actor_Movie", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("Actors_Movies");
                });

            modelBuilder.Entity("EMovies.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EMovies.Models.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirectorId"), 1L, 1);

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DirectorId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("EMovies.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("MovieDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MoviePrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("EMovies.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EMovies.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("EMovies.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("MovieId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("EMovies.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartItemId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("MovieId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("EMovies.Models.Actor_Movie", b =>
                {
                    b.HasOne("EMovies.Models.Actor", "Actor")
                        .WithMany("Actors_Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMovies.Models.Movie", "Movie")
                        .WithMany("Actors_Movies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("EMovies.Models.Movie", b =>
                {
                    b.HasOne("EMovies.Models.Category", "Category")
                        .WithMany("movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMovies.Models.Director", "Director")
                        .WithMany("movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("EMovies.Models.OrderItem", b =>
                {
                    b.HasOne("EMovies.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMovies.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EMovies.Models.Review", b =>
                {
                    b.HasOne("EMovies.Models.Movie", "Movie")
                        .WithMany("reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("EMovies.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("EMovies.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("EMovies.Models.Actor", b =>
                {
                    b.Navigation("Actors_Movies");
                });

            modelBuilder.Entity("EMovies.Models.Category", b =>
                {
                    b.Navigation("movies");
                });

            modelBuilder.Entity("EMovies.Models.Director", b =>
                {
                    b.Navigation("movies");
                });

            modelBuilder.Entity("EMovies.Models.Movie", b =>
                {
                    b.Navigation("Actors_Movies");

                    b.Navigation("reviews");
                });

            modelBuilder.Entity("EMovies.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
