using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.App.Dominio;

namespace Market.App.Persistencia
{
    public interface IRepositorioDomicilios
    {
        IEnumerable<Domicilios> GetAllDomicilios();
        Domicilios AddDomicilios(Domicilios domicilios);
        Domicilios UpdateDomicilios(Domicilios domicilios);
        void Domicilios(int idDomicilios);
        Domicilios GetDomicilios(int idDomicilios);

    }
}