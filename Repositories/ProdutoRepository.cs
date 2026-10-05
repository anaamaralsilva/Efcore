using Efcore.Contexts;
using Efcore.Domains;
using Efcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efcore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository(PedidoContext context)
        {
            _ctx = context;
        }
        
        public void Adicionar(Produto produto)
        {
            try
            {
                _ctx.Produtos.Add(produto);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Produtos.Find(id);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> BuscarPorNome(string nome)
        {
             try
            {
                
                List<Produto> produtos = _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
              
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                Produto produtoTemp = BuscarPorId(produto.Id);

                //if (produtoTemp == null)
                 // throw new Exception("Produto não encontrado");

                //Alterar as propiedades do produto
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Alterar o produto no contexto
                _ctx.Produtos.Update(produtoTemp);
                //Salvar o produto
                _ctx.SaveChanges();



                _ctx.Produtos.Remove(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                List<Produto> produtos = _ctx.Produtos.ToList();

                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                Produto produto = BuscarPorId(id);

                if (produto == null)
                    throw new Exception("Produto não encontrado");

                _ctx.Produtos.Remove(produto);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
