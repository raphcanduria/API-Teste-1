using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProduto.Models
{
    public class Produtos
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal Preco { get; set; }
    }
}
