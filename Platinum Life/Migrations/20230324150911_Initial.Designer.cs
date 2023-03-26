﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Platinum_Life.Data;

#nullable disable

namespace Platinum_Life.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230324150911_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PlatinumLife.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PaymentDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentRecipientAccount")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentRecipientBank")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentRecipientName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Signed")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SigningManager")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Submitter")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}