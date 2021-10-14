using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APIProdutos.Models
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext _context;


        public Repository(DatabaseContext ctx )
        {          

            _context = ctx;
        }

        public IEnumerable<Produtos> Produto()
        {
            return _context.produto.ToList();
        }

        public Produtos AdicionaProduto(Produtos produto)
        {
            _context.Add(produto);
            _context.SaveChanges();            
            return produto;
        }

        public void ApagaProduto(int codigo)
        {
            Produtos prod = Obtem(codigo);
            if (prod == null)
                return;

            _context.Remove(prod);
            _context.SaveChanges();
        }

        public Produtos EditaProduto(Produtos produto)
        {
            AdicionaProduto(produto);
            return produto;

        }

        public Produtos Obtem(int codigo)
        {
            return _context.produto.Where(a => a.Codigo == codigo).FirstOrDefault();
        }

        public void GeraDadosIniciais()
        {
            Produtos prod = new Produtos()
            {
                Codigo = 1,
                Descricao = "MONITOR",
                Estoque = 10,
                Preco = 800.00M
            };

            AdicionaProduto(prod);

        }
    

    public class DatabaseContext : DbContext
        {
            public  DatabaseContext(DbContextOptions<DatabaseContext> options ) : base(options)
            {

            }

            public DbSet<Produtos> produto { get; set; }
        }






    }
}
