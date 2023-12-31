﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestRpg.Data;

namespace RestRpg.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230922015046_SeedItemsTable")]
    partial class SeedItemsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestRpg.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 3,
                            Name = "Small Mana potion",
                            Price = 20.0
                        },
                        new
                        {
                            Id = 2,
                            Amount = 3,
                            Name = "Small Life potion",
                            Price = 20.0
                        },
                        new
                        {
                            Id = 3,
                            Amount = 3,
                            Name = "Light Mana potion",
                            Price = 55.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
