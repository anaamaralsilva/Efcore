using Efcore.Domains;
using Microsoft.EntityFrameworkCore;

namespace Efcore.Contexts
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }

        public PedidoContext(DbContextOptions<PedidoContext> options)
            : base(options)
        {
        }
    }
}
