using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.App.Dominio;

namespace Market.App.Persistencia
{
    public interface IRepositorioUsuariosTiendas
    {
        IEnumerable<UsuariosTiendas> GetAllUsuariosTiendas();
        UsuariosTiendas AddUsuariosTiendas(UsuariosTiendas UsuariosTiendas);
        UsuariosTiendas UpdateUsuariosTiendas(UsuariosTiendas UsuariosTiendas);
        void DeleteUsuariosTiendas(int idUsuariosTiendas);
        UsuariosTiendas GetUsuariosTiendas(int idUsuariosTiendas);

    }
}