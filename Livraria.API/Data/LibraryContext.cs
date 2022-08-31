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
                    new User(1, "João Lopes", "Fortaleza", "Rua A,190", "joão@bol"),
                    new User(2, "Marcelo Silva", "Caucaia", "Av. B, 1200", "ms@gmail"),
                    new User(3, "Carlos Aguiar", "São Paulo", "Rua C, 87", "aguiar@ig"),
                    new User(4, "Roberto Porto", "Fortaleza", "Rua D, 120", "rporto@bol"),
                });

            builder.Entity<Book>()
                .HasData(new List<Book>(){
                    new Book(1, "Banco de Dados", "Navathe", 2, DateTime.Parse("14/10/2002"), 98, 2),
                    new Book(2, "Redes de Computadores", "Deitel", 1, DateTime.Parse("25/02/2005"), 99, 1),
                    new Book(3, "Java Prático", "Deitel", 3, DateTime.Parse("24/05/2004"), 99, 1),
                    new Book(4, "Sistemas Operacionais", "Cormen", 2, DateTime.Parse("03/09/2006"), 99, 1),
                    new Book(5, "Algoritmos", "Cormen", 1, DateTime.Parse("12/04/2005"), 99, 1),
                    new Book(6, "Programando em C++", "Deitel", 2, DateTime.Parse("23/09/2006"), 100, 0),
                });

            builder.Entity<Publisher>()
                .HasData(new List<Publisher>(){
                    new Publisher(1, "Makron", "São Paulo"),
                    new Publisher(2, "Campus", "Rio de Janeiro"),
                    new Publisher(3, "Pearson", "São Paulo"),
                    new Publisher(4, "Bookman", "São Paulo"),
                });

            builder.Entity<Rental>()
                .HasData(new List<Rental>(){
                    new Rental(1, 2, 1, DateTime.Parse("14/10/2022"), DateTime.Parse("23/10/2022"), DateTime.Parse("25/10/2022")),
                    new Rental(2, 1, 2, DateTime.Parse("14/10/2022"), DateTime.Parse("27/10/2022"), DateTime.Parse("28/10/2022")),
                    new Rental(3, 4, 5, DateTime.Parse("01/10/2022"), DateTime.Parse("15/10/2022"), DateTime.Parse("18/10/2022")),
                    new Rental(4, 1, 3, DateTime.Parse("14/10/2022"), DateTime.Parse("18/10/2022"), DateTime.Parse("20/10/2022")),
                    new Rental(5, 3, 1, DateTime.Parse("14/09/2022"), DateTime.Parse("14/10/2022"), DateTime.Parse("15/10/2022")),
                    new Rental(6, 3, 2, DateTime.Parse("23/07/2022"), DateTime.Parse("30/07/2022"), DateTime.Parse("01/08/2022")),
                    new Rental(7, 4, 4, DateTime.Parse("23/10/2022"), DateTime.Parse("09/11/2022"), DateTime.Parse("14/11/2022")),
                });
        }
    }
}