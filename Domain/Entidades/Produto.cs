using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Estoque { get; set; }
        public string Descricao { get; set; }

        public bool ValidarProduto()
        {
            if(string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentException("Nome do produto não pode ser vazio");
            }
            if(Valor < 0)
            {
                throw new ArgumentException("Valor do produto não pode ser menor que zero");
            }
            if(Estoque < 0)
            {
                throw new ArgumentException("Estoque do produto não pode ser menor que zero");
            }

            return true;
        }
    }
}
