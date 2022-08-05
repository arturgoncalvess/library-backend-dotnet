using Livraria.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Livraria.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>(){
                    new User(1, "Artur", "Cascavel", "Rua A", "Artur@gmail.com"),
                    new User(2, "Ana", "Caucaia", "Rua T", "Ana@gmail.com"),
                    new User(3, "Vilma", "São Paulo", "Rua K", "Vilma@gmail.com"),
                    new User(4, "Vitor", "Fortaleza", "Rua E", "Vitor@gmail.com"),
                });

            builder.Entity<Book>()
                .HasData(new List<Book>(){
                    new Book(1, "Flor de Verão", "Juliano Santos", 1, 23072001, 10, 23),
                    new Book(2, "Flor", "Alex Santos", 3, 08072001, 68, 90),
                    new Book(3, "Oi vida", "Raquel Lovewood", 5, 23082001, 10, 36),
                    new Book(4, "Feliz mas não", "Ana Luana", 2, 23072004, 3, 23),
                    new Book(5, "Doce tristeza", "Lara Alencar", 4, 13072001, 53, 46), 
                });

            builder.Entity<Publisher>()
                .HasData(new List<Publisher>(){
                    new Publisher(1, "Bem me quer", "Cascavel"),
                    new Publisher(2, "Flores balas", "RJ"),
                    new Publisher(3, "Produtos Ivone", "Horizonte"),
                    new Publisher(4, "Nuvem", "São Paulo"),
                    new Publisher(5, "Luz", "Fortaleza"),
                });

            builder.Entity<Rental>()
                .HasData(new List<Rental>(){
                    new Rental(1, 1, 1, 20220923, 280920022, 26092022),
                    new Rental(3, 1, 2, 01092022, 200920022, 15092022),
                    new Rental(4, 4, 1, 04092022, 210920022, 20092022),
                    new Rental(5, 2, 5, 21092022, 300920022, 25092022),
                });
        }
    }
}

