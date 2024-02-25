﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TarefasApp.Infra.Data.Contexts;

#nullable disable

namespace TarefasApp.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240225143028_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TarefasApp.Domain.Entities.Tarefa", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("DataHora")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAHORA");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.Property<int?>("Prioridade")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("PRIORIDADE");

                    b.HasKey("Id");

                    b.ToTable("TAREFA", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
