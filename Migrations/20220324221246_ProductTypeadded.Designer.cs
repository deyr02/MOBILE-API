﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mobile_api.Data;

namespace mobile_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220324221246_ProductTypeadded")]
    partial class ProductTypeadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("mobile_api.Model.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("ProductType")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("products");
                });
#pragma warning restore 612, 618
        }
    }
}
