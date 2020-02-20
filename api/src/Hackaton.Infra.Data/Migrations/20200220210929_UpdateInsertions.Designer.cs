﻿// <auto-generated />
using System;
using Hackaton.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200220210929_UpdateInsertions")]
    partial class UpdateInsertions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hackaton.Domain.Entities.Trail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateAt");

                    b.Property<string>("Description");

                    b.Property<int>("Reward");

                    b.Property<string>("Title");

                    b.Property<int>("TypeID");

                    b.Property<DateTime?>("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("TypeID");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("Hackaton.Domain.Entities.TrailType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("UpdateAt");

                    b.HasKey("Id");

                    b.ToTable("TrailType");

                    b.HasData(
                        new { Id = 1, CreateAt = new DateTime(2020, 2, 20, 18, 9, 28, 906, DateTimeKind.Local), Description = "Text" },
                        new { Id = 2, CreateAt = new DateTime(2020, 2, 20, 18, 9, 28, 907, DateTimeKind.Local), Description = "Video" },
                        new { Id = 3, CreateAt = new DateTime(2020, 2, 20, 18, 9, 28, 907, DateTimeKind.Local), Description = "Quiz" }
                    );
                });

            modelBuilder.Entity("Hackaton.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Coins")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("CreateAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("FullName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("TrailID");

                    b.Property<DateTime?>("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TrailID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hackaton.Domain.Entities.Trail", b =>
                {
                    b.HasOne("Hackaton.Domain.Entities.TrailType", "TrailType")
                        .WithMany("Trails")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hackaton.Domain.Entities.User", b =>
                {
                    b.HasOne("Hackaton.Domain.Entities.Trail", "Trail")
                        .WithMany("Users")
                        .HasForeignKey("TrailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
