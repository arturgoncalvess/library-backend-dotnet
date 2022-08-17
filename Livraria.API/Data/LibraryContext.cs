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
                    new User(1, "Artur", "Fortaleza", "Rua A", "Artur@gmail.com"),
                    new User(2, "Ana", "Caucaia", "Rua T", "Ana@gmail.com"),
                    new User(3, "Vilma", "São Paulo", "Rua K", "Vilma@gmail.com"),
                    new User(4, "Vitor", "Fortaleza", "Rua E", "Vitor@gmail.com"),
                });

            builder.Entity<Book>()
                .HasData(new List<Book>(){
                    new Book(1, "Clear Code", "Juliano Santos", 2, 23072001, 10, 23),
                    new Book(2, "Logica de Programação", "Alex Santos", 1, 08072001, 68, 90),
                    new Book(3, "PHP e Laravel", "Raquel Lovewood", 3, 23082001, 10, 36),
                    new Book(4, "Dicionário do Programador", "Ana Luana", 1, 23072004, 3, 23),
                });

            builder.Entity<Publisher>()
                .HasData(new List<Publisher>(){
                    new Publisher(1, "Informatica Lite", "São Paulo"),
                    new Publisher(2, "Expresso Tec", "Horizonte"),
                    new Publisher(3, "Nuvem Logica", "São Paulo"),
                });

            builder.Entity<Rental>()
                .HasData(new List<Rental>(){
                    new Rental(1, 1, 4, DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010")),
                    new Rental(2, 3, 3, DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010")),
                    new Rental(3, 4, 1, DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010")),
                    new Rental(4, 1, 2, DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010")),
                    new Rental(5, 2, 3, DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010"), DateTime.Parse("14/10/2010")),
                });
        }
    }
}

