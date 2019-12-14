﻿// <auto-generated />
using System;
using HighStakes.Storing.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HighStakes.Storing.Migrations
{
    [DbContext(typeof(HighStakesContext))]
    [Migration("20191214033117_try-foreign")]
    partial class tryforeign
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HighStakes.Domain.Models.DAccount", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("AccountId");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            Password = "Pannu",
                            UserName = "Simar"
                        },
                        new
                        {
                            AccountId = 2,
                            Password = "Nguyen",
                            UserName = "Han"
                        },
                        new
                        {
                            AccountId = 3,
                            Password = "Goldsmith",
                            UserName = "James"
                        });
                });

            modelBuilder.Entity("HighStakes.Domain.Models.DCard", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Suit")
                        .HasColumnType("text");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("CardId");

                    b.ToTable("Card");

                    b.HasData(
                        new
                        {
                            CardId = 1,
                            Suit = "Spades",
                            Value = 2
                        },
                        new
                        {
                            CardId = 2,
                            Suit = "Spades",
                            Value = 3
                        },
                        new
                        {
                            CardId = 3,
                            Suit = "Spades",
                            Value = 4
                        },
                        new
                        {
                            CardId = 4,
                            Suit = "Spades",
                            Value = 5
                        },
                        new
                        {
                            CardId = 5,
                            Suit = "Spades",
                            Value = 6
                        },
                        new
                        {
                            CardId = 6,
                            Suit = "Spades",
                            Value = 7
                        },
                        new
                        {
                            CardId = 7,
                            Suit = "Spades",
                            Value = 8
                        },
                        new
                        {
                            CardId = 8,
                            Suit = "Spades",
                            Value = 9
                        },
                        new
                        {
                            CardId = 9,
                            Suit = "Spades",
                            Value = 10
                        },
                        new
                        {
                            CardId = 10,
                            Suit = "Spades",
                            Value = 11
                        },
                        new
                        {
                            CardId = 11,
                            Suit = "Spades",
                            Value = 12
                        },
                        new
                        {
                            CardId = 12,
                            Suit = "Spades",
                            Value = 13
                        },
                        new
                        {
                            CardId = 13,
                            Suit = "Spades",
                            Value = 14
                        },
                        new
                        {
                            CardId = 14,
                            Suit = "Hearts",
                            Value = 2
                        },
                        new
                        {
                            CardId = 15,
                            Suit = "Hearts",
                            Value = 3
                        },
                        new
                        {
                            CardId = 16,
                            Suit = "Hearts",
                            Value = 4
                        },
                        new
                        {
                            CardId = 17,
                            Suit = "Hearts",
                            Value = 5
                        },
                        new
                        {
                            CardId = 18,
                            Suit = "Hearts",
                            Value = 6
                        },
                        new
                        {
                            CardId = 19,
                            Suit = "Hearts",
                            Value = 7
                        },
                        new
                        {
                            CardId = 20,
                            Suit = "Hearts",
                            Value = 8
                        },
                        new
                        {
                            CardId = 21,
                            Suit = "Hearts",
                            Value = 9
                        },
                        new
                        {
                            CardId = 22,
                            Suit = "Hearts",
                            Value = 10
                        },
                        new
                        {
                            CardId = 23,
                            Suit = "Hearts",
                            Value = 11
                        },
                        new
                        {
                            CardId = 24,
                            Suit = "Hearts",
                            Value = 12
                        },
                        new
                        {
                            CardId = 25,
                            Suit = "Hearts",
                            Value = 13
                        },
                        new
                        {
                            CardId = 26,
                            Suit = "Hearts",
                            Value = 14
                        },
                        new
                        {
                            CardId = 27,
                            Suit = "Clubs",
                            Value = 2
                        },
                        new
                        {
                            CardId = 28,
                            Suit = "Clubs",
                            Value = 3
                        },
                        new
                        {
                            CardId = 29,
                            Suit = "Clubs",
                            Value = 4
                        },
                        new
                        {
                            CardId = 30,
                            Suit = "Clubs",
                            Value = 5
                        },
                        new
                        {
                            CardId = 31,
                            Suit = "Clubs",
                            Value = 6
                        },
                        new
                        {
                            CardId = 32,
                            Suit = "Clubs",
                            Value = 7
                        },
                        new
                        {
                            CardId = 33,
                            Suit = "Clubs",
                            Value = 8
                        },
                        new
                        {
                            CardId = 34,
                            Suit = "Clubs",
                            Value = 9
                        },
                        new
                        {
                            CardId = 35,
                            Suit = "Clubs",
                            Value = 10
                        },
                        new
                        {
                            CardId = 36,
                            Suit = "Clubs",
                            Value = 11
                        },
                        new
                        {
                            CardId = 37,
                            Suit = "Clubs",
                            Value = 12
                        },
                        new
                        {
                            CardId = 38,
                            Suit = "Clubs",
                            Value = 13
                        },
                        new
                        {
                            CardId = 39,
                            Suit = "Clubs",
                            Value = 14
                        },
                        new
                        {
                            CardId = 40,
                            Suit = "Diamonds",
                            Value = 2
                        },
                        new
                        {
                            CardId = 41,
                            Suit = "Diamonds",
                            Value = 3
                        },
                        new
                        {
                            CardId = 42,
                            Suit = "Diamonds",
                            Value = 4
                        },
                        new
                        {
                            CardId = 43,
                            Suit = "Diamonds",
                            Value = 5
                        },
                        new
                        {
                            CardId = 44,
                            Suit = "Diamonds",
                            Value = 6
                        },
                        new
                        {
                            CardId = 45,
                            Suit = "Diamonds",
                            Value = 7
                        },
                        new
                        {
                            CardId = 46,
                            Suit = "Diamonds",
                            Value = 8
                        },
                        new
                        {
                            CardId = 47,
                            Suit = "Diamonds",
                            Value = 9
                        },
                        new
                        {
                            CardId = 48,
                            Suit = "Diamonds",
                            Value = 10
                        },
                        new
                        {
                            CardId = 49,
                            Suit = "Diamonds",
                            Value = 11
                        },
                        new
                        {
                            CardId = 50,
                            Suit = "Diamonds",
                            Value = 12
                        },
                        new
                        {
                            CardId = 51,
                            Suit = "Diamonds",
                            Value = 13
                        },
                        new
                        {
                            CardId = 52,
                            Suit = "Diamonds",
                            Value = 14
                        });
                });

            modelBuilder.Entity("HighStakes.Domain.Models.DUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int>("ChipTotal")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("AccountId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            AccountId = 1,
                            ChipTotal = 5000,
                            FirstName = "Simar",
                            LastName = "Pannu"
                        },
                        new
                        {
                            UserId = 2,
                            AccountId = 2,
                            ChipTotal = 5000,
                            FirstName = "Han",
                            LastName = "Nguyen"
                        },
                        new
                        {
                            UserId = 3,
                            AccountId = 3,
                            ChipTotal = 5000,
                            FirstName = "James",
                            LastName = "Goldsmith"
                        });
                });

            modelBuilder.Entity("HighStakes.Domain.Models.DUser", b =>
                {
                    b.HasOne("HighStakes.Domain.Models.DAccount", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });
#pragma warning restore 612, 618
        }
    }
}