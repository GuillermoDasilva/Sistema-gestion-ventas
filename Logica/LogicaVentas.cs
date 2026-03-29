using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaVentas
    {
        public static int Agregar(Ventas pVentas)
        {
            return PersistenciaVentas.Agregar(pVentas);
        }

        public static int BuscarEstado(string CodigoVenta)
        {
            return PersistenciaVentas.DesplegarEstado(CodigoVenta);
        }
        public static int CambiarEstado(string CodigoVenta)
        {
            return PersistenciaVentas.CambiarEstado(CodigoVenta);
        }

        public static List<Ventas> ListarVentasCliente(String cedula)
        {
            return PersistenciaVentas.ObtenerVentaCliente(cedula);
        }
    
        public static List<Ventas> ListarVentasAE()
        {
            return PersistenciaVentas.ListarVentasAE();
        }

        public static List<Ventas> ListarVentas(String CodigoArticuloAsp)
        {
            return PersistenciaVentas.ListarVentas(CodigoArticuloAsp);
        }

    }
}
