using System.Collections.Generic;
using System.Linq;
using Market.App.Dominio;

namespace Market.App.Persistencia
{
    public class RepositorioPedidos : IRepositorioPedidos
    {
        private readonly AplicationContext _aplicationContext;

        public RepositorioPedidos(AplicationContext aplicationContext)
        {
            _aplicationContext = aplicationContext;
        }
        Pedidos IRepositorioPedidos.AddPedidos(Pedidos pedidos)
        {
            var pedidosAdicionados = _aplicationContext.Pedido.Add(pedidos);
            _aplicationContext.SaveChanges();
            return pedidosAdicionados.Entity;
        }

        void IRepositorioPedidos.DeletePedidos(int idPedidos)
        {
            var pedidosEncontrados = _aplicationContext.Pedido.FirstOrDefault(u => u.Id == idPedidoss);
            if (pedidosEncontrados != null)
            {
                _aplicationContext.Pedido.Remove(pedidosEncontrados);
                _aplicationContext.SaveChanges();
            }
            else
            {
                return;
            }

        }
        IEnumerable<Pedidos> IRepositorioPedidos.GetAllPedidos()
        {
            return _aplicationContext.Pedido;
        }
        Pedidos IRepositorioPedidos.GetPedidos(int idPedidos)
        {
            return _aplicationContext.Pedido.FirstOrDefault(u => u.Id == idPedidos);
        }


        Pedidos IRepositorioPedidos.UpdatePedidos(Pedidos pedidos)
        {
            var pedidosEncontrados = _aplicationContext.Pedido.FirstOrDefault(u => u.Id == pedidos.Id);
            if (pedidosEncontrados != null)
            {
                pedidosEncontrados.Id = pedidos.Id;
                pedidosEncontrados.FechaPedido = pedidos.FechaPedido;
                pedidosEncontrados.IdUsuarios = pedidos.IdUsuarios;
                pedidosEncontrados.NumProductos = pedidos.NumProductos;
                pedidosEncontrados.PrecioProducto = pedidos.PrecioProducto;
                pedidosEncontrados.Factura = pedidos.Factura;
                _aplicationContext.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Informacion del pedido no encontrada");
            }
            return pedidos;
        }

    }
}