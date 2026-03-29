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
    public class PersistenciaCategoria
    {
        public static Categoria Buscar(string pCodigo)
        {
            string nombre;
            Categoria oCategoria = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pCodigo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombre = (string)oReader["nombre"];

                        oCategoria = new Categoria(pCodigo, nombre);
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
            return oCategoria;
        }

        public static void Agregar(Categoria pCategoria)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Codigo", pCategoria.Codigo);
            oComando.Parameters.AddWithValue("@nombre", pCategoria.Nombre);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("Código Incorrecto");

                else if (resultado == -2)
                    throw new Exception("Ya existe una Categoria con ese Código");

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

        public static void Modificar(Categoria pCategoria)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pCategoria.Codigo);
            oComando.Parameters.AddWithValue("@nombre", pCategoria.Nombre);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("Código Incorrecto");

                else if (resultado == -2)
                    throw new Exception("No existe - No se modifica");

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

        public static void Eliminar(Categoria pCategoria)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pCategoria.Codigo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("No existe una Categoria en ese Código");

                else if (resultado == -2)
                    throw new Exception("Hay Artículos asociados - No se elimina");

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

        public static List<Categoria> ListarCategoria()
        {
            string codigo;
            string nombre;
            List<Categoria> colCategoria = new List<Categoria>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("listarcategorias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigo = (string)oReader["codigo"];
                        nombre = (string)oReader["nombre"];

                        Categoria oCategoria = new Categoria(codigo, nombre);
                        colCategoria.Add(oCategoria);
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
            return colCategoria;
        }
    }
}
