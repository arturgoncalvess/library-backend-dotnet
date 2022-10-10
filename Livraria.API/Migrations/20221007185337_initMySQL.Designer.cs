﻿// <auto-generated />
using System;
using Livraria.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Livraria.API.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20221007185337_initMySQL")]
    partial class initMySQL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Livraria.API.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Launch")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MaxRented")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TotalRented")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Cecil Martin",
                            Launch = new DateTime(2012, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 123,
                            Name = "Clean Code",
                            PublisherId = 3,
                            Quantity = 120,
                            TotalRented = 7
                        },
                        new
                        {
                            Id = 3,
                            Author = "Alex Max",
                            Launch = new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 1,
                            Name = "Banco de dados",
                            PublisherId = 4,
                            Quantity = 87,
                            TotalRented = 1
                        },
                        new
                        {
                            Id = 4,
                            Author = "Eduardo Candido",
                            Launch = new DateTime(2012, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 23,
                            Name = "Javascript e seus conceitos",
                            PublisherId = 1,
                            Quantity = 49,
                            TotalRented = 0
                        },
                        new
                        {
                            Id = 6,
                            Author = "George Nick",
                            Launch = new DateTime(2015, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 22,
                            Name = "A arte de programar",
                            PublisherId = 1,
                            Quantity = 32,
                            TotalRented = 0
                        },
                        new
                        {
                            Id = 7,
                            Author = "Paul Marks",
                            Launch = new DateTime(2018, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 10,
                            Name = "Algoritmos",
                            PublisherId = 2,
                            Quantity = 68,
                            TotalRented = 0
                        },
                        new
                        {
                            Id = 19,
                            Author = "Robert Cecil",
                            Launch = new DateTime(2012, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 43,
                            Name = "Aprenda a programar com Python",
                            PublisherId = 5,
                            Quantity = 43,
                            TotalRented = 1
                        },
                        new
                        {
                            Id = 20,
                            Author = "Andy Hunt e Dave Thomas",
                            Launch = new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 56,
                            Name = "Lógica de programação com Portugol",
                            PublisherId = 7,
                            Quantity = 49,
                            TotalRented = 1
                        },
                        new
                        {
                            Id = 21,
                            Author = "Ana Lima",
                            Launch = new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 25,
                            Name = "Coleção Frameworks Java",
                            PublisherId = 8,
                            Quantity = 65,
                            TotalRented = 0
                        },
                        new
                        {
                            Id = 24,
                            Author = "Caio Lopes",
                            Launch = new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 10,
                            Name = "SOA, web services e além",
                            PublisherId = 3,
                            Quantity = 33,
                            TotalRented = 0
                        },
                        new
                        {
                            Id = 45,
                            Author = "Navathe",
                            Launch = new DateTime(2011, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 43,
                            Name = "ASP.NET Core MVC",
                            PublisherId = 5,
                            Quantity = 23,
                            TotalRented = 0
                        },
                        new
                        {
                            Id = 46,
                            Author = "Navathe",
                            Launch = new DateTime(2005, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 21,
                            Name = "Orientação a Objetos em C#",
                            PublisherId = 7,
                            Quantity = 43,
                            TotalRented = 2
                        },
                        new
                        {
                            Id = 48,
                            Author = "Raquel Rose",
                            Launch = new DateTime(2008, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 11,
                            Name = "TDD para Games",
                            PublisherId = 2,
                            Quantity = 87,
                            TotalRented = 0
                        },
                        new
                        {
                            Id = 58,
                            Author = "Charllote Will",
                            Launch = new DateTime(2012, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 12,
                            Name = "Elixir",
                            PublisherId = 3,
                            Quantity = 95,
                            TotalRented = 1
                        },
                        new
                        {
                            Id = 70,
                            Author = "Lana Beck",
                            Launch = new DateTime(2021, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxRented = 19,
                            Name = "Computação Evolucionária",
                            PublisherId = 1,
                            Quantity = 23,
                            TotalRented = 1
                        });
                });

            modelBuilder.Entity("Livraria.API.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "São Paulo",
                            Name = "Makron"
                        },
                        new
                        {
                            Id = 2,
                            City = "São Paulo",
                            Name = "TecInova"
                        },
                        new
                        {
                            Id = 3,
                            City = "Rio de janeiro",
                            Name = "Atena"
                        },
                        new
                        {
                            Id = 4,
                            City = "Fortaleza",
                            Name = "AFE"
                        },
                        new
                        {
                            Id = 5,
                            City = "Fortaleza",
                            Name = "Novatec"
                        },
                        new
                        {
                            Id = 6,
                            City = "Belo Horizonte",
                            Name = "Juruá"
                        },
                        new
                        {
                            Id = 7,
                            City = "Estocolmo",
                            Name = "Moderna"
                        },
                        new
                        {
                            Id = 8,
                            City = "Riomaggiore",
                            Name = "Feevale"
                        });
                });

            modelBuilder.Entity("Livraria.API.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Forecast_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Rental_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Return_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("Returned_Book")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Status_Rental")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Rentals");

                    b.HasData(
                        new
                        {
                            Id = 12,
                            BookId = 1,
                            Forecast_Date = new DateTime(2022, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 1
                        },
                        new
                        {
                            Id = 14,
                            BookId = 1,
                            Forecast_Date = new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 2
                        },
                        new
                        {
                            Id = 15,
                            BookId = 3,
                            Forecast_Date = new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 1
                        },
                        new
                        {
                            Id = 16,
                            BookId = 19,
                            Forecast_Date = new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 3
                        },
                        new
                        {
                            Id = 45,
                            BookId = 20,
                            Forecast_Date = new DateTime(2022, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 18
                        },
                        new
                        {
                            Id = 47,
                            BookId = 46,
                            Forecast_Date = new DateTime(2022, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 33
                        },
                        new
                        {
                            Id = 58,
                            BookId = 70,
                            Forecast_Date = new DateTime(2022, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 37
                        },
                        new
                        {
                            Id = 59,
                            BookId = 1,
                            Forecast_Date = new DateTime(2022, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 52
                        },
                        new
                        {
                            Id = 80,
                            BookId = 1,
                            Forecast_Date = new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 3
                        },
                        new
                        {
                            Id = 81,
                            BookId = 1,
                            Forecast_Date = new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 3
                        },
                        new
                        {
                            Id = 84,
                            BookId = 46,
                            Forecast_Date = new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 1
                        },
                        new
                        {
                            Id = 87,
                            BookId = 58,
                            Forecast_Date = new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 52
                        },
                        new
                        {
                            Id = 89,
                            BookId = 1,
                            Forecast_Date = new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 54
                        },
                        new
                        {
                            Id = 91,
                            BookId = 1,
                            Forecast_Date = new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rental_Date = new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Return_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Returned_Book = false,
                            Status_Rental = "Com pendência",
                            UserId = 16
                        });
                });

            modelBuilder.Entity("Livraria.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Rua A,190",
                            City = "Fortaleza",
                            Email = "artur@gmail.com",
                            Name = "Artur Gonçalves"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Rua J,324",
                            City = "São Paulo",
                            Email = "ana5@gmail.com",
                            Name = "Ana Maria"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Rua B,353",
                            City = "Rio de Janeiro",
                            Email = "caioh@gmail.com",
                            Name = "Caio Henrique"
                        },
                        new
                        {
                            Id = 13,
                            Address = "Rua L,985",
                            City = "Fortaleza",
                            Email = "luzia123@gmail.com",
                            Name = "Luzia Carvalho"
                        },
                        new
                        {
                            Id = 16,
                            Address = "Rua W,122",
                            City = "Los Angeles",
                            Email = "ronald98@gmail.com",
                            Name = "Ronald Santos"
                        },
                        new
                        {
                            Id = 18,
                            Address = "Rua Q,133",
                            City = "Nova Iorque",
                            Email = "ava.max@gmail.com",
                            Name = "Ava Max"
                        },
                        new
                        {
                            Id = 33,
                            Address = "Rua E,343",
                            City = "Fortaleza",
                            Email = "henri3@gmail.com",
                            Name = "Henrique Lopes"
                        },
                        new
                        {
                            Id = 37,
                            Address = "Rua Z,543",
                            City = "Torino",
                            Email = "joh.const@gmail.com",
                            Name = "Johanna Constantine"
                        },
                        new
                        {
                            Id = 41,
                            Address = "Rua N,645",
                            City = "Fortaleza",
                            Email = "caiques@gmail.com",
                            Name = "Caique Silva"
                        },
                        new
                        {
                            Id = 52,
                            Address = "Rua S,709",
                            City = "Fortaleza",
                            Email = "leona3@gmail.com",
                            Name = "Leona Luz"
                        },
                        new
                        {
                            Id = 54,
                            Address = "Rua R, 837",
                            City = "Paris",
                            Email = "amy23@gmail.com",
                            Name = "Amy Pond"
                        });
                });

            modelBuilder.Entity("Livraria.API.Models.Book", b =>
                {
                    b.HasOne("Livraria.API.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Livraria.API.Models.Rental", b =>
                {
                    b.HasOne("Livraria.API.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livraria.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
