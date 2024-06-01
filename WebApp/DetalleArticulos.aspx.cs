using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominios;
using Conexiones;

namespace WebApp
{
    public partial class DetalleArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlCategoria.Enabled = false;
            ddlMarca.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    ConexionCategoria categoria = new ConexionCategoria();
                    ConexionMarca marca = new ConexionMarca();
                    List<Marcas> listamarcas = marca.listar();
                    Session["listamarcas"] = listamarcas;


                    ddlMarca.DataSource = listamarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    List<Categorias> listacategorias = categoria.listar();
                    ddlCategoria.DataSource = listacategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ConexionArticulos articulo = new ConexionArticulos();

                    Articulos seleccionado = (articulo.listar(id))[0];



                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString("0");
                    txtImage.Text = seleccionado.ImagenUrl;
                    ddlCategoria.SelectedValue = seleccionado.Categorias.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marcas.Id.ToString();
                    txtImage_TextChanged(sender, e);


                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
                throw ex;
            }
        }



        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = int.Parse(ddlCategoria.SelectedItem.Value);
            ddlMarca.DataSource = ((List<Marcas>)Session["listamarcas"]).FindAll(x => x.Id == Id);
            ddlMarca.DataBind();
        }

        protected void txtImage_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImage.Text;
        }
    }
}