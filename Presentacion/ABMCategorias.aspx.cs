using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

using System.Drawing;

public partial class ABMCategorias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
        {
            
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text.Trim();
            string nombre = txtNombre.Text.Trim();

            Categoria categoria = new Categoria(codigo, nombre);

            LogicaCategoria.Agregar(categoria);

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
            Categoria categoria = (Categoria)Session["Categoria"];

            categoria.Nombre = txtNombre.Text.Trim();

            LogicaCategoria.Modificar(categoria);

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
            Categoria categoria = (Categoria)Session["Categoria"];

            LogicaCategoria.Eliminar(categoria);

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

    private void LimpioFormulario()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;

        txtCodigo.Text = "";
        txtCodigo.Enabled = true;
        txtNombre.Text = "";
        txtNombre.Enabled = false;
    }

    private void ActivoBotones(bool esAlta = true)
    {
        btnModificar.Enabled = !esAlta;
        btnEliminar.Enabled = !esAlta;
        btnAgregar.Enabled = esAlta;
        btnBuscar.Enabled = false;
        txtCodigo.Enabled = false;
        txtNombre.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text.Trim();

            Categoria cat = LogicaCategoria.Buscar(codigo);

            if (cat != null)
            {
                txtCodigo.Text = cat.Codigo.ToString();
                txtNombre.Text = cat.Nombre;

                ActivoBotones(false);

                Session["Categoria"] = cat;
            }
            else
            {
                ActivoBotones();

                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay Categorias registradas con es código";

                Session["Categoria"] = null;
            }
        }
        catch (FormatException)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "El formato del Código no es correcto";
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}