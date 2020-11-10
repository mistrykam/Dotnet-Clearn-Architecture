﻿// <auto-generated />
using System;
using App.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20201110153509_BookFormat")]
    partial class BookFormat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Domain.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int?>("BookFormatValue")
                        .HasColumnType("int");

                    b.Property<int>("DislikeCount")
                        .HasColumnType("int");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("BookId");

                    b.HasIndex("BookFormatValue");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("App.Domain.Entities.Enum.BookFormatType", b =>
                {
                    b.Property<int>("Value")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Value");

                    b.ToTable("BookFormats");

                    b.HasData(
                        new
                        {
                            Value = 0,
                            DisplayName = "Book"
                        },
                        new
                        {
                            Value = 1,
                            DisplayName = "AudioBook"
                        },
                        new
                        {
                            Value = 2,
                            DisplayName = "eBook"
                        });
                });

            modelBuilder.Entity("App.Domain.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<bool>("Flagged")
                        .HasColumnType("bit");

                    b.HasKey("ReviewId");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("App.Domain.Entities.Book", b =>
                {
                    b.HasOne("App.Domain.Entities.Enum.BookFormatType", "BookFormat")
                        .WithMany()
                        .HasForeignKey("BookFormatValue");
                });

            modelBuilder.Entity("App.Domain.Entities.Review", b =>
                {
                    b.HasOne("App.Domain.Entities.Book", null)
                        .WithMany("Reviews")
                        .HasForeignKey("BookId");
                });
#pragma warning restore 612, 618
        }
    }
}
