using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.App.Dominio;

namespace Market.App.Persistencia
{
    public interface IRepositorioPedidos
    {
        IEnumerable<Pedidos> GetAllPedidos();
        Pedidos AddPedidos(Pedidos pedidoss);
        Pedidos UpdatePedidos(Pedidos pedidos);
        void DeletePedidos(int idPedidos);
        Pedidos GetPedidos(int idPedidos);

    }
}