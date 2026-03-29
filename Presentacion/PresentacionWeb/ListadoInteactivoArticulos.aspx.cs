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
    public partial class ListadoInteactivoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                LimpioFormulario();
                CargoDatosCategoria();
            }
        }

        private void LimpioFormulario()
        {

            ddlArticulos.Enabled = false;
            btnLimpiar.Enabled = false;
            lblError.Text = "";

            GridDatosVentasCompleta.DataSource = null;
            GridDatosVentasCompleta.DataBind();
            GridDatosVentas.DataSource = null;
            GridDatosVentas.DataBind();
            GridDatosArticulo.DataSource = null;
            GridDatosArticulo.DataBind();


        }
        private void OrednarVentasFecha(List<Ventas> ventas)
        {

            // allgoritmo burbuja para oreednar por fecha

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

        protected void CargoDatosVentas()
        {
            try
            {
                GridDatosVentas.DataSource = null;
                GridDatosVentas.DataBind();
                // cargo en la gird los datos de la venta del articulo 
                string codigoArticulo = ddlArticulos.SelectedValue;
                List<Ventas> colventas = Logica.LogicaVentas.ListarVentas(codigoArticulo);
                //las ordeno por fecha antes de cargarlas en la grid 
                OrednarVentasFecha(colventas);
                Session["Ventas"] = colventas;
                Articulos ArticuloSeleccionado = null;


                GridDatosVentas.DataSource = colventas;
                GridDatosVentas.DataBind();




            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void CargoDatosArticulo(string CodigoCategoria)
        {
            try
            {
                //cargo los articulos almacenados en el ddl de Articulos

                btnLimpiar.Enabled = true;
                ddlArticulos.Enabled = true;

                List<Articulos> colArticulos = Logica.LogicaArticulos.ListarArticulos2(CodigoCategoria);

                Session["ListaArticulos"] = colArticulos;

                if (colArticulos.Count > 0)
                {
                    ddlArticulos.DataSource = colArticulos;
                    ddlArticulos.DataValueField = "Codigo";
                    ddlArticulos.DataTextField = "Nombre";
                    ddlArticulos.DataBind();
                    ddlArticulos.Items.Insert(0, new ListItem("------------"));
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No existen ningun articulo ";

                }

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void CargoDatosCategoria()
        {
            try
            {
                //cargo las catecorias almacenadas en el ddl de categoria
                List<Categoria> colCategorias = Logica.LogicaCategoria.ListarCategoria();

                Session["ListaCategorias"] = colCategorias;

                if (colCategorias.Count > 0)
                {
                    ddlCategoria.DataSource = colCategorias;
                    ddlCategoria.DataValueField = "Codigo";
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem("------------"));



                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No existen ninguna categoria ";

                }

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpioFormulario();

            if (ddlCategoria.SelectedIndex > 0)
            {
                // si se selecciona una categoria utilizo el codigo de la categoria que guarde en el datavalue para traer de sql los articulos correspondientes a dicha categoria 
                CargoDatosArticulo(ddlCategoria.SelectedValue.ToString());
            }
        }

        protected void ddlArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // me aseguro que las grid esten vacias 
                GridDatosVentas.DataSource = null;
                GridDatosVentas.DataBind();
                GridDatosArticulo.DataSource = null;
                GridDatosArticulo.DataBind();
                GridDatosVentasCompleta.DataSource = null;
                GridDatosVentasCompleta.DataBind();

                CargoDatosVentas();

                if (ddlArticulos.SelectedIndex > 0)
                {

                    string codigoArticulo = ddlArticulos.SelectedValue;

                    // creo una col de articulos que ya cargue en la session para evitar llamar otra vez el procedimiento alamacenado 
                    List<Articulos> colArticulos = (List<Articulos>)Session["ListaArticulos"];
                    Articulos ArticuloSeleccionado = null;

                    //busco el articulo seleccionado en la col 
                    for (int i = 0; i < colArticulos.Count; i++)
                    {
                        if (colArticulos[i].Codigo == codigoArticulo)
                        {
                            ArticuloSeleccionado = colArticulos[i];
                            break;
                        }
                    }

                    if (ArticuloSeleccionado != null)
                    {
                        //creo una lista nueva para la grid a la cual le voy a concatenar al tamanio su tipo correcto
                        List<Articulos> listaParaGrid = new List<Articulos> { ArticuloSeleccionado };


                        GridDatosArticulo.DataSource = listaParaGrid;
                        GridDatosArticulo.DataBind();


                        string tamañoConUnidad = ArticuloSeleccionado.Tamaño.ToString();


                        if (ArticuloSeleccionado.Tipo == "sobre")
                        {
                            tamañoConUnidad += "g";
                        }
                        else if (ArticuloSeleccionado.Tipo == "blister")
                        {
                            tamañoConUnidad += " pastillas";
                        }
                        else if (ArticuloSeleccionado.Tipo == "frasco")
                        {
                            tamañoConUnidad += " ml";
                        }
                        else if (ArticuloSeleccionado.Tipo == "unidad")
                        {
                            tamañoConUnidad += " unidades";
                        }


                        if (GridDatosArticulo.Rows.Count > 0)
                        {
                            //Cambio la columna del grid de tamanio por la que le agregue el tipo correcto
                            GridDatosArticulo.Rows[0].Cells[4].Text = tamañoConUnidad;
                        }
                        else
                        {
                            lblError.ForeColor = Color.Blue;
                            lblError.Text = "No se encontro el Articulo seleccionado.";
                            GridDatosArticulo.DataSource = null;
                            GridDatosArticulo.DataBind();
                        }

                    }
                    else
                    {

                        GridDatosArticulo.DataSource = null;
                        GridDatosArticulo.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Error al cargar los datos del articulo: " + ex.Message;
            }

        }

        protected void GridDatosVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int selectedIndex = GridDatosVentas.SelectedIndex;
                //obtengo el numero de venta de la primera columna de la grid 
                string numeroVenta = GridDatosVentas.SelectedRow.Cells[1].Text;
                List<Ventas> colventas = (List<Ventas>)Session["Ventas"];
                Ventas ventaSeleccionada = null;
                //utilizo la session para evitar llamar otra vez al precedimiento alamacenado y lbusco la venta 

                for (int i = 0; i < colventas.Count; i++)
                {
                    if (colventas[i].Numero.ToString() == numeroVenta)
                    {
                        ventaSeleccionada = colventas[i];
                        break;
                    }
                }

                if (ventaSeleccionada != null)
                {

                    //creo el objeto de la venta completa para mostrar los datos faltantes de la venta en la otra grid
                    var ventaCompleta = new
                    {
                        Numero = ventaSeleccionada.Numero,
                        FechaVenta = ventaSeleccionada.FechaVenta.ToString("dd/MM/yyyy"),
                        Cantidad = ventaSeleccionada.Cantidad,
                        Estado = ventaSeleccionada.Estado,
                        CedulaCliente = ventaSeleccionada.Cli.Cedula,
                        NombreCliente = ventaSeleccionada.Cli.NombreCompleto,
                        Tarjeta = ventaSeleccionada.Cli.NumTarjeta,
                        Telefono = ventaSeleccionada.Cli.Telefono,
                        DireccionCliente = ventaSeleccionada.Direccion
                    };
                    //creo la lista para la grid
                    var listaParaGrid = new List<object> { ventaCompleta };
                    //se la agrego a la grid de la venta completa
                    GridDatosVentasCompleta.DataSource = listaParaGrid;
                    GridDatosVentasCompleta.DataBind();
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "No se encontro la venta seleccionada.";
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Error al cargar los datos de la venta: " + ex.Message;
            }
        }

        protected void GridDatosArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridDatosVentasCompleta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }
    }
}