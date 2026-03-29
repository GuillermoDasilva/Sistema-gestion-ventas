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
    public partial class AltaVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                CargoDatos();
            }
        }

        private void CargoDatos()
        {
            try
            {
                List<Cliente> colClientes = LogicaCliente.ListarClientes();
                Session["Clientes"] = colClientes;

                List<Articulos> colArticulos = LogicaArticulos.ListarArticulos();
                Session["Articulos"] = colArticulos;



                if (colArticulos.Count > 0)
                {
                    ddlArticulos.DataSource = colArticulos;
                    ddlArticulos.DataTextField = "Mostrar";
                    ddlArticulos.DataValueField = "Codigo";
                    ddlArticulos.DataBind();
                    ddlArticulos.Items.Insert(0, new ListItem("--------------"));
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No existe ningun Articulo disponible";

                    ddlArticulos.Enabled = false;
                    ddlClientes.Enabled = true;
                    txtCantidad.Enabled = false;
                    txtDireccion.Enabled = false;
                }

                if (colClientes.Count > 0)
                {
                    ddlClientes.DataSource = colClientes;
                    ddlClientes.DataTextField = "AMostrar";
                    ddlClientes.DataValueField = "Cedula";
                    ddlClientes.DataBind();
                    ddlClientes.Items.Insert(0, new ListItem("--------------"));
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No existe ningun Cliente";
                    txtDireccion.Enabled = false;
                    btnAgregar.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Mostrar;
                int cedula;
                string estado = "armado";
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                string direccion = txtDireccion.Text.Trim();
                DateTime fecha = DateTime.Now;
                int numeroint = 100;

                Empleado unEmp = (Empleado)Session["EmpleadoLogueado"];


                List<Articulos> colArticulos = (List<Articulos>)Session["Articulos"];
                Articulos oArticulos = null;

                List<Cliente> colClientes = (List<Cliente>)Session["Clientes"];
                Cliente oCliente = null;

                if (ddlArticulos.SelectedIndex != 0)
                {
                    Mostrar = ddlArticulos.SelectedValue;
                }
                else
                    throw new Exception("Seleccione un Artículo");

                foreach (Articulos A in colArticulos)
                {
                    if (A.AMostrar == Mostrar)
                    {
                        oArticulos = A;
                        break;
                    }
                }



                if (ddlClientes.SelectedIndex != 0)
                {
                    cedula = Convert.ToInt32(ddlClientes.SelectedValue);
                }
                else
                    throw new Exception("Seleccione un Paciente");

                foreach (Cliente C in colClientes)
                {
                    if (C.Cedula == cedula)
                    {
                        oCliente = C;
                        break;
                    }
                }

                Ventas oVentas = new Ventas(numeroint, fecha, cantidad, estado, direccion, unEmp, oCliente, oArticulos);
                LogicaVentas.Agregar(oVentas);
                int numero = LogicaVentas.Agregar(oVentas);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Alta con éxito de la Venta Nº " + numero;

                CargoDatos();
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }
    }
}