using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            // Ensure the database is created and seed data is applied
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProdutoMapping());

            GenerateSeed(ref modelBuilder);
        }

        private void GenerateSeed(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = Guid.NewGuid(), Nome = "Produto", Valor = 10.99m, Estoque = 100, Descricao = "Descrição do Produto", },
                new Produto { Id = Guid.NewGuid(), Nome = "Produto Lorem Ipsum", Valor = 20.99m, Estoque = 2, Descricao = "Descrição do Produto 2", },
                new Produto { Id = Guid.NewGuid(), Nome = "Produto 3", Valor = 20.99m, Estoque = 3000, Descricao = "Descrição do Produto " },
                new Produto { Id = Guid.NewGuid(), Nome = "Produto Aleatório", Valor = 20.99m, Estoque = 0, Descricao = "Descrição do Produto quatro" },
                new Produto { Id = Guid.NewGuid(), Nome = "Outro Produto", Valor = 11.99m, Estoque = 50, Descricao = "Descrição do Produto 5" }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MemoryDB");
        }


    }
}
