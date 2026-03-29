using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCliente
    {
        public static Cliente Buscar(int pCedula)
        {
            Cliente oCliente = PersistenciaCliente.Buscar(pCedula);

            return oCliente;
        }
        public static void Agregar(Cliente pCliente)
        {
            PersistenciaCliente.Agregar(pCliente);
        }

        public static void Modificar(Cliente pCliente)
        {
            PersistenciaCliente.Modificar(pCliente);
        }

        public static void Eliminar(Cliente pCliente)
        {
            PersistenciaCliente.Eliminar(pCliente);
        }

        public static List<Cliente> ListarClientes()
        {
            return PersistenciaCliente.ListarClientes();
        }
    }
}
