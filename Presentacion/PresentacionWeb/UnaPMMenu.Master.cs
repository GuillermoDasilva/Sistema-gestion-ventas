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
    public partial class UnaPMMenu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Empleado emp = (Empleado) Session["EmpleadoLogueado"];
            lblUsuario.Text = "Empleado: " + emp.Nombre;
        }
    }
}