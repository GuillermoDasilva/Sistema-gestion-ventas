using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia
{
    public class PersistenciaVentas
    {
        public static int Agregar(Ventas pVentas)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaVentas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@fechaVenta", pVentas.FechaVenta);
            oComando.Parameters.AddWithValue("@estado", pVentas.Estado);
            oComando.Parameters.AddWithValue("@direccion", pVentas.Direccion);
            oComando.Parameters.AddWithValue("@cantidad", pVentas.Cantidad);
            oComando.Parameters.AddWithValue("@cedulacliente", pVentas.Cli.Cedula);
            oComando.Parameters.AddWithValue("@codigoarticulo", pVentas.Art.Codigo);
            oComando.Parameters.AddWithValue("@empleadoasociado", pVentas.Emp.UsuDeLogueo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int resultado = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                resultado = (int)oRetorno.Value;

                if (resultado == -1)
                    throw new Exception("No existe el Artículo");

                else if (resultado == -2)
                    throw new Exception("El Cliente no existe");

                else if (resultado == -3)
                    throw new Exception("El Empleado no existe");

                else if (resultado == -4)
                    throw new Exception("La Fecha de Venta tiene que ser la actual");

                else if (resultado == -5)
                    throw new Exception("Ocurrió un error inesperado");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return resultado;
        }

        public static List<Ventas> ListarVentas(string CodigoArticuloAsp)
        {
            List<Ventas> colventas = new List<Ventas>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ObtenerVentasPorArticulos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CodigoArticulo", CodigoArticuloAsp);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {

                    string NumeroDeVenta = oReader["NumeroDeVenta"].ToString();
                    DateTime fechaVenta = Convert.ToDateTime(oReader["fechaVenta"]);
                    int cantidad = Convert.ToInt32(oReader["cantidad"]);
                    string Estado = oReader["Estado"].ToString();
                    string Direccion = oReader["Direccion"].ToString();
                    string EmpleadoAsociado = oReader["EmpleadoAsociado"].ToString();
                    string CedulaCliente = oReader["CedulaCliente"].ToString();
                    string CodigoArticulo = oReader["CodigoArticulo"].ToString();


                    Empleado empleado = PersistenciaEmpleado.ObtenerEmpleado(EmpleadoAsociado);
                    Articulos articulo = PersistenciaArticulos.ObtenerArticulo(CodigoArticulo);
                    Cliente cliente = PersistenciaCliente.ObtenerCliente(CedulaCliente);


                    Ventas oVentas = new Ventas(Convert.ToInt32(NumeroDeVenta), fechaVenta, cantidad, Estado, Direccion, empleado, cliente, articulo);
                    colventas.Add(oVentas);
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return colventas;
        }

        public static List<Ventas> ObtenerVentaCliente(string Cedula)
        {
            List<Ventas> colventas = new List<Ventas>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ObtenerVentaCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@Cedula", Cedula);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {

                    string NumeroDeVenta = oReader["NumeroDeVenta"].ToString();
                    DateTime fechaVenta = Convert.ToDateTime(oReader["fechaVenta"]);
                    int cantidad = Convert.ToInt32(oReader["cantidad"]);
                    string Estado = oReader["Estado"].ToString();
                    string Direccion = oReader["Direccion"].ToString();
                    string EmpleadoAsociado = oReader["EmpleadoAsociado"].ToString();
                    string CedulaCliente = oReader["CedulaCliente"].ToString();
                    string CodigoArticulo = oReader["CodigoArticulo"].ToString();



                    Empleado empleado = PersistenciaEmpleado.ObtenerEmpleado(EmpleadoAsociado);
                    Articulos articulo = PersistenciaArticulos.ObtenerArticulo(CodigoArticulo);
                    Cliente cliente = PersistenciaCliente.ObtenerCliente(CedulaCliente);

                    Ventas oVentas = new Ventas(Convert.ToInt32(NumeroDeVenta), fechaVenta, cantidad, Estado, Direccion, empleado, cliente, articulo);
                    colventas.Add(oVentas);
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return colventas;
        }

        public static List<Ventas> ListarVentasAE()
        {
            List<Ventas> colventas = new List<Ventas>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ObtenerVentaArmadoEnviado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {

                    string NumeroDeVenta = oReader["NumeroDeVenta"].ToString();
                    DateTime fechaVenta = Convert.ToDateTime(oReader["fechaVenta"]);
                    int cantidad = Convert.ToInt32(oReader["cantidad"]);
                    string Estado = oReader["Estado"].ToString();
                    string Direccion = oReader["Direccion"].ToString();
                    string EmpleadoAsociado = oReader["EmpleadoAsociado"].ToString();
                    string CedulaCliente = oReader["CedulaCliente"].ToString();
                    string CodigoArticulo = oReader["CodigoArticulo"].ToString();



                    Empleado empleado = PersistenciaEmpleado.ObtenerEmpleado(EmpleadoAsociado);
                    Articulos articulo = PersistenciaArticulos.ObtenerArticulo(CodigoArticulo);
                    Cliente cliente = PersistenciaCliente.ObtenerCliente(CedulaCliente);

                    Ventas oVentas = new Ventas(Convert.ToInt32(NumeroDeVenta), fechaVenta, cantidad, Estado, Direccion, empleado, cliente, articulo);
                    colventas.Add(oVentas);
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return colventas;
        }

        public static int CambiarEstado(string CodigoVenta)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Seguimientodeventa", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numerodeventa", CodigoVenta);


            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int resultado = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                resultado = (int)oRetorno.Value;

                if (resultado == -1)
                    throw new Exception("no se encontro el estado para este numero de venta");
                if (resultado == -2)
                    throw new Exception("transaccion fallida");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return resultado;
        }

        public static int DesplegarEstado(string CodigoVenta)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("desplegestadoactual", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoVenta", CodigoVenta);


            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int resultado = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                resultado = (int)oRetorno.Value;

                if (resultado == 0)
                    throw new Exception("no se encontro el estado para este numero de venta");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return resultado;
        }


    }
}
