﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayrollDAL;

namespace PayrollDAL.Migrations
{
    [DbContext(typeof(PayrollContext))]
    [Migration("20210514125645_Add DB")]
    partial class AddDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PayrollDAL.ModelsDAL.LoadedFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("LoadFile")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PayrollId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PayrollId")
                        .IsUnique();

                    b.ToTable("LoadedFile");
                });

            modelBuilder.Entity("PayrollDAL.ModelsDAL.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PayrollId")
                        .HasColumnType("int");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Summ")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("PayrollId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PayrollDAL.ModelsDAL.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "Начислено"
                        },
                        new
                        {
                            Id = 2,
                            TypeName = "Удержано"
                        },
                        new
                        {
                            Id = 3,
                            TypeName = "Натуральных доходов"
                        },
                        new
                        {
                            Id = 4,
                            TypeName = "Выплачено"
                        });
                });

            modelBuilder.Entity("PayrollDAL.ModelsDAL.Payroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Accrued")
                        .HasColumnType("float");

                    b.Property<double>("Natural")
                        .HasColumnType("float");

                    b.Property<double>("Paid")
                        .HasColumnType("float");

                    b.Property<DateTime>("Period")
                        .HasColumnType("datetime2");

                    b.Property<double>("Withheld")
                        .HasColumnType("float");

                    b.Property<string>("Worker")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payrolls");
                });

            modelBuilder.Entity("PayrollDAL.ModelsDAL.LoadedFile", b =>
                {
                    b.HasOne("PayrollDAL.ModelsDAL.Payroll", "Payroll")
                        .WithOne("File")
                        .HasForeignKey("PayrollDAL.ModelsDAL.LoadedFile", "PayrollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payroll");
                });

            modelBuilder.Entity("PayrollDAL.ModelsDAL.Payment", b =>
                {
                    b.HasOne("PayrollDAL.ModelsDAL.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayrollDAL.ModelsDAL.Payroll", "Payroll")
                        .WithMany("Payments")
                        .HasForeignKey("PayrollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentType");

                    b.Navigation("Payroll");
                });

            modelBuilder.Entity("PayrollDAL.ModelsDAL.Payroll", b =>
                {
                    b.Navigation("File");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
