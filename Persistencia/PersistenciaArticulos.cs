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
    public class PersistenciaArticulos
    {
        public static Articulos Buscar(string pCodigo)
        {
            string tipo;
            string nombre;
            int precio;
            int tamaño;
            string codigoCat;
            Articulos oArticulos = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarArticulos", oConexion);
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
                        codigoCat = (string)oReader["codigocategoria"];
                        tipo = (string)oReader["tipo"];
                        nombre = (string)oReader["nombre"];
                        precio = Convert.ToInt32(oReader["precio"]);
                        tamaño = Convert.ToInt32(oReader["tamaño"]);
                        Categoria oCategoria = PersistenciaCategoria.Buscar(codigoCat);
                        if (oCategoria == null)
                            throw new Exception("El código de la categoria no existe");

                        oArticulos = new Articulos(pCodigo, nombre, tipo, tamaño, precio, oCategoria);
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
            return oArticulos;
        }

        public static void Agregar(Articulos pArticulos)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("altaarticulos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Codigo", pArticulos.Codigo);
            oComando.Parameters.AddWithValue("@nombre", pArticulos.Nombre);
            oComando.Parameters.AddWithValue("@precio", pArticulos.Precio);
            oComando.Parameters.AddWithValue("@tipo", pArticulos.Tipo);
            oComando.Parameters.AddWithValue("@tamaño", pArticulos.Tamaño);
            oComando.Parameters.AddWithValue("@codigoCat", pArticulos.Cat.Codigo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("Ya existe un Artículo con ese Código");

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

        public static void Modificar(Articulos pArticulos)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarArticulos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pArticulos.Codigo);
            oComando.Parameters.AddWithValue("@nombre", pArticulos.Nombre);
            oComando.Parameters.AddWithValue("@precio", pArticulos.Precio);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("No existe - No se modifica");

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

        public static void Eliminar(Articulos pArticulos)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarArticulos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pArticulos.Codigo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oRetorno.Value);

                if (resultado == -1)
                    throw new Exception("No existe un Artículo en ese Código");

                else if (resultado == -2)
                    throw new Exception("Hay Ventas asociadas - No se elimina");

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

        public static List<Articulos> ListarArticulos()
        {
            string codigo;
            string tipo;
            string nombre;
            int precio;
            int tamaño;
            string codigoCat;
            List<Articulos> colArticulos = new List<Articulos>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("listararticulos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigoCat = (string)oReader["codigocategoria"];
                        codigo = (string)oReader["codigo"];
                        tipo = (string)oReader["tipo"];
                        nombre = (string)oReader["nombre"];
                        precio = Convert.ToInt32(oReader["precio"]);
                        tamaño = Convert.ToInt32(oReader["tamaño"]);
                        Categoria oCategoria = PersistenciaCategoria.Buscar(codigoCat);
                        if (oCategoria == null)
                            throw new Exception("El código de la categoria no existe");

                        Articulos oArticulos = new Articulos(codigo, nombre, tipo, tamaño, precio, oCategoria);
                        colArticulos.Add(oArticulos);
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
            return colArticulos;
        }

        public static Articulos ObtenerArticulo(string codigoArticulo)
        {
            Articulos articulo = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ObtenerArticulo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@Codigo", codigoArticulo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {

                    string Codigo = oReader["Codigo"].ToString();
                    string Nombre = oReader["Nombre"].ToString();
                    string Precio = oReader["Precio"].ToString();
                    string Tipo = oReader["Tipo"].ToString();
                    string Tamaño = oReader["Tamaño"].ToString();
                    string CodigoCat = oReader["CodigoCategoria"].ToString();
                    Categoria oCategoria = PersistenciaCategoria.Buscar(CodigoCat);
                    if (oCategoria == null)
                        throw new Exception("El código de la categoria no existe");

                    articulo = new Articulos(Codigo, Nombre, Tipo, Convert.ToInt32(Tamaño), Convert.ToInt32(Precio), oCategoria);

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

            return articulo;
        }

        public static List<Articulos> ListarArticulosCodigo(String oCodigoArticulo)
        {

            List<Articulos> colArticulos = new List<Articulos>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ObtenerAriculoCodigo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@Codigo", oCodigoArticulo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    string CodigoArticulo = oReader["Codigo"].ToString();
                    string Nombre = oReader["Nombre"].ToString();
                    string Precio = oReader["Precio"].ToString();
                    string Tipo = oReader["Tipo"].ToString();
                    string tamaño = oReader["tamaño"].ToString();
                    string CodigoCat = oReader["CodigoCategoria"].ToString();
                    Categoria oCategoria = PersistenciaCategoria.Buscar(CodigoCat);
                    if (oCategoria == null)
                        throw new Exception("El código de la categoria no existe");

                    Articulos oArticulos = new Articulos(CodigoArticulo, Nombre, Tipo, Convert.ToInt32(tamaño), Convert.ToInt32(Precio), oCategoria);
                    colArticulos.Add(oArticulos);
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

            return colArticulos;
        }

        public static List<Articulos> ListarArticulos2(String CodigoCategoria)
        {

            List<Articulos> colArticulos = new List<Articulos>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ObtenerArticulosPorCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CodigoCategoria", CodigoCategoria);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    string CodigoArticulo = oReader["Codigo"].ToString();
                    string Nombre = oReader["Nombre"].ToString();
                    string Precio = oReader["Precio"].ToString();
                    string Tipo = oReader["Tipo"].ToString();
                    string tamaño = oReader["tamaño"].ToString();
                    string CodigoCat = oReader["CodigoCategoria"].ToString();
                    Categoria oCategoria = PersistenciaCategoria.Buscar(CodigoCat);
                    if (oCategoria == null)
                        throw new Exception("El código de la categoria no existe");
                    Articulos oArticulos = new Articulos(CodigoArticulo, Nombre, Tipo, Convert.ToInt32(tamaño), Convert.ToInt32(Precio), oCategoria);
                    colArticulos.Add(oArticulos);
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

            return colArticulos;
        }

    }
}
