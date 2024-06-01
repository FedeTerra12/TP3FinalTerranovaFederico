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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://www.shutterstock.com/image-vector/vector-flat-illustration-grayscale-avatar-260nw-2281862025.jpg";
            
            if (!(Page is Login || Page is Registro || Page is Error))
            {
                if (!Seguridad.SesionActiva(Session["usuario"]))
                {
                    if (!(Page is Default || Page is DetalleArticulos))
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                }
                else
                {
                    Users user = (Users)Session["usuario"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.urlImagenPerfil))
                    imgAvatar.ImageUrl = "~/Imagenes/" + user.urlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                }
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}