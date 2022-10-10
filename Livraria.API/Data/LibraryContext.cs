using Livraria.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Livraria.API.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>(){
                    new User(1, "Artur Gonçalves", "Fortaleza", "Rua A,190", "artur@gmail.com"),
                    new User(2, "Ana Maria", "São Paulo", "Rua J,324", "ana5@gmail.com"),
                    new User(3, "Caio Henrique", "Rio de Janeiro", "Rua B,353", "caioh@gmail.com"),
                    new User(13, "Luzia Carvalho", "Fortaleza", "Rua L,985", "luzia123@gmail.com"),
                    new User(16, "Ronald Santos", "Los Angeles", "Rua W,122", "ronald98@gmail.com"),
                    new User(18, "Ava Max", "Nova Iorque", "Rua Q,133", "ava.max@gmail.com"),
                    new User(33, "Henrique Lopes", "Fortaleza", "Rua E,343", "henri3@gmail.com"),
                    new User(37, "Johanna Constantine", "Torino", "Rua Z,543", "joh.const@gmail.com"),
                    new User(41, "Caique Silva", "Fortaleza", "Rua N,645", "caiques@gmail.com"),
                    new User(52, "Leona Luz", "Fortaleza", "Rua S,709", "leona3@gmail.com"),
                    new User(54, "Amy Pond", "Paris", "Rua R, 837", "amy23@gmail.com"),

                });

            builder.Entity<Book>()
                .HasData(new List<Book>(){
                    new Book(1, "Clean Code", "Cecil Martin", 3, DateTime.Parse("14/10/2012"), 120, 7, 123),
                    new Book(3, "Banco de dados", "Alex Max", 4, DateTime.Parse("06/11/2018"), 87, 1, 1),
                    new Book(4, "Javascript e seus conceitos", "Eduardo Candido", 1, DateTime.Parse("14/02/2012"), 49, 0, 23),
                    new Book(6, "A arte de programar", "George Nick", 1, DateTime.Parse("23/10/2015"), 32, 0, 22),
                    new Book(7, "Algoritmos", "Paul Marks", 2, DateTime.Parse("16/03/2018"), 68, 0, 10),
                    new Book(19, "Aprenda a programar com Python", "Robert Cecil", 5, DateTime.Parse("14/04/2012"), 43, 1, 43),
                    new Book(20, "Lógica de programação com Portugol", "Andy Hunt e Dave Thomas", 7, DateTime.Parse("14/10/2019"), 49, 1, 56),
                    new Book(21, "Coleção Frameworks Java", "Ana Lima", 8, DateTime.Parse("21/02/2020"), 65, 0, 25),
                    new Book(24, "SOA, web services e além", "Caio Lopes", 3, DateTime.Parse("05/01/2022"), 33, 0, 10),
                    new Book(45, "ASP.NET Core MVC", "Navathe", 5, DateTime.Parse("08/12/2011"), 23, 0, 43),
                    new Book(46, "Orientação a Objetos em C#", "Navathe", 7, DateTime.Parse("03/10/2005"), 43, 2, 21),
                    new Book(48, "TDD para Games", "Raquel Rose", 2, DateTime.Parse("09/05/2008"), 87, 0, 11),
                    new Book(58, "Elixir", "Charllote Will", 3, DateTime.Parse("14/11/2012"), 95, 1, 12),
                    new Book(70, "Computação Evolucionária", "Lana Beck", 1, DateTime.Parse("24/07/2021"), 23, 1, 19),
                });

            builder.Entity<Publisher>()
                .HasData(new List<Publisher>(){
                    new Publisher(1, "Makron", "São Paulo"),
                    new Publisher(2, "TecInova", "São Paulo"),
                    new Publisher(3, "Atena", "Rio de janeiro"),
                    new Publisher(4, "AFE", "Fortaleza"),
                    new Publisher(5, "Novatec", "Fortaleza"),
                    new Publisher(6, "Juruá", "Belo Horizonte"),
                    new Publisher(7, "Moderna", "Estocolmo"),
                    new Publisher(8, "Feevale", "Riomaggiore"),
                });

            builder.Entity<Rental>()
                .HasData(new List<Rental>(){
                    new Rental(12, 1, 1, DateTime.Parse("01/06/2022"), DateTime.Parse("04/10/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(14, 2, 1, DateTime.Parse("05/06/2022"), DateTime.Parse("16/09/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(15, 1, 3, DateTime.Parse("23/06/2022"), DateTime.Parse("09/10/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(16, 3, 19, DateTime.Parse("20/06/2022"), DateTime.Parse("15/10/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(45, 18, 20, DateTime.Parse("10/06/2022"), DateTime.Parse("30/10/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(47, 33, 46, DateTime.Parse("21/06/2022"), DateTime.Parse("26/09/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(58, 37, 70, DateTime.Parse("28/06/2022"), DateTime.Parse("09/08/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(59, 52, 1, DateTime.Parse("03/06/2022"), DateTime.Parse("03/10/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(80, 3, 1, DateTime.Parse("10/09/2022"), DateTime.Parse("30/11/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(81, 3, 1, DateTime.Parse("04/09/2022"), DateTime.Parse("23/12/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(84, 1, 46, DateTime.Parse("12/09/2022"), DateTime.Parse("12/11/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(87, 52, 58, DateTime.Parse("07/09/2022"), DateTime.Parse("29/09/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(89, 54, 1, DateTime.Parse("05/09/2022"), DateTime.Parse("14/11/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                    new Rental(91, 16, 1, DateTime.Parse("20/09/2022"), DateTime.Parse("08/12/2022"), DateTime.Parse("01/01/0001"), false, "Com pendência"),
                });
        }
    }
}