using System.Collections.Generic;
using System.Linq;
using Market.App.Dominio;

namespace Market.App.Persistencia
{
    public class RepositorioCatalogo : IRepositorioCatalogo
    {
        private readonly AplicationContext _aplicationContext;

        public RepositorioCatalogo(AplicationContext aplicationContext)
        {
            _aplicationContext = aplicationContext;
        }
        Catalogo IRepositorioCatalogo.AddCatalogo(Catalogo catalogo)
        {
            var catalogoAdicionados = _aplicationContext.Catalogos.Add(catalogo);
            _aplicationContext.SaveChanges();
            return catalogoAdicionados.Entity;
        }

        void IRepositorioCatalogo.DeleteCatalogo(int idCatalogo)
        {
            var catalogoEncontrados = _aplicationContext.Catalogos.FirstOrDefault(u => u.Id == idCatalogo);
            if (catalogoEncontrados != null)
            {
                _aplicationContext.Catalogos.Remove(catalogoEncontrados);
                _aplicationContext.SaveChanges();
            }
            else
            {
                return;
            }

        }
        IEnumerable<Catalogo> IRepositorioCatalogo.GetAllCatalogo()
        {
            return _aplicationContext.Catalogos;
        }
        Catalogo IRepositorioCatalogo.GetCatalogo(int idCatalogo)
        {
            return _aplicationContext.Catalogos.FirstOrDefault(u => u.Id == idCatalogo);
        }


        Catalogo IRepositorioCatalogo.UpdateCatalogo(Catalogo catalogo)
        {
            var catalogoEncontrados = _aplicationContext.Catalogos.FirstOrDefault(u => u.Id == catalogo.Id);
            if (catalogoEncontrados != null)
            {
                catalogoEncontrados.Id = catalogo.Id;
                catalogoEncontrados.NombreProductos = catalogo.NombreProductos;
                catalogoEncontrados.Precio = catalogo.Precio;
                catalogoEncontrados.Cantidad = catalogo.Cantidad;
                catalogoEncontrados.Descripcion = catalogo.descripcion;
                _aplicationContext.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Catalogo no encontrado");
            }
            return catalogo;
        }

    }
}