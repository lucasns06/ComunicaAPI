using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComunicaAPI.Models;
using ComunicaAPI.Models.Enuns;
using Microsoft.EntityFrameworkCore;

namespace ComunicaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Categoria>().HasData
            (
                new Categoria() { Id = 1, Nome = "Social", CorBackground = BackgroundEnum.Azul },
                new Categoria() { Id = 2, Nome = "Roupas", CorBackground = BackgroundEnum.Verde }
            );
        }
    }
}