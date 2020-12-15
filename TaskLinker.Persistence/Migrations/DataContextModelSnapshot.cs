﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskLinker.Persistence;

namespace TaskLinker.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TaskLinker.Model.Command", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CommandLine")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LinkName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommandLine");

                    b.HasIndex("GroupId");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("TaskLinker.Model.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("TaskLinker.Model.Command", b =>
                {
                    b.HasOne("TaskLinker.Model.Group", null)
                        .WithMany("Commands")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("TaskLinker.Model.Group", b =>
                {
                    b.Navigation("Commands");
                });
#pragma warning restore 612, 618
        }
    }
}