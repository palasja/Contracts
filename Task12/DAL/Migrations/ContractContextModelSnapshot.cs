﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ContractContext))]
    partial class ContractContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.ModelsDAL.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SimpleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Smdo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UNP")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("UNP")
                        .IsUnique();

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Serivces.ServiceHardware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("ServerCount")
                        .HasColumnType("int");

                    b.Property<int>("ServiceInfoId")
                        .HasColumnType("int");

                    b.Property<int>("WorkplaceCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("ServiceInfoId");

                    b.ToTable("ServiceHardwares");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Serivces.ServiceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AdditionalCost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MainCost")
                        .HasColumnType("float");

                    b.Property<double>("More5Cost")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdditionalCost = 19.800000000000001,
                            Description = "Консультации, удалённая поддержка. При необходимости выезд к клиенту",
                            MainCost = 39.600000000000001,
                            More5Cost = 14.76,
                            Name = "Обслуживание КлиентТК"
                        },
                        new
                        {
                            Id = 2,
                            AdditionalCost = 19.800000000000001,
                            Description = "Консультации, удалённая поддержка. При необходимости выезд к клиенту.",
                            MainCost = 39.600000000000001,
                            More5Cost = 14.76,
                            Name = "Обслуживание ГРС"
                        },
                        new
                        {
                            Id = 3,
                            AdditionalCost = 52.799999999999997,
                            Description = "Обслуживание техники. Ежемесечная проверка с диагностикой на месте эксплуатации.",
                            MainCost = 24.0,
                            More5Cost = 0.0,
                            Name = "Сопровождение вычислительно техники"
                        },
                        new
                        {
                            Id = 4,
                            AdditionalCost = 14.4,
                            Description = "Удалённое бслуживание техники без выезда на место",
                            MainCost = 19.199999999999999,
                            More5Cost = 0.0,
                            Name = "Удалённое сопровождение вычислительно техники"
                        },
                        new
                        {
                            Id = 5,
                            AdditionalCost = 21.48,
                            Description = "Удалённая установка. При необходимости выезд к клиенту и установка на месте.",
                            MainCost = 50.399999999999999,
                            More5Cost = 0.0,
                            Name = "Установка ГРС"
                        });
                });

            modelBuilder.Entity("DAL.ModelsDAL.Serivces.ServiceSoftware", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdditionalPlaceCount")
                        .HasColumnType("int");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("MainPlaceCount")
                        .HasColumnType("int");

                    b.Property<int>("ServiceInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("ServiceInfoId");

                    b.ToTable("ServiceSoftwares");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Contract", b =>
                {
                    b.HasOne("DAL.ModelsDAL.Organization", "Organization")
                        .WithMany("Contracts")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Organization", b =>
                {
                    b.HasOne("DAL.ModelsDAL.Area", "Area")
                        .WithMany("Organizations")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Person", b =>
                {
                    b.HasOne("DAL.ModelsDAL.Organization", "Organization")
                        .WithMany("People")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Serivces.ServiceHardware", b =>
                {
                    b.HasOne("DAL.ModelsDAL.Contract", "Contract")
                        .WithMany("ServicesHardware")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.ModelsDAL.Serivces.ServiceInfo", "ServiceInfo")
                        .WithMany()
                        .HasForeignKey("ServiceInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("ServiceInfo");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Serivces.ServiceSoftware", b =>
                {
                    b.HasOne("DAL.ModelsDAL.Contract", "Contract")
                        .WithMany("ServicesSoftware")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.ModelsDAL.Serivces.ServiceInfo", "ServiceInfo")
                        .WithMany()
                        .HasForeignKey("ServiceInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("ServiceInfo");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Area", b =>
                {
                    b.Navigation("Organizations");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Contract", b =>
                {
                    b.Navigation("ServicesHardware");

                    b.Navigation("ServicesSoftware");
                });

            modelBuilder.Entity("DAL.ModelsDAL.Organization", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
