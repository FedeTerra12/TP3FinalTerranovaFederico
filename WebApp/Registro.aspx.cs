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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Users users = new Users();
                ConexionUsers conexionUsers = new ConexionUsers();

                users.Email = txtCorreo.Text;
                users.Pass = txtPassword.Text;
                users.Id = conexionUsers.crearUsuario(users);
                Session.Add("usuario", users);
                Response.Redirect("Default.aspx", false);


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }

        }
    }
}