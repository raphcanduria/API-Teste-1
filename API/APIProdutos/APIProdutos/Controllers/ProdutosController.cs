using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using APIProdutos.Models;

namespace APIProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IRepository repository;

        public ProdutosController(IRepository r) => repository = r;

        [HttpGet]
        public IEnumerable<Produtos> Get() => repository.Produto();

        [HttpGet("{codigo}")]
        public Produtos Get(int codigo) => repository.Obtem(codigo);

        [HttpPost]
        public Produtos Post([FromBody] Produtos prod) =>
            repository.AdicionaProduto(new Produtos
            {
                Descricao = prod.Descricao,
                Estoque = prod.Estoque,
                Preco = prod.Preco
            }  );

        [HttpPut]
        public Produtos Put([FromForm] Produtos prod) => repository.EditaProduto(prod);

        [HttpPatch("{codigo}")]
        public StatusCodeResult Patch(int codigo, [FromForm]JsonPatchDocument<Produtos> patch)
        {
            Produtos prod = Get(codigo);
            if (prod != null)
            {
                patch.ApplyTo(prod);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{codigo}")]
        public void Delete(int codigo) => repository.ApagaProduto(codigo);


    }
}
