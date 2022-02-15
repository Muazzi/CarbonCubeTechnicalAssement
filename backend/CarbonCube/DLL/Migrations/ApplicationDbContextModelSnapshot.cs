﻿// <auto-generated />
using System;
using DLL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DLL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DLL.Models.MedicalClaim", b =>
                {
                    b.Property<int>("MedicalClaimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diagnoses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ICDCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("MedicalClaimId");

                    b.ToTable("MedicalClaims");
                });

            modelBuilder.Entity("DLL.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalAidName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalAidNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MedicalClaimId")
                        .HasColumnType("int");

                    b.HasKey("PatientId");

                    b.HasIndex("MedicalClaimId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DLL.Models.Patient", b =>
                {
                    b.HasOne("DLL.Models.MedicalClaim", "MedicalClaim")
                        .WithMany("Patients")
                        .HasForeignKey("MedicalClaimId");

                    b.Navigation("MedicalClaim");
                });

            modelBuilder.Entity("DLL.Models.MedicalClaim", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
