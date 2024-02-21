using CrossCutting.Enums;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.v1;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.v1
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        private ProdutoRepository repository;
        public ProdutoService(Context context) : base(context)
        {
            repository = new ProdutoRepository(context);
        }


        public async Task AddAsync(Produto entity)
        {
            if (!entity.ValidarProduto()) { throw new Exception("Produto inválido"); }
            await repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<ICollection<Produto>> OrderedByAsync(CampoProduto field)
        {

            return await repository.OrderedByAsync(field);
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<ICollection<Produto>> GetByName(string nome)
        {
            return await repository.GetByExpressionAsync(x => x.Nome.Contains(nome));
        }

        public async Task UpdateAsync(Produto entity)
        {
            await repository.UpdateAsync(entity);
        }

        public Task<ICollection<Produto>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }
    }
}
