using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.App.Dominio;

namespace Market.App.Persistencia
{
    public interface IRepositorioCatalogo
    {
        IEnumerable<Catalogo> GetAllCatalogo();
        Catalogo AddCatalogo(Catalogo catalogo);
        Catalogo UpdateCatalogo(Catalogo catalogo);
        void DeleteCatalogo(int idCatalogo);
        Catalogo GetCatalogo(int idCatalogo);

    }
}