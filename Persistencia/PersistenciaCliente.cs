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
    public class PersistenciaCliente
    {
        public static Cliente Buscar(int pCedula)
        {
            string nombre;
            int telefono;
            long numTarejta;
            Cliente oCliente = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("buscarcliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cedula", pCedula);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombre = (string)oReader["nombrecompleto"];
                        telefono = Convert.ToInt32(oReader["telefono"]);
                        numTarejta = Convert.ToInt64(oReader["numerodetarjeta"]);

                        oCliente = new Cliente(pCedula, nombre, numTarejta, telefono);
                    }
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
            return oCliente;
        }

        public static void Agregar(Cliente pCliente)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Cedula", pCliente.Cedula);
            oComando.Parameters.AddWithValue("@NombreCompleto", pCliente.NombreCompleto);
            oComando.Parameters.AddWithValue("@Telefono", pCliente.Telefono);
            oComando.Parameters.AddWithValue("@NumeroDeTarjeta", pCliente.NumTarjeta);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("Ya existe el cliente");

                //else if (resultado == -2)
                //    throw new Exception("Error Inesperado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Modificar(Cliente pCliente)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarCaliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Cedula", pCliente.Cedula);
            oComando.Parameters.AddWithValue("@NombreCompleto", pCliente.NombreCompleto);
            oComando.Parameters.AddWithValue("@Telefono", pCliente.Telefono);
            oComando.Parameters.AddWithValue("@NumeroDeTarjeta", pCliente.NumTarjeta);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("No existe el Cliente");

                else if (resultado == -2)
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
        }

        public static void Eliminar(Cliente pCliente)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Cedula", pCliente.Cedula);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("No existe una Cliente con esa Cédula");

                else if (resultado == -2)
                    throw new Exception("Hay Ventas asociados - No se elimina");

                else if (resultado == -3)
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
        }

        public static List<Cliente> ListarClientes()
        {
            int cedula;
            string nombre;
            int telefono;
            long numTarejta;
            List<Cliente> colCliente = new List<Cliente>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("listarclientes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        cedula = Convert.ToInt32(oReader["cedula"]);
                        nombre = (string)oReader["nombrecompleto"];
                        telefono = Convert.ToInt32(oReader["telefono"]);
                        numTarejta = Convert.ToInt64(oReader["numerodetarjeta"]);

                        Cliente oCliente = new Cliente(cedula, nombre, numTarejta, telefono);
                        colCliente.Add(oCliente);
                    }
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
            return colCliente;
        }

        public static Cliente ObtenerCliente(string cedula)
        {
            Cliente cliente = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ObtenerCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@Cedula", cedula);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {

                    string Cedula = oReader["Cedula"].ToString();
                    string NombreCompleto = oReader["NombreCompleto"].ToString();
                    string Telefono = oReader["Telefono"].ToString();
                    long NumeroDeTarjeta = Convert.ToInt64(oReader["NumeroDeTarjeta"]);
                    cliente = new Cliente(Convert.ToInt32(Cedula), NombreCompleto.Trim(), NumeroDeTarjeta, Convert.ToInt32(Telefono));

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

            return cliente;
        }
    }
}
