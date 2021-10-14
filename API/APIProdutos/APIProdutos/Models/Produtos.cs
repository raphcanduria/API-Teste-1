using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APIProdutos.Models
{
    public class Produtos
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public decimal Preco { get; set; }

    }
}
