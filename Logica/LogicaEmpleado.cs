using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaEmpleado
    {
        public static Empleado Logueo(string pUsu, string pPass, string pNombre)
        {
            Empleado oEmpleado = null;

            oEmpleado = PersistenciaEmpleado.Logueo(pUsu, pPass, pNombre);

            return oEmpleado;
        }
    }
}
