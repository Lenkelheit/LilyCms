﻿// <auto-generated />
using System;
using LilyCms.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LilyCms.DataAccess.Migrations
{
    [DbContext(typeof(LilyCmsDbContext))]
    [Migration("20210815112003_OptionalUrlSlug")]
    partial class OptionalUrlSlug
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LilyCms.DataAccess.Models.ContentType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("ContentType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Displays HTML content",
                            Name = "Html Content"
                        });
                });

            modelBuilder.Entity("LilyCms.DataAccess.Models.Page", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UrlSlug")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("LilyCms.DataAccess.Models.PageArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContentType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("PageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ContentType");

                    b.HasIndex("PageId");

                    b.ToTable("PageArea");
                });

            modelBuilder.Entity("LilyCms.DataAccess.Models.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UrlSlug")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("LilyCms.DataAccess.Models.Page", b =>
                {
                    b.HasOne("LilyCms.DataAccess.Models.Site", "Site")
                        .WithMany("Pages")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("LilyCms.DataAccess.Models.PageArea", b =>
                {
                    b.HasOne("LilyCms.DataAccess.Models.ContentType", "ContentTypeRelation")
                        .WithMany()
                        .HasForeignKey("ContentType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LilyCms.DataAccess.Models.Page", "Page")
                        .WithMany("PageAreas")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentTypeRelation");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("LilyCms.DataAccess.Models.Page", b =>
                {
                    b.Navigation("PageAreas");
                });

            modelBuilder.Entity("LilyCms.DataAccess.Models.Site", b =>
                {
                    b.Navigation("Pages");
                });
#pragma warning restore 612, 618
        }
    }
}
