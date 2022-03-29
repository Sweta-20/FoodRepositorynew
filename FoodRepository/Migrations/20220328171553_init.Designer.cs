﻿// <auto-generated />
using FoodRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodRepository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220328171553_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodRepository.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemID");

                    b.ToTable("itemnames");
                });

            modelBuilder.Entity("FoodRepository.Models.User", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodRepository.Models.UserItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Itemid")
                        .HasColumnType("int");

                    b.Property<int>("uid")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Itemid");

                    b.HasIndex("uid");

                    b.ToTable("storeDatas");
                });

            modelBuilder.Entity("FoodRepository.Models.UserItem", b =>
                {
                    b.HasOne("FoodRepository.Models.Item", "Itemname")
                        .WithMany()
                        .HasForeignKey("Itemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodRepository.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("uid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Itemname");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
