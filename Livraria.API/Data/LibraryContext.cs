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
                });

            builder.Entity<Book>()
                .HasData(new List<Book>(){
                    new Book(1, "Banco de Dados", "Navathe", 1, DateTime.Parse("14/10/2002"), 49, 1, 1),
                });

            builder.Entity<Publisher>()
                .HasData(new List<Publisher>(){
                    new Publisher(1, "Makron", "São Paulo"),
                });

            builder.Entity<Rental>()
                .HasData(new List<Rental>(){
                    new Rental(1, 2, 1, DateTime.Parse("14/09/2022"), DateTime.Parse("30/10/2022"), DateTime.Parse("25/09/2022"), true),
                });
        }
    }
}