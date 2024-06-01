using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexiones;
using Dominios;

namespace WebApp
{
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;

            try
            {

                if (!IsPostBack)
                {
                    ConexionCategoria categorias = new ConexionCategoria();
                    ConexionMarca marca = new ConexionMarca();
                    List<Marcas> listamarcas = marca.listar();
                    Session["listamarcas"] = listamarcas;

                    ddlMarca.DataSource = listamarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();


                    List<Categorias> listacategorias = categorias.listar();
                    ddlCategoria.DataSource = listacategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ConexionArticulos articulo = new ConexionArticulos();
                    //List<Articulo> lista = negocio.listar(Request.QueryString["id"].ToString());
                    //Articulo seleccionado = lista[0];
                    Articulos seleccionado = (articulo.listar(id))[0];


                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtImage.Text = seleccionado.ImagenUrl;
                    ddlCategoria.SelectedValue = seleccionado.Categorias.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marcas.Id.ToString();

                    txtImage_TextChanged(sender, e);

                }
                     
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                
               
               Articulos nuevo = new Articulos();
                ConexionArticulos conexion = new ConexionArticulos();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImage.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Categorias = new Categorias();
                nuevo.Categorias.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marcas = new Marcas();
                nuevo.Marcas.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["id"] != null)
                {

                    nuevo.Id = int.Parse(txtId.Text);
                    conexion.modificarArticuloSp(nuevo);
                }
                else
                    conexion.agregarArticuloSp(nuevo);

                Response.Redirect("ListadeArticulos.aspx", false);

           
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }



        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlCategoria.SelectedItem.Value);
            ddlMarca.DataSource = ((List<Marcas>)Session["listamarcas"]).FindAll(x => x.Id == id);
            ddlMarca.DataBind();
        }

        protected void txtImage_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImage.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    ConexionArticulos conexion = new ConexionArticulos();
                    conexion.eliminarArticulo(int.Parse(txtId.Text));
                    Response.Redirect("ListadeArticulos.aspx", false);

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");

            }
            

        }
    }
}