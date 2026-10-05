using Efcore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efcore.Interfaces
{
     public interface IProdutoRepository
    {
        List<Produto> Listar();
        List<Produto> BuscarPorNome(string nome);
        Produto BuscarPorId(Guid id);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Remover(Guid id);

    }
}
