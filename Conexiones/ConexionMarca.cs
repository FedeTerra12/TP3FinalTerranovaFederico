using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominios;

namespace Conexiones
{
    public class ConexionMarca
    {
       public List<Marcas> listar()
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
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
