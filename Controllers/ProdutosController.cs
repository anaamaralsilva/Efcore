using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Efcore.Domains;
using Efcore.Interfaces;
using Efcore.Repositories;
using Efcore.Utlls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Efcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
    private readonly IProdutoRepository _produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os produtos no repositorio
                var produtos = _produtoRepository.Listar();

                //Verificar se existe produtos, se não existir ira retornar Sem Conteudo
                if (produtos.Count == 0)
                    return NoContent();

                //Se existir retornara ok
                return Ok(new {
                    totalCount = produtos.Count,
                    data = produtos
                });
            }
            catch(Exception ex)
            {
                //Se dar algum erro retornara BadRequest e uma mensagem de erro
                return BadRequest(new {
                    StatusCode = 400,
                    error = ex.Message
                }
                    );
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //buscar produto no repositorio
                Produto produto = _produtoRepository.BuscarPorId(id);

                //verificar se o produto existe, caso não exista retornar com NotFund
                if (produto == null)
                    return NotFound();

                Moeda dolar = new Moeda();

                //caso o produto exista retornara ok junto com os dados do produto
                return Ok(new {
                    produto, 
                    valorDolar = dolar.GetDolarValue() * produto.Preco   
                });
            }
            catch (Exception ex)
            {
                //se ocorrer algum erro retornara Badrequest com a mensagem de erro 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Post([FromForm] Produto produto)
        {
            try
            {
                if (produto.Imagem != null)
                {
                    var urlImagem = Upload.Local(produto.Imagem);

                    produto.UrlImagem = urlImagem;
                }


                // Adiciona um produto
                _produtoRepository.Adicionar(produto);

                // retorna ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);

                if (produtoTemp == null)
                    return NotFound();

                produto.Id = id;
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }

            catch (Exception ex)
            {
                //se ocorrer algum erro retornara Badrequest com a mensagem de erro 
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                //se ocorrer algum erro retornara Badrequest com a mensagem de erro 
                return BadRequest(ex.Message);
            }
        }


    }

}
