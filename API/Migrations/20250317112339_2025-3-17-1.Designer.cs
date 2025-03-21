﻿// <auto-generated />
using System;
using API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250317112339_2025-3-17-1")]
    partial class _20253171
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Model.DB.Department", b =>
                {
                    b.Property<string>("DepNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("DepNo");

                    b.Property<string>("DepName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("DepName");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Location");

                    b.HasKey("DepNo");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("API.Model.DB.Employee", b =>
                {
                    b.Property<string>("EmpNum")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("EmpNum");

                    b.Property<string>("DepNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("DepNo");

                    b.Property<string>("EmpName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EmpName");

                    b.Property<string>("HeadNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("HeadNo");

                    b.Property<DateOnly?>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("HireDate");

                    b.Property<string>("Position")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Position");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Salary");

                    b.HasKey("EmpNum");

                    b.HasIndex("DepNo");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("API.Model.DB.EmployeeBackup", b =>
                {
                    b.Property<string>("EmpNum")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("EmpNum");

                    b.Property<string>("EmpName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EmpName");

                    b.Property<string>("Position")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Position");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Salary");

                    b.HasKey("EmpNum");

                    b.ToTable("EmployeeBackup");
                });

            modelBuilder.Entity("API.Model.DB.Employee", b =>
                {
                    b.HasOne("API.Model.DB.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepNo");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("API.Model.DB.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
