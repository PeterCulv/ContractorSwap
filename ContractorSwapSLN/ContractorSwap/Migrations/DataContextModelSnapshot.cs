﻿// <auto-generated />
using System;
using ContractorSwap.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContractorSwap.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContractorSwap.Models.ApplicationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Bid")
                        .HasColumnType("float");

                    b.Property<int>("JobListingId")
                        .HasColumnType("int");

                    b.Property<int?>("JobListingModelId")
                        .HasColumnType("int");

                    b.Property<int>("SeekerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobListingModelId");

                    b.ToTable("Applications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bid = 750.0,
                            JobListingId = 1,
                            SeekerId = 2
                        },
                        new
                        {
                            Id = 2,
                            Bid = 5800.0,
                            JobListingId = 2,
                            SeekerId = 1
                        });
                });

            modelBuilder.Entity("ContractorSwap.Models.ContractorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contractors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Grand Detour, Illinois",
                            Name = "John Deere",
                            Password = "deerebutstillgoated",
                            Specialties = "Landscaping",
                            UserName = "johndeere123"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Hartford, Connecticut",
                            Name = "Francis Charlery",
                            Password = "francis456",
                            Specialties = "Carpenrty",
                            UserName = "frantheman"
                        });
                });

            modelBuilder.Entity("ContractorSwap.Models.JobListingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AcceptedId")
                        .HasColumnType("int");

                    b.Property<int>("ContractorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcceptedId = 0,
                            ContractorId = 1,
                            Date = new DateTime(2019, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ceiling fan installation: Master Bedroom",
                            Location = "666 Elm Street, Aurora, IL",
                            Name = "Test Job"
                        },
                        new
                        {
                            Id = 2,
                            AcceptedId = 0,
                            ContractorId = 2,
                            Date = new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Install a hot tub for a Chihuaha",
                            Location = "1111 Hampton Hills Ct., Hamptons, CT",
                            Name = "Secondary Job"
                        });
                });

            modelBuilder.Entity("ContractorSwap.Models.ApplicationModel", b =>
                {
                    b.HasOne("ContractorSwap.Models.JobListingModel", null)
                        .WithMany("Applications")
                        .HasForeignKey("JobListingModelId");
                });

            modelBuilder.Entity("ContractorSwap.Models.JobListingModel", b =>
                {
                    b.HasOne("ContractorSwap.Models.ContractorModel", "Contractor")
                        .WithMany("JobListings")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("ContractorSwap.Models.ContractorModel", b =>
                {
                    b.Navigation("JobListings");
                });

            modelBuilder.Entity("ContractorSwap.Models.JobListingModel", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
