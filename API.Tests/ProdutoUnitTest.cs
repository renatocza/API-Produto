using Domain.Entidades;
using NUnit.Framework;

namespace API.Tests
{
    public class ProdutoUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidarProduto_NomeVazio_ThrowsArgumentException()
        {
            
            Produto produto = new Produto();
            produto.Nome = "";
            Assert.Throws<ArgumentException>(() => produto.ValidarProduto());
        }

        [Test]
        public void ValidarProduto_ValorNegativo_ThrowsArgumentException()
        {
            
            Produto produto = new Produto();
            produto.Nome = "Produto Teste";
            produto.Valor = -10;
            Assert.Throws<ArgumentException>(() => produto.ValidarProduto());
        }

        [Test]
        public void ValidarProduto_EstoqueNegativo_ThrowsArgumentException()
        {
            
            Produto produto = new Produto();
            produto.Nome = "Produto Teste";
            produto.Valor = 10;
            produto.Estoque = -5;

            Assert.Throws<ArgumentException>(() => produto.ValidarProduto());
        }

        [Test]
        public void ValidarProduto_ReturnsTrue()
        {

            Produto produto = new Produto();
            produto.Nome = "Produto Teste";
            produto.Valor = 10;
            produto.Estoque = 5;

            bool result = produto.ValidarProduto();
            Assert.IsTrue(result);
        }
    }
}