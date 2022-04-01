﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tamagotchi.Services;

namespace Tamagotchi.Migrations
{
    [DbContext(typeof(TamagotchiContext))]
    partial class TamagotchiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Tamagotchi.Models.ImageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PetTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PetTypeId");

                    b.ToTable("ImageTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PetTypeId = 1,
                            Tag = "Happy",
                            URL = "images.pets.basic.tamagotchi_happy.png"
                        },
                        new
                        {
                            Id = 2,
                            PetTypeId = 1,
                            Tag = "Neutral",
                            URL = "images.pets.basic.tamagotchi_normal.png"
                        },
                        new
                        {
                            Id = 3,
                            PetTypeId = 1,
                            Tag = "Sad",
                            URL = "images.pets.basic.tamagotchi_sad.png"
                        },
                        new
                        {
                            Id = 4,
                            PetTypeId = 1,
                            Tag = "Sleep",
                            URL = "images.pets.basic.tamagotchi_sleep.png"
                        },
                        new
                        {
                            Id = 5,
                            PetTypeId = 1,
                            Tag = "Dead",
                            URL = "images.pets.basic.tamagotchi_dead.png"
                        },
                        new
                        {
                            Id = 6,
                            PetTypeId = 1,
                            Tag = "Egg_Fase_1",
                            URL = "images.eggs.egg_fase_1.png"
                        },
                        new
                        {
                            Id = 7,
                            PetTypeId = 1,
                            Tag = "Egg_Fase_2",
                            URL = "images.eggs.egg_fase_2.png"
                        },
                        new
                        {
                            Id = 8,
                            PetTypeId = 1,
                            Tag = "Egg_Fase_3",
                            URL = "images.eggs.egg_fase_3.png"
                        },
                        new
                        {
                            Id = 9,
                            PetTypeId = 1,
                            Tag = "Egg_Fase_4",
                            URL = "images.eggs.egg_fase_4.png"
                        });
                });

            modelBuilder.Entity("Tamagotchi.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attention")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Death")
                        .HasColumnType("TEXT");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Nutrition")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("PetTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sleep")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PetTypeId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Tamagotchi.Models.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PetTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "Basic"
                        });
                });

            modelBuilder.Entity("Tamagotchi.Models.ImageType", b =>
                {
                    b.HasOne("Tamagotchi.Models.PetType", "PetType")
                        .WithMany("ImageTypes")
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetType");
                });

            modelBuilder.Entity("Tamagotchi.Models.Pet", b =>
                {
                    b.HasOne("Tamagotchi.Models.PetType", "PetType")
                        .WithMany("Pets")
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetType");
                });

            modelBuilder.Entity("Tamagotchi.Models.PetType", b =>
                {
                    b.Navigation("ImageTypes");

                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
