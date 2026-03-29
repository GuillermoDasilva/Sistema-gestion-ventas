using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

using System.Drawing;

public partial class ABMArticulos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
        {
            CargoDatos();
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            int precio = Convert.ToInt32(txtPrecio.Text);
            string tipo = txtTipo.Text.Trim();
            int tamaño = Convert.ToInt32(txtTamaño.Text);
            string codigoCat;

            List<Categoria> colCategoria = (List<Categoria>)Session["Categorias"];
            Categoria oCategoria = null;

            if (ddlCategoria.SelectedIndex != 0)
            {
                codigoCat = Convert.ToString(ddlCategoria.SelectedValue);
            }
            else
                throw new Exception("Seleccione una Categoría");

            foreach (Categoria C in colCategoria)
            {
                if (C.Codigo == codigoCat)
                {
                    oCategoria = C;
                    break;
                }
            }

            Articulos articulos = new Articulos(codigo, nombre, tipo, precio, tamaño, oCategoria);

            LogicaArticulos.Agregar(articulos);

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
        txtPrecio.Text = "";
        txtPrecio.Enabled = false;
        txtTipo.Text = "";
        txtTipo.Enabled = false;
        txtTamaño.Text = "";
        txtTamaño.Enabled = false;
    }

    private void ActivoBotones(bool esAlta = true)
    {
        btnModificar.Enabled = !esAlta;
        btnEliminar.Enabled = !esAlta;
        btnAgregar.Enabled = esAlta;
        btnBuscar.Enabled = false;
        txtCodigo.Enabled = false;
        txtNombre.Enabled = true;
        txtPrecio.Enabled = true;
        txtTamaño.Enabled = false;
        txtTipo.Enabled = true;
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Articulos articulos = (Articulos)Session["Articulos"];

            articulos.Nombre = txtNombre.Text.Trim();
            articulos.Tipo = txtTipo.Text.Trim();
            articulos.Precio = Convert.ToInt32(txtPrecio.Text);
            articulos.Tamaño = Convert.ToInt32(txtTamaño.Text);

            LogicaArticulos.Modificar(articulos);

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
            Articulos articulos = (Articulos)Session["Articulos"];

            LogicaArticulos.Eliminar(articulos);

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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text.Trim();

            Articulos art = LogicaArticulos.Buscar(codigo);

            if (art != null)
            {
                txtCodigo.Text = art.Codigo.ToString();
                txtNombre.Text = art.Nombre;
                txtPrecio.Text = art.Precio.ToString();
                txtTamaño.Text = art.Tamaño.ToString();
                txtTipo.Text = art.Tipo;

                ActivoBotones(false);

                Session["Articulos"] = art;
            }
            else
            {
                ActivoBotones();

                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay Articulos registrados con es código";

                Session["Articulos"] = null;
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

    private void CargoDatos()
    {
        try
        {
            List<Categoria> colCategoria = LogicaCategoria.ListarCategoria();
            Session["Categorias"] = colCategoria;

            if (colCategoria.Count > 0)
            {
                ddlCategoria.DataSource = colCategoria;
                ddlCategoria.DataTextField = "Mostrar";
                ddlCategoria.DataValueField = "Codigo";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new ListItem("--------------"));
            }
            else
            {
                lblError.ForeColor = Color.Blue;
                lblError.Text = "No existe ninguna categoria";
                btnAgregar.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}

