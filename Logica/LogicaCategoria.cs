using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCategoria
    {
        public static Categoria Buscar(string pCodigo)
        {
            Categoria oCategoria = PersistenciaCategoria.Buscar(pCodigo);

            return oCategoria;
        }

        public static void Agregar(Categoria pCategoria)
        {
            PersistenciaCategoria.Agregar(pCategoria);
        }

        public static void Modificar(Categoria pCategoria)
        {
            PersistenciaCategoria.Modificar(pCategoria);
        }

        public static void Eliminar(Categoria pCategoria)
        {
            PersistenciaCategoria.Eliminar(pCategoria);
        }

        public static List<Categoria> ListarCategoria()
        {
            return PersistenciaCategoria.ListarCategoria();
        }
    }
}
