﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TermProject.Models;

#nullable disable

namespace TermProject.Migrations
{
    [DbContext(typeof(CookieContext))]
    partial class CookieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TermProject.Models.Members", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cell")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "MonsterEatsCookies@gmail.com",
                            FirstName = "Cookie",
                            LastName = "Monster"
                        },
                        new
                        {
                            Id = 2,
                            Email = "CookieCrispCereal@aol.com",
                            FirstName = "Cookie",
                            LastName = "Crisp"
                        },
                        new
                        {
                            Id = 3,
                            Email = "ennis@gmail.nmc.edu",
                            FirstName = "Sarah",
                            LastName = "Ennis"
                        });
                });

            modelBuilder.Entity("TermProject.Models.MoodEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Entry Date");

                    b.Property<int>("MembersId")
                        .HasColumnType("int");

                    b.Property<string>("Mood")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MembersId");

                    b.ToTable("MoodEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EntryDate = new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            MembersId = 1,
                            Mood = "Sad",
                            Notes = "Today was a tough day"
                        },
                        new
                        {
                            Id = 2,
                            EntryDate = new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            MembersId = 2,
                            Mood = "Happy",
                            Notes = "Today was a great day"
                        },
                        new
                        {
                            Id = 3,
                            EntryDate = new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            MembersId = 3,
                            Mood = "Okay",
                            Notes = "Today was neutral"
                        });
                });

            modelBuilder.Entity("TermProject.Models.MoodEntry", b =>
                {
                    b.HasOne("TermProject.Models.Members", "Members")
                        .WithMany("MoodEntrys")
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Members");
                });

            modelBuilder.Entity("TermProject.Models.Members", b =>
                {
                    b.Navigation("MoodEntrys");
                });
#pragma warning restore 612, 618
        }
    }
}
