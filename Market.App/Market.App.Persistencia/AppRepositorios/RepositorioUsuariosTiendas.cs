using System.Collections.Generic;
using System.Linq;
using Market.App.Dominio;

namespace Market.App.Persistencia
{
    public class RepositorioUsuariosTiendas : IRepositorioUsuariosTiendas
    {
        private readonly AplicationContext _aplicationContext;

        public RepositorioUsuariosTiendas(AplicationContext aplicationContext)
        {
            _aplicationContext = aplicationContext;
        }
        UsuariosTiendas IRepositorioUsuariosTiendas.AddUsuariosTiendas(UsuariosTiendas usuariosTiendas)
        {
            var usuariosTiendasAdicionados = _aplicationContext.UsuarioTienda.Add(usuariosTiendas);
            _aplicationContext.SaveChanges();
            return usuariosTiendasAdicionados.Entity;
        }

        void IRepositorioUsuariosTiendas.DeleteUsuariosTiendas(int idUsuariosTiendas)
        {
            var usuariosTiendasEncontrados = _aplicationContext.UsuarioTienda.FirstOrDefault(u => u.Id == idUsuariosTiendas);
            if (usuariosTiendasEncontrados != null)
            {
                _aplicationContext.UsuarioTienda.Remove(usuariosTiendasEncontrados);
                _aplicationContext.SaveChanges();
            }
            else
            {
                return;
            }

        }
        IEnumerable<UsuariosTiendas> IRepositorioUsuariosTiendas.GetAllUsuariosTiendas()
        {
            return _aplicationContext.UsuarioTienda;
        }
        UsuariosTiendas IRepositorioUsuariosTiendas.GetUsuariosTiendas(int idUsuariosTiendas)
        {
            return _aplicationContext.UsuarioTienda.FirstOrDefault(u => u.Id == idUsuariosTiendas);
        }


        UsuariosTiendas IRepositorioUsuariosTiendas.UpdateUsuariosTiendas(UsuariosTiendas usuariosTiendas)
        {
            var usuariosTiendasEncontrados = _aplicationContext.UsuarioTienda.FirstOrDefault(u => u.Id == usuariosTiendas.Id);
            if (usuariosTiendasEncontrados != null)
            {
                usuariosTiendasEncontrados.Nombre = usuariosTiendas.Nombre;
                usuariosTiendasEncontrados.Apellidos = usuariosTiendas.Apellidos;
                usuariosTiendasEncontrados.NumeroTelefonico = usuariosTiendas.NumeroTelefonico;
                usuariosTiendasEncontrados.Genero = usuariosTiendas.Genero;
                usuariosTiendasEncontrados.HorarioAtencion = usuariosTiendas.HorarioAtencion;
                usuariosTiendasEncontrados.NombreTienda = usuariosTiendas.NombreTienda;
                usuariosTiendasEncontrados.Nit = usuariosTiendas.Nit;
                usuariosTiendasEncontrados.Domicilios = usuariosTiendas.Domicilios;

                _aplicationContext.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("usuario no encontrado");
            }
            return usuariosTiendasEncontrados;

        }

    }
}