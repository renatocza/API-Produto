using API.Controllers;
using CrossCutting.Enums;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Interfaces;

namespace API.Tests
{
    public class ProdutoControllerTests
    {
        private Mock<IProdutoService> _produtoServiceMock;
        private ProdutoController _produtoController;

        [SetUp]
        public void Setup()
        {
            _produtoServiceMock = new Mock<IProdutoService>();
            _produtoController = new ProdutoController(_produtoServiceMock.Object);
        }

        [Test]
        public async Task Get_ReturnsOkResultWithProdutos()
        {
            var produtos = new List<Produto>
                {
                    new Produto { Id = Guid.NewGuid(), Nome = "Produto 1" },
                    new Produto { Id = Guid.NewGuid(), Nome = "Produto 2" }
                };
            _produtoServiceMock.Setup(service => service.GetAllAsync()).ReturnsAsync(produtos);

            var result = await _produtoController.Get();

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(produtos, okResult.Value);
        }

        [Test]
        public async Task Get_ReturnsNotFoundResult()
        {
            Guid id = Guid.NewGuid();
            _produtoServiceMock.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((Produto)null);

            var result = await _produtoController.Get(id);

            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public async Task Get_ReturnsOkResultWithProduto()
        {
            Guid id = Guid.NewGuid();
            var produto = new Produto { Id = id, Nome = "Produto 1" };
            _produtoServiceMock.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(produto);

            var result = await _produtoController.Get(id);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(produto, okResult.Value);
        }

        [Test]
        public async Task GetByName_ReturnsNotFoundResult()
        {
            string name = "Produto 1";
            _produtoServiceMock.Setup(service => service.GetByName(name)).ReturnsAsync(new List<Produto>());

            var result = await _produtoController.GetByName(name);

            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public async Task GetByName_ReturnsOkResultWithProdutos()
        {
            string name = "Produto 1";
            var produtos = new List<Produto>
                {
                    new Produto { Id = Guid.NewGuid(), Nome = name },
                    new Produto { Id = Guid.NewGuid(), Nome = name }
                };
            _produtoServiceMock.Setup(service => service.GetByName(name)).ReturnsAsync(produtos);

            var result = await _produtoController.GetByName(name);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(produtos, okResult.Value);
        }

        [Test]
        public async Task GetOrderedBy_ReturnsOkResultWithProdutos()
        {
            CampoProduto field = CampoProduto.Nome;
            var produtos = new List<Produto>
                {
                    new Produto { Id = Guid.NewGuid(), Nome = "Produto 1" },
                    new Produto { Id = Guid.NewGuid(), Nome = "Produto 2" }
                };
            _produtoServiceMock.Setup(service => service.OrderedByAsync(field)).ReturnsAsync(produtos);

            var result = await _produtoController.GetOrderedBy(field);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(produtos, okResult.Value);
        }

        [Test]
        public async Task GetOrderedBy_ReturnsBadRequestResult()
        {
            CampoProduto field = CampoProduto.Nome;
            string errorMessage = "Error message";
            _produtoServiceMock.Setup(service => service.OrderedByAsync(field)).ThrowsAsync(new Exception(errorMessage));

            var result = await _produtoController.GetOrderedBy(field);

            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.AreEqual(errorMessage, badRequestResult.Value);
        }

        [Test]
        public async Task Post_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            var produto = new Produto { Id = Guid.NewGuid(), Nome = "Produto 1" };
            _produtoController.ModelState.AddModelError("Nome", "Nome é obrigatório");
            var expected = new BadRequestObjectResult(_produtoController.ModelState);

            var result = await _produtoController.Post(produto);

            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.AreEqual(expected.Value, badRequestResult.Value);
        }

        [Test]
        public async Task Post_ReturnsCreatedAtActionResult_WhenProdutoIsAdded()
        {
            var produto = new Produto { Id = Guid.NewGuid(), Nome = "Produto 1" };

            var result = await _produtoController.Post(produto);

            Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
            var createdAtActionResult = result.Result as CreatedAtActionResult;
            Assert.AreEqual(nameof(_produtoController.Get), createdAtActionResult.ActionName);
            Assert.AreEqual(produto.Id, createdAtActionResult.RouteValues["id"]);
            Assert.AreEqual(produto, createdAtActionResult.Value);
        }

        [Test]
        public async Task Post_WhenAddAsyncThrowsException()
        {
            var produto = new Produto { Id = Guid.NewGuid(), Nome = "Produto 1" };
            string errorMessage = "Error message";
            _produtoServiceMock.Setup(service => service.AddAsync(produto)).ThrowsAsync(new Exception(errorMessage));

            var result = await _produtoController.Post(produto);

            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.AreEqual(errorMessage, badRequestResult.Value);
        }

        [Test]
        public async Task Put_WhenIdDoesNotMatchProdutoId()
        {
            Guid id = Guid.NewGuid();
            var produto = new Produto { Id = Guid.NewGuid(), Nome = "Produto 1" };

            var result = await _produtoController.Put(id, produto);

            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public async Task Put_WhenModelStateInvalid()
        {
            Guid id = Guid.NewGuid();
            var produto = new Produto { Id = id, Nome = "Produto 1" };
            _produtoController.ModelState.AddModelError("Nome", "Nome é obrigatório");
            var expected = new BadRequestObjectResult(_produtoController.ModelState);
            var result = await _produtoController.Put(id, produto);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(expected.Value, badRequestResult.Value);
        }

        [Test]
        public async Task Put_WhenProdutoNotFound()
        {
            Guid id = Guid.NewGuid();
            var produto = new Produto { Id = id, Nome = "Produto 1" };
            _produtoServiceMock.Setup(service => service.UpdateAsync(produto)).Throws<KeyNotFoundException>();

            var result = await _produtoController.Put(id, produto);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Put_WhenUpdateAsyncThrowsException()
        {
            Guid id = Guid.NewGuid();
            var produto = new Produto { Id = id, Nome = "Produto 1" };
            string errorMessage = "Error message";
            _produtoServiceMock.Setup(service => service.UpdateAsync(produto)).ThrowsAsync(new Exception(errorMessage));

            var result = await _produtoController.Put(id, produto);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(errorMessage, badRequestResult.Value);
        }

        [Test]
        public async Task Put_WhenProdutoUpdated()
        {
            Guid id = Guid.NewGuid();
            var produto = new Produto { Id = id, Nome = "Produto 1" };

            var result = await _produtoController.Put(id, produto);

            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task Delete_WhenProdutoNotFound()
        {
            Guid id = Guid.NewGuid();
            _produtoServiceMock.Setup(service => service.DeleteAsync(id)).Throws<KeyNotFoundException>();

            var result = await _produtoController.Delete(id);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task Delete_WhenProdutoDeleted()
        {
            Guid id = Guid.NewGuid();

            var result = await _produtoController.Delete(id);

            Assert.IsInstanceOf<NoContentResult>(result);
        }
    }
}
