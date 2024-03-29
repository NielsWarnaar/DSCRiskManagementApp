﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiskManagementAPI.DBContext;

#nullable disable

namespace RiskManagementAPI.Migrations
{
    [DbContext(typeof(RiskDbContext))]
    partial class RiskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NormRisk", b =>
                {
                    b.Property<int>("NormRiskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NormRiskId"));

                    b.Property<int>("NormId")
                        .HasColumnType("int");

                    b.Property<int>("RiskId")
                        .HasColumnType("int");

                    b.HasKey("NormRiskId");

                    b.HasIndex("NormId");

                    b.HasIndex("RiskId");

                    b.ToTable("NormRisk");
                });

            modelBuilder.Entity("RiskManagementAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categorydescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RiskManagementAPI.Models.Control", b =>
                {
                    b.Property<int>("ControlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ControlId"));

                    b.Property<string>("ControlDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControlName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControlType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RiskId")
                        .HasColumnType("int");

                    b.HasKey("ControlId");

                    b.HasIndex("RiskId");

                    b.ToTable("Controls");
                });

            modelBuilder.Entity("RiskManagementAPI.Models.Norm", b =>
                {
                    b.Property<int>("NormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NormId"));

                    b.Property<string>("NormDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RiskId")
                        .HasColumnType("int");

                    b.HasKey("NormId");

                    b.ToTable("Norms");
                });

            modelBuilder.Entity("RiskManagementAPI.Models.Risk", b =>
                {
                    b.Property<int>("RiskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RiskId"));

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImpactValueControlled")
                        .HasColumnType("int");

                    b.Property<int>("ImpactValueInherent")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NormId")
                        .HasColumnType("int");

                    b.Property<string>("OutstandingActions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProbabilityValueControlled")
                        .HasColumnType("int");

                    b.Property<int>("ProbabilityValueInherent")
                        .HasColumnType("int");

                    b.Property<string>("RiskName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RiskValueControlled")
                        .HasColumnType("int");

                    b.Property<int>("RiskValueInherent")
                        .HasColumnType("int");

                    b.HasKey("RiskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Risks");
                });

            modelBuilder.Entity("RiskManagementAPI.Models.RiskHistory", b =>
                {
                    b.Property<int>("RiskHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RiskHistoryId"));

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HistoryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImpactValueControlled")
                        .HasColumnType("int");

                    b.Property<int>("ImpactValueInherent")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("OutstandingActions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProbabilityValueControlled")
                        .HasColumnType("int");

                    b.Property<int>("ProbabilityValueInherent")
                        .HasColumnType("int");

                    b.Property<int>("RiskId")
                        .HasColumnType("int");

                    b.Property<string>("RiskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RiskValueControlled")
                        .HasColumnType("int");

                    b.Property<int>("RiskValueInherent")
                        .HasColumnType("int");

                    b.HasKey("RiskHistoryId");

                    b.ToTable("RiskHistories");
                });

            modelBuilder.Entity("NormRisk", b =>
                {
                    b.HasOne("RiskManagementAPI.Models.Norm", null)
                        .WithMany()
                        .HasForeignKey("NormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RiskManagementAPI.Models.Risk", null)
                        .WithMany()
                        .HasForeignKey("RiskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RiskManagementAPI.Models.Control", b =>
                {
                    b.HasOne("RiskManagementAPI.Models.Risk", "Risk")
                        .WithMany("Controls")
                        .HasForeignKey("RiskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Risk");
                });

            modelBuilder.Entity("RiskManagementAPI.Models.Risk", b =>
                {
                    b.HasOne("RiskManagementAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RiskManagementAPI.Models.Risk", b =>
                {
                    b.Navigation("Controls");
                });
#pragma warning restore 612, 618
        }
    }
}
