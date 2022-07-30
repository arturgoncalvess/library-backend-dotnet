using Livraria.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Livraria.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //    builder.Entity<UsuarioAluguel>()
            //        .HasKey(AD => new { AD.UsuarioId, AD.AluguelId });


            builder.Entity<Usuario>()
                .HasData(new List<Usuario>(){
                    new Usuario(1, "Artur", "Cascavel", "Rua A", "Artur@gmail.com"),
                    new Usuario(2, "Ana", "Caucaia", "Rua T", "Ana@gmail.com"),
                    new Usuario(3, "Vilma", "São Paulo", "Rua K", "Vilma@gmail.com"),
                    new Usuario(4, "Vitor", "Fortaleza", "Rua E", "Vitor@gmail.com"),
                });
        }
    }
}

