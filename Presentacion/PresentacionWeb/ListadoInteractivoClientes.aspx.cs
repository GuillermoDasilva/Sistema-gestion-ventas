using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

using System.Drawing;

namespace PresentacionWeb
{
    public partial class ListadoInteractivoClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                LimpioFormulario();
                CargoDatoscliente();
            }
        }

        private void OrednarVentasFecha(List<Ventas> ventas)
        {
            int n = ventas.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (ventas[j].FechaVenta > ventas[j + 1].FechaVenta)
                    {
                        Ventas temp = ventas[j];
                        ventas[j] = ventas[j + 1];
                        ventas[j + 1] = temp;
                    }
                }
            }
        }

        private void LimpioFormulario()
        {
            GridVentas.DataSource = null;
            GridVentas.DataBind();
            GridArticulos.DataSource = null;
            GridArticulos.DataBind();
        }

        protected void CargoDatoscliente()
        {
            try
            {
                //traigo los clientes de sql
                btnLimpiar.Enabled = true;


                List<Cliente> colClientes = Logica.LogicaCliente.ListarClientes();

                Session["ListaCliente"] = colClientes;

                if (colClientes.Count > 0)
                {
                    GridDatosClientes.DataSource = colClientes;
                    GridDatosClientes.DataBind();
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No existen ningun cliente ";

                }

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void CargoDatosventas(string cedula)
        {
            try
            {
                btnLimpiar.Enabled = true;

                //traigo las ventas del cliente por su cedula 
                List<Ventas> colventas = Logica.LogicaVentas.ListarVentasCliente(cedula);
                OrednarVentasFecha(colventas);
                Session["Listaventas"] = colventas;

                if (colventas.Count > 0)
                {
                    GridVentas.DataSource = colventas;
                    GridVentas.DataBind();
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No existen ningua venta ";

                }

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void CargoDatosArticulo(string cedula)
        {
            try
            {

                List<Ventas> colventas = (List<Ventas>)Session["Listaventas"];

                if (colventas != null && colventas.Count > 0)
                {
                    // esta lista la utilizo para guardar los articulos que no estan repetidos 
                    List<string> codigosArticulos = new List<string>();


                    //recorro la lisa guardando solo los que no estan repetidos 
                    for (int i = 0; i < colventas.Count; i++)
                    {

                        string codigoArticulo = colventas[i].Art.Codigo;

                        //verifico que no esten repetidos usando la propiedad de list . contain
                        if (!codigosArticulos.Contains(codigoArticulo))
                        {
                            codigosArticulos.Add(codigoArticulo);
                        }
                    }

                    // Esta es la lista final de articulos no repetidos 
                    List<Articulos> colArticulos = new List<Articulos>();

                    //traigo los datos de los articulo que no estan repetidos 
                    for (int i = 0; i < codigosArticulos.Count; i++)
                    {

                        List<Articulos> articulos = Logica.LogicaArticulos.ListarArticulosCodigo(codigosArticulos[i]);


                        if (articulos != null && articulos.Count > 0)
                        {
                            colArticulos.AddRange(articulos);
                        }
                    }

                    // los ordno alfabeticamente antes de agregarlos a la grid 
                    ordenarArticulosPorNombre(colArticulos);

                    Session["ListaArticulos"] = colArticulos;

                    if (colArticulos.Count > 0)
                    {
                        GridArticulos.DataSource = colArticulos;
                        GridArticulos.DataBind();
                    }
                    else
                    {
                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "No se encontraron articulos para este cliente.";
                    }
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No hay ventas registradas para este cliente.";
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Error al cargar los datos del articulo: " + ex.Message;
            }
        }

        protected void GridDatosClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            // obtengo la cedula del cliente da la row cedula 
            GridViewRow row = GridDatosClientes.SelectedRow;
            string cedula = row.Cells[2].Text;
            // la utilido para llamar a los procedimientos 
            CargoDatosventas(cedula);
            CargoDatosArticulo(cedula);
            CalcularTotalGastado();
        }

        protected void CalcularTotalGastado()
        {
            try
            {

                List<Ventas> colventas = (List<Ventas>)Session["Listaventas"];

                if (colventas != null && colventas.Count > 0)
                {

                    decimal totalGastado = 0;


                    for (int i = 0; i < colventas.Count; i++)
                    {
                        //hago la sumatoria en base a la cantidad del articulo y su precio 
                        Articulos articulo = colventas[i].Art;


                        int cantidadComprada = colventas[i].Cantidad;


                        decimal precioArticulo = Convert.ToDecimal(articulo.Precio);


                        decimal subtotal = precioArticulo * cantidadComprada;
                        totalGastado += subtotal;
                    }

                    // lo desplego en la lbl

                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "Total gastado por el cliente: $" + totalGastado;
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No hay ventas registradas para este cliente.";
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Error al calcular el total gastado: " + ex.Message;
            }
        }

        private void ordenarArticulosPorNombre(List<Articulos> articulos)
        {
            int n = articulos.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {

                    if (string.Compare(articulos[j].Nombre, articulos[j + 1].Nombre) > 0)
                    {
                        Articulos temp = articulos[j];
                        articulos[j] = articulos[j + 1];
                        articulos[j + 1] = temp;
                    }
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void GridDatosVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}