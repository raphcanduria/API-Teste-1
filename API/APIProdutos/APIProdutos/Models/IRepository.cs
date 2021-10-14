using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProdutos.Models
{
    public interface IRepository
    {
        public IEnumerable<Produtos> Produto();
        public Produtos AdicionaProduto(Produtos produto);
        public Produtos EditaProduto(Produtos produto);
        public void ApagaProduto(int codigo);
        public Produtos Obtem(int codigo);
        public void GeraDadosIniciais();
    }
}
