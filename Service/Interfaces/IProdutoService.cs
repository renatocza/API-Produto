using CrossCutting.Enums;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProdutoService : IGetById<Produto>, IGetAll<Produto>, IAdd<Produto>, IUpdate<Produto>, IDeleteById<Produto>
    {
        Task<ICollection<Produto>> GetByName(string nome);
        Task<ICollection<Produto>> OrderedByAsync(CampoProduto field);
    }
}
