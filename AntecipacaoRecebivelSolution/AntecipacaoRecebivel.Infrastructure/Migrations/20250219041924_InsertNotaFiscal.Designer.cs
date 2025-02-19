﻿// <auto-generated />
using System;
using AntecipacaoRecebivel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AntecipacaoRecebivel.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250219041924_InsertNotaFiscal")]
    partial class InsertNotaFiscal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AntecipacaoRecebivel.Infrastructure.Data.Models.Empresa", b =>
                {
                    b.Property<string>("Cnpj")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<decimal>("FaturamentoMensal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Ramo")
                        .HasColumnType("int");

                    b.HasKey("Cnpj");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("AntecipacaoRecebivel.Infrastructure.Data.Models.NotaFiscal", b =>
                {
                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("EmpresaCNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Numero");

                    b.HasIndex("EmpresaCNPJ");

                    b.ToTable("NotaFiscal");
                });

            modelBuilder.Entity("AntecipacaoRecebivel.Infrastructure.Data.Models.NotaFiscal", b =>
                {
                    b.HasOne("AntecipacaoRecebivel.Infrastructure.Data.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaCNPJ")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });
#pragma warning restore 612, 618
        }
    }
}
