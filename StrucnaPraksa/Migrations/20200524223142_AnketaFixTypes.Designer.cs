﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StrucnaPraksa.Models;

namespace StrucnaPraksa.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200524223142_AnketaFixTypes")]
    partial class AnketaFixTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StrucnaPraksa.Entities.Anketa", b =>
                {
                    b.Property<string>("IdAnkete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cetvrto")
                        .HasColumnType("int");

                    b.Property<string>("Deseto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesetoKomentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Deveto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Drugo")
                        .HasColumnType("int");

                    b.Property<string>("Dvanaesto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Godina")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdUsera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jedanaesto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Osmo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Peto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prvo")
                        .HasColumnType("int");

                    b.Property<string>("Sedmo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SedmoKomentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sesto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trece")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAnkete");

                    b.ToTable("Ankete");
                });

            modelBuilder.Entity("StrucnaPraksa.Entities.Dnevnik", b =>
                {
                    b.Property<string>("IdDnevnika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Godina")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdUsera")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDnevnika");

                    b.ToTable("Dnevnici");
                });

            modelBuilder.Entity("StrucnaPraksa.Entities.Izvjesce", b =>
                {
                    b.Property<string>("IdIzvjesca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Godina")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdUsera")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIzvjesca");

                    b.ToTable("Izvjesca");
                });

            modelBuilder.Entity("StrucnaPraksa.Entities.OsnovniPodaci", b =>
                {
                    b.Property<string>("IdPodataka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUsera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivMentora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poduzece")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Termin")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPodataka");

                    b.ToTable("OsnovniPodaci");
                });

            modelBuilder.Entity("StrucnaPraksa.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin",
                            Role = "Admin",
                            Username = "fabijan"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
