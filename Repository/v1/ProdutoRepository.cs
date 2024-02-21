using CrossCutting.Enums;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.v1
{
    public class ProdutoRepository : BaseRepository<Produto>
    {
        public ProdutoRepository(Context context) : base(context)
        {
        }

        public override async Task<ICollection<Produto>> GetAllAsync()
        {
            return await _context.Produtos.OrderBy(x=>x.Nome).ToListAsync();
        }

        public async Task<ICollection<Produto>> OrderedByAsync(CampoProduto field)
        {
            switch (field)
            {
                case CampoProduto.Nome:
                    return await _context.Produtos.OrderBy(p => p.Nome).ToListAsync();
                case CampoProduto.Valor:
                    return await _context.Produtos.OrderBy(p => p.Valor).ToListAsync();
                case CampoProduto.Estoque:
                    return await _context.Produtos.OrderBy(p => p.Estoque).ToListAsync();
                case CampoProduto.Descricao:
                    return await _context.Produtos.OrderBy(p => p.Descricao).ToListAsync();
                default:
                    throw new ArgumentException("Campo inválido.");
            }
        }
    }
}
