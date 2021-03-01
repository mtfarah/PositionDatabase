﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PositionDatabase.Data;

namespace PositionDatabase.Migrations
{
    [DbContext(typeof(PositionDatabaseContext))]
    [Migration("20210212202808_mmmm")]
    partial class mmmm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PositionDatabase.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("PositionDatabase.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractType")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Position");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Position");
                });

            modelBuilder.Entity("PositionDatabase.Models.SalaryComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PersonId1")
                        .HasColumnType("int");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId1");

                    b.HasIndex("PositionId");

                    b.ToTable("SalaryComponent");

                    b.HasDiscriminator<string>("Discriminator").HasValue("SalaryComponent");
                });

            modelBuilder.Entity("PositionDatabase.Models.SalaryScale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("SalaryScale");
                });

            modelBuilder.Entity("PositionDatabase.Models.SalaryStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SalaryScaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaryScaleId");

                    b.ToTable("SalaryStep");
                });

            modelBuilder.Entity("PositionDatabase.Models.AcademicStaff", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.Position");

                    b.HasDiscriminator().HasValue("AcademicStaff");
                });

            modelBuilder.Entity("PositionDatabase.Models.AdministrativeStipend", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.SalaryComponent");

                    b.HasDiscriminator().HasValue("AdministrativeStipend");
                });

            modelBuilder.Entity("PositionDatabase.Models.BaseSalary", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.SalaryComponent");

                    b.HasDiscriminator().HasValue("BaseSalary");
                });

            modelBuilder.Entity("PositionDatabase.Models.MarketSupplement", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.SalaryComponent");

                    b.HasDiscriminator().HasValue("MarketSupplement");
                });

            modelBuilder.Entity("PositionDatabase.Models.APO", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.AcademicStaff");

                    b.HasDiscriminator().HasValue("APO");
                });

            modelBuilder.Entity("PositionDatabase.Models.ATS", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.AcademicStaff");

                    b.HasDiscriminator().HasValue("ATS");
                });

            modelBuilder.Entity("PositionDatabase.Models.FSO", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.AcademicStaff");

                    b.HasDiscriminator().HasValue("FSO");
                });

            modelBuilder.Entity("PositionDatabase.Models.Faculty", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.AcademicStaff");

                    b.HasDiscriminator().HasValue("Faculty");
                });

            modelBuilder.Entity("PositionDatabase.Models.Librarian", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.AcademicStaff");

                    b.HasDiscriminator().HasValue("Librarian");
                });

            modelBuilder.Entity("PositionDatabase.Models.TemporaryAPO", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.AcademicStaff");

                    b.HasDiscriminator().HasValue("TemporaryAPO");
                });

            modelBuilder.Entity("PositionDatabase.Models.TemporaryLibrarian", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.AcademicStaff");

                    b.HasDiscriminator().HasValue("TemporaryLibrarian");
                });

            modelBuilder.Entity("PositionDatabase.Models.TrustResearchAcademic", b =>
                {
                    b.HasBaseType("PositionDatabase.Models.AcademicStaff");

                    b.HasDiscriminator().HasValue("TrustResearchAcademic");
                });

            modelBuilder.Entity("PositionDatabase.Models.Position", b =>
                {
                    b.HasOne("PositionDatabase.Models.Person", "Person")
                        .WithMany("Positions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PositionDatabase.Models.SalaryComponent", b =>
                {
                    b.HasOne("PositionDatabase.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId1");

                    b.HasOne("PositionDatabase.Models.Position", null)
                        .WithMany("SalaryComponents")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("PositionDatabase.Models.SalaryScale", b =>
                {
                    b.HasOne("PositionDatabase.Models.Position", null)
                        .WithMany("SalaryScales")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("PositionDatabase.Models.SalaryStep", b =>
                {
                    b.HasOne("PositionDatabase.Models.SalaryScale", null)
                        .WithMany("SalarySteps")
                        .HasForeignKey("SalaryScaleId");
                });
#pragma warning restore 612, 618
        }
    }
}
