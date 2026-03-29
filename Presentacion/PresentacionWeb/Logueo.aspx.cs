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
    public partial class Logueo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["EmpleadoLogueado"] = null;
        }

        protected void btnLogueo_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado unEmp = LogicaEmpleado.Logueo(txtNomUsu.Text.Trim(), txtPassUsu.Text.Trim(), txtNombre.Text.Trim());

                if (unEmp != null)
                {
                    Session["EmpleadoLogueado"] = unEmp;
                    Response.Redirect("Default.aspx");
                }
                else
                    lblError.Text = "Datos Incorrectos";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}