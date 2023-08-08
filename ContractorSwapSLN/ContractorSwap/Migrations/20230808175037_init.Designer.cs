﻿// <auto-generated />
using System;
using ContractorSwap.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContractorSwap.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230808175037_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("ContractorModelId")
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

                    b.Property<int>("PosterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractorModelId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ContractorSwap.Models.ApplicationModel", b =>
                {
                    b.HasOne("ContractorSwap.Models.JobListingModel", null)
                        .WithMany("Applications")
                        .HasForeignKey("JobListingModelId");
                });

            modelBuilder.Entity("ContractorSwap.Models.JobListingModel", b =>
                {
                    b.HasOne("ContractorSwap.Models.ContractorModel", null)
                        .WithMany("JobListings")
                        .HasForeignKey("ContractorModelId");
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
