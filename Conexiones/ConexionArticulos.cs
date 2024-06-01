using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominios;
using System.Configuration;




namespace Conexiones
{
    public class ConexionArticulos
    { 
        public List<Articulos> listar(string id = "")                                    
        {
            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {

                conexion.ConnectionString = ConfigurationManager.AppSettings["cadenaConexion"];
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Codigo, Nombre, a.Descripcion, c.Descripcion, M.Descripcion, ImagenUrl, precio, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, Categorias C where IdCategoria = c.Id and IdMarca = m.Id ";
                                        
                if (id != "") 
                    comando.CommandText += "and A.Id = " + id;
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector[0];
                    aux.Nombre = (string)lector[1];
                    aux.Descripcion = (string)lector[2];
                    aux.Categorias = new Categorias();
                    aux.Categorias.Id = (int)lector["IdCategoria"];
                    aux.Categorias.Descripcion = (string)lector[3];
                    aux.Marcas = new Marcas();
                    aux.Marcas.Id = (int)lector["IdMarca"];
                    aux.Marcas.Descripcion = (string)lector[4];
                    aux.ImagenUrl = (string)lector[5];
                    aux.Precio = (decimal)lector[6];

                    lista.Add(aux);

                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulos> listarconSp()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearconSp("storedListar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos Aux = new Articulos();
                    Aux.Id = (int)datos.Lector["Id"];
                    Aux.Codigo = (string)datos.Lector[0];
                    Aux.Nombre = (string)datos.Lector["Nombre"];
                    Aux.Descripcion = (string)datos.Lector[2];
                    Aux.Categorias = new Categorias();
                    Aux.Categorias.Id = (int)datos.Lector["IdCategoria"];
                    Aux.Categorias.Descripcion = (string)datos.Lector[3];
                    Aux.Marcas = new Marcas();
                    Aux.Marcas.Id = (int)datos.Lector["IdMarca"];
                    Aux.Marcas.Descripcion = (string)datos.Lector[4];
                    Aux.ImagenUrl = (string)datos.Lector[5];
                    Aux.Precio = (decimal)datos.Lector[6];

                    lista.Add(Aux);


                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void agregarArticuloSp(Articulos nuevo)
        {
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.setearconSp("storedAltadeArticulos");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@imagenurl", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@idMarca", nuevo.Marcas.Id);
                datos.setearParametro("@idCategoria", nuevo.Categorias.Id);

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

        public void modificarArticuloSp(Articulos articulo)
        {
            {
                AccesoaDatos datos = new AccesoaDatos();

                try
                {
                    datos.setearconSp("storedModificarArticulo");
                    datos.setearParametro("@id", articulo.Id);
                    datos.setearParametro("@Codigo", articulo.Codigo);
                    datos.setearParametro("@Nombre", articulo.Nombre);
                    datos.setearParametro("@Descripcion", articulo.Descripcion);
                    datos.setearParametro("@imagenurl", articulo.ImagenUrl);
                    datos.setearParametro("@precio", articulo.Precio);
                    datos.setearParametro("@idMarca", articulo.Marcas.Id);
                    datos.setearParametro("@idCategoria", articulo.Categorias.Id);
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
        }
        public void modificarArticulo(Articulos articulo)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, ImagenUrl = @imagenurl, Precio = @precio where Id = @id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@imagenurl", articulo.ImagenUrl);
                datos.setearParametro("@precio", articulo.Precio);
                datos.setearParametro("@idMarca", articulo.Marcas.Id);
                datos.setearParametro("@idCategoria", articulo.Categorias.Id);
                datos.setearParametro("@id", articulo.Id);
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

        public void eliminarArticulo(int id)
        {
            AccesoaDatos datos = new AccesoaDatos();


            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                string consulta = "select Codigo, Nombre, a.Descripcion, C.Descripcion, M.Descripcion, ImagenUrl, Precio, A.IdMarca, A.IdCategoria, A.Id from ARTICULOS A, MARCAS M, CATEGORIAS C where IdCategoria = c.Id and IdMarca = M.Id And ";
                switch (campo)
                {
                    case "Categoría":

                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "c.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "c.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "c.Descripcion like '%" + filtro + "%'";
                                break;

                        }
                        break;


                    case "Marca":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;


                    case "Precio":
                        switch (criterio)

                        {
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }

                        break;


                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos Aux = new Articulos();
                    Aux.Codigo = (string)datos.Lector[0];
                    Aux.Nombre = (string)datos.Lector["Nombre"];
                    Aux.Descripcion = (string)datos.Lector[2];
                    Aux.Categorias = new Categorias();
                    Aux.Categorias.Id = (int)datos.Lector["IdCategoria"];
                    Aux.Categorias.Descripcion = (string)datos.Lector[3];
                    Aux.Marcas = new Marcas();
                    Aux.Marcas.Id = (int)datos.Lector["IdMarca"];
                    Aux.Marcas.Descripcion = (string)datos.Lector[4];
                    Aux.ImagenUrl = (string)datos.Lector[5];
                    Aux.Precio = (decimal)datos.Lector[6];
                    Aux.Id = (int)datos.Lector["Id"];

                    lista.Add(Aux);



                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
