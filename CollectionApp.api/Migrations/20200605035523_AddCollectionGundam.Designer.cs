﻿// <auto-generated />
using System;
using CollectionApp.api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CollectionApp.api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200605035523_AddCollectionGundam")]
    partial class AddCollectionGundam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("CollectionApp.api.Models.CollectionGundam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<string>("Grade")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModelName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Series")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CollectionGundams");
                });

            modelBuilder.Entity("CollectionApp.api.Models.CollectionGundamPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("collectionGundamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("collectionGundamId");

                    b.ToTable("CollectionGundamPhotos");
                });

            modelBuilder.Entity("CollectionApp.api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Introduction")
                        .HasColumnType("TEXT");

                    b.Property<string>("KnownAs")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CollectionApp.api.Models.UserPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPhotos");
                });

            modelBuilder.Entity("CollectionApp.api.Models.CollectionGundamPhoto", b =>
                {
                    b.HasOne("CollectionApp.api.Models.CollectionGundam", "collectionGundam")
                        .WithMany("Photos")
                        .HasForeignKey("collectionGundamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CollectionApp.api.Models.UserPhoto", b =>
                {
                    b.HasOne("CollectionApp.api.Models.User", "user")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
