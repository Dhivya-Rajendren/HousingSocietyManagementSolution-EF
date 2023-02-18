﻿// <auto-generated />
using System;
using HousingSociety.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HousingSociety.Data.Migrations
{
    [DbContext(typeof(HousingSocietyDbContext))]
    [Migration("20230218095826_Initial Create transa")]
    partial class InitialCreatetransa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HousingSociety.Domain.Flat", b =>
                {
                    b.Property<int>("FlatNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlatNo"), 1L, 1);

                    b.Property<long?>("AAdhar")
                        .HasColumnType("bigint");

                    b.Property<long>("Contact")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Wing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlatNo");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("HousingSociety.Domain.Maintenance", b =>
                {
                    b.Property<int>("MaintenanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaintenanceId"), 1L, 1);

                    b.Property<string>("MaintenanceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaintenanceId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("HousingSociety.Domain.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<int>("FlatNo")
                        .HasColumnType("int");

                    b.Property<int>("FlatNo1")
                        .HasColumnType("int");

                    b.Property<int>("MaintenanceId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.HasIndex("FlatNo1");

                    b.HasIndex("MaintenanceId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("HousingSociety.Domain.Transaction", b =>
                {
                    b.HasOne("HousingSociety.Domain.Flat", "Flat")
                        .WithMany()
                        .HasForeignKey("FlatNo1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HousingSociety.Domain.Maintenance", "Maintenance")
                        .WithMany()
                        .HasForeignKey("MaintenanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flat");

                    b.Navigation("Maintenance");
                });
#pragma warning restore 612, 618
        }
    }
}