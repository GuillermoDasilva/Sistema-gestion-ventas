using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaArticulos
    {
        public static Articulos Buscar(string pCodigo)
        {
            Articulos oArticulos = PersistenciaArticulos.Buscar(pCodigo);

            return oArticulos;
        }

        public static void Agregar(Articulos pArticulos)
        {
            PersistenciaArticulos.Agregar(pArticulos);
        }

        public static void Modificar(Articulos pArticulos)
        {
            PersistenciaArticulos.Modificar(pArticulos);
        }

        public static void Eliminar(Articulos pArticulos)
        {
            PersistenciaArticulos.Eliminar(pArticulos);
        }

        public static List<Articulos> ListarArticulos()
        {
            return PersistenciaArticulos.ListarArticulos();
        }

        public static List<Articulos> ListarArticulosCodigo(String CodigoArticulo)
        {
            return PersistenciaArticulos.ListarArticulosCodigo(CodigoArticulo);
        }

        public static List<Articulos> ListarArticulos2(String CodigoCategoria)
        {
            return PersistenciaArticulos.ListarArticulos2(CodigoCategoria);

        }
    }
}
