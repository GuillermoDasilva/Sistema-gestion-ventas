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
    public partial class SeguimientoDeVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (!IsPostBack)
                LimpioFormulario();
        }

        private void LimpioFormulario()
        {
            txtCodigoventa.Text = "";
            btnSi.Enabled = false;
            btnNo.Enabled = false;
            btnLimpiar.Enabled = false;
            lblError.Text = "";
            lblEstado.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoVenta = txtCodigoventa.Text.Trim();

                //traigo de sql el estado actual de la venta por su codigo 
                int estado = Logica.LogicaVentas.BuscarEstado(codigoVenta);

                if (estado == 1)
                {
                    lblEstado.ForeColor = Color.Blue;
                    lblEstado.Text = "El esado actual de la venta es armado, Desea cambiarlo a enviado?";
                    btnSi.Enabled = true;
                    btnNo.Enabled = true;
                }
                else if (estado == 2)
                {
                    lblEstado.ForeColor = Color.Blue;
                    lblEstado.Text = "El esado actual de la venta es enviado , Desea cambiarlo a entregado?";
                    btnSi.Enabled = true;
                    btnNo.Enabled = true;
                }
                else if (estado == 3)
                {
                    lblEstado.ForeColor = Color.Blue;
                    lblEstado.Text = "El esado actual de la venta es entregado , Desea cambiarlo a devuelto?";
                    btnSi.Enabled = true;
                    btnNo.Enabled = true;
                }
                else if (estado == 4)
                {
                    lblEstado.ForeColor = Color.Blue;
                    lblEstado.Text = "El esado actual de la venta es devuelto,";
                    btnLimpiar.Enabled = true;
                }
                else if (estado == -1)
                {
                    lblEstado.ForeColor = Color.Red;
                    lblEstado.Text = "No se ah encontrado la venta";
                    btnLimpiar.Enabled = true;
                }
                else
                {

                    btnSi.Enabled = false;
                    btnNo.Enabled = false;
                    btnLimpiar.Enabled = false;
                    lblEstado.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
                btnSi.Enabled = false;
                btnNo.Enabled = false;
                btnLimpiar.Enabled = true;
                lblEstado.Text = "";
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            try
            {

                // Utilido el procedimiento alamacenado para cambiar el estado de la venta
                string codigoVenta = txtCodigoventa.Text.Trim();
                Logica.LogicaVentas.CambiarEstado(codigoVenta);
                lblEstado.ForeColor = Color.Green;
                lblEstado.Text = "Se cambio correctamente";
                btnSi.Enabled = false;
                btnNo.Enabled = false;
                btnLimpiar.Enabled = true;

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }

        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpioFormulario();

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpioFormulario();

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }
    }
}