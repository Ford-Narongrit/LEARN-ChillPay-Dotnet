﻿// <auto-generated />
using System;
using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace chillpayGateway.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Models.PaymentHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime?>("ChillpayExpiredDatetime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ChillpayTransactionId")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateDatetime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CurrencyConversionValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PaidPoint")
                        .HasColumnType("real");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("PointConversionValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdateDatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("trn_payment_history");
                });
#pragma warning restore 612, 618
        }
    }
}
