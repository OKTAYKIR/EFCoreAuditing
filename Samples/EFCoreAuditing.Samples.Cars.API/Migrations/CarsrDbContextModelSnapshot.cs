﻿// <auto-generated />
using System;
using EFCoreAuditing.Samples.Cars.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreAuditing.Samples.Cars.API.Migrations
{
    [DbContext(typeof(CarsrDbContext))]
    partial class CarsrDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreAuditing.Models.Audit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnName("date_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("KeyValues")
                        .HasColumnName("key_values")
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modified_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValues")
                        .HasColumnName("new_values")
                        .HasColumnType("text");

                    b.Property<string>("OldValues")
                        .HasColumnName("old_values")
                        .HasColumnType("text");

                    b.Property<string>("TableName")
                        .HasColumnName("table_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("audits");
                });

            modelBuilder.Entity("EFCoreAuditing.Samples.Cars.API.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnName("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnName("created_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MarketValue")
                        .HasColumnName("market_value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnName("owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnName("registration_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("cars");
                });
#pragma warning restore 612, 618
        }
    }
}
