﻿// <auto-generated />
using System;
using BookAservices.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookAservices.Persistence.Migrations
{
    [DbContext(typeof(ServicesDbContext))]
    [Migration("20241227143252_S5")]
    partial class S5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookAservices.Domain.DifferenceData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DifferencesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServiceRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DifferencesId");

                    b.HasIndex("ServiceRequestId");

                    b.ToTable("DifferenceDatas");
                });

            modelBuilder.Entity("BookAservices.Domain.Differences", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeData")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Differences");
                });

            modelBuilder.Entity("BookAservices.Domain.OptionsDifference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifferencesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("OptionsDifferences");
                });

            modelBuilder.Entity("BookAservices.Domain.OptionsDifferenceData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DifferenceDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OptionsDifferenceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DifferenceDataId");

                    b.HasIndex("OptionsDifferenceId");

                    b.ToTable("OptionsDifferenceDatas");
                });

            modelBuilder.Entity("BookAservices.Domain.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServiceRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ServiceRequestId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("BookAservices.Domain.OrderDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BookAservices.Domain.ServiceRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("serviceRequests");
                });

            modelBuilder.Entity("BookAservices.Domain.Services", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("BookAservices.Domain.DifferenceData", b =>
                {
                    b.HasOne("BookAservices.Domain.Differences", "Differences")
                        .WithMany("DifferenceDatas")
                        .HasForeignKey("DifferencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookAservices.Domain.ServiceRequest", "ServiceRequest")
                        .WithMany()
                        .HasForeignKey("ServiceRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Differences");

                    b.Navigation("ServiceRequest");
                });

            modelBuilder.Entity("BookAservices.Domain.OptionsDifferenceData", b =>
                {
                    b.HasOne("BookAservices.Domain.DifferenceData", "DifferenceData")
                        .WithMany()
                        .HasForeignKey("DifferenceDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookAservices.Domain.OptionsDifference", "OptionsDifference")
                        .WithMany("optionsDifferenceDatas")
                        .HasForeignKey("OptionsDifferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DifferenceData");

                    b.Navigation("OptionsDifference");
                });

            modelBuilder.Entity("BookAservices.Domain.Order", b =>
                {
                    b.HasOne("BookAservices.Domain.ServiceRequest", "ServiceRequest")
                        .WithMany()
                        .HasForeignKey("ServiceRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceRequest");
                });

            modelBuilder.Entity("BookAservices.Domain.OrderDetails", b =>
                {
                    b.HasOne("BookAservices.Domain.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookAservices.Domain.Services", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BookAservices.Domain.Differences", b =>
                {
                    b.Navigation("DifferenceDatas");
                });

            modelBuilder.Entity("BookAservices.Domain.OptionsDifference", b =>
                {
                    b.Navigation("optionsDifferenceDatas");
                });

            modelBuilder.Entity("BookAservices.Domain.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
