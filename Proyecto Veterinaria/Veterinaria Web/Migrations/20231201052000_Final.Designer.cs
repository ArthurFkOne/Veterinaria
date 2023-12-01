﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veterinaria_Web.Context;

#nullable disable

namespace Veterinaria_Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231201052000_Final")]
    partial class Final
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.Articulo", b =>
                {
                    b.Property<int>("PKArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKArticulo"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UrlImagenPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PKArticulo");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.Citas", b =>
                {
                    b.Property<int>("PkCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkCita"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Servicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkCita");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.Factura", b =>
                {
                    b.Property<int>("PkFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkFactura"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Identificador")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkFactura");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.FacturaProducto", b =>
                {
                    b.Property<int>("PkArticulo")
                        .HasColumnType("int");

                    b.Property<int>("PkFactura")
                        .HasColumnType("int");

                    b.HasKey("PkArticulo", "PkFactura");

                    b.HasIndex("PkFactura");

                    b.ToTable("FacturaProducto");
                });

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.Promocion", b =>
                {
                    b.Property<int>("PKPromocion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKPromocion"));

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FkArticulo")
                        .HasColumnType("int");

                    b.Property<string>("UrlImagenPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PKPromocion");

                    b.HasIndex("FkArticulo");

                    b.ToTable("Promocion");
                });

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.Rol", b =>
                {
                    b.Property<int>("PkRoles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRoles"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRoles");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.FacturaProducto", b =>
                {
                    b.HasOne("Veterinaria_Web.Models.Entities.Articulo", null)
                        .WithMany()
                        .HasForeignKey("PkArticulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Veterinaria_Web.Models.Entities.Factura", null)
                        .WithMany()
                        .HasForeignKey("PkFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.Promocion", b =>
                {
                    b.HasOne("Veterinaria_Web.Models.Entities.Articulo", "Articulo")
                        .WithMany()
                        .HasForeignKey("FkArticulo");

                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("Veterinaria_Web.Models.Entities.Usuario", b =>
                {
                    b.HasOne("Veterinaria_Web.Models.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
