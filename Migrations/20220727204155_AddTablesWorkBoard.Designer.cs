﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkOrder.Context;

namespace WorkOrder.Migrations
{
    [DbContext(typeof(WorkDbContext))]
    [Migration("20220727204155_AddTablesWorkBoard")]
    partial class AddTablesWorkBoard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WorkOrder.Model.Address", b =>
                {
                    b.Property<string>("Pincode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandMark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineOne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pincode");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("WorkOrder.Model.Technician", b =>
                {
                    b.Property<string>("TechnicianId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");
                });

            modelBuilder.Entity("WorkOrder.Model.Work", b =>
                {
                    b.Property<string>("WorkOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddressPincode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("InterventionTime")
                        .HasColumnType("datetime2");

                    b.HasKey("WorkOrderId");

                    b.HasIndex("AddressPincode");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("WorkOrder.Model.WorkBoard", b =>
                {
                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsWorkDone")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWorkOrderActive")
                        .HasColumnType("bit");

                    b.Property<string>("TechnicianId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WorkId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("JobId");

                    b.HasIndex("TechnicianId");

                    b.HasIndex("WorkId");

                    b.ToTable("WorkBoards");
                });

            modelBuilder.Entity("WorkOrder.Model.Work", b =>
                {
                    b.HasOne("WorkOrder.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressPincode");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("WorkOrder.Model.WorkBoard", b =>
                {
                    b.HasOne("WorkOrder.Model.Technician", "Technician")
                        .WithMany("WorkBoardsTechnicainDetails")
                        .HasForeignKey("TechnicianId");

                    b.HasOne("WorkOrder.Model.Work", "Work")
                        .WithMany("WorkBoardsWorkDetails")
                        .HasForeignKey("WorkId");

                    b.Navigation("Technician");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("WorkOrder.Model.Technician", b =>
                {
                    b.Navigation("WorkBoardsTechnicainDetails");
                });

            modelBuilder.Entity("WorkOrder.Model.Work", b =>
                {
                    b.Navigation("WorkBoardsWorkDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
