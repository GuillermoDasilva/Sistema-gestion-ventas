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
    public partial class ABMClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (!IsPostBack)
                LimpioFormulario();
        }

        private void LimpioFormulario()
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAgregar.Enabled = false;
            btnBuscar.Enabled = true;

            txtCedula.Text = "";
            txtCedula.Enabled = true;
            txtNombre.Text = "";
            txtNombre.Enabled = false;
            txtNumTarjeta.Text = "";
            txtNumTarjeta.Enabled = false;
            txtTelefono.Text = "";
            txtTelefono.Enabled = false;
        }

        private void ActivoBotones(bool esAlta = true)
        {
            btnModificar.Enabled = !esAlta;
            btnEliminar.Enabled = !esAlta;
            btnAgregar.Enabled = esAlta;
            btnBuscar.Enabled = false;
            txtCedula.Enabled = false;
            txtNombre.Enabled = true;
            txtNumTarjeta.Enabled = true;
            txtTelefono.Enabled = true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int cedula = Convert.ToInt32(txtCedula.Text);
                string nombre = txtNombre.Text.Trim();
                long numTarjeta = Convert.ToInt64(txtNumTarjeta.Text);
                int telefono = Convert.ToInt32(txtTelefono.Text);

                Cliente cliente = new Cliente(cedula, nombre, numTarjeta, telefono);

                LogicaCliente.Agregar(cliente);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Alta con éxito";

                LimpioFormulario();
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)Session["Clientes"];

                cliente.NombreCompleto = txtNombre.Text.Trim();
                cliente.NumTarjeta = Convert.ToInt32(txtNumTarjeta.Text);
                cliente.Telefono = Convert.ToInt32(txtTelefono.Text);

                LogicaCliente.Modificar(cliente);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Modificación exitosa";

                LimpioFormulario();
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)Session["Clientes"];

                LogicaCliente.Eliminar(cliente);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Eliminación exitosa";

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
            LimpioFormulario();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int cedula = Convert.ToInt32(txtCedula.Text);

                Cliente cli = LogicaCliente.Buscar(cedula);

                if (cli != null)
                {
                    txtCedula.Text = cli.Cedula.ToString();
                    txtNombre.Text = cli.NombreCompleto;
                    txtTelefono.Text = cli.Telefono.ToString();
                    txtNumTarjeta.Text = cli.NumTarjeta.ToString();

                    ActivoBotones(false);

                    Session["Clientes"] = cli;
                }
                else
                {
                    ActivoBotones();

                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No hay Clientes registrados con esa Cédula";

                    Session["Clientes"] = null;
                }
            }
            catch (FormatException)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "El formato de la Cédula no es correcto";
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }
    }
}