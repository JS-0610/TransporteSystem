﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranporteSistem.Models;

#nullable disable

namespace TranporteSistem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230418192715_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TranporteSistem.Models.Colaborador", b =>
                {
                    b.Property<int>("Colaborador_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Colaborador_Id"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Colaborador_Id");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("TranporteSistem.Models.Sucursal", b =>
                {
                    b.Property<int>("Sucursal_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sucursal_Id"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sucursal_Id");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("TranporteSistem.Models.SucursalColaborador", b =>
                {
                    b.Property<int>("SucursalColaborador_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SucursalColaborador_Id"));

                    b.Property<int>("Colaborador_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Colaborador_Id1")
                        .HasColumnType("int");

                    b.Property<double>("Distancia")
                        .HasColumnType("float");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("Sucursal_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Sucursal_Id1")
                        .HasColumnType("int");

                    b.HasKey("SucursalColaborador_Id");

                    b.HasIndex("Colaborador_Id1");

                    b.HasIndex("Sucursal_Id1");

                    b.ToTable("SucursalColaborador");
                });

            modelBuilder.Entity("TranporteSistem.Models.Transportista", b =>
                {
                    b.Property<int>("Transportista_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Transportista_Id"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Transportista_Id");

                    b.ToTable("Transportista");
                });

            modelBuilder.Entity("TranporteSistem.Models.Viaje", b =>
                {
                    b.Property<int>("Viaje_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Viaje_Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Sucursal_Id")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int>("Transportista_Id")
                        .HasColumnType("int");

                    b.HasKey("Viaje_Id");

                    b.ToTable("Viaje");
                });

            modelBuilder.Entity("TranporteSistem.Models.ViajeDetalle", b =>
                {
                    b.Property<int>("ViajeDetalle_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ViajeDetalle_Id"));

                    b.Property<int>("SucursalColaborador_Id")
                        .HasColumnType("int");

                    b.Property<int>("Viaje_Id")
                        .HasColumnType("int");

                    b.HasKey("ViajeDetalle_Id");

                    b.ToTable("ViajeDetalle");
                });

            modelBuilder.Entity("TranporteSistem.Models.SucursalColaborador", b =>
                {
                    b.HasOne("TranporteSistem.Models.Colaborador", "Colaborador")
                        .WithMany("SucursalColaborador")
                        .HasForeignKey("Colaborador_Id1");

                    b.HasOne("TranporteSistem.Models.Sucursal", "Sucursal")
                        .WithMany("SucursalColaborador")
                        .HasForeignKey("Sucursal_Id1");

                    b.Navigation("Colaborador");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("TranporteSistem.Models.Colaborador", b =>
                {
                    b.Navigation("SucursalColaborador");
                });

            modelBuilder.Entity("TranporteSistem.Models.Sucursal", b =>
                {
                    b.Navigation("SucursalColaborador");
                });
#pragma warning restore 612, 618
        }
    }
}