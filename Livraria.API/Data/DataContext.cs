using Livraria.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Livraria.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        //public DbSet<Aluguel> Alugueis { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>()
                .HasData(new List<Usuario>(){
                    new Usuario(1, "Artur", "Cascavel", "Rua A", "Artur@gmail.com"),
                    new Usuario(2, "Ana", "Caucaia", "Rua T", "Ana@gmail.com"),
                    new Usuario(3, "Vilma", "São Paulo", "Rua K", "Vilma@gmail.com"),
                    new Usuario(4, "Vitor", "Fortaleza", "Rua E", "Vitor@gmail.com"),
                });

            builder.Entity<Livro>()
                .HasData(new List<Livro>(){
                    new Livro(1, "Flor de Verão", "Juliano Santos", 1, 23072001, 10, 23),
                    new Livro(2, "Flor", "Alex Santos", 3, 08072001, 68, 90),
                    new Livro(3, "Oi vida", "Raquel Lovewood", 5, 23082001, 10, 36),
                    new Livro(4, "Feliz mas não", "Ana Luana", 2, 23072004, 3, 23),
                    new Livro(5, "Doce tristeza", "Lara Alencar", 4, 13072001, 53, 46), 
                });

            builder.Entity<Editora>()
                .HasData(new List<Editora>(){
                    new Editora(1, "Bem me quer", "Cascavel"),
                    new Editora(2, "Flores balas", "RJ"),
                    new Editora(3, "Produtos Ivone", "Horizonte"),
                    new Editora(4, "Nuvem", "São Paulo"),
                    new Editora(5, "Luz", "Fortaleza"),
                });

            //builder.Entity<Usuario>()
            //    .HasData(new List<Usuario>(){
            //        new Usuario(1, "Artur", "Cascavel", "Rua A", "Artur@gmail.com"),
            //        new Usuario(2, "Ana", "Caucaia", "Rua T", "Ana@gmail.com"),
            //        new Usuario(3, "Vilma", "São Paulo", "Rua K", "Vilma@gmail.com"),
            //        new Usuario(4, "Vitor", "Fortaleza", "Rua E", "Vitor@gmail.com"),
            //    });
        }
    }
}

