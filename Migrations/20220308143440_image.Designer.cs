﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using go_blogs.Data;

namespace go_blogs.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220308143440_image")]
    partial class image
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("go_blogs.Models.Blog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("Username");

                    b.ToTable("Tb_Blog");
                });

            modelBuilder.Entity("go_blogs.Models.Roles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tb_Roles");
                });

            modelBuilder.Entity("go_blogs.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Username");

                    b.HasIndex("RolesId");

                    b.ToTable("Tb_User");
                });

            modelBuilder.Entity("go_blogs.Models.Blog", b =>
                {
                    b.HasOne("go_blogs.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.Navigation("User");
                });

            modelBuilder.Entity("go_blogs.Models.User", b =>
                {
                    b.HasOne("go_blogs.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}