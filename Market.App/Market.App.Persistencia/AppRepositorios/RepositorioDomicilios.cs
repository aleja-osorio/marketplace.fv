using System.Collections.Generic;
using System.Linq;
using Market.App.Dominio;

namespace Market.App.Persistencia
{
    public class RepositorioDomicilios : IRepositorioDomicilios
    {
        private readonly AplicationContext _aplicationContext;

        public RepositorioDomicilios(AplicationContext aplicationContext)
        {
            _aplicationContext = aplicationContext;
        }
        Domicilios IRepositorioDomicilios.AddDomicilios(Domicilios domicilios)
        {
            var domiciliosAdicionados = _aplicationContext.Domicilio.Add(Domicilios);
            _aplicationContext.SaveChanges();
            return domiciliosAdicionados.Entity;
        }

        void IRepositorioDomicilios.DeleteDomicilios(int idDomicilios)
        {
            var domiciliosEncontrados = _aplicationContext.Domicilio.FirstOrDefault(u => u.Id == idDomicilios);
            if (domiciliosEncontrados != null)
            {
                _aplicationContext.Domicilio.Remove(domiciliosEncontrados);
                _aplicationContext.SaveChanges();
            }
            else
            {
                return;
            }

        }
        IEnumerable<Domicilios> IRepositorioDomicilios.GetAllDomicilios()
        {
            return _aplicationContext.Domicilio;
        }
        Domicilios IRepositorioDomicilios.GetDomicilios(int idDomicilios)
        {
            return _aplicationContext.Domicilio.FirstOrDefault(u => u.Id == idDomicilios);
        }


        Domicilios IRepositorioDomicilios.UpdateDomicilios(Domicilios domicilios)
        {
            var domiciliosEncontrados = _aplicationContext.Domicilio.FirstOrDefault(u => u.Id == domicilios.Id);
            if (domiciliosEncontrados != null)
            {
                domiciliosEncontrados.Id = domicilios.Id;
                domiciliosEncontrados.Nombre = domicilios.Nombre;
                domiciliosEncontrados.TipoVehiculo = domicilios.TipoVehiculo;
                domiciliosEncontrados.IdVehiculo = domicilios.IdVehiculo;
                domiciliosEncontrados.EstadoPedido = domicilios.EstadoPedido;
                _aplicationContext.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Informacion del domicilio no encontrada");
            }
            return domiciliosEncontrados;
        }

    }
}