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
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                CargoDatosVentas();
            }
        }

        protected void CargoDatosVentas()
        {
            try
            {
                GridVentas.DataSource = null;
                GridVentas.DataBind();

                // traigo las ventas de sql que su estado sea armado o enviado
                List<Ventas> colventas = Logica.LogicaVentas.ListarVentasAE();

                //Las ordeno por fecha antes de guardar 
                OrednarVentasFecha(colventas);
                Session["Ventas"] = colventas;
                Articulos ArticuloSeleccionado = null;


                GridVentas.DataSource = colventas;
                GridVentas.DataBind();

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        private void OrednarVentasFecha(List<Ventas> ventas)
        {
            //burbuja para oredenar por fecha 
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

        protected void GridDatosVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}