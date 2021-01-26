﻿// <auto-generated />
using System;
using FunTogether.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FunTogether.Migrations
{
    [DbContext(typeof(FunTogetherContext))]
    [Migration("20210125131726_AddFilterData")]
    partial class AddFilterData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FunTogether.Data.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LocationLatitude")
                        .HasColumnType("float");

                    b.Property<double>("LocationLongitude")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("FunTogether.Data.ActivityFilter", b =>
                {
                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("FilterId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId", "FilterId");

                    b.HasIndex("FilterId");

                    b.ToTable("ActivityFilters");
                });

            modelBuilder.Entity("FunTogether.Data.Filter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Filters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "AgeGroup",
                            Value = "18-23"
                        },
                        new
                        {
                            Id = 2,
                            Category = "AgeGroup",
                            Value = "24-29"
                        },
                        new
                        {
                            Id = 3,
                            Category = "AgeGroup",
                            Value = "30-39"
                        },
                        new
                        {
                            Id = 4,
                            Category = "AgeGroup",
                            Value = "40-49"
                        },
                        new
                        {
                            Id = 5,
                            Category = "AgeGroup",
                            Value = "50+"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Gender",
                            Value = "Female"
                        },
                        new
                        {
                            Id = 7,
                            Category = "Gender",
                            Value = "Male"
                        });
                });

            modelBuilder.Entity("FunTogether.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FunTogether.Data.UserActivity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHost")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.ToTable("UserActivities");
                });

            modelBuilder.Entity("FunTogether.Data.ActivityFilter", b =>
                {
                    b.HasOne("FunTogether.Data.Activity", "Activity")
                        .WithMany("ActivityFilters")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FunTogether.Data.Filter", "Filter")
                        .WithMany("ActivityFilters")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FunTogether.Data.UserActivity", b =>
                {
                    b.HasOne("FunTogether.Data.Activity", "Activity")
                        .WithMany("UserActivities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FunTogether.Data.User", "User")
                        .WithMany("UserActivities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}