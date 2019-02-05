﻿// <auto-generated />
using CrawlerApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrawlerApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190205083456_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("CrawlerApp.API.Models.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageURL");

                    b.Property<string>("Name");

                    b.Property<string>("PageURL");

                    b.HasKey("Id");

                    b.ToTable("Apps");
                });
#pragma warning restore 612, 618
        }
    }
}