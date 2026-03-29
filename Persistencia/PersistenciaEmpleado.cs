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
    public class PersistenciaEmpleado
    {
        public static Empleado Logueo(string pUsu, string pPass, string pNombre)
        {
            Empleado oEmpleado = null;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Usu", pUsu);
            oComando.Parameters.AddWithValue("@Pass", pPass);
            oComando.Parameters.AddWithValue("@nombre", pNombre);

            try
            {
                oConexion.Open();
                SqlDataReader oLector = oComando.ExecuteReader();

                if (oLector.HasRows)
                {
                    if (oLector.Read())
                    {
                        oEmpleado = new Empleado((string)oLector["contraseña"], (string)oLector["UsuarioLogeo"], (string)oLector["nombre"]);
                    }
                }
                oLector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return oEmpleado;
        }

        public static Empleado ObtenerEmpleado(string usuarioLogeo)
        {
            Empleado empleado = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ObtenerEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@UsuarioLogeo", usuarioLogeo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {


                    string UsuarioLogeo = oReader["UsuarioLogeo"].ToString();
                    string Nombre = oReader["Nombre"].ToString();
                    string Contraseña = oReader["contraseña"].ToString();


                    empleado = new Empleado(Contraseña, usuarioLogeo, Nombre);
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

            return empleado;
        }
    }
}
