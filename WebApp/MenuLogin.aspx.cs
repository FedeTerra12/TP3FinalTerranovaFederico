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
    public partial class MenuLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.SesionActiva(Session["usuario"]))
                    {
                        Users user = (Users)Session["usuario"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;

                        if (!string.IsNullOrEmpty(user.urlImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Imagenes/" + user.urlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                ConexionUsers conexion = new ConexionUsers();
                Users user = (Users)Session["usuario"];
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Imagenes/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.urlImagenPerfil = "perfil-" + user.Id + ".jpg";
                    imgNuevoPerfil.ImageUrl = "~/Imagenes/" + user.urlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();


                }
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                ConexionUsers.actualizar(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Imagenes/" + user.urlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();



            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());


            }
        }
    }
    }
