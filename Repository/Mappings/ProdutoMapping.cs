using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mappings
{
    //Configuração do mapeamento da entidade Produto, criada em um arquivo separado para melhor organização
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Estoque).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(200);
        }
    }
}
