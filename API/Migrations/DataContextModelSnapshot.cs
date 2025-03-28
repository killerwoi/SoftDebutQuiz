﻿// <auto-generated />
using System;
using API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("PositionNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("PositionNo");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Salary");

                    b.HasKey("EmpNum");

                    b.HasIndex("DepNo");

                    b.HasIndex("PositionNo");

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

            modelBuilder.Entity("API.Model.DB.Position", b =>
                {
                    b.Property<string>("PositionNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("PositionNo");

                    b.Property<string>("PositionName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("PositionName");

                    b.HasKey("PositionNo");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("API.Model.DB.Employee", b =>
                {
                    b.HasOne("API.Model.DB.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepNo");

                    b.HasOne("API.Model.DB.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionNo");

                    b.Navigation("Department");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("API.Model.DB.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("API.Model.DB.Position", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
