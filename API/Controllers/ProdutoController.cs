using CrossCutting.Enums;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Produto>>> Get()
        {
            var produtos = await _produtoService.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(Guid id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpGet("nome/{name}")]
        public async Task<ActionResult<ICollection<Produto>>> GetByName(string name)
        {
            var produtos = await _produtoService.GetByName(name);
            if (produtos.Count == 0)
            {
                return NotFound();
            }
            return Ok(produtos);
        }


        [HttpGet("ordenado/{field}")]
        public async Task<ActionResult<ICollection<Produto>>> GetOrderedBy(CampoProduto field)
        {
            try
            {
                var produtos = await _produtoService.OrderedByAsync(field);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Post([FromBody] Produto produto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _produtoService.AddAsync(produto);

                return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _produtoService.UpdateAsync(produto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _produtoService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
