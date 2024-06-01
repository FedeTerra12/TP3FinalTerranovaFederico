using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominios;


namespace Conexiones
{
    public class ConexionCategoria
    {
      public List<Categorias> listar()
        {
            List<Categorias> lista = new List<Categorias>();
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearConsulta(" select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();
                    aux.Id = (int)datos.Lector[0];
                    aux.Descripcion = (string)datos.Lector[1];

                    lista.Add(aux);
                     
                }

                return lista;
            
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
    }
}
