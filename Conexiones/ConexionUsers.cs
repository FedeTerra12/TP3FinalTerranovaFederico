using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominios;

namespace Conexiones
{

    public class ConexionUsers
    {
        public bool Loguear(Users users)
        {
            AccesoaDatos datos = new AccesoaDatos();
            try
            {

                datos.setearConsulta("select Id, nombre, apellido, urlImagenPerfil, admin from Users where email= @email and pass = @pass");
                datos.setearParametro("@email", users.Email);
                datos.setearParametro("@pass", users.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    users.Id = (int)datos.Lector["Id"];
                    users.TipoUsuario = (bool)(datos.Lector["admin"]);
                    return true;
                }
                return false;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public static void actualizar(Users users)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearConsulta("Update Users set imagenPerfil = @imagen where Id = @id");
                datos.setearParametro("@imagen", users.urlImagenPerfil);
                datos.setearParametro("@id", users.Id);
                datos.ejecutarAccion();



            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            finally
            {
                datos.cerrarConexion();
            }
            
        }

        public int crearUsuario(Users users)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearconSp("nuevoUser");
                datos.setearParametro("@email", users.Email);
                datos.setearParametro("@pass", users.Pass);
                return datos.ejecutarAccionScalar();


            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
