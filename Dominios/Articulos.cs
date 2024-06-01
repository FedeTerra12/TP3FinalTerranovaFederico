using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Dominios
{
     public class Articulos
    {
        public int Id { get; set; }
        
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
       
        [DisplayName("Imagen Url")]
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
        public Categorias Categorias { get; set; }
        public Marcas Marcas { get; set; }

    }
}
